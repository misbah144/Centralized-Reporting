<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="TradeProcess.aspx.cs" Inherits="TradeProcess.MiSReports_TradeProcess" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 50%;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function callviewer(type) {

            var fund = document.getElementById('<%=ddl_fund.ClientID%>');
            var fund_id = fund.options[fund.selectedIndex].value;
            var fund_txt = fund.options[fund.selectedIndex].text;
            var date = document.getElementById('<%=txt_date.ClientID%>').value;

            '<%Session["startdate"] = "' + start_date + '"; %>';
            window.open("TradeProcess_Viewer.aspx?rptOption=html&SavepCode=0&FundID=" + fund_id + "&Date=" + date + "&FundName=" + fund_txt +"&type="+type);


        }
        function setHeightIfram() {
            document.getElementById('p_view').height = 10;
        }

        function getCurrDate()
        {
            var tdate = new Date().getDate();
            document.getElementById('<%=txt_date.ClientID%>').value = tdate;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <fieldset class="style1">
        <legend>Trade Process</legend>
        <table class="style1">
            <tr>
                <td>
                    <asp:Label ID="label1" runat="server" Text="Fund"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="label2" runat="server" Text="Date"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddl_fund" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txt_date" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="startdate" runat="server" TargetControlID="txt_date" Format="yyyy-MM-dd">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Button ID="btn_viewReport" runat="server" Text="View Report" OnClientClick="javascript:callviewer('pdf');" />
                </td>
                <td>
                    <asp:Button ID="btn_viewReportExcel" runat="server" Text="Export to Excel" OnClientClick="javascript:callviewer('excel');" />
                </td>
            </tr>
        </table>
    </fieldset> 
</asp:Content>
