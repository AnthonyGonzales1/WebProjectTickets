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
    public partial class ClienteViewer : System.Web.UI.Page
    {
        Expression<Func<Cliente, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.RepositorioBase<Cliente> repositorio = new BLL.RepositorioBase<Cliente>();
                ClienteReportViewer.ProcessingMode = ProcessingMode.Local;
                ClienteReportViewer.Reset();

                ClienteReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ClienteReport.rdlc");
                ClienteReportViewer.LocalReport.DataSources.Clear();
                ClienteReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Clientes", repositorio.GetList(x => true)));
                ClienteReportViewer.LocalReport.Refresh();

            }
        }
    }
}