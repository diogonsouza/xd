using Business.Interface;
using Engine.Interface;
using Fbiz.Framework.Core;
using Fbiz.Framework.Core.Cryptography;
using Model;
using System;
using Business.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Helper;
using System.Globalization;

namespace Engine.Implementation
{
    public class UsuarioEngine : IUsuarioEngine
    {

        private readonly SymmetricBase _crypto;
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioEngine(SymmetricBase crypto,
                             IUsuarioBusiness usuarioBusiness)
        {
            this._crypto = crypto;
            this._usuarioBusiness = usuarioBusiness;
        }

        public string Cadastrar(Usuario usuario)
        {
            usuario.UsuarioId = atualizarBase(usuario);
            return usuario.UsuarioId.ToString();
        }



        private int atualizarBase(Usuario usuario)
        {
            Usuario usuarioCrypt = cadastrarUsuario(usuario);
            return usuarioCrypt.UsuarioId;
        }


        private Usuario cadastrarUsuario(Usuario usuario)
        {
            var now = DateTime.Now;
            usuario.DataCriacao = now;
            
            string s = "01/01/1900 00h00mn00s";
            DateTime dt = DateTime.ParseExact(s, "dd/MM/yyyy hh\\hmm\\m\\nss\\s", CultureInfo.InvariantCulture);
            usuario.DataNascimento = dt;
            this._usuarioBusiness.Add(usuario);

            try
            {
                this._usuarioBusiness.Save();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string message = (ex.InnerException?.InnerException?.Message) ?? string.Empty;
                if (message.ToLower().Contains("IX_TB_SITE_USUARIO_NR_CPF".ToLower()))
                    throw new CPFJaCadastradoException();
                else if (message.ToLower().Contains("IX_TB_SITE_USUARIO_EN_EMAI".ToLower()))
                    throw new EmailJaCadastradoException();
                else throw;
            }

            return usuario;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            var now = DateTime.Now;
            usuario.DataCriacao = now;

            this._usuarioBusiness.Update(usuario);
            this._usuarioBusiness.Save();
            return usuario;
        }

        public Usuario ObterPorId(int usuarioId)
        {
            return this._usuarioBusiness.ObterPorId(usuarioId);
        }
    }
}
