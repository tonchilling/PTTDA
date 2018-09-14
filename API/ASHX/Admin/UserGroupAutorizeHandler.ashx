<%@ WebHandler Language="C#" Class="UserGroupAutorizeHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Admin;
using DTO.Util;
using BAL.PTT.Admin;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
public class UserGroupAutorizeHandler : IHttpHandler
{


    USERGroupAutorizeBAL bal = null;
    List<USERGroupAutorizeDTO> grouplist = null;
    MenuDTO dto = null;
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
                    case "Search": grouplist = FindByCondition();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(grouplist);
                        context.Response.Write(jsonString);
                        break;

                    case "loadMemuGroup": grouplist = FindByCondition();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(grouplist);
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
        USERGroupAutorizeDTO[] userGroupAutorizeDTO = new JavaScriptSerializer().Deserialize<USERGroupAutorizeDTO[]>(context.Request.Form["objList"]);
       
      //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        USERGroupAutorizeBAL bal = new USERGroupAutorizeBAL();

        if (context.Request.Form["Action"].ToLower() == "add")
        {
         // dto.USERGroupAutorize_OID = context.Request.Form["selectUSERGroupAutorize"].ToString();
            result = bal.Add(userGroupAutorizeDTO);
        }
        else if (context.Request.Form["Action"].ToLower() == "delete")
        {
           // result = bal.Delete(dto);
        }
        return result;
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public List<USERGroupAutorizeDTO> FindByCondition()
    {
        bool result = false;
        List<USERGroupAutorizeDTO> userList = null;

        USERGroupAutorizeDTO dto = ConvertX.GetReqeustForm<USERGroupAutorizeDTO>();

        bal = new USERGroupAutorizeBAL();
         userList = bal.FindByObjList(dto);
        return userList;
    }


  
 
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}