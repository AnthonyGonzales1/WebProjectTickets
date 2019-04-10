<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormTickets.aspx.cs" Inherits="WebProjectTickets.Registros.WebFormTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="text-center">
            <div class="col-md-12">
                <h1 class="page-header">Tickets</h1>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" Text="Ticket ID"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="TicketIdTextBox" CssClass="form-control" placeholder="ID Ticket" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="TicketIdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
            <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label2" runat="server" Text="Tipo Ticket"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:DropDownList type="button" class="form-control" ID="TipoTicketDropDownList" Width="170px" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label3" runat="server" Text="Nombre Evento"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="NombreEventoTextBox" CssClass="form-control" placeholder="Nombre del Evento" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NombreRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="NombreEventoTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombreEventoTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label4" runat="server" Text="Cantidad Tickets"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="CantidaTextBox" CssClass="form-control" placeholder="Cantidad" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CantidadRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="CantidaTextBox" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="CantidadREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="CantidaTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label5" runat="server" Text="Precio Ticket"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="PrecioTextBox" CssClass="form-control" placeholder="Precio Ticket" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PrecioRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="PrecioTextBox" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="PrecioREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="PrecioTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button ID="NuevoButton" class="btn btn-outline-primary" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                <asp:Button ID="GuardarButton" class="btn btn-outline-success" runat="server" Text="Guardar" ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="ElminarButton" class="btn btn-outline-dark" runat="server" Text="Eliminar" OnClick="ElminarButton_Click" />
            </div>
        </div>
    </div>
    <div style="margin-top: 30px">
        <footer style="text-align: center">
            <hr />
            <p>&copy; <%: DateTime.Now.Year %>- Web Project Tickets 2019</p>
        </footer>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" />

</asp:Content>
