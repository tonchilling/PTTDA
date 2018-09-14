<%@ WebHandler Language="C#" Class="M_CustomerTypeHandler" %>

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

public class M_CustomerTypeHandler :IHttpHandler, IRequiresSessionState{


    List<M_CustomerTypeDTO> list = null;

    M_CustomerTypeDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;  
    
    
    public void ProcessRequest (HttpContext context) {
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
        dto = ConvertX.GetReqeustForm<M_CustomerTypeDTO>();

        //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        M_CustomerTypeBAL bal = new M_CustomerTypeBAL();

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
    public List<M_CustomerTypeDTO> FindByCondition()
    {
        bool result = false;
        List<M_CustomerTypeDTO> objList = null;

        dto = ConvertX.GetReqeustForm<M_CustomerTypeDTO>();

        M_CustomerTypeBAL bal = new M_CustomerTypeBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}