using Business.Interface;
using Fbiz.Framework.Core;
using System;
using System.Configuration.Provider;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace Admin.WebCommon
{
    public class MembershipProvider : System.Web.Security.MembershipProvider
    {
        private string _applicationName;
        private string _decryptionKey;
        private string _validationKey;
        private MembershipPasswordFormat _passwordFormat;

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return this._passwordFormat; }
        }
        public override string ApplicationName
        {
            get
            {
                return this._applicationName;
            }
            set
            {
                this._applicationName = value;
            }
        }


        public override bool ValidateUser(string username, string password)
        {
            username = username.Trim().ToLower();
            password = password.Trim();

            var operador = IoCWrapper.Container.Resolve<IOperadorBusiness>().Obter(username);

            return operador != null && CheckPassword(password, Convert.ToBase64String(operador.Senha));
        }

        public override string GetUserNameByEmail(string email)
        {
            email = email.Trim().ToLower();

            var operador = IoCWrapper.Container.Resolve<IOperadorBusiness>().Obter(email);

            return operador != null ? operador.Senha.ToString() : string.Empty;
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            this._passwordFormat = (MembershipPasswordFormat)Enum.Parse(typeof(MembershipPasswordFormat), config["passwordFormat"]);
            this._decryptionKey = config["decryptionKey"];
            this._validationKey = config["validationKey"];
            this._applicationName = config["applicationName"];

        }


        //
        // CheckPassword
        //   Compares password values based on the MembershipPasswordFormat.
        //
        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;
                default:
                    break;
            }

            return pass1 == pass2;
        }


        //
        // EncodePassword
        //   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
        //
        public string EncodePassword(string password)
        {
            string encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword = Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    using (var hash = HMACSHA1.Create())
                    {
                        hash.Key = HexToByte(this._validationKey);
                        encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    }
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return encodedPassword;
        }


        //
        // UnEncodePassword
        //   Decrypts or leaves the password clear based on the PasswordFormat.
        //
        public string UnEncodePassword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password = IoCWrapper.Container.Resolve<Fbiz.Framework.Core.Cryptography.Rijndael>().Decode<string>(Convert.FromBase64String(encodedPassword));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        protected override byte[] EncryptPassword(byte[] password)
        {
            try
            {
                return IoCWrapper.Container.Resolve<Fbiz.Framework.Core.Cryptography.Rijndael>().Encode(password);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Exception on encrypt password", ex);
            }
        }

        //
        // HexToByte
        //   Converts a hexadecimal string to a byte array. Used to convert encryption
        // key values from the configuration.
        //
        private byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        #region Base


        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool EnablePasswordReset
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override string GetPassword(string username, string answer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }


        public override string PasswordStrengthRegularExpression
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool UnlockUser(string userName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion

    }
}
