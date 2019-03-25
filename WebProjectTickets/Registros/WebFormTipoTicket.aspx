<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormTipoTicket.aspx.cs" Inherits="WebProjectTickets.Registros.WebFormTipoTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="text-center">
            <div class="col-md-12">
                <h1 class="page-header">Tipo Tickets</h1>
            </div>
        </div>
    </div>
    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label2" runat="server" Text="Tipo Ticket ID"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox ID="TipoTicketIdTextBox" CssClass="form-control" placeholder="ID Tipo Ticket" runat="server"></asp:TextBox>
                <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" />
            </div>
        </div>
    </div>
    <br />
    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label1" runat="server" Text="Descripcion Evento"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox ID="DescripcionTextBox" CssClass="form-control" placeholder="Descripcion Ticket" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />
    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label3" runat="server" Text="Lugar Evento"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox ID="LugarTextBox" CssClass="form-control" placeholder="Lugar Evento" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />
    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label4" runat="server" Text="Fecha Evento"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox ID="FechaTextBox" type="Date" CssClass="form-control" placeholder="Fecha Evento" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button ID="NuevoButton" class="btn btn-outline-primary" runat="server" Text="Button" />
                <asp:Button ID="GuardarButton" class="btn btn-outline-success" runat="server" Text="Button" />
                <asp:Button ID="ElminarButton" class="btn btn-outline-dark" runat="server" Text="Button" />
            </div>
        </div>
    </div>
</asp:Content>
