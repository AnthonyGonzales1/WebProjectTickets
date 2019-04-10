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
    public partial class WebFormUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
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

        private Usuario LlenaClase()
        {
            Usuario usuario = new Usuario();

            usuario.UsuarioId = ToInt(UsuarioIdTextBox.Text);
            usuario.Nombres = NombreTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Clave = ClaveTextBox.Text;

            return usuario;
        }

        private void LlenarCampos(Usuario usuario)
        {
            UsuarioIdTextBox.Text = usuario.UsuarioId.ToString();
            NombreTextBox.Text = usuario.Nombres;
            EmailTextBox.Text = usuario.Email;
            ClaveTextBox.Text = usuario.Clave;
        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Usuario usuario = repositorio.Buscar(ToInt(UsuarioIdTextBox.Text));
            if (usuario != null)
            {
                LlenarCampos(usuario);
                Utils.ShowToastr(this.Page, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "No se pudo encontrar el Préstamo especificado", "Error", "error");
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
                RepositorioBase<Usuario> rep = new RepositorioBase<Usuario>();

                if (ToInt(UsuarioIdTextBox.Text) == 0)
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
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            Usuario usuario = repositorio.Buscar(ToInt(UsuarioIdTextBox.Text));

            if (usuario != null)
            {
                if (repositorio.Eliminar(ToInt(UsuarioIdTextBox.Text)))
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