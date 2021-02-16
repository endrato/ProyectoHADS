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
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="CAMBIAR CONTRASEÑA"></asp:Label>
            <br />
            <asp:Image ID="Image1" runat="server" />
        </div>
        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail" ErrorMessage="Introduce un email válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
        <p>
            <asp:Button ID="btnSolicitarCambio" runat="server" Text="Solicitar cambio de contraseña" OnClick="btnSolicitarCambio_Click" />
        </p>
        <p>
            Introduce el código recibido en tu email:</p>
        <p>
            <asp:TextBox ID="tbRespuesta" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRespuesta" runat="server" ControlToValidate="tbRespuesta" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Button ID="btnConfirmarClave" runat="server" Text="Confirmar clave" OnClick="btnModificar_Click" />
            <asp:Label ID="lblFeedback" runat="server"></asp:Label>
        </p>
        <p>
                    <asp:Label ID="Label6" runat="server" Text="Password" Visible="False"></asp:Label>
                    <asp:TextBox ID="tbPassword" runat="server" Height="22px" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="tbPassword" ErrorMessage="*" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
                </p>
        <p>
                    <asp:Label ID="Label5" runat="server" Text="Repetir Password" Visible="False"></asp:Label>
                    <asp:TextBox ID="tbRepPassword" runat="server" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRePass" runat="server" ControlToValidate="tbRepPassword" ErrorMessage="*" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvPass" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbRepPassword" ErrorMessage="Las contraseñas difieren" ForeColor="Red" Visible="False"></asp:CompareValidator>
        </p>
        <p>
            <asp:Button ID="btnModificarContraseña" runat="server" Text="Modificar contraseña" OnClick="btnModificarContraseña_Click" Visible="False" />
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
