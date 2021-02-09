<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="HADS_IBER_EVAR.CambiarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="Image1" runat="server" />
        </div>
        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btnSolicitarCambio" runat="server" Text="Solicitar cambio de contraseña" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Pregunta:"></asp:Label>
            <asp:Label ID="lblPregunta" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Respuesta"></asp:Label>
            <asp:TextBox ID="tbRespuesta" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnModificar" runat="server" Text="Modificar contraseña" />
        </p>
    </form>
</body>
</html>
