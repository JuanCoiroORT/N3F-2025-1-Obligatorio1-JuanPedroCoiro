using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Seguimiento
    {
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Empleado { get; set; }

        public Seguimiento(string comentario, DateTime fecha, Usuario empleado)
        {
            Comentario = comentario;
            Fecha = fecha;
            Empleado = empleado;
        }
    }
}
