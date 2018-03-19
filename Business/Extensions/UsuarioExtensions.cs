using Fbiz.Framework.Core.Cryptography;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class UsuarioExtensions
    {
        public static Usuario Encrypt(this Usuario usuario, SymmetricBase symmetricBase)
        {
            var usuarioEncrypt = new Usuario();


            return usuario;
        }


        public static Usuario Decrypt(this Usuario usuario, SymmetricBase symmetricBase)
        {
            var usuarioDecrypt = new Usuario();


            return usuarioDecrypt;
        }

        public static string HashCpf(this Usuario usuario, SymmetricBase symmetricBase)
        {
            return usuario.Cpf;
        }
        public static string HashEmail(this Usuario usuario, SymmetricBase symmetricBase)
        {
                return usuario.Nome ;
        }

        private static string encode(SymmetricBase symmetricBase, string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            return Convert.ToBase64String(symmetricBase.Encode(source));
        }
        private static string decode(SymmetricBase symmetricBase, string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            return symmetricBase.Decode<string>(Convert.FromBase64String(source));
        }

    }
}
