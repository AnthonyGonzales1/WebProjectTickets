using BLL;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProjectTickets.Utilitarios;

namespace WebProjectTickets.Registros
{
    public partial class WebFormVentaTickets : System.Web.UI.Page
    {
        public bool SeBusco { get; set; }
        List<ConsultorioVenta> detalle = new List<ConsultorioVenta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDown();
                ViewState["ConsultorioVenta"] = new ConsultorioVenta();

                FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<VentaTicket> repositorio = new RepositorioBase<VentaTicket>();
                    var registro = repositorio.Buscar(id);

                    if (registro == null)
                    {
                        Utils.ShowToastr(this.Page, "Registro no encontrado", "Error", "error");
                    }
                    else
                    {
                        LlenarCampos(registro);
                    }
                }
            }
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

            RepositorioBase<Ticket> ticket = new RepositorioBase<Ticket>();
            TicketDropDownList.DataSource = ticket.GetList(x => true);
            TicketDropDownList.DataValueField = "TicketId";
            TicketDropDownList.DataTextField = "NombreEvento";
            TicketDropDownList.DataBind();

        }

        private void Limpiar()
        {
            VentaTicketIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ClienteDropDownList.SelectedValue = null;
            TicketDropDownList.SelectedValue = null;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            ImporteTextBox.Text = "0";
            VentasGridView.DataSource = null;
            SubTotalTextBox.Text = "";
            ITBISTextBox.Text = "0";
            TotalTextBox.Text = string.Empty;
            VentasGridView.DataSource = null;
            VentasGridView.DataBind();
        }

        private VentaTicket LlenaClase()
        {
            VentaTicket ventaTicket = new VentaTicket();

            ventaTicket.VentaTicketId = ToInt(VentaTicketIdTextBox.Text);
            ventaTicket.ClienteId = ToInt(ClienteDropDownList.SelectedValue);
            ventaTicket.TicketId = ToInt(TicketDropDownList.SelectedValue);
            ventaTicket.Fecha = DateTime.Parse(FechaTextBox.Text);
            ventaTicket.SubTotal = ToInt(SubTotalTextBox.Text);
            ventaTicket.Itbis = ToInt(ITBISTextBox.Text);
            ventaTicket.Total = ToInt(TotalTextBox.Text);

            ventaTicket.Detalle = (List<ConsultorioVenta>)ViewState["ConsultorioVenta"];


            return ventaTicket;
        }

        private void LlenarCampos(VentaTicket ventaTicket)
        {
            ClienteDropDownList.SelectedValue = ventaTicket.ClienteId.ToString();
            TicketDropDownList.SelectedValue = ventaTicket.TicketId.ToString();
            FechaTextBox.Text = ventaTicket.Fecha.ToString("yyyy-MM-dd");
            SubTotalTextBox.Text = ventaTicket.SubTotal.ToString();
            ITBISTextBox.Text = ventaTicket.Itbis.ToString();
            TotalTextBox.Text = ventaTicket.Total.ToString();

            VentasGridView.DataSource = Utils.AddDetalle(ToInt(VentaTicketIdTextBox.Text));
            VentasGridView.DataBind();

        }

        private void LlenarPrecio()
        {
            int id = Utils.ToInt(TicketDropDownList.SelectedValue);
            Ticket ticket = new Ticket();
            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();
            ticket = repositorio.Buscar(id);
            int p = ticket.Precio;
            PrecioTextBox.Text = p.ToString();
        }

        private void LlenarImporte()
        {
            int cantidad, precio;

            cantidad = ToInt(CantidadTextBox.Text);
            precio = ToInt(PrecioTextBox.Text);
            ImporteTextBox.Text = Utils.Importe(cantidad, precio).ToString();
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

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            VentaTicket ventaTicket = new VentaTicket();
            VentaTicketRepositorio repositorio = new VentaTicketRepositorio();
            bool Paso = false;

            if (Page.IsValid)
            {

                ventaTicket = LlenaClase();

                if (Utils.ToInt(VentaTicketIdTextBox.Text) == 0)
                {
                    Paso = repositorio.Guardar(ventaTicket);
                    Limpiar();
                    Utils.ShowToastr(this.Page, "Guardado", "Exito", "success");
                }
                else
                {
                    VentaTicketRepositorio repository = new VentaTicketRepositorio();
                    int id = Utils.ToInt(VentaTicketIdTextBox.Text);
                    ventaTicket = repository.Buscar(id);

                    if (ventaTicket != null)
                    {
                        Paso = repository.Modificar(LlenaClase());
                        Utils.ShowToastr(this.Page, "Modificado", "Exito", "success");
                    }
                    else
                        Utils.ShowToastr(this.Page, "Id no existe", "Error", "error");
                }

                if (Paso)
                {
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No se pudo guardar", "Error", "error");
            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            VentaTicketRepositorio repositorio = new VentaTicketRepositorio();
            VentaTicket ventaTicket = repositorio.Buscar(ToInt(VentaTicketIdTextBox.Text));

            if (ventaTicket != null)
            {
                if (repositorio.Eliminar(ToInt(VentaTicketIdTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No se pudo eliminar", "Error", "error");
            }
        }

        private bool ContarCantidad()
        {
            List<ConsultorioVenta> detalle = new List<ConsultorioVenta>();

            if (VentasGridView.DataSource != null)
            {
                detalle = (List<ConsultorioVenta>)VentasGridView.DataSource;
            }

            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();

            Ticket ticket = new Ticket();

            RepositorioBase<Ticket> repository = new RepositorioBase<Ticket>();

            ticket = repository.Buscar(Utils.ToInt(TicketDropDownList.SelectedValue));

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

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<ConsultorioVenta> repositorio = new RepositorioBase<ConsultorioVenta>();
            VentaTicket ventaTicket = new VentaTicket();
            var detalle = repositorio.Buscar(Utils.ToInt(VentaTicketIdTextBox.Text));

            if (VentasGridView.Rows.Count != 0)
            {
                ventaTicket.Detalle = (List<ConsultorioVenta>)ViewState["ConsultorioVenta"];
            }
            if (ContarCantidad())
            {
                Utils.ShowToastr(this.Page, "Cantidad Mayor a la Existente", "Error", "Exit");

            }
            else if (String.IsNullOrEmpty(CantidadTextBox.Text))
            {
                Utils.ShowToastr(this.Page, "Cantidad no puede estar vacia", "Error", "Exit");

            }
            else
            {
                ventaTicket.Detalle.Add(new ConsultorioVenta(0, Utils.ToInt(VentaTicketIdTextBox.Text), Utils.ToInt(ClienteDropDownList.Text), Utils.ToInt(TicketDropDownList.Text), Utils.ToInt(CantidadTextBox.Text), Utils.ToInt(PrecioTextBox.Text), Utils.ToInt(ImporteTextBox.Text)));

                ViewState["ConsultorioVenta"] = ventaTicket.Detalle;
                VentasGridView.DataSource = ViewState["ConsultorioVenta"];
                VentasGridView.DataBind();
                SubirValores();
            }

        }

        protected void BindGrid()
        {
            VentasGridView.DataSource = ((VentaTicket)ViewState["VentaTicket"]).Detalle;
            VentasGridView.DataBind();

        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            LlenarImporte();
        }

        protected void TicketDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //todo: instanciar un ticket y buscar el seleccionado
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            VentaTicketRepositorio ventaTicketsRepositorio = new VentaTicketRepositorio();
            VentaTicket ventaTicket = ventaTicketsRepositorio.Buscar(ToInt(VentaTicketIdTextBox.Text));

            if (ventaTicket != null)
            {
                LlenarCampos(ventaTicket);
                Utils.ShowToastr(this.Page, "Busqueda exitosa", "Exito", "success");

            }
            else
            {
                Utils.ShowToastr(this.Page, "No Hay Resultado", "Error", "error");
                Limpiar();
            }

        }

        protected void VentasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {/*
                int index = Convert.ToInt32(e.CommandArgument);
                Expression<Func<ConsultorioVenta, bool>> filtro = p => true;
                RepositorioBase<ConsultorioVenta> repositorio = new RepositorioBase<ConsultorioVenta>();
                var lista = repositorio.GetList(c => true);
                var consultorio = repositorio.Buscar(lista[index].VentaTicketId);
                ((List<ConsultorioVenta>)ViewState["ConsultorioVenta"]).RemoveAt(index);
                VentasGridView.DataSource = ViewState["ConsultorioVenta"];
                VentasGridView.DataBind();*/
                
                VentasGridView.DataSource = null;
                VentasGridView.DataBind();
                BajarValores();
            }
        }

        protected void VentasGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            VentasGridView.DataSource = ViewState["ConsultorioVenta"];
            VentasGridView.PageIndex = e.NewPageIndex;
            VentasGridView.DataBind();
        }
    }
}