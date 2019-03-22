using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Tickets> Ticket { get; set; }
        public DbSet<TipoTickets> TipoTicket { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<VentaTickets> VentaTicket { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
