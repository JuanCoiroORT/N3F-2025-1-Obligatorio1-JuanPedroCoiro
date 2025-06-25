using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs
{
    public class CambioPasswordDTO
    {
        public int Id { get; set; }
        public string PasswordActual { get; set; }
        public string PasswordNueva { get; set; }
    }
}
