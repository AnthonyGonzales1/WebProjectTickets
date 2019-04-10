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
            <asp:TextBox type="number" ID="VentaTicketIdTextBox" CssClass="form-control" placeholder="Venta Ticket Id" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="[0-9]{1,9}(\.[0-9]{0,2})?$" ControlToValidate="VentaTicketIdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
            <asp:Button ID="BuscarButton" CssClass="btn btn-info" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label2" runat="server" Text="Fecha"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="FechaTextBox" type="date" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label6" runat="server" Text="Cliente"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:DropDownList type="button" class="form-control" ID="ClienteDropDownList" Width="170px" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label7" runat="server" Text="Ticket"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:DropDownList type="button" class="form-control" ID="TicketDropDownList" Width="170px" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label3" runat="server" Text="Cantidad Tickets"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="CantidadTextBox" type="number" AutoPostBack="true" CssClass="form-control" placeholder="Cantidad Ticket" runat="server" OnTextChanged="CantidadTextBox_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CantidadRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="CantidadTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="CantidadREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="CantidadTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label4" runat="server" Text="Precio Tickets"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="PrecioTextBox" AutoPostBack="true" placeholder="Precio" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PrecioRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="PrecioTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label5" runat="server" Text="Importe"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="ImporteTextBox" type="number" AutoPostBack="true" ReadOnly="true" placeholder="Importe" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ImporteRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="ImporteTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button ID="AgregarButton" class="btn btn-primary" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
            </div>
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="VentasGridView" OnPageIndexChanging="VentasGridView_PageIndexChanging" OnRowCommand="VentasGridView_RowCommand" class="table table-bordered table-hover table-striped table-responsive" runat="server" Height="213px" Width="542px">
            <Columns>
                <asp:TemplateField ShowHeader="False" HeaderText="Opciones">
                    <ItemTemplate>
                        <asp:Button ID="Remover" runat="server" CausesValidation="false" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).DataItemIndex %>"
                            Text="Remover" class="btn btn-danger btn-sm"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label8" runat="server" Text="Sub Total"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="SubTotalTextBox" type="number" placeholder="SubTotal" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="SubTotalRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="SubTotalTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label9" runat="server" Text="ITBIS%"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="ITBISTextBox" type="number" placeholder="ITBIS" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ItebisRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="ITBISTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="Label10" runat="server" Text="Total"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="TotalTextBox" type="number" placeholder="Total" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="TotalRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="TotalTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button ID="NuevoButton" class="btn btn-outline-primary" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                <asp:Button ID="GuardarButton" class="btn btn-outline-success" runat="server" Text="Guardar" ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="EliminarButton" class="btn btn-outline-dark" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />

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
