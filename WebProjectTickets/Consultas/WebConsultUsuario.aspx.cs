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
    public partial class WebConsultUsuario : System.Web.UI.Page
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
            UsuarioReportViewer.ProcessingMode = ProcessingMode.Local;
            UsuarioReportViewer.Reset();

            UsuarioReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\UsuarioReport.rdlc");
            UsuarioReportViewer.LocalReport.DataSources.Clear();
            UsuarioReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuario", Utilitarios.Utils.usuarios()));
            UsuarioReportViewer.LocalReport.Refresh();
        }

        protected void BuscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(BuscarTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            UsuarioGridView.DataSource = Utilitarios.Utils.FiltrarUsuario(index, BuscarTextBox.Text);
            UsuarioGridView.DataBind();

            ModalLabel.Text = FiltroDropDownList.Text.ToString();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}