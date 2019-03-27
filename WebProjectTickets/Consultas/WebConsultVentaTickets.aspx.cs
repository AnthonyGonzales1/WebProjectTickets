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
    public partial class WebConsultVentaTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ModalReport();
            }

        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        public void ModalReport()
        {
            VentaTicketReportViewer.ProcessingMode = ProcessingMode.Local;
            VentaTicketReportViewer.Reset();

            VentaTicketReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\VentaTicketReport.rdlc");
            VentaTicketReportViewer.LocalReport.DataSources.Clear();
            VentaTicketReportViewer.LocalReport.DataSources.Add(new ReportDataSource("VentaTickets", Utilitarios.Utils.ventaTickets()));
            VentaTicketReportViewer.LocalReport.Refresh();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(BuscarTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
            ClienteGridView.DataSource = Utilitarios.Utils.FiltrarVenta(index, BuscarTextBox.Text, desde, hasta);
            ClienteGridView.DataBind();

            ModalLabel.Text = FiltroDropDownList.Text.ToString();

        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/ViewerCuentas.aspx");
        }
    }
}