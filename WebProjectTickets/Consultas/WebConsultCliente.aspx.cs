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
    public partial class WebConsultCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
            ClienteReportViewer.ProcessingMode = ProcessingMode.Local;
            ClienteReportViewer.Reset();

            ClienteReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ClienteReport.rdlc");
            ClienteReportViewer.LocalReport.DataSources.Clear();
            ClienteReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Clientes", Utilitarios.Utils.clientes()));
            ClienteReportViewer.LocalReport.Refresh();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(BuscarTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            ClienteGridView.DataSource = Utilitarios.Utils.FiltrarCliente(index, BuscarTextBox.Text);
            ClienteGridView.DataBind();

            ModalLabel.Text = FiltroDropDownList.Text.ToString();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}