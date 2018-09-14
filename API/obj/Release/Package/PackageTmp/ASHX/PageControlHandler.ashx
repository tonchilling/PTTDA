<%@ WebHandler Language="C#" Class="PageControlHandler" %>


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

public class PageControlHandler : IHttpHandler, IRequiresSessionState
{

    
    List<MenuDTO> list = null;
    static UserDTO UserLOGIN = null;
    public void ProcessRequest (HttpContext context) {

        string result = "";

        UserLOGIN = AppConfig.GetUserLogin();
        if (context.Request.Form.Count > 0)
        {
          switch (context.Request.Form["Action"])
                {
                    case "GetTopMenu": result = UserAutorize();
                        context.Response.Write(result);
                        break;
                    case "GetUserSession": result = GetUserSession();
                        context.Response.Write(result);
                        break;
        }
        }
    }

    public static string GetMenu()
    {
        string result = "";
        
        
        List<MenuDTO> menuList = null;
        MenuDTO menuDto = new MenuDTO();
        menuDto.ROW_STATE = "1";
        MenuBAL bal = null;
        JavaScriptSerializer json = null;

        bal = new MenuBAL();
        menuList = bal.FindByObjList(menuDto);
        json = new JavaScriptSerializer();
        result = json.Serialize(menuList);
        return result;

    }

    public static string UserAutorize()
    {
        string result = "";

        UserAndMenuAutorize dto = new UserAndMenuAutorize();
        List<MenuDTO> menuList = null;
        MenuDTO menuDto = new MenuDTO();
        menuDto.ROW_STATE = "1";
        menuDto.CREATE_BY = UserLOGIN.UserID;
          menuDto.CreateBy = UserLOGIN.UserID;
        MenuBAL bal = null;
        JavaScriptSerializer json = null;

        bal = new MenuBAL();
        menuList = bal.FindByObjLoginList(menuDto);
        dto.MenuAll = menuList;
        dto.UserLogin = (UserDTO)HttpContext.Current.Session["UserLogin"];
        json = new JavaScriptSerializer();
        result = json.Serialize(dto);
        return result;

    }

    public static string GetUserSession()
    {
        string result = "";
        UserDTO userLogin = null;
        
      
        JavaScriptSerializer json = null;

       

        if (HttpContext.Current.Session["UserLogin"] != null)
        {
            userLogin = (UserDTO)HttpContext.Current.Session["UserLogin"];
        }
        
        json = new JavaScriptSerializer();
        result = json.Serialize(userLogin);
        return result;

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}