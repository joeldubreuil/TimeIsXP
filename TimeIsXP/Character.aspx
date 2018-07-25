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
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <asp:Label ID="Label1" runat="server" Text="Character Sheet"></asp:Label>
            <br />
            <asp:Label ID="Label_Time" runat="server" Text="Time"></asp:Label>
            <telerik:RadSlider ID="RadSlider_Time" runat="server"></telerik:RadSlider>
            <br />
            <asp:Label ID="Label_Upkeep" runat="server" Text="Upkeep"></asp:Label>
            <telerik:RadSlider ID="RadSlider_Upkeep" runat="server"></telerik:RadSlider>
            <br />
            <asp:Label ID="Label_InvestedTime" runat="server" Text="InvestedTime"></asp:Label>
            <telerik:RadSlider ID="RadSlider_InvestedTime" runat="server"></telerik:RadSlider>
            <br />
            <br />
            <br />
            <asp:Label ID="Label_Detail_Upkeep" runat="server" Text="Detail_Upkeep"></asp:Label>
            <telerik:RadSlider ID="RadSlider_Detail_Upkeep" runat="server"></telerik:RadSlider>
            <br />
            <br />
            <br />
            <asp:Label ID="Label_Detail_InvestedTime" runat="server" Text="Detail_InvestedTime"></asp:Label>
            <telerik:RadSlider ID="RadSlider_Detail_InvestedTime" runat="server"></telerik:RadSlider>

        </div>
    </form>
</body>
</html>
