<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="HADS_IBER_EVAR.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 334px;
        }
        .auto-style2 {
            height: 30px;
        }
        .auto-style3 {
            width: 334px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label7" runat="server" Text="REGISTRO"></asp:Label>
        <table>
            <tr>        
                <th>
                    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="tbNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbApellidos" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellidos" runat="server" ControlToValidate="tbApellidos" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbPassword" runat="server" Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="tbPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>        
                <th class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Repetir Password"></asp:Label>
                </th>
                <th class="auto-style3">
                    <asp:TextBox ID="tbRepPassword" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRePass" runat="server" ControlToValidate="tbRepPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label6" runat="server" Text="Rol"></asp:Label>
                </th>
                <th class="auto-style1">
                    <p>
            <asp:RadioButton ID="rbtnProf" runat="server" GroupName="rol" OnCheckedChanged="rbtnProfesor_CheckedChanged" Text="Profesor" />
            <asp:RadioButton ID="rbtnAlum" runat="server" GroupName="rol" OnCheckedChanged="rbtnProfesor_CheckedChanged" Text="Alumno" Checked="True" />
        </p>
                </th>
            </tr>

        </table>
        
        <p>
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
        </p>
        <p>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail" ErrorMessage="Introduce un email válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
        </p>
        <p>
            <asp:CompareValidator ID="cvPass" runat="server" ControlToCompare="tbPassword" ControlToValidate="tbRepPassword" ErrorMessage="Las contraseñas difieren" ForeColor="Red"></asp:CompareValidator>
        </p>
        <p>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbPassword" ErrorMessage="La contraseña debe tener al menos 6 caracteres" ValidationExpression="^[\s\S]{6,}$" ForeColor="Red"></asp:RegularExpressionValidator>
        </p>
        
    </form>
</body>
</html>
