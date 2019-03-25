<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormUsuario.aspx.cs" Inherits="WebProjectTickets.Registros.WebFormUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="text-center">
            <div class="col-md-12">
                <h1 class="page-header">Usuarios</h1>
            </div>
        </div>
    </div>
    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label1" runat="server" Text="Usuario ID"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox ID="UsuarioIdTextBox" placeholder="ID Usuario" runat="server"></asp:TextBox>
                <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" />
            </div>
        </div>
    </div>
    <br />

    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label2" runat="server" Text="Nombre Completo"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox ID="NombreTextBox" placeholder="Nombre Usuario" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />

    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox type="email" ID="EmailTextBox" placeholder="Direccion de Email" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />

    <div class="text-center">
        <div class="form-group">
            <div class="col-md-12">
                <asp:Label ID="Label4" runat="server" Text="Clave"></asp:Label>
            </div>
            <div class="col-md-6 col-xs-8">
                <asp:TextBox type="password" ID="ClaveTextBox" placeholder="Clave Usuario" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />

    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button ID="NuevoButton" class="btn btn-outline-primary" runat="server" Text="Nuevo" />
                <asp:Button ID="GuardarButton" class="btn btn-outline-success" runat="server" Text="Guardar" />
                <asp:Button ID="ElminarButton" class="btn btn-outline-dark" runat="server" Text="Elimar" />

            </div>
        </div>
    </div>

</asp:Content>
