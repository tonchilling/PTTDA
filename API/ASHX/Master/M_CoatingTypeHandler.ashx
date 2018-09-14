<%@ WebHandler Language="C#" Class="M_CoatingTypeHandler" %>

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


public class M_CoatingTypeHandler : IHttpHandler, IRequiresSessionState {


    List<M_CoatingTypeDTO> list = null;

    M_CoatingTypeDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;
    UserDTO UserLOGIN = null;
    
    public void ProcessRequest (HttpContext context) {

        UserLOGIN = AppConfig.GetUserLogin();
        context.Response.ContentType = "multipart/form-data";
        //  context.Response.Expires = -1;
        string jsonString = "";

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
        dto = ConvertX.GetReqeustForm<M_CoatingTypeDTO>();

        //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        M_CoatingTypeBAL bal = new M_CoatingTypeBAL();

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
    public List<M_CoatingTypeDTO> FindByCondition()
    {
        bool result = false;
        List<M_CoatingTypeDTO> objList = null;

        dto = ConvertX.GetReqeustForm<M_CoatingTypeDTO>();
        dto.CreateBy = UserLOGIN.UserID;
        M_CoatingTypeBAL bal = new M_CoatingTypeBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}