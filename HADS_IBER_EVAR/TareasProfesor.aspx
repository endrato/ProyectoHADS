<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TareasProfesor.aspx.cs" Inherits="HADS_IBER_EVAR.WebForm4" %>

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
            <asp:Label ID="Label1" runat="server" Text="PROFESOR"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx">Cerrar sesión</asp:HyperLink>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="GESTIÓN DE TAREAS GENÉRICAS"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text=" Seleccionar asignatura"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="dlAsignaturas" runat="server" DataSourceID="sqlTareasProf" DataTextField="codigo">
            </asp:DropDownList>
            <asp:SqlDataSource ID="sqlTareasProf" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-19ConnectionString %>" SelectCommand="SELECT Asignaturas.codigo FROM Usuarios CROSS JOIN Asignaturas WHERE (Usuarios.email = @email)">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" DbType="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
            <p>
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar nueva tarea" OnClick="btnInsertar_Click" />
        </p>
            <p>
            <asp:GridView ID="gvTareasProf" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="sqlTareasProfTabla" OnSelectedIndexChanged="gvTareasProf_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                    <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig" />
                    <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas" />
                    <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion" />
                    <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea" />
                </Columns>
            </asp:GridView>
                <asp:SqlDataSource ID="sqlTareasProfTabla" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-19ConnectionString %>" SelectCommand="SELECT TareasGenericas.Codigo, TareasGenericas.Descripcion, TareasGenericas.CodAsig, TareasGenericas.HEstimadas, TareasGenericas.Explotacion, TareasGenericas.TipoTarea FROM TareasGenericas INNER JOIN Asignaturas ON TareasGenericas.CodAsig = Asignaturas.codigo WHERE (Asignaturas.codigo = @codasig)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dlAsignaturas" Name="codasig" PropertyName="SelectedValue" DbType="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
        </p>
        </div>
    </form>
</body>
</html>
