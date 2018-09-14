<%@ WebHandler Language="C#" Class="UserRoleAutorizeHandler" %>

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

public class UserRoleAutorizeHandler : IHttpHandler, IRequiresSessionState
{
    List<USERRoleAutorizeDTO> list = null;
    USERRoleAutorizeDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;
    string jsonString = "";
    public void ProcessRequest(HttpContext context)
    {


        context.Response.ContentType = "multipart/form-data";
        //  context.Response.Expires = -1;


        //  context.Response.Write(DateTime.Now.Ticks.ToString());

        if (context.Request.Form.Count > 0)
        {

            if (context.Request.Form["Action"] != null)
            {
                switch (context.Request.Form["Action"])
                {
                    case "Add":
                        json = new JavaScriptSerializer();


                        result = Action(context);
                        // list = FindByCondition();

                        // jsonString = json.Serialize(list);
                        context.Response.Write(result.ToString());
                        break;
                    case "Search":
                        json = new JavaScriptSerializer();


                        list = FindByCondition();

                        jsonString = json.Serialize(list);
                        context.Response.Write(jsonString);
                        break;




                }
            }
            else
            {

                if (context.Request.Form["Category"] != null)
                {


                    switch (context.Request.Form["Category"])
                    {
                        case "menu":
                            json = new JavaScriptSerializer();
                            List<MenuDTO> menuAll = GetAllMenu();
                            jsonString = json.Serialize(menuAll);
                            context.Response.Write(jsonString);
                            break;
                    }

                }


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
      
        
        //  dto = ConvertX.GetReqeustForm<UserPermissionDTO>();
        USERRoleAutorizeDTO[] list = new JavaScriptSerializer().Deserialize<USERRoleAutorizeDTO[]>(context.Request.Form["tags"]);
        USERRoleAutorizeBAL bal = new USERRoleAutorizeBAL();
        result = bal.Add(list);
        return result;
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public List<USERRoleAutorizeDTO> FindByCondition()
    {
        bool result = false;
        List<USERRoleAutorizeDTO> userList = null;

        dto = ConvertX.GetReqeustForm<USERRoleAutorizeDTO>();

        USERRoleAutorizeBAL bal = new USERRoleAutorizeBAL();
        userList = bal.FindByObjList(dto);
        return userList;
    }

    public List<MenuDTO> GetAllMenu()
    {
        return new MenuBAL().FindByObjList(new MenuDTO());
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}