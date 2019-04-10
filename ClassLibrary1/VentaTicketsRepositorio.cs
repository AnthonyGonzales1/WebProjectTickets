using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VentaTicketRepositorio : RepositorioBase<VentaTicket>
    {
        public VentaTicketRepositorio() : base()
        {

        }

        public override bool Guardar(VentaTicket ventaTicket)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.VentaTicket.Add(ventaTicket) != null)
                {
                    foreach (var item in ventaTicket.Detalle)
                    {
                        contexto.Ticket.Find(item.TicketId).Cantidad -= item.Cantidad;
                    }

                    contexto.Cliente.Find(ventaTicket.ClienteId).Deuda += ventaTicket.Total;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static void ModificarBien(VentaTicket ventaTicket, VentaTicket ventaTicketAnt)
        {
            Contexto contexto = new Contexto();
            var Cliente = contexto.Cliente.Find(ventaTicket.ClienteId);
            var ClienteAnt = contexto.Cliente.Find(ventaTicketAnt.ClienteId); 
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            RepositorioBase<Cliente> repository = new RepositorioBase<Cliente>();

            Cliente.Deuda += ventaTicket.Total;
            ClienteAnt.Deuda -= ventaTicketAnt.Total;
            repositorio.Modificar(Cliente);
            repository.Modificar(ClienteAnt);
        }

        public static void Modifica(VentaTicket ventaTicket, VentaTicket VentaAnt, Contexto contexto)
        {
            double modificado = ventaTicket.Total - VentaAnt.Total;
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            var Cliente = contexto.Cliente.Find(ventaTicket.ClienteId);
            Cliente.Deuda += Convert.ToInt32(modificado);
            repositorio.Modificar(Cliente);
        }

        public override bool Modificar(VentaTicket ventaTicket)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            RepositorioBase<VentaTicket> repositorio = new RepositorioBase<VentaTicket>();
           try
                {
                    var VentaAnt = repositorio.Buscar(ventaTicket.VentaTicketId);

                    if (ventaTicket.ClienteId != VentaAnt.ClienteId)
                    {
                        ModificarBien(ventaTicket, VentaAnt);
                    }

                    if (ventaTicket != null)
                    {
                        foreach (var item in VentaAnt.Detalle)
                        {
                            contexto.Ticket.Find(item.TicketId).Cantidad += item.Cantidad;

                            if (!ventaTicket.Detalle.ToList().Exists(v => v.Id == item.Id))
                            {
                                item.Tickets = null;
                                contexto.Entry(item).State = EntityState.Deleted;
                            }
                        }
                        contexto = new Contexto();

                        foreach (var item in ventaTicket.Detalle)
                        {
                            contexto.Ticket.Find(item.TicketId).Cantidad -= item.Cantidad;
                            var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                            contexto.Entry(item).State = estado;
                        }
                        contexto = new Contexto();
                        contexto.Entry(ventaTicket).State = EntityState.Modified;
                    }

                    Modifica(ventaTicket, VentaAnt, contexto);

                    if (contexto.SaveChanges() > 0)
                    {
                        paso = true;
                    }
                    contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            } 
            return paso;
        }


        public override bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                VentaTicket ventaTicket = contexto.VentaTicket.Find(id);

                foreach (var item in ventaTicket.Detalle)
                {
                    var Elimininar = contexto.Ticket.Find(item.TicketId);
                    Elimininar.Cantidad += item.Cantidad;
                }

                contexto.Cliente.Find(ventaTicket.ClienteId).Deuda -= Convert.ToInt32(ventaTicket.Total);

                contexto.VentaTicket.Remove(ventaTicket);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public override VentaTicket Buscar(int id)
        {
            Contexto contexto = new Contexto();
            VentaTicket ventaTicket = new VentaTicket();
            try
            {
                ventaTicket = contexto.VentaTicket.Find(id);

                if (ventaTicket != null)
                {
                    ventaTicket.Detalle.Count();

                    foreach (var item in ventaTicket.Detalle)
                    {
                        string ss = item.Clientes.Nombres;
                        string sss = item.Tickets.NombreEvento;
                    }
                }

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return ventaTicket;
        }

        public override List<VentaTicket> GetList(Expression<Func<VentaTicket, bool>> expression)
        {
            List<VentaTicket> list = new List<VentaTicket>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.VentaTicket.Where(expression).ToList();
                //contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public static int Importe(int cantidad, int precio)
        {
            return cantidad * precio;
        }
    }
}
