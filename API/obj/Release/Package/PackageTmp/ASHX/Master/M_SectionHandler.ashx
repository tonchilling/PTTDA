<%@ WebHandler Language="C#" Class="M_SectionHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Master;
using DTO.Util;
using BAL.PTT.Master;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using DTO.PTT.Admin;
public class M_SectionHandler : IHttpHandler, IRequiresSessionState
{

    List<M_SectionDTO> list = null;
    UserDTO UserLOGIN = null;
    M_SectionDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;


    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "multipart/form-data";
        //  context.Response.Expires = -1;
        string jsonString = "";
        UserLOGIN = AppConfig.GetUserLogin();
        //  context.Response.Write(DateTime.Now.Ticks.ToString());

        if (context.Request.Form.Count > 0)
        {

            if (context.Request.Form["Action"] != null)
            {
                switch (context.Request.Form["Action"])
                {
                    case "Add": result = Action(context);
                        break;
                    case "Delete": result = Action(context);
                        break;
                    case "Search": list = FindByCondition();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(list);
                        context.Response.Write(jsonString);
                        break;

                            ///Search by RouteCodeName and KP
                    case "FindByRouteCode": dto = FindByRouteCodeName();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(dto);
                        context.Response.Write(jsonString);
                        break;




                }
            }
            else
            {



            }
        }
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public bool Action(HttpContext context)
    {
        bool result = false;
        dto = ConvertX.GetReqeustForm<M_SectionDTO>();

        //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        M_SectionBAL bal = new M_SectionBAL();

        if (context.Request.Form["Action"].ToLower() == "add")
        {
            //  dto.MENUGROUP_OID = context.Request.Form["selectMENUGROUP"].ToString();
            result = bal.Add(dto);
        }
        else if (context.Request.Form["Action"].ToLower() == "delete")
        {
            result = bal.Delete(dto);
        }
        return result;
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public List<M_SectionDTO> FindByCondition()
    {
        bool result = false;
        List<M_SectionDTO> objList = null;

        dto = ConvertX.GetReqeustForm<M_SectionDTO>();
        dto.CreateBy = UserLOGIN.UserID;
        M_SectionBAL bal = new M_SectionBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }



    public M_SectionDTO FindByRouteCodeName()
    {
        bool result = false;
        M_SectionDTO obj = null;

        dto = ConvertX.GetReqeustForm<M_SectionDTO>();
        dto.CreateBy = UserLOGIN.UserID;
        M_SectionBAL bal = new M_SectionBAL();
        obj = bal.FinByRouteCodeName(dto);
        return obj;
    }




    public bool IsReusable {
        get {
            return false;
        }
    }

}