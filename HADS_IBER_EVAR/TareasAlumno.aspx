<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="HADS_IBER_EVAR.TareasAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ALUMNO"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Cerrar sesión</asp:HyperLink>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="GESTIÓN DE TAREAS GENÉRICAS"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text=" Seleccionar asignatura (sólo se muestran en las que estas matriculado)"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:GridView ID="gvTareasAlum" runat="server">
            </asp:GridView>
        </p>
    </form>
</body>
</html>
