using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;

namespace WebProjectTickets.Utilitarios
{
    public static class Utils
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static int Importe(int cantidad, int precio)
        {
            int CalImporte = 0;
            CalImporte = cantidad * precio;

            return CalImporte;
        }

        private static int ToIntObjetos(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        public static decimal ToDecimal(string valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor, out retorno);

            return retorno;
        }

        public static DateTime ToDateTime(string valor)
        {
            DateTime retorno = DateTime.Now;
            DateTime.TryParse(valor, out retorno);

            return retorno;
        }

        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        public static void MostrarMensaje(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                 String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
        
        public static List<Cliente> clientes()
        {
            Expression<Func<Cliente, bool>> filtro = p => true;
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            List<Cliente> lista = new List<Cliente>();

            lista = repositorio.GetList(filtro);

            return lista;
        }

        public static List<Ticket> tickets()
        {
            Expression<Func<Ticket, bool>> filtro = p => true;
            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();
            List<Ticket> lista = new List<Ticket>();

            lista = repositorio.GetList(filtro);

            return lista;
        }

        public static List<TipoTicket> tipoTickets()
        {
            Expression<Func<TipoTicket, bool>> filtro = p => true;
            RepositorioBase<TipoTicket> repositorio = new RepositorioBase<TipoTicket>();
            List<TipoTicket> lista = new List<TipoTicket>();

            lista = repositorio.GetList(filtro);

            return lista;
        }

        public static List<Usuario> usuarios()
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            List<Usuario> lista = new List<Usuario>();

            lista = repositorio.GetList(filtro);

            return lista;
        }

        public static List<VentaTicket> ventaTickets()
        {
            Expression<Func<VentaTicket, bool>> filtro = p => true;
            RepositorioBase<VentaTicket> repositorio = new RepositorioBase<VentaTicket>();
            List<VentaTicket> lista = new List<VentaTicket>();

            lista = repositorio.GetList(filtro);

            return lista;
        }

        public static List<Cliente> FiltrarCliente(int index, string buscar)
        {
            Expression<Func<Cliente, bool>> filtro = p => true;
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            List<Cliente> lista = new List<Cliente>();

            int id = ToInt(buscar);
            switch (index)
            {
                case 0://Todo
                    break;
                case 1://ClienteId
                    filtro = p => p.ClienteId == id;
                    break;
                case 3://Nombres
                    filtro = p => p.Nombres.Contains(buscar);
                    break;
                case 4://Telefono
                    filtro = p => p.Telefono.Contains(buscar);
                    break;

            }
            lista = repositorio.GetList(filtro);
            return lista;
        }

        public static List<Ticket> FiltrarTicket(int index, string buscar)
        {
            Expression<Func<Ticket, bool>> filtro = p => true;
            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();
            List<Ticket> lista = new List<Ticket>();

            int id = ToInt(buscar);
            switch (index)
            {
                case 0://Todo
                    break;
                case 1://TicketId
                    filtro = p => p.TicketId == id;
                    break;
                case 2://TipoTicket
                    filtro = p => p.TipoTicket.ToString().Contains(buscar);
                    break;
                case 3://NombreEvento
                    filtro = p => p.NombreEvento.Contains(buscar);
                    break;
            }
            lista = repositorio.GetList(filtro);
            return lista;
        }

        public static List<TipoTicket> FiltrarTipo(int index, string buscar, DateTime desde, DateTime hasta)
        {
            Expression<Func<TipoTicket, bool>> filtro = p => true;
            RepositorioBase<TipoTicket> repositorio = new RepositorioBase<TipoTicket>();
            List<TipoTicket> lista = new List<TipoTicket>();

            int id = ToInt(buscar);
            switch (index)
            {
                case 0://Todo
                    break;
                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 2://TipoTicket
                    filtro = p => p.TipoTicketId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://Descripcion
                    filtro = p => p.Descripcion.Contains(buscar) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 4://Lugar
                    filtro = p => p.Lugar.Contains(buscar) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }
            lista = repositorio.GetList(filtro);
            return lista;
        }

        public static List<Usuario> FiltrarUsuario(int index, string buscar)
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            List<Usuario> lista = new List<Usuario>();

            int id = ToInt(buscar);
            switch (index)
            {
                case 0://Todo
                    break;
                case 1://UsuarioId
                    filtro = p => p.UsuarioId == id;
                    break;
                case 2://Nombre
                    filtro = p => p.Nombres.Contains(buscar);
                    break;
                case 3://Email
                    filtro = p => p.Email.Contains(buscar);
                    break;

            }
            lista = repositorio.GetList(filtro);
            return lista;
        }

        public static List<VentaTicket> FiltrarVenta(int index, string buscar, DateTime desde, DateTime hasta)
        {
            Expression<Func<VentaTicket, bool>> filtro = p => true;
            RepositorioBase<VentaTicket> repositorio = new RepositorioBase<VentaTicket>();
            List<VentaTicket> lista = new List<VentaTicket>();

            int id = ToInt(buscar);
            switch (index)
            {
                case 0://Todo
                    break;
                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 2://VentaTicket
                    filtro = p => p.VentaTicketId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://Cliente
                    filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 4://Ticket
                    filtro = p => p.TicketId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

            }
            lista = repositorio.GetList(filtro);
            return lista;
        }
        public static List<ConsultorioVenta> AddDetalle(int ID)
        {
            RepositorioBase<ConsultorioVenta> repositorioBase = new RepositorioBase<ConsultorioVenta>();
            List<ConsultorioVenta> lista = new List<ConsultorioVenta>();
            int id = ID;
            lista = repositorioBase.GetList(c => c.VentaTicketId == id);

            return lista;
        }
    }
}