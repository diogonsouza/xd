using Fbiz.Framework.Business;
using Model;
using PagedList;

namespace Business.Interface
{
    public interface IOperadorBusiness : IBusiness<Operador>
    {
        Operador Obter(int operadorId);
        Operador Obter(string login);

        IPagedList<Operador> ListarTodos(int pageNumber, int pageSize);
    }
}
