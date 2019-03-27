<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebConsultVentaTickets.aspx.cs" Inherits="WebProjectTickets.Consultas.WebConsultVentaTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="col-md-6 col-xs-8">
        <asp:LinkButton ID="ImprimirLinkButton" runat="server" OnClick="ImprimirLinkButton_Click">Imprimir</asp:LinkButton>
    </div>
    <br />
</asp:Content>
