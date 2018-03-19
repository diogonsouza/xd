using Business.Interface;
using Fbiz.Framework.Business;
using Model;
using PagedList;
using System.Linq;

namespace Business.Implementation
{
    public class OperadorBusiness : BusinessBase<Operador>, IOperadorBusiness
    {
        public Operador Obter(int operadorId)
        {
            return this.GetQuery().Where(x => x.OperadorId == operadorId)
                                  .FirstOrDefault();
        }

        public Operador Obter(string login)
        {
             return this.GetQuery().Where(x => x.Login == login)
                                  .Where(x => x.Ativo)
                                  .FirstOrDefault();
        }

        public IPagedList<Operador> ListarTodos(int pageNumber, int pageSize)
        {
            return this.GetQuery()
                       .OrderBy(x => x.Nome)
                       .ToPagedList(pageNumber, pageSize);
        }
    }
}
