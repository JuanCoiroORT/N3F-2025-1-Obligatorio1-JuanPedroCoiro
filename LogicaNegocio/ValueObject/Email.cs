using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public class Email
    {
        public string Valor { get; }

        public Email(string valor) 
        {
            Valor = valor;
            Validar();
        }
        
        private void Validar()
        {
            // VALIDACION DE EMAIL
        }

    }
}
