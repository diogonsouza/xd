using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class CPFJaCadastradoException : Exception
    {
        public CPFJaCadastradoException() : base("CPF já cadastrado")
        {

        }
    }
}
