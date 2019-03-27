using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectTickets.Registros
{
    public partial class WebFormTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LlenarDropDown();
            
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
            RepositorioBase<Ticket> rep = new RepositorioBase<Ticket>();
            TipoTicketDropDownList.DataSource = rep.GetList(x => true);
            TipoTicketDropDownList.DataValueField = "CuentaId";
            TipoTicketDropDownList.DataTextField = "Nombre";
            TipoTicketDropDownList.DataBind();
            TipoTicketDropDownList.Items.Insert(0, new ListItem("", ""));
        }

        private void Limpiar()
        {
            TicketIdTextBox.Text = string.Empty;
            NombreEventoTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
            CantidaTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
        }

        private Ticket LlenaClase()
        {
            return new Ticket(
                ToInt(TicketIdTextBox.Text),
                TipoTicketDropDownList.SelectedValue,
                NombreEventoTextBox.Text,
                ToInt(CantidaTextBox.Text),
                ToInt(PrecioTextBox.Text)
                );
        }

        private void LlenarCampos(Ticket ticket)
        {
            TicketIdTextBox.Text = ticket.TicketId.ToString();
            TipoTicketDropDownList.SelectedValue = ticket.TipoTicket;
            NombreEventoTextBox.Text = ticket.NombreEvento;
            CantidaTextBox.Text = ticket.Cantidad.ToString();
            PrecioTextBox.Text = ticket.Precio.ToString();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Ticket> repositorio = new RepositorioBase<Ticket>();
            Ticket ticket = repositorio.Buscar(ToInt(TicketIdTextBox.Text));
            if (ticket != null)
                LlenarCampos(ticket);
            else
                CallModal("Este Ticket no existe");

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TicketRepositorio repositorio = new TicketRepositorio();

                if (ToInt(TicketIdTextBox.Text) == 0)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        CallModal("Se a registrado el Ticket");
                        Limpiar();
                    }
                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        CallModal("Se no se pudo registrar el Ticket");
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
                    CallModal("Se a eliminado el Ticket");
                    Limpiar();
                }
                else
                    CallModal("Se no se pudo eliminar el Ticket");
            }
        }
    }
}