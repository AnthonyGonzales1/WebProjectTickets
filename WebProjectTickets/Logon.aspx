<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="WebProjectTickets.Logon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" d-flex justify-content-center h-100">
        <div class="panel-body ">
            <div class="card  " style="width: 250px">
                <div class="card-header ">
                    <asp:Label ID="Label1" runat="server" Text="Iniciar Ses&iacute;on" Font-Size="XX-Large"></asp:Label>
                </div>
                <div class="card-body">
                    <div class="input-group form-group">
                        <span class="col-2 form-control"><i class="fas fa-user"></i></span>
                        <asp:TextBox class="form-control" ID="UsuarioTextBox" placeholder="Usuario" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Digite su Usuario" ControlToValidate="UsuarioTextBox" ValidationGroup="Entrar" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class=" input-group   form-group">
                        <span class=" col-2 form-control "><i class="fas fa-key"></i></span>
                        <asp:TextBox placeholder="Contraseña" class="form-control" ID="ClaveTextBox" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Digite su Contraseña" ControlToValidate="ClaveTextBox" ValidationGroup="Entrar" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="LogonButton" runat="server" Text="Login" class="btn float-right login_btn" ValidationGroup="Entrar" OnClick="LogonButton_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div style="margin-top: 30px">
            <footer style="text-align: center">
                <hr />
                <p>&copy; <%: DateTime.Now.Year %>- Web Project Tickets</p>
            </footer>
        </div>
    </div>
</asp:Content>
