<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormCliente.aspx.cs" Inherits="WebProjectTickets.Registros.WebFormCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="text-center">
            <div class="col-md-12">
                <h1 class="page-header">Clientes</h1>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label2" runat="server" Text="Cliente ID"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="ClienteIdTextBox" CssClass="form-control" placeholder="ID Cliente" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="ClienteIdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
            <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" Text="Nombres"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="NombresTextBox" CssClass="form-control" placeholder="Nombre Cliente" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NombreRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="NombresTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombresTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label3" runat="server" Text="Telefono"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="TelefonoTextBox" CssClass="form-control" placeholder="Telefono Cliente" MaxLength="10" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="TelefonoRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="TelefonoTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="TelefonoREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="TelefonoTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label4" runat="server" Text="Deuda"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="DeudaTextBox" ReadOnly="true" CssClass="form-control" placeholder="Deuda" runat="server"></asp:TextBox>
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
    <div class="col-md-12">
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <div style="margin-top: 30px">
        <footer style="text-align: center">
            <hr />
            <p>&copy; <%: DateTime.Now.Year %>- Web Project Tickets 2019</p>
        </footer>
    </div>

</asp:Content>
