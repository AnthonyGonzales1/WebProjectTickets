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
    public partial class WebFormTipoTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        private void Limpiar()
        {
            TipoTicketIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            LugarTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }

        private TipoTicket LlenaClase()
        {
            return new TipoTicket(
                ToInt(TipoTicketIdTextBox.Text),
                DescripcionTextBox.Text,
                LugarTextBox.Text
                );
        }

        private void LlenarCampos(TipoTicket tipoTicket)
        {
            TipoTicketIdTextBox.Text = tipoTicket.TipoTicketId.ToString();
            DescripcionTextBox.Text = tipoTicket.Descripcion;
            LugarTextBox.Text = tipoTicket.Lugar;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoTicket> repositorio = new RepositorioBase<TipoTicket>();
            TipoTicket tipoTicket = repositorio.Buscar(ToInt(TipoTicketIdTextBox.Text));
            if (tipoTicket != null)
                LlenarCampos(tipoTicket);
            else
                CallModal("Este Tipo de Ticket no existe");

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TipoTicketRepositorio repositorio = new TipoTicketRepositorio();

                if (ToInt(TipoTicketIdTextBox.Text) == 0)
                {
                    if (repositorio.Guardar(LlenaClase()))
                    {
                        CallModal("Se a registrado el Tipo del Ticket");
                        Limpiar();
                    }
                }
                else
                {
                    if (repositorio.Modificar(LlenaClase()))
                    {
                        CallModal("Se no se pudo registrar el Tipo del Ticket");
                        Limpiar();
                    }
                }
            }
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            TipoTicketRepositorio repositorio = new TipoTicketRepositorio();
            TipoTicket tipo = repositorio.Buscar(ToInt(TipoTicketIdTextBox.Text));

            if (tipo != null)
            {
                if (repositorio.Eliminar(ToInt(TipoTicketIdTextBox.Text)))
                {
                    CallModal("Se a eliminado el Tipo del Ticket");
                    Limpiar();
                }
                else
                    CallModal("Se no se pudo eliminar el Tipo del Ticket");
            }
        }
    }
}