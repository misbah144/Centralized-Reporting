<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Inv_By_FOF.aspx.cs" Inherits="MiSReports_Inv_By_FOF" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <rsweb:ReportViewer ID="rv_SND" runat="server" Font-Names="Verdana" ShowPrintButton="true"
        Font-Size="8pt" Width="100%" ProcessingMode="Remote" AsyncRendering="true"
        ShowToolBar="true" ShowParameterPrompts="true" ShowWaitControlCancelLink="false"
        SizeToReportContent="false">
    </rsweb:ReportViewer>
</asp:Content>