using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
public partial class Main : System.Web.UI.MasterPage
{
    private const string AntiXsrfTokenKey = "148DF7C0CF93F8474257778B167705E37969046F1D0F34056AC343BB78ADDF0F6A69DD511866D90F9230E3D2582F978F753087AC4B38CB173AF285EEF85C2B4C";
    private const string AntiXsrfUserNameKey = "PTTDirectAccess";
    private string _antiXsrfTokenValue;
    HiddenField hdnID = null;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["UserLogin"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
         hdnID = (HiddenField)Page.Master.FindControl("antiforgery");

        // Place page-specific code here.
        //  antiforgery = this.FindControl("antiforgery") as System.Web.UI.WebControls.HiddenField;

        if (!this.IsPostBack)
        {
            Guid antiforgeryToken = Guid.NewGuid();
            this.Session["AntiforgeryToken"] = antiforgeryToken;
          //  antiforgery = this.Master.FindControl("ContentPlaceHolder1").FindControl("antiforgery") as System.Web.UI.WebControls.HiddenField;
          

            if (hdnID != null)
                hdnID.Value = antiforgeryToken.ToString();


        }
        else
        {

            Guid stored = (Guid)this.Session["AntiforgeryToken"];
            Guid sent = new Guid(hdnID.Value);
            if (sent != stored)
            {
                throw new Exception("XSRF Attack Detected!");
            }

        }


        if (!InValidAccess())
        {
            this.Page.RegisterClientScriptBlock("Invalid Access", "<script>alert('Invalid Access')<script>");
            Response.Redirect(this.ResolveUrl("~/UI/Index.aspx"));

        }


    }



    public bool InValidAccess()
    {
        string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
        bool isCanAccess = true;
        List<string> restrictPage = new List<string>();

        restrictPage.Add("PlanActionSiteSurvey.aspx");
        restrictPage.Add("PlanActionSitePreparation.aspx");
        restrictPage.Add("PlanActionWeatherCollection.aspx");
        restrictPage.Add("PlanActionBeforeCoatingRemoval.aspx");
        restrictPage.Add("PlanActionAfterCoatingRemoval.aspx");
        restrictPage.Add("PlanActionAppliedCoating.aspx");
        restrictPage.Add("PlanActionAfterAppliedCoating.aspx");
        restrictPage.Add("PlanActionSiteRecovery.aspx");

        if (restrictPage.Find(mPage => mPage.ToLower().Equals(pageName.ToLower())) != null)
        {
            if (Request.QueryString["PID"] == null)
            {

                isCanAccess = false;
            }
            else if (Request.QueryString["PID"] == "")
            {
                isCanAccess = false;
            }
        }


        return isCanAccess;

    }

}
