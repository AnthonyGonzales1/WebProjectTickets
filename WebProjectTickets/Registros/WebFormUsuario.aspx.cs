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
    public partial class WebFormUsuario : System.Web.UI.Page
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

        private Usuario LlenaClase()
        {
            Usuario usuario = new Usuario();

            usuario.UsuarioId = Convert.ToInt32(UsuarioIdTextBox.Text);
            usuario.Nombres = NombreTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.Clave = ClaveTextBox.Text;

            return usuario;
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
                UsuarioIdTextBox.Text = usuario.UsuarioId.ToString();
                NombreTextBox.Text = usuario.Nombres;
                EmailTextBox.Text = usuario.Email;
                ClaveTextBox.Text = usuario.Clave;
            }
            else
                CallModal("Este Usuario no existe");

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
                        CallModal("Se guardo el Usuario");
                        Limpiar();

                    }
                }
                else
                {
                    if (rep.Modificar(LlenaClase()))
                    {
                        CallModal("Se modifico el Usuario");
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
                    CallModal("Se elimino el Usuario");
                    Limpiar();
                }
                else
                    CallModal("No se elimino el Usuario");
            }
        }
    }
}