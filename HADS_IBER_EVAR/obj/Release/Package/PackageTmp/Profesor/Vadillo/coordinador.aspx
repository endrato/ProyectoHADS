<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="coordinador.aspx.cs" Inherits="HADS_IBER_EVAR.Profesor.Vadillo.coordinador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label2" runat="server" Text="COORDINADOR DE TAREAS GENÉRICAS"></asp:Label>
        </div>
                    <asp:DropDownList ID="dlAsignaturas" runat="server" AutoPostBack="True" DataSourceID="sqlTareasProf" DataTextField="codigo">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sqlTareasProf" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-19ConnectionString %>" SelectCommand="SELECT Asignaturas.codigo FROM Usuarios CROSS JOIN Asignaturas WHERE (Usuarios.email = @email)">
                        <SelectParameters>
                            <asp:SessionParameter DbType="String" Name="email" SessionField="email" />
                        </SelectParameters>
                    </asp:SqlDataSource>
            <br />
        <asp:Button ID="btnMedia" runat="server" OnClick="btnMedia_Click" style="height: 26px" Text="Obtener dedicación media" />
        <br />
        <br />
        <asp:Label ID="lblMedia" runat="server"></asp:Label>
    </form>
</body></html>
