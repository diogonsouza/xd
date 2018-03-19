using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class EmailJaCadastradoException : Exception
    {
        public EmailJaCadastradoException() : base("Email já cadastrado")
        {

        }
    }
}
