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
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TipoTicket> TipoTicket { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<VentaTicket> VentaTicket { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
