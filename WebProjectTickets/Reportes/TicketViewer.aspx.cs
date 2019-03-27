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
    public partial class TicketViewer : System.Web.UI.Page
    {
        Expression<Func<Ticket, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.RepositorioBase<Cliente> repositorio = new BLL.RepositorioBase<Cliente>();
                TicketReportViewer.ProcessingMode = ProcessingMode.Local;
                TicketReportViewer.Reset();

                TicketReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\TicketsReport.rdlc");
                TicketReportViewer.LocalReport.DataSources.Clear();
                TicketReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Tickets", repositorio.GetList(x => true)));
                TicketReportViewer.LocalReport.Refresh();

            }
        }
    }
}