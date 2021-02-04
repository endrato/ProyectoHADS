<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="HADS_IBER_EVAR.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
        <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
        <div>
            <asp:HyperLink ID="hlRegistro" runat="server">Registro</asp:HyperLink>
        </div>
        <asp:HyperLink ID="hlCambiarPassword" runat="server">Cambiar contraseña</asp:HyperLink>
    </form>
</body>
</html>
