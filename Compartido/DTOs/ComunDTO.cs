using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs
{
    public class ComunDTO
    {
        public int Id { get; set; }
        public double Peso {  get; set; }
        public Agencia Agencia { get; set; }

        public ComunDTO(Comun envioComun) 
        {
            Id = envioComun.Id;
            Peso = envioComun.Peso;
            Agencia = envioComun.Agencia;
        }

        public ComunDTO() { }

        public Comun ToComun()
        {
            Comun envioComun = new Comun()
            {
                Id = this.Id,
                Peso = this.Peso,
                Agencia = this.Agencia
            };
            return envioComun;
        }
    }
}
