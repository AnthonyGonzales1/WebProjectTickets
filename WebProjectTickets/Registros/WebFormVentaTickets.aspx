<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormVentaTickets.aspx.cs" Inherits="WebProjectTickets.Registros.WebFormVentaTickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="text-center">
            <div class="col-md-12">
                <h1 class="page-header">Venta Tickets</h1>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" Text="Venta Ticket ID"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="VentaTicketIdTextBox" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="FechaTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label6" runat="server" Text="Cliente"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:DropDownList type="button" class="btn btn-dark dropdown-toggle" ID="ClienteDropDownList" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server">
                <asp:ListItem>Seleccionar...</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label7" runat="server" Text="Ticket"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:DropDownList type="button" class="btn btn-dark dropdown-toggle" ID="TicketDropDownList" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" runat="server">
                <asp:ListItem>Seleccionar...</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label3" runat="server" Text="Cantidad Tickets"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="CantidadTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label4" runat="server" Text="Precio Tickets"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="PrecioTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label5" runat="server" Text="Importe"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="ImporteTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button ID="AgregarButton" class="btn btn-primary" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                <asp:Button ID="RemoverButton" class="btn btn-danger" runat="server" Text="Remover" OnClick="RemoverButton_Click" />
            </div>
        </div>
    </div>

    <div class="text-center">
        <div class="form-group">
            <div class="table table-responsive col-md-12">
                <asp:GridView ID="VentasGridView" class="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="False" runat="server" Height="67px">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="VentaTicketId" HeaderText="Venta Ticket ID" />
                        <asp:BoundField DataField="ClienteId" HeaderText="Cliente ID" />
                        <asp:BoundField DataField="TicketId" HeaderText="Ticket ID" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="Importe" HeaderText="Importe" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label8" runat="server" Text="Sub Total"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="SubTotalTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label9" runat="server" Text="ITBIS%"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="ITBISTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label10" runat="server" Text="Total"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="TotalTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button ID="NuevoButton" class="btn btn-outline-primary" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                <asp:Button ID="GuardarButton" class="btn btn-outline-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="EliminarButton" class="btn btn-outline-dark" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />

            </div>
        </div>
    </div>
</asp:Content>
