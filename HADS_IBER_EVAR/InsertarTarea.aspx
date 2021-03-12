<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="HADS_IBER_EVAR.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            PROFESOR<br />
            <asp:Label ID="Label2" runat="server" Text="GESTIÓN DE TAREAS GENÉRICAS"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Código"></asp:Label>
            <asp:TextBox ID="tbCodigo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Descripción"></asp:Label>
            <asp:TextBox ID="tbDescripcion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Asignatura"></asp:Label>
            <asp:DropDownList ID="dlAsignatura" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Horas estimadas"></asp:Label>
            <asp:TextBox ID="tbHrsEstimadas" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Tipo tarea"></asp:Label>
            <asp:DropDownList ID="dlTipo" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnAnadir" runat="server" Text="Añadir" />
            <br />
            <asp:HyperLink ID="hlVerTareas" runat="server">Ver tareas</asp:HyperLink>
        </div>
    </form>
</body>
</html>
