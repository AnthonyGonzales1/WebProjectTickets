<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormUsuario.aspx.cs" Inherits="WebProjectTickets.Registros.WebFormUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="text-center">
            <div class="col-md-12">
                <h1 class="page-header">Usuarios</h1>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" Text="Usuario ID"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="UsuarioIdTextBox" CssClass="form-control" placeholder="ID Usuario" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="UsuarioIdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
            <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label2" runat="server" Text="Nombre Completo"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="NombreTextBox" CssClass="form-control" placeholder="Nombre Usuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NombreRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="NombreTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombreTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox type="email" ID="EmailTextBox" CssClass="form-control" placeholder="Direccion de Email" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="EmailRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="EmailTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label4" runat="server" Text="Clave"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox type="password" ID="ClaveTextBox" CssClass="form-control" placeholder="Clave Usuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ClaveRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="ClaveTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button ID="NuevoButton" class="btn btn-outline-primary" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                <asp:Button ID="GuardarButton" class="btn btn-outline-success" runat="server" Text="Guardar" ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="ElminarButton" class="btn btn-outline-dark" runat="server" Text="Elimar" OnClick="ElminarButton_Click" />

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
