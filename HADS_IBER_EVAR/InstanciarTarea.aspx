<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="HADS_IBER_EVAR.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="ALUMNO"></asp:Label>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="INSTANCIAR TAREAS GENÉRICAS"></asp:Label>
        </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox ID="tbUsuario" runat="server"></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Tarea"></asp:Label>
                <asp:TextBox ID="tbTarea" runat="server"></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="Label5" runat="server" Text="Horas estimadas"></asp:Label>
                <asp:TextBox ID="tbHrsEst" runat="server"></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="Label6" runat="server" Text="Horas reales"></asp:Label>
                <asp:TextBox ID="tbHrsReal" runat="server"></asp:TextBox>
        </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Crear" />
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
        </p>
        </div>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server">Página anterior</asp:HyperLink>
        </p>
    </form>
</body>
</html>
