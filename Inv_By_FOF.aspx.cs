using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class MiSReports_Inv_By_FOF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] == null)
        {
            Response.Redirect("~/Account/login.aspx");
        }
        if (!IsPostBack)
        {
            // webservice.UseDefaultCredentials = true;
            string ReportPathNew = ConfigurationManager.AppSettings["Inv_By_FOF"].ToString(); ;
            //System.Net.NetworkCredential nc = new System.Net.NetworkCredential(_username, _password, _domain);
            String reportServerURL = ConfigurationManager.AppSettings["ReportServerUrl"].ToString();
            rv_SND.ServerReport.ReportServerUrl = new Uri(reportServerURL);
            rv_SND.ServerReport.ReportPath = ReportPathNew;

            //System.Net.NetworkCredential rvc = new System.Net.NetworkCredential();
            ReportViewerCredentials rvc = new ReportViewerCredentials();
            rvc.ReportServerUrl = rv_SND.ServerReport.ReportServerUrl;
            rv_SND.ServerReport.ReportServerCredentials = rvc;

        }
    }
}