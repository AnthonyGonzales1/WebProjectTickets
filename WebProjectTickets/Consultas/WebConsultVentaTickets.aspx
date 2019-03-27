<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebConsultVentaTickets.aspx.cs" Inherits="WebProjectTickets.Consultas.WebConsultVentaTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="text-center">
            <div class="col-md-12">
                <h1 class="page-header">Consulta Venta Ticket</h1>
            </div>
        </div>
    </div>
    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label1" runat="server" Text="Filtro"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:DropDownList type="button" class="btn btn-dark dropdown-toggle" ID="FiltroDropDownList" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server">
                    <asp:ListItem>Seleccionar...</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <br />
    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label2" runat="server" Text="Buscar"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox ID="BuscarTextBox" CssClass="form-control" placeholder="Buscar" runat="server"></asp:TextBox>
                <asp:LinkButton ID="BuscarLinkButton" runat="server" OnClick="BuscarLinkButton_Click">Buscar</asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label4" runat="server" Text="Desde">Desde:</asp:Label>
            <asp:TextBox ID="DesdeTextBox" CssClass="form-control" TextMode="Date" placeholder="Desde" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-2"></div>
        <div class="col-lg-4">
            <asp:Label ID="Label3" runat="server" Text="Hasta">Hasta:</asp:Label>
            <asp:TextBox ID="HastaTextBox" CssClass="form-control" TextMode="Date" placeholder="Hasta" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Label ID="ModalLabel" runat="server" Text="Modal"></asp:Label>
    <div class="text-center">
        <div class="form-group">
            <div class="table table-responsive col-md-12">
                <asp:GridView ID="ClienteGridView" class="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="False" runat="server" Height="67px">
                    <Columns>
                        <asp:BoundField DataField="UsuarioId" HeaderText="Usuario ID" />
                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Clave" HeaderText="Clave" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="card-footer">
        <div class="justify-content-start">
            <div class="col-md-6 col-xs-8">
                <div class="form-group" style="display: inline-block">
                    <asp:LinkButton ID="ImprimirLinkButton" data-toggle="modal" data-target=".bd-example-modal-lg"runat="server">LinkButton</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="LargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm" style="max-width: 600px!important; min-width: 300px!important">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal Report</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <rsweb:ReportViewer ID="VentaTicketReportViewer" runat="server" ProcessingMode="Remote" Height="400px" Width="500px">
                        <ServerReport ReportPath="" ReportServerUrl="" />
                    </rsweb:ReportViewer>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
