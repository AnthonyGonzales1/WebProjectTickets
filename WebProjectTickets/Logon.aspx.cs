using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProjectTickets.Utilitarios;

namespace WebProjectTickets
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogonButton_Click(object sender, EventArgs e)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario user = new Usuario();

            if (repositorio.Verificar(UsuarioTextBox.Text, ClaveTextBox.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(user.Email, true);
            }
            else
            {
                Utils.ShowToastr(this.Page, "Email y/o Contraseña Incorrectas", "Fallido", "error");
            }
        }
    }
}