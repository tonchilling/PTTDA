using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script;
using System.Web.Services;
using System.Web.Script.Serialization;
using DTO.PTT.Admin;
using BAL.PTT.Admin;
using System.Web.UI;


    public  class BasePage : System.Web.UI.Page
    {
    System.Web.UI.WebControls.HiddenField antiforgery = null;
        public BasePage()
        {
            this.Load += Page_LoadMain;
            //
            // TODO: Add constructor logic here
            //
        }



        protected  void Page_LoadMain(object sender, EventArgs e)
        {

        // Place page-specific code here.
        antiforgery = this.FindControl("antiforgery") as System.Web.UI.WebControls.HiddenField;

        if (!this.IsPostBack)
        {
            Guid antiforgeryToken = Guid.NewGuid();
            this.Session["AntiforgeryToken"] = antiforgeryToken;

            antiforgery = this.FindControl("antiforgery") as System.Web.UI.WebControls.HiddenField;

            if(antiforgery!=null)
            antiforgery.Value = antiforgeryToken.ToString();


        }
        else
        {

            Guid stored = (Guid)this.Session["AntiforgeryToken"];
            Guid sent = new Guid(antiforgery.Value);
            if (sent != stored)
            {
                throw new Exception("XSRF Attack Detected!");
            }

        }


        if (!InValidAccess())
            {
                this.RegisterClientScriptBlock("Invalid Access", "<script>alert('Invalid Access')<script>");
                Response.Redirect(this.ResolveUrl("~/UI/Index.aspx"));

            }

        }

    protected override void OnLoad(EventArgs e)
    {
        //your code
        // get data that's common to all implementors of FactsheetBase 
        // and store the values in FactsheetBase's properties 
     

        base.OnLoad(e);
    }

    protected override void OnInit(EventArgs e)
    {
       
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

        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();


            //Server.Transfer("~/mycustomerrorpage.aspx");
        }

        [WebMethod]

        public static string GetTopMenu()
        {
            string result = "";
            List<MenuDTO> menuList = null;
            MenuDTO menuDto = null;
            MenuBAL bal = null;
            JavaScriptSerializer json = null;

            bal = new MenuBAL();
            menuList = bal.FindByObjList(new MenuDTO());
            json = new JavaScriptSerializer();
            result = json.Serialize(menuList);
            return result;

        }
    }

