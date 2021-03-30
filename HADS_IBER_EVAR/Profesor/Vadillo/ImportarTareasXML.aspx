<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarTareasXML.aspx.cs" Inherits="HADS_IBER_EVAR.ImportarTareasXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 247px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">PROFESOR<br />
            <asp:Label ID="Label2" runat="server" Text="IMPORTAR TAREAS GENÉRICAS"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text=" Seleccionar asignatura a importar"></asp:Label>
                    <br />
            <asp:DropDownList ID="dlAsignaturas" runat="server" DataSourceID="sqlTareasProf" DataTextField="codigo" AutoPostBack="True" OnSelectedIndexChanged="dlAsignaturas_SelectedIndexChanged1">
            </asp:DropDownList>
            <asp:SqlDataSource ID="sqlTareasProf" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-19ConnectionString %>" SelectCommand="SELECT Asignaturas.codigo FROM Usuarios CROSS JOIN Asignaturas WHERE (Usuarios.email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" DbType="String" />
                </SelectParameters>
            </asp:SqlDataSource>
                </td>
                <td>
                    <asp:Xml ID="xmlTareas" runat="server"></asp:Xml>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnImportar" runat="server" Text="IMPORTAR" OnClick="btnImportar_Click" />
                    <br />
                    <asp:Label ID="lblFeedback" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor/Profesor.aspx">Menu Profesor</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
