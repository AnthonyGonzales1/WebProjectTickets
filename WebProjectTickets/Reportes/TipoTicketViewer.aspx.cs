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
    public partial class TipoTicketViewer : System.Web.UI.Page
    {
        Expression<Func<TipoTicket, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.RepositorioBase<Cliente> repositorio = new BLL.RepositorioBase<Cliente>();
                TipoTicketReportViewer.ProcessingMode = ProcessingMode.Local;
                TipoTicketReportViewer.Reset();

                TipoTicketReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\TipoTicketsReport.rdlc");
                TipoTicketReportViewer.LocalReport.DataSources.Clear();
                TipoTicketReportViewer.LocalReport.DataSources.Add(new ReportDataSource("TipoTickets", repositorio.GetList(x => true)));
                TipoTicketReportViewer.LocalReport.Refresh();

            }
        }
    }
}