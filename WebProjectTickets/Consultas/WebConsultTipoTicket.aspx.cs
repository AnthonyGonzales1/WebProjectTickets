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
    public partial class WebConsultTipoTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            TipoTicketReportViewer.ProcessingMode = ProcessingMode.Local;
            TipoTicketReportViewer.Reset();

            TipoTicketReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\TipoTicketReport.rdlc");
            TipoTicketReportViewer.LocalReport.DataSources.Clear();
            TipoTicketReportViewer.LocalReport.DataSources.Add(new ReportDataSource("TipoTicket", Utilitarios.Utils.tipoTickets()));
            TipoTicketReportViewer.LocalReport.Refresh();
        }
        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(BuscarTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
            ClienteGridView.DataSource = Utilitarios.Utils.FiltrarTipo(index, BuscarTextBox.Text, desde, hasta);
            ClienteGridView.DataBind();

            ModalLabel.Text = FiltroDropDownList.Text.ToString();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}