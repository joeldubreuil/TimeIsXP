<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Character.aspx.cs" Inherits="TimeIsXP.Character" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Character Sheet"></asp:Label>
            <br />
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <telerik:RadSlider ID="RadSlider1" runat="server"></telerik:RadSlider>
        </div>
    </form>
</body>
</html>
