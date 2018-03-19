using Engine.Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WWW.ViewModels.Response;

namespace WWW.Controllers
{
    public class AtivarUsuarioController : ApiController
    {
        private readonly IUsuarioEngine _usuarioEngine;
        private readonly ITokenEngine _tokenEngine;

        public AtivarUsuarioController(IUsuarioEngine usuarioEngine, ITokenEngine tokenEngine)
        {
            this._usuarioEngine = usuarioEngine;
            this._tokenEngine = tokenEngine;
        }
        public HttpResponseMessage Get(string token)
        {

            Token usuarioToken = this._tokenEngine.TokenAtivacao(token);

            Usuario usuario = this._usuarioEngine.ObterPorId(usuarioToken.Id_usuario);
            var now = DateTime.Now;
            var tokenUrl = new Token()
            {
                CodigoToken = Guid.NewGuid().ToString().Replace("-", ""),
                TipoToken = 1,
                DataCriacao = now,
                Id_usuario = usuario.UsuarioId
            };
            string codToken = this._tokenEngine.Cadastrar(tokenUrl);
            try
            {
                if (!usuario.Ativo)
                {
                    usuario.Ativo = true;
                    usuario = this._usuarioEngine.Atualizar(usuario);

                    return Request.CreateResponse(HttpStatusCode.OK, new AtivacaoUsuarioResponse()
                    {
                        Token = codToken,
                        Nome = usuario.Nome
                    });
                }
                else {

                    return Request.CreateResponse(HttpStatusCode.OK, new AtivacaoUsuarioResponse()
                    {
                        Token = codToken,
                        Nome = usuario.Nome
                    });
                }
            }
            catch (Exception) {

                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            
        }
    }
}