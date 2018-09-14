using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO.PTT.Admin;
using System.Web.Script.Serialization;
using System.Web.Security;
public partial class Login : System.Web.UI.Page
{
    List<DefectLevel1> level1List = new List<DefectLevel1>();
    DefectLevel1 level1 = null;
    List<DefectLevel2> level2List = new List<DefectLevel2>();
    DefectLevel2 level2 = null;
    List<DefectLevel3> level3List = new List<DefectLevel3>();
    DefectLevel3 level3 = null;
    JavaScriptSerializer json = null;

    HiddenField hdnID = null;
    private const string AntiXsrfTokenKey = "148DF7C0CF93F8474257778B167705E37969046F1D0F34056AC343BB78ADDF0F6A69DD511866D90F9230E3D2582F978F753087AC4B38CB173AF285EEF85C2B4C";
    private const string AntiXsrfUserNameKey = "PTTDirectAccess";
    private string _antiXsrfTokenValue;


    protected void Page_Load(object sender, EventArgs e)
    {


        hdnID = (HiddenField)this.FindControl("antiforgery");



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


    protected void Page_Init(object sender, EventArgs e)
    {
        // The code below helps to protect against XSRF attacks
       /* var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;*/
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }


    protected List<DefectLevel2> loadDefectLevel2(string level1ID)
    {
        level2List = new List<DefectLevel2>();


            level2 = new DefectLevel2();
            level2.Id = "L21";
            level2.Level1ID = "L1";
            level2.defectLevel3List = loadDefectLevel3(level2.Id);
            level2List.Add(level2);

            return level2List;

    
    }

    protected List<DefectLevel3> loadDefectLevel3(string level2ID)
    {
        level3List = new List<DefectLevel3> ();

        level3 = new DefectLevel3();
        level3.Id="L31";
          level3.Name="Level 3 1";
        level3.LevelID="L21";

          level3List.Add(level3);

          level3 = new DefectLevel3();
          level3.Id = "L32";
          level3.Name = "Level 3 2";
          level3.LevelID = "L21";

          level3List.Add(level3);



          return level3List;


    }

}