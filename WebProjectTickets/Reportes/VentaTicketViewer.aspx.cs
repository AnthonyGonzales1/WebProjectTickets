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
    public partial class VentaTicketViewer : System.Web.UI.Page
    {
        Expression<Func<VentaTicket, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.RepositorioBase<Cliente> repositorio = new BLL.RepositorioBase<Cliente>();
                VentaTicketReportViewer.ProcessingMode = ProcessingMode.Local;
                VentaTicketReportViewer.Reset();

                VentaTicketReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\VentaTicketReport.rdlc");
                VentaTicketReportViewer.LocalReport.DataSources.Clear();
                VentaTicketReportViewer.LocalReport.DataSources.Add(new ReportDataSource("VentaTickets", repositorio.GetList(x => true)));
                VentaTicketReportViewer.LocalReport.Refresh();

            }
        }
    }
}