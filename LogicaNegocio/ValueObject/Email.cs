using LogicaNegocio.ExcepcionesEntidades;
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
            if (String.IsNullOrEmpty(Valor) || Valor.Length < 7 || !Valor.Contains("@") || !Valor.Contains(".com"))
            {
                throw new UsuarioException("Email invalido.");
            }
        }
       

    }
}
