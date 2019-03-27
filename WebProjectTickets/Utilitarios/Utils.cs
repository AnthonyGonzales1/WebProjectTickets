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
            List<Cliente> list = new List<Cliente>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Ticket> tickets()
        {
            Expression<Func<Ticket, bool>> filtro = p => true;
            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();
            List<Ticket> list = new List<Ticket>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<TipoTicket> tipoTickets()
        {
            Expression<Func<TipoTicket, bool>> filtro = p => true;
            RepositorioBase<TipoTicket> repositorio = new RepositorioBase<TipoTicket>();
            List<TipoTicket> list = new List<TipoTicket>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Usuario> usuarios()
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            List<Usuario> list = new List<Usuario>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<VentaTicket> ventaTickets()
        {
            Expression<Func<VentaTicket, bool>> filtro = p => true;
            RepositorioBase<VentaTicket> repositorio = new RepositorioBase<VentaTicket>();
            List<VentaTicket> list = new List<VentaTicket>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Cliente> FiltrarCliente(int index, string buscar)
        {
            Expression<Func<Cliente, bool>> filtro = p => true;
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            List<Cliente> list = new List<Cliente>();

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
                case 5://Deuda
                    filtro = p => p.Deuda.ToString().Contains(buscar);
                    break;
            }
            list = repositorio.GetList(filtro);
            return list;
        }

        public static List<Ticket> FiltrarTicket(int index, string buscar)
        {
            Expression<Func<Ticket, bool>> filtro = p => true;
            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();
            List<Ticket> list = new List<Ticket>();

            int id = ToInt(buscar);
            switch (index)
            {
                case 0://Todo
                    break;
                case 1://TicketId
                    filtro = p => p.TicketId == id;
                    break;
                case 2://TipoTicket
                    filtro = p => p.TipoTicket.Contains(buscar);
                    break;
                case 3://NombreEvento
                    filtro = p => p.NombreEvento.Contains(buscar);
                    break;
                case 4://Cantidad
                    filtro = p => p.Cantidad.ToString().Contains(buscar);
                    break;
                case 5://Precio
                    filtro = p => p.Precio.ToString().Contains(buscar);
                    break;
            }
            list = repositorio.GetList(filtro);
            return list;
        }

        public static List<TipoTicket> FiltrarTipo(int index, string buscar, DateTime desde, DateTime hasta)
        {
            Expression<Func<TipoTicket, bool>> filtro = p => true;
            RepositorioBase<TipoTicket> repositorio = new RepositorioBase<TipoTicket>();
            List<TipoTicket> list = new List<TipoTicket>();

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
            list = repositorio.GetList(filtro);
            return list;
        }

        public static List<Usuario> FiltrarUsuario(int index, string buscar)
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            List<Usuario> list = new List<Usuario>();

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
                case 4://Clave
                    filtro = p => p.Clave.ToString().Contains(buscar);
                    break;
            }
            list = repositorio.GetList(filtro);
            return list;
        }

        public static List<VentaTicket> FiltrarVenta(int index, string buscar, DateTime desde, DateTime hasta)
        {
            Expression<Func<VentaTicket, bool>> filtro = p => true;
            RepositorioBase<VentaTicket> repositorio = new RepositorioBase<VentaTicket>();
            List<VentaTicket> list = new List<VentaTicket>();

            int id = ToInt(buscar);
            switch (index)
            {
                case 0://Todo
                    break;
                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 2://TipoTicket
                    filtro = p => p.VentaTicketId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 3://TipoTicket
                    filtro = p => p.ClienteId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 4://TipoTicket
                    filtro = p => p.TicketId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 5://Descripcion
                    filtro = p => p.SubTotal.ToString().Contains(buscar) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                case 6://Lugar
                    filtro = p => p.Itbis.ToString().Contains(buscar) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }
            list = repositorio.GetList(filtro);
            return list;
        }
    }
}