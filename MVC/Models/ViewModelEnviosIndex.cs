using Compartido.DTOs;

namespace MVC.Models
{
    public class ViewModelEnviosIndex
    {
        public ViewModelEnviosIndex(IEnumerable<ComunDTO> comunDTOs, IEnumerable<UrgenteDTO> urgenteDTOs)
        {
            this.comunDTOs = comunDTOs;
            this.urgenteDTOs = urgenteDTOs;
        }
        public IEnumerable<ComunDTO> comunDTOs { get; set; }
        public IEnumerable<UrgenteDTO> urgenteDTOs { get; set; }
    }
}
