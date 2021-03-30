<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarTareasXML.aspx.cs" Inherits="HADS_IBER_EVAR.Profesor.Vadillo.ExportarTareasXML" %>

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
        .auto-style3 {
            width: 247px;
            height: 41px;
        }
        .auto-style4 {
            height: 41px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">PROFESOR<br />
            <asp:Label ID="Label2" runat="server" Text="EXPORTAR TAREAS GENÉRICAS"></asp:Label>
                </td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text=" Seleccionar asignatura a exportar"></asp:Label>
                    <br />
            <asp:DropDownList ID="dlAsignaturas" runat="server" DataSourceID="sqlTareasProf" DataTextField="codigo" AutoPostBack="True" OnSelectedIndexChanged="dlAsignaturas_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:SqlDataSource ID="sqlTareasProf" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-19ConnectionString %>" SelectCommand="SELECT Asignaturas.codigo FROM Usuarios CROSS JOIN Asignaturas WHERE (Usuarios.email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" DbType="String" />
                </SelectParameters>
            </asp:SqlDataSource>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Lista de tareas de la asignatura seleccionada"></asp:Label>
                    <asp:GridView ID="gvTareas" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnExportar" runat="server" Text="EXPORTAR" OnClick="btnImportar_Click" />
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
