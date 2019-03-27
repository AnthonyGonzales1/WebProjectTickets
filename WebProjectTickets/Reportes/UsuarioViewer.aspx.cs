using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectTickets.Reportes
{
    public partial class UsuarioViewer : System.Web.UI.Page
    {
        Expression<Func<Usuario, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.RepositorioBase<Cliente> repositorio = new BLL.RepositorioBase<Cliente>();
                UsuarioReportViewer.ProcessingMode = ProcessingMode.Local;
                UsuarioReportViewer.Reset();

                UsuarioReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\UsuarioReport.rdlc");
                UsuarioReportViewer.LocalReport.DataSources.Clear();
                UsuarioReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", repositorio.GetList(x => true)));
                UsuarioReportViewer.LocalReport.Refresh();

            }
        }
    }
}