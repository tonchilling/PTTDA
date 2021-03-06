﻿<%@ WebHandler Language="C#" Class="PTTUserInfoHandler" %>

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
public class PTTUserInfoHandler : IHttpHandler {
    
    
    List<PTTUserInfoDTO> list = null;
    
    PTTUserInfoDTO dto = null;
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
        dto = ConvertX.GetReqeustForm<PTTUserInfoDTO>();
       
      //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        PTTUserInfoBAL bal = new PTTUserInfoBAL();

        if (context.Request.Form["Action"].ToLower() == "add")
        {
         
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
    public List<PTTUserInfoDTO> FindByCondition()
    {
        bool result = false;
        List<PTTUserInfoDTO> userList = null;

        dto = ConvertX.GetReqeustForm<PTTUserInfoDTO>();

        PTTUserInfoBAL bal = new PTTUserInfoBAL();
        userList = bal.FindByObjList(dto);
        return userList;
    }


   
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}