
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fbiz.Framework.Business;
using Model;
using PagedList;

namespace Business.Interface
{
    public interface ICompartilhamentoBusiness : IBusiness<Compartilhamento>
    {
        Compartilhamento ObterPorUsuario(int usuarioId);
        Compartilhamento[] ListarCompartilhamento();
    }
}
