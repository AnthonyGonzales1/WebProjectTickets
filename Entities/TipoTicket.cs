using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class TipoTicket
    {
        [Key]
        public int TipoTicketId { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }

        public TipoTicket()
        {
            TipoTicketId = 0;
            Descripcion = string.Empty;
            Lugar = string.Empty;
            Fecha = DateTime.Now;
        }

        public TipoTicket(int tipoTicketId, string descripcion, string lugar, DateTime fecha)
        {
            TipoTicketId = tipoTicketId;
            Descripcion = descripcion;
            Lugar = lugar;
            Fecha = fecha;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
