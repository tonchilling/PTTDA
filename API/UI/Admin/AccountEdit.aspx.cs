using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_Admin_AccountEdit : System.Web.UI.Page
{
    HiddenField hdnID = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        hdnID = (HiddenField)Page.Master.FindControl("antiforgery");



        if (!this.IsPostBack)
        {
            Guid antiforgeryToken = Guid.NewGuid();
            this.Session["AntiforgeryToken"] = antiforgeryToken;
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
    }
}