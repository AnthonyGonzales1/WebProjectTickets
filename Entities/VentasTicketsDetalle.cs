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
    public class VentasTicketsDetalle
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
        public virtual Clientes Cliente { get; set; }

        [ForeignKey("TicketId")]
        public virtual Tickets Tickets { get; set; }

        public VentasTicketsDetalle()
        {
            Id = 0;
            VentaTicketId = 0;
            ClienteId = 0;
            TicketId = 0;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public VentasTicketsDetalle(int id, int ventaTicketId, int clienteId, int ticketId, int cantidad, int precio, int importe)
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
