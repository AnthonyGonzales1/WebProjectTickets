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
    public partial class WebFormCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        private Cliente LlenaClase()
        {
            return new Cliente(
                ToInt(ClienteIdTextBox.Text),
                NombresTextBox.Text,
                TelefonoTextBox.Text,
                int.Parse(DeudaTextBox.Text)
                );

        }

        private void Limpiar()
        {
            ClienteIdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DeudaTextBox.Text = string.Empty;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            Cliente cuentas = repositorio.Buscar(ToInt(ClienteIdTextBox.Text));
            if (cuentas != null)
            {
                NombresTextBox.Text = cuentas.Nombres;
                TelefonoTextBox.Text = cuentas.Telefono.ToString();
                DeudaTextBox.Text = cuentas.Deuda.ToString();
            }
            else
                CallModal("Esta cuenta no existe");

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                RepositorioBase<Cliente> rep = new RepositorioBase<Cliente>();

                if (ToInt(ClienteIdTextBox.Text) == 0)
                {
                    if (rep.Guardar(LlenaClase()))
                    {
                        CallModal("Se guardo la cuenta");
                        Limpiar();

                    }
                }
                else
                {
                    if (rep.Modificar(LlenaClase()))
                    {
                        CallModal("Se modifico la cuenta");
                        Limpiar();
                    }
                }
            }
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            ClientesRepositorio repositorio = new ClientesRepositorio();
            Cliente cliente = repositorio.Buscar(ToInt(ClienteIdTextBox.Text));

            if (cliente != null)
            {
                if (repositorio.Eliminar(ToInt(ClienteIdTextBox.Text)))
                {
                    CallModal("Se elimino la cuenta");
                    Limpiar();
                }
                else
                    CallModal("No se elimino la cuenta");
            }
        }
    }
}