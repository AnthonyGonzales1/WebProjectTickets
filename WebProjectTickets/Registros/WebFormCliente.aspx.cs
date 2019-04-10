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
    public partial class WebFormCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
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

        private Cliente LlenaClase()
        {
            Cliente cliente = new Cliente();

            cliente.ClienteId = ToInt(ClienteIdTextBox.Text);
            cliente.Nombres = NombresTextBox.Text;
            cliente.Telefono = TelefonoTextBox.Text;
            cliente.Deuda = ToInt(DeudaTextBox.Text);

            return cliente;
        }

        private void Limpiar()
        {
            ClienteIdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            DeudaTextBox.Text = string.Empty;
        }

        private void LlenarCampos(Cliente cliente)
        {
            ClienteIdTextBox.Text = cliente.ClienteId.ToString();
            NombresTextBox.Text = cliente.Nombres;
            TelefonoTextBox.Text = cliente.Telefono;
            DeudaTextBox.Text = cliente.Deuda.ToString();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Cliente> repositorio = new RepositorioBase<Cliente>();
            Cliente cliente = repositorio.Buscar(ToInt(ClienteIdTextBox.Text));
            if (cliente != null)
            {
                LlenarCampos(cliente);
                Utils.ShowToastr(this.Page, "Busqueda exitosa", "Exito");

            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page,
                    "No se pudo encontrar",
                    "Error", "error");
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
                RepositorioBase<Cliente> rep = new RepositorioBase<Cliente>();

                if (ToInt(ClienteIdTextBox.Text) == 0)
                {
                    if (rep.Guardar(LlenaClase()))
                    {
                        Utils.ShowToastr(this.Page, "Guardado", "Exito", "success");
                        Limpiar();

                    }
                }
                else
                {
                    if (rep.Modificar(LlenaClase()))
                    {
                        Utils.ShowToastr(this.Page, "Modificado", "Exito", "success");
                        Limpiar();
                    }
                }
            }
            else
                Utils.ShowToastr(this.Page, "No se pudo guardar", "Error", "error");

        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            ClientesRepositorio repositorio = new ClientesRepositorio();
            Cliente cliente = repositorio.Buscar(ToInt(ClienteIdTextBox.Text));

            if (cliente != null)
            {
                if (repositorio.Eliminar(ToInt(ClienteIdTextBox.Text)))
                {
                    Utils.ShowToastr(this.Page, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this.Page, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this.Page, "No existe", "Error", "error");

        }
    }
}