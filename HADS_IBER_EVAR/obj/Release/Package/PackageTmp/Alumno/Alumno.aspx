<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="HADS_IBER_EVAR.Alumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar sesión</asp:HyperLink>
        </p>
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Alumno/TareasAlumno.aspx">Tareas genéricas</asp:HyperLink>
        </div>
    </form>
</body>
</html>
