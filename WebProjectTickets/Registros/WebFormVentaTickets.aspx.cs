using BLL;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectTickets.Registros
{
    public partial class WebFormVentaTickets : System.Web.UI.Page
    {
        public bool SeBusco { get; set; }
        List<ConsultorioVenta> detalle = new List<ConsultorioVenta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LlenarDropDown();

            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

        }

        protected void CallModal(string mensaje)
        {
            Label label = (Label)Master.FindControl("MessageLabel");
            if (label != null)
                label.Text = mensaje;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert",
                            "$(function() { openModal(); });", true);
        }

        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        private void LlenarDropDown()
        {
            RepositorioBase<Cliente> cliente = new RepositorioBase<Cliente>();
            ClienteDropDownList.DataSource = cliente.GetList(x => true);
            ClienteDropDownList.DataValueField = "CLienteId";
            ClienteDropDownList.DataTextField = "Nombres";
            ClienteDropDownList.DataBind();
            ClienteDropDownList.Items.Insert(0, new ListItem("", ""));

            RepositorioBase<Ticket> ticket = new RepositorioBase<Ticket>();
            TicketDropDownList.DataSource = ticket.GetList(x => true);
            TicketDropDownList.DataValueField = "TicketId";
            TicketDropDownList.DataTextField = "NombreEvento";
            TicketDropDownList.DataBind();
            TicketDropDownList.Items.Insert(0, new ListItem("", ""));

        }

        private void Limpiar()
        {
            VentaTicketIdTextBox.Text = "0";
            FechaTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
            VentasGridView.DataSource = null;
            SubTotalTextBox.Text = string.Empty;
            ITBISTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            VentasGridView.DataSource = null;
            VentasGridView.DataBind();
        }

        private VentaTicket LlenaClase()
        {
            return new VentaTicket(
                ToInt(VentaTicketIdTextBox.Text),
                ToInt(ClienteDropDownList.SelectedValue),
                ToInt(TicketDropDownList.SelectedValue),
                DateTime.Parse(FechaTextBox.Text),
                ToInt(SubTotalTextBox.Text),
                ToInt(ITBISTextBox.Text),
                ToInt(TotalTextBox.Text)

                );
        }

        private void LlenarCampos(VentaTicket ventaTicket)
        {
            VentaTicketIdTextBox.Text = ventaTicket.VentaTicketId.ToString();
            ClienteDropDownList.SelectedValue = ventaTicket.ClienteId.ToString();
            TicketDropDownList.SelectedValue = ventaTicket.TicketId.ToString();
            FechaTextBox.Text = ventaTicket.Fecha.ToString("yyyy-MM-dd");
            SubTotalTextBox.Text = ventaTicket.SubTotal.ToString();
            ITBISTextBox.Text = ventaTicket.Itbis.ToString();
            TotalTextBox.Text = ventaTicket.Total.ToString();
            VentasGridView.DataSource = ventaTicket.Detalle.ToList();
            VentasGridView.DataBind();
            ViewState["Detalle"] = ventaTicket.Detalle;

        }

        private void LlenarPrecio()
        {
            List<Ticket> lista = new RepositorioBase<Ticket>().GetList(c => c.NombreEvento == TicketDropDownList.Text);
            foreach (var item in lista)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }

        private void LlenarImporte()
        {
            int cantidad, precio;

            cantidad = ToInt(CantidadTextBox.Text);
            precio = ToInt(PrecioTextBox.Text);
            ImporteTextBox.Text = VentaTicketRepositorio.Importe(cantidad, precio).ToString();
        }

        private void SubirValores()
        {
            List<ConsultorioVenta> detalle = new List<ConsultorioVenta>();

            if (VentasGridView.DataSource != null)
            {
                detalle = (List<ConsultorioVenta>)VentasGridView.DataSource;
            }
            int Total = 0;
            int Itbis = 0;
            int SubTotal = 0;
            foreach (var item in detalle)
            {
                Total += item.Importe;
            }
            Itbis = (Total * 18) / 100;
            SubTotal = Total - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ITBISTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
        }

        private void BajarValores()
        {
            List<ConsultorioVenta> detalle = new List<ConsultorioVenta>();

            if (VentasGridView.DataSource != null)
            {
                detalle = (List<ConsultorioVenta>)VentasGridView.DataSource;
            }
            int Total = 0;
            int Itbis = 0;
            int SubTotal = 0;
            foreach (var item in detalle)
            {
                Total -= item.Importe;
            }
            Total *= (-1);
            Itbis = (Total * 18) / 100;
            SubTotal = Total - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ITBISTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Total.ToString();
        }


        private bool ContarCantidad()
        {
            List<ConsultorioVenta> detalle = new List<ConsultorioVenta>();

            if (VentasGridView.DataSource != null)
            {
                detalle = (List<ConsultorioVenta>)VentasGridView.DataSource;
            }

            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();

            Ticket ticket = (Ticket)TicketDropDownList.SelectedItem;

            int CantidadCotizada = 0;
            foreach (var item in detalle)
            {
                CantidadCotizada += item.Cantidad;
            }

            int CantidadTickets = ticket.Cantidad;

            bool paso = false;

            if (Convert.ToInt32(CantidadTextBox.Text) > ticket.Cantidad)
            {
                paso = true;
            }

            CantidadTickets -= CantidadCotizada;

            if (CantidadTickets < CantidadCotizada)
            {
                paso = true;
            }

            return paso;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            VentaTicketRepositorio ventaTicketsRepositorio = new VentaTicketRepositorio();
            VentaTicket ventaTicket = ventaTicketsRepositorio.Buscar(ToInt(VentaTicketIdTextBox.Text));

            if (ventaTicket != null)
            {
                LlenarCampos(ventaTicket);
                SeBusco = true;
                ViewState["SeBusco"] = SeBusco;
            }
            else
                CallModal("Esta Venta no existe.");

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioBase<VentaTicket> repositorio = new RepositorioBase<VentaTicket>();

                if (ToInt(VentaTicketIdTextBox.Text) == 0)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        CallModal("Se guardo la Venta");
                        Limpiar();

                    }
                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        CallModal("Se modifico la Venta");
                        Limpiar();
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            List<ConsultorioVenta> detalle = new List<ConsultorioVenta>();

            if (VentasGridView.DataSource != null)
            {
                detalle = (List<ConsultorioVenta>)VentasGridView.DataSource;
            }
            if (ContarCantidad())
            {
            }
            else if (String.IsNullOrEmpty(CantidadTextBox.Text))
            {
            }
            else
            {
                detalle.Add(
               new ConsultorioVenta(
                   id: 0,
                   ventaTicketId: (int)Convert.ToInt32(VentaTicketIdTextBox.Text),
                   clienteId: (int)Convert.ToInt32(ClienteDropDownList.SelectedValue),
                   ticketId: (int)Convert.ToInt32(TicketDropDownList.SelectedValue),
                   cantidad: (int)Convert.ToInt32(CantidadTextBox.Text),
                   precio: (int)Convert.ToInt32(PrecioTextBox.Text),
                   importe: (int)Convert.ToInt32(ImporteTextBox.Text)
               ));

                VentasGridView.DataSource = null;
                VentasGridView.DataSource = detalle;

                SubirValores();
            }
        }

        protected void RemoverButton_Click(object sender, EventArgs e)
        {
                VentasGridView.DataSource = null;
                VentasGridView.DataSource = detalle;

                BajarValores();
        }
    }
}