<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmar.aspx.cs" Inherits="HADS_IBER_EVAR.Confirmar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
        <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Login" />
        <asp:HyperLink ID="hlRegistro" runat="server">¿No tienes cuenta? Registrarse</asp:HyperLink>
        <asp:HyperLink ID="hlCambiarPassword" runat="server">Cambiar contraseña</asp:HyperLink>
    </form>
</body>
</html>
