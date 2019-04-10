using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebProjectTickets.Utilitarios;

namespace WebProjectTickets.Consultas
{
    public partial class WebConsultTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ModalReport();
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        public void ModalReport()
        {
            TicketReportViewer.ProcessingMode = ProcessingMode.Local;
            TicketReportViewer.Reset();

            TicketReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\TicketReport.rdlc");
            TicketReportViewer.LocalReport.DataSources.Clear();
            TicketReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Tickets", Utilitarios.Utils.tickets()));
            TicketReportViewer.LocalReport.Refresh();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(BuscarTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            TicketGridView.DataSource = Utilitarios.Utils.FiltrarTicket(index, BuscarTextBox.Text);
            TicketGridView.DataBind();

            ModalLabel.Text = FiltroDropDownList.Text.ToString();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}