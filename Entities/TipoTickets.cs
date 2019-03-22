using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class TipoTickets
    {
        [Key]
        public int TipoTicketId { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime FechaHora { get; set; }

        public TipoTickets()
        {
            TipoTicketId = 0;
            Descripcion = string.Empty;
            Lugar = string.Empty;
            FechaHora = DateTime.Now;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
