using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class VentaTicket
    {
        [Key]
        public int VentaTicketId { get; set; }
        public int ClienteId { get; set; }
        public int TicketId { get; set; }
        public DateTime Fecha { get; set; }
        public double SubTotal { get; set; }
        public double Itbis { get; set; }
        public double Total { get; set; }

        public virtual List<ConsultorioVenta> Detalle { get; set; }

        public VentaTicket()
        {
            this.Detalle = new List<ConsultorioVenta>();
        }

        public void AgregarDetalle(int Id, int VentaTicketId, int ClienteId, int TicketId, int Cantidad, int Precio, int Importe)
        {
            this.Detalle.Add(new ConsultorioVenta(Id, VentaTicketId, ClienteId, TicketId, Cantidad, Precio, Importe));
        }
    }
}
