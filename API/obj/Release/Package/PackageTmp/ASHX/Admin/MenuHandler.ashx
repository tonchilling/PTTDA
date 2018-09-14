<%@ WebHandler Language="C#" Class="MenuHandler" %>

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
public class MenuHandler : IHttpHandler {
    
    
    List<MenuDTO> list = null;
    List<MenuGroupDTO> grouplist = null;
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
                    case "Search": list = FindByCondition();
                        json = new JavaScriptSerializer();
                         jsonString = json.Serialize(list);
                        context.Response.Write(jsonString);
                        break;

                    case "loadMemuGroup": grouplist = FindMenuGroup();
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
        dto = ConvertX.GetReqeustForm<MenuDTO>();
       
      //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        MenuBAL bal = new MenuBAL();

        if (context.Request.Form["Action"].ToLower() == "add")
        {
            dto.MENUGROUP_OID = context.Request.Form["selectMENUGROUP"].ToString();
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
    public List<MenuDTO> FindByCondition()
    {
        bool result = false;
        List<MenuDTO> userList = null;

        dto = ConvertX.GetReqeustForm<MenuDTO>();

        MenuBAL bal = new MenuBAL();
        userList = bal.FindByObjList(dto);
        return userList;
    }


    public List<MenuGroupDTO> FindMenuGroup()
    {
        bool result = false;
        List<MenuGroupDTO> objList = null;

        MenuGroupDTO mgDto = ConvertX.GetReqeustForm<MenuGroupDTO>();

        MenuBAL bal = new MenuBAL();
        objList = bal.FindMenuGroupAll(mgDto);
        return objList;
    }
 
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}