using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs
{
    public class UrgenteDTO
    {
        public int Id { get; set; }
        public double Peso { get; set; }
        public int DireccionPostal { get; set; }

        public UrgenteDTO(Urgente envioUrgente)
        {
            Id = envioUrgente.Id;
            Peso = envioUrgente.Peso;
            DireccionPostal = envioUrgente.DireccionPostal;
        }

        public UrgenteDTO() { }

        public Urgente ToUrgente()
        {
            Urgente envioUrgente = new Urgente()
            {
                Id = this.Id,
                Peso = this.Peso,
                DireccionPostal= this.DireccionPostal,
            };
            return envioUrgente;
        }
    }
}
