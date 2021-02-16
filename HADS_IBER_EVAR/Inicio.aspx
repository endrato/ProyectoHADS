<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="HADS_IBER_EVAR.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label2" runat="server" Text="INICIAR SESIÓN"></asp:Label>
        <br />
        Email<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbUsername" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail" ErrorMessage="Introduce un email válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="tbPassword" runat="server" OnTextChanged="tbPassword_TextChanged" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="tbPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <div>
            <asp:HyperLink ID="hlRegistro" runat="server" NavigateUrl="~/Registro.aspx">Registro</asp:HyperLink>
        <asp:HyperLink ID="hlCambiarPassword" runat="server" NavigateUrl="~/CambiarPassword.aspx">Cambiar contraseña</asp:HyperLink>
        </div>
        <p>
            <asp:Button ID="btnIniciar" runat="server" OnClick="Button1_Click" Text="Iniciar sesión" />
        </p>
    </form>
</body>
</html>
