using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class VentaTickets
    {
        [Key]
        public int VentaTicketId { get; set; }
        public int ClienteId { get; set; }
        public int TicketId { get; set; }
        public DateTime Fecha { get; set; }
        public double SubTotal { get; set; }
        public double Itbis { get; set; }
        public double Total { get; set; }

        public virtual List<VentasTicketsDetalle> Detalle { get; set; }

        public VentaTickets()
        {
            this.Detalle = new List<VentasTicketsDetalle>();
        }

        public void AgregarDetalle(int Id, int VentaTicketId, int ClienteId, int TicketId, int Cantidad, int Precio, int Importe)
        {
            this.Detalle.Add(new VentasTicketsDetalle(Id, VentaTicketId, ClienteId, TicketId, Cantidad, Precio, Importe));
        }
    }
}
