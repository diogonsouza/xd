using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;

namespace Admin.WebCommon
{
    public class FileUpload
    {
        private byte[] _originalData;
        private string _fileName;
        private ImageFormat _imageFormat;

        public FileUpload(HttpPostedFileBase httpPostedFile, ImageFormat imageFormat)
        {
            if (httpPostedFile == null)
                throw new ArgumentNullException("httpPostedFile");

            if (imageFormat == null)
                throw new ArgumentNullException("imageFormat");

            _originalData = getData(httpPostedFile);
            _imageFormat = imageFormat;
        }

        public FileUpload(HttpPostedFileBase httpPostedFile)
        {
            if (httpPostedFile == null)
                throw new ArgumentNullException("httpPostedFile");

            _originalData = getData(httpPostedFile);
            _fileName = httpPostedFile.FileName;
        }

        public string ProcessUpload(string path, Size size)
        {
            var resizedImaged = resizeImage(_originalData, size);

            _fileName = string.Concat(getMd5Hash(resizedImaged), string.Concat(".", _imageFormat.ToString().ToLower()));

            saveFile(_fileName, path, resizedImaged);

            return _fileName;
        }

        public string ProcessUpload(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException("path");

            var extension = _imageFormat != null ? string.Concat(".", _imageFormat.ToString().ToLower()) : Path.GetExtension(_fileName);
            _fileName = string.Concat(getMd5Hash(_originalData), extension);

            saveFile(_fileName, path, _originalData);

            return _fileName;
        }

        #region Private Members

        private byte[] getData(HttpPostedFileBase httpPostedFile)
        {
            byte[] data;
            using (MemoryStream stream = new MemoryStream(httpPostedFile.ContentLength))
            {
                httpPostedFile.InputStream.CopyTo(stream);
                data = stream.ToArray();
            }
            return data;
        }

        private void saveFile(string fileName, string directory, byte[] data)
        {
            if (directory.StartsWith("~"))
            {
                if (HttpContext.Current != null)
                    directory = HttpContext.Current.Server.MapPath(directory);
                else
                    directory = directory.Replace("~/", Environment.CurrentDirectory).Replace("/", @"\");
            }

            Directory.CreateDirectory(directory);

            string path = Path.Combine(directory, fileName);

            if (!File.Exists(path))
                File.WriteAllBytes(path, data);

        }

        private byte[] resizeImage(byte[] image, Size size)
        {
            using (var memoryStream = new MemoryStream(image))
            {
                using (var originalImage = new Bitmap(memoryStream))
                {
                    using (var resizedImage = resizeImage(originalImage, size))
                    {
                        using (var result = new MemoryStream())
                        {
                            resizedImage.Save(result, _imageFormat);
                            return result.ToArray();
                        }
                    }
                }
            }
        }

        private Bitmap resizeImage(Image image, Size size)
        {
            var bitmap = new Bitmap(size.Width, size.Height);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphic = Graphics.FromImage((Image)bitmap))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.AntiAlias;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.DrawImage(image, 0, 0, size.Width, size.Height);
            }

            return bitmap;
        }

        private string getMd5Hash(byte[] data)
        {
            StringBuilder output = new StringBuilder();
            byte[] hash = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            for (int i = 0; i < hash.Length; i++)
                output.Append(hash[i].ToString("x2"));
            return output.ToString();
        }

        #endregion

    }
}