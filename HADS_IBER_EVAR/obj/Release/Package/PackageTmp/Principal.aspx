<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="HADS_IBER_EVAR.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 78px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
        <div>
            Sesión iniciada correctamente</div>
        <asp:SqlDataSource ID="sqlTipo" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-19ConnectionString %>" SelectCommand="SELECT [tipo] FROM [Usuarios] WHERE ([email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="email" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
