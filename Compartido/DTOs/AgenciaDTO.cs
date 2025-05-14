using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs
{
    public class AgenciaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DireccionPostal { get; set; }
        public double Ubicacion {  get; set; }

        public AgenciaDTO(Agencia agencia)
        {
            Id = agencia.Id;
            Nombre = agencia.Nombre;
            DireccionPostal = agencia.DireccionPostal;
            Ubicacion = agencia.Ubicacion;
        }

        public AgenciaDTO() { }

        public Agencia ToAgencia()
        {
            Agencia agencia = new Agencia()
            {
                Id = this.Id,
                Nombre = this.Nombre,
                DireccionPostal = this.DireccionPostal,
                Ubicacion = this.Ubicacion
            };
            return agencia;
        }
    }
}
