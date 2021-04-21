<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="HADS_IBER_EVAR.Profesor.Profesor" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar sesión</asp:HyperLink>
        </p>
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesor/TareasProfesor.aspx">Tareas</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Profesor/Vadillo/ImportarTareasXML.aspx">ImportarXML</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Profesor/Vadillo/ExportarTareasXML.aspx">ExportarXML</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Profesor/Vadillo/coordinador.aspx">Media tareas</asp:HyperLink>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <div runat="server" id="contProfesores" visible="false">
                     <h2>Profesores Conectados: <asp:Label runat="server" ID="numProf"/></h2>
                </div>
                <asp:ListView runat="server" ID="profesoresListView" OnSelectedIndexChanged="profesoresListView_SelectedIndexChanged">
                    <LayoutTemplate>

                        <ul class="list-group">
                            <li id="itemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li class="list-group-item"><%#: Eval("EmailList") %></li>
                    </ItemTemplate>
                </asp:ListView>


                 <div runat="server" id="contAlumnos" visible="false">
                     <h2>Alumnos Conectados: <asp:Label runat="server" ID="numAlums"/></h2>
                </div>
                <asp:ListView runat="server" ID="alumnosListView">
                    <LayoutTemplate>
                        <ul class="list-group">
                            <li id="itemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li class="list-group-item"><%#: Eval("EmailList") %></li>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
        </asp:Timer>
    </form>
</body>
</html>
