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
        public int SubTotal { get; set; }
        public int Itbis { get; set; }
        public int Total { get; set; }

        public virtual List<ConsultorioVenta> Detalle { get; set; }

        public VentaTicket()
        {
            VentaTicketId = 0;
            ClienteId = 0;
            TicketId = 0;
            Fecha = DateTime.Now;
            SubTotal = 0;
            Itbis = 0;
            Total = 0;

            Detalle = new List<ConsultorioVenta>();

        }

        public void AgregarDetalle(int Id, int VentaTicketId, int ClienteId, int TicketId, int Cantidad, int Precio, int Importe)
        {
            this.Detalle.Add(new ConsultorioVenta(Id, VentaTicketId, ClienteId, TicketId, Cantidad, Precio, Importe));
        }

        public override string ToString()
        {
            return VentaTicketId.ToString();
        }
        
    }
}
