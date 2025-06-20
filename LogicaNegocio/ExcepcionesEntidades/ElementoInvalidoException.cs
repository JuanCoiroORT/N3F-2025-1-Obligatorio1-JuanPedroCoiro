using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ElementoInvalidoException : Exception
    {
        public ElementoInvalidoException(string message) : base(message) { }
    }
}
