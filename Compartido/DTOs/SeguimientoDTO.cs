using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs
{
    public class SeguimientoDTO
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }

        public SeguimientoDTO(Seguimiento s)
        {
            Id = s.Id;
            Comentario = s.Comentario;
            Fecha = s.Fecha;
            EmpleadoId = s.EmpleadoId;
        }

        public SeguimientoDTO() { }

        public Seguimiento ToSeguimiento()
        {
            Seguimiento s = new Seguimiento()
            {
                Id = this.Id,
                Comentario = this.Comentario,
                Fecha = this.Fecha,
                EmpleadoId = this.EmpleadoId
            };
            return s;
        }
    }
}
