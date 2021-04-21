<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="HADS_IBER_EVAR.WebForm5" %>

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
        <div>
            <asp:Label ID="Label1" runat="server" Text="ALUMNO"></asp:Label>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="INSTANCIAR TAREAS GENÉRICAS"></asp:Label>
        </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox ID="tbUsuario" runat="server" ReadOnly="True"></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="Label4" runat="server" Text="Tarea"></asp:Label>
                <asp:TextBox ID="tbTarea" runat="server" ReadOnly="True"></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="Label5" runat="server" Text="Horas estimadas"></asp:Label>
                <asp:TextBox ID="tbHrsEst" runat="server" ReadOnly="True"></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="Label6" runat="server" Text="Horas reales"></asp:Label>
                <asp:TextBox ID="tbHrsReal" runat="server"></asp:TextBox>
        </p>
            <div class="form-row">
                <div runat="server" class="alert alert-danger" role="alert" id="formatoHoras" visible="false">
                    &nbsp;Introduce un número válido para las horas.
                </div>

                <div runat="server" class="alert alert-danger" role="alert" id="ErrorRegistro" visible="false">
                    Error insertando la tarea.
                </div>

                <div runat="server" class="alert alert-success" role="alert" id="Correcto" visible="false">
                    Tarea insertada correctamente.
                </div>
                <div runat="server" class="alert alert-danger" role="alert" id="TareaRepeAlerta" visible="false">
                    La tarea ya existe.
        </div>
    </div>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Crear" OnClick="Button1_Click" />
                <asp:GridView ID="gvTareas" runat="server">
                </asp:GridView>
        </p>
        </div>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TareasAlumno.aspx">Página anterior</asp:HyperLink>
        </p>
    </form>
</body>
</html>
