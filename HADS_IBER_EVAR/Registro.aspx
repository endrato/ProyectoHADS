<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="HADS_IBER_EVAR.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 148px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>        
                <th>
                    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbApellidos" runat="server"></asp:TextBox>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label5" runat="server" Text="Repetir Password"></asp:Label>
                </th>
                <th class="auto-style1">
                    <asp:TextBox ID="tbRepPassword" runat="server"></asp:TextBox>
                </th>
            </tr>
            <tr>        
                <th>
                    <asp:Label ID="Label6" runat="server" Text="Rol"></asp:Label>
                </th>
                <th class="auto-style1">
                    <p>
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="rol" OnCheckedChanged="rbtnProfesor_CheckedChanged" Text="Profesor" />
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="rol" OnCheckedChanged="rbtnProfesor_CheckedChanged" Text="Alumno" />
        </p>
                </th>
            </tr>

        </table>
        
    </form>
</body>
</html>
