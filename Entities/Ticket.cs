using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int TipoTicket { get; set; }
        public string NombreEvento { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

        public Ticket()
        {
            TicketId = 0;
            TipoTicket = 0;
            NombreEvento = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }

        public Ticket(int ticketId, int tipoTicket, string nombreEvento, int cantidad, int precio)
        {
            TicketId = ticketId;
            TipoTicket = tipoTicket;
            NombreEvento = nombreEvento;
            Cantidad = cantidad;
            Precio = precio;
        }

        public override string ToString()
        {
            return NombreEvento;
        }
    }
}
