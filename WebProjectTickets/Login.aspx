<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebProjectTickets.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"="sha384-wHAiFfRlMFy6i5SRaxvfOCifBUQy1xHdJ/yoi7FRNXMRBu5WHdZYu1hA6ZOblgut" ="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"="sha384-B0UglyR+jN6CkvvICOB2joaf5I4l3gm9GU6Hc1og6Ls7i6U/mkkaduKaBhlAXv9k" ="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="content/toastr.css" rel="stylesheet" />
    <script src="Scripts/toastr.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="/default.aspx">Inicio <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="perfil" data-toggle="dropdown">Perfil
                            </a>
                            <div class="dropdown-menu">
                              <asp:LoginStatus ID="Loginstatus" style="text-align: right;" runat="server" Visible="True" OnLoggingOut="Loginstatus_LoggingOut" />
                           </div>
                        </li>
                    </ul>
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
                    <asp:Button ID="ButtonLogon" runat="server" Text="Login" class="btn float-right login_btn" ValidationGroup="Entrar" OnClick="ButtonLogon_Click" />
                </div>
        </div>
        <div style="margin-top: 30px">
            <footer style="text-align: center">
                <hr />
                <p>&copy; <%: DateTime.Now.Year %>- Web Project Tickets</p>
            </footer>
        </div>
    </form>
</body>
</html>
