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
    public partial class WebFormTipoTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<TipoTicket> repositorio = new RepositorioBase<TipoTicket>();
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
            FechaTextBox.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
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
                LugarTextBox.Text,
                DateTime.Parse(FechaTextBox.Text)
                );
        }

        private void LlenarCampos(TipoTicket tipoTicket)
        {
            TipoTicketIdTextBox.Text = tipoTicket.TipoTicketId.ToString();
            DescripcionTextBox.Text = tipoTicket.Descripcion;
            LugarTextBox.Text = tipoTicket.Lugar;
            FechaTextBox.Text = tipoTicket.Fecha.ToString("yyyy-MM-dd");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoTicket> repositorio = new RepositorioBase<TipoTicket>();
            TipoTicket tipoTicket = repositorio.Buscar(ToInt(TipoTicketIdTextBox.Text));
            if (tipoTicket != null)
            {
                Utils.ShowToastr(this.Page, "Guardado", "Exito", "success");
                LlenarCampos(tipoTicket);
            }
            else
            {
                Utils.ShowToastr(this.Page, "Id no existe", "Error", "error");
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
                RepositorioBase<TipoTicket> repositorio = new RepositorioBase<TipoTicket>();

                if (ToInt(TipoTicketIdTextBox.Text) == 0)
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
            TipoTicketRepositorio repositorio = new TipoTicketRepositorio();
            TipoTicket tipo = repositorio.Buscar(ToInt(TipoTicketIdTextBox.Text));

            if (tipo != null)
            {
                if (repositorio.Eliminar(ToInt(TipoTicketIdTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No existe", "Error", "error");
            }
        }
    }
}