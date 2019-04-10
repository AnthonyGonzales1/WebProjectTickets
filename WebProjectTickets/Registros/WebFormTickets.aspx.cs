using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProjectTickets.Utilitarios;

namespace WebProjectTickets.Registros
{
    public partial class WebFormTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDown();
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();
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
            RepositorioBase<TipoTicket> rep = new RepositorioBase<TipoTicket>();
            TipoTicketDropDownList.DataSource = rep.GetList(x => true);
            TipoTicketDropDownList.DataValueField = "TipoTicketId";
            TipoTicketDropDownList.DataTextField = "Descripcion";
            TipoTicketDropDownList.DataBind();
            TipoTicketDropDownList.Items.Insert(0, new ListItem("", ""));

        }

        private void Limpiar()
        {
            TicketIdTextBox.Text = string.Empty;
            TipoTicketDropDownList.SelectedValue = null;
            NombreEventoTextBox.Text = string.Empty;
            CantidaTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
        }

        private Ticket LlenaClase()
        {
            Ticket ticket = new Ticket();

            ticket.TicketId = ToInt(TicketIdTextBox.Text);
            ticket.TipoTicket = ToInt(TipoTicketDropDownList.SelectedValue);
            ticket.NombreEvento = NombreEventoTextBox.Text;
            ticket.Cantidad = ToInt(CantidaTextBox.Text);
            ticket.Precio = ToInt(PrecioTextBox.Text);

            return ticket;
        }

        private void LlenarCampos(Ticket ticket)
        {
            TicketIdTextBox.Text = ticket.TicketId.ToString();
            TipoTicketDropDownList.SelectedValue = ticket.TipoTicket.ToString();
            NombreEventoTextBox.Text = ticket.NombreEvento;
            CantidaTextBox.Text = ticket.Cantidad.ToString();
            PrecioTextBox.Text = ticket.Precio.ToString();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();
            Ticket ticket = repositorio.Buscar(ToInt(TicketIdTextBox.Text));
            if (ticket != null)
            {
                LlenarCampos(ticket);
                Utils.ShowToastr(this.Page, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "No Hay Resultado", "Error", "error");
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();

                if (ToInt(TicketIdTextBox.Text) == 0)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        Utils.ShowToastr(this.Page, "Guardado", "Exito", "success");
                        Limpiar();
                    }
                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        Utils.ShowToastr(this.Page, "No se pudo guardar", "Error", "error");
                        Limpiar();
                    }
                }
            }
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            TicketRepositorio repositorio = new TicketRepositorio();
            Ticket ticket = repositorio.Buscar(ToInt(TicketIdTextBox.Text));

            if (ticket != null)
            {
                if (repositorio.Eliminar(ToInt(TicketIdTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No se pudo eliminar", "Error", "error");
            }
        }
    }
}