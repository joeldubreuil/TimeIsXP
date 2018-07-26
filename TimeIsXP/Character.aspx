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
            <asp:Label ID="Label_Upkeep_Detail_100" runat="server" Text="Upkeep_Detail"></asp:Label>
            <telerik:RadSlider ID="RadSlider_Upkeep_Detail_100" runat="server"></telerik:RadSlider>
            <br />
            <div class="Sliders_Upkeep_Detail">
                <asp:Label ID="Label_Upkeep_Detail_Skill_1" runat="server" Text="Upkeep_Detail_Skill_1"></asp:Label>
                <telerik:RadSlider ID="RadSlider_Upkeep_Detail_Skill_1" runat="server"></telerik:RadSlider>
                <asp:Label ID="Label_Upkeep_Detail_Skill_2" runat="server" Text="Upkeep_Detail_Skill_2"></asp:Label>
                <telerik:RadSlider ID="RadSlider_Upkeep_Detail_Skill_2" runat="server"></telerik:RadSlider>
                <asp:Label ID="Label_Upkeep_Detail_Skill_3" runat="server" Text="Upkeep_Detail_Skill_3"></asp:Label>
                <telerik:RadSlider ID="RadSlider_Upkeep_Detail_Skill_3" runat="server"></telerik:RadSlider>
            </div>
            <br />
            <br />
            <br />
            <asp:Label ID="Label_InvestedTime_Detail_100" runat="server" Text="InvestedTime_Detail"></asp:Label>
            <telerik:RadSlider ID="RadSlider_InvestedTime_Detail_100" runat="server"></telerik:RadSlider>
            <br />
            <div class="Sliders_InvestedTime_Detail">
                <asp:Label ID="Label_InvestedTime_Detail_Skill_1" runat="server" Text="InvestedTime_Detail_Skill_1"></asp:Label>
                <telerik:RadSlider ID="RadSlider_InvestedTime_Detail_Skill_1" runat="server"></telerik:RadSlider>
                <asp:Label ID="Label_InvestedTime_Detail_Skill_2" runat="server" Text="InvestedTime_Detail_Skill_2"></asp:Label>
                <telerik:RadSlider ID="RadSlider_InvestedTime_Detail_Skill_2" runat="server"></telerik:RadSlider>
                <asp:Label ID="Label_InvestedTime_Detail_Skill_3" runat="server" Text="InvestedTime_Detail_Skill_3"></asp:Label>
                <telerik:RadSlider ID="RadSlider_InvestedTime_Detail_Skill_3" runat="server"></telerik:RadSlider>
            </div>

        </div>
    </form>
</body>
</html>
