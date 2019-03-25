using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class ConsultorioVenta
    {
        [Key]
        public int Id { get; set; }
        public int VentaTicketId { get; set; }
        public int ClienteId { get; set; }
        public int TicketId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Importe { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Tickets { get; set; }

        public ConsultorioVenta()
        {
            Id = 0;
            VentaTicketId = 0;
            ClienteId = 0;
            TicketId = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public ConsultorioVenta(int id, int ventaTicketId, int clienteId, int ticketId, int cantidad, int precio, int importe)
        {
            Id = id;
            VentaTicketId = ventaTicketId;
            ClienteId = clienteId;
            TicketId = ticketId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
