using Business.Interface;
using Fbiz.Framework.Business;
using Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace Business.Implementation
{
    public class RecuperacaoSenhaBusiness : BusinessBase<RecuperacaoSenha>, IRecuperacaoSenhaBusiness
    {
        public RecuperacaoSenha Obter(string token)
        {
            return this.GetQuery().Include(x => x.Operador)
                                  .Where(x => x.Token == token)
                                  .Where(x => x.Valido)
                                  .FirstOrDefault();
        }

        public void InativarRegistrosAntigos(int operadorId)
        {
            var model = this.GetQuery().Where(x => x.OperadorId == operadorId && x.Valido)
                                       .ToList();

            model.ForEach(x => x.Valido = false);
            this.Update(model);
            this.Save();
        }

        public RecuperacaoSenha Criar(int operadorId)
        {
            var model = new RecuperacaoSenha()
            {
                DataCadastro = DateTime.Now,
                OperadorId = operadorId,
                Token = Guid.NewGuid().ToString().Replace("-", string.Empty),
                Valido = true
            };

            this.Add(model);
            this.Save();
            return model;
        }
    }
}
