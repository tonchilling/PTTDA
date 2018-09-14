<%@ WebHandler Language="C#" Class="AccountListHandler" %>

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

public class AccountListHandler : IHttpHandler, IRequiresSessionState
{
    List<UserDTO> list = null;
    List<UserRoleDTO> userRoleList = null;
    UserDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;
         UserDTO UserLOGIN = null;
    string jsonString = "";
    public void ProcessRequest(HttpContext context)
    {

              UserLOGIN = AppConfig.GetUserLogin();
        context.Response.ContentType = "multipart/form-data";
        //  context.Response.Expires = -1;


        //  context.Response.Write(DateTime.Now.Ticks.ToString());

        if (context.Request.Form.Count > 0)
        {

            if (context.Request.Form["Action"] != null)
            {
                switch (context.Request.Form["Action"])
                {
                    case "Add": result = Action(context);

                        break;
                               case "Delete": result = Delete(context);
                        break;
                    case "Search": list = FindByCondition();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(list);
                        context.Response.Write(jsonString);
                        break;
                    case "loadUserRole": userRoleList = FindUserRole();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(userRoleList);
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
        dto = ConvertX.GetReqeustForm<UserDTO>();
        dto.Position = context.Request.Form["selectPositionPSI"].ToString();
        dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        UserBAL bal = new UserBAL();
        result = bal.Add(dto);
        return result;
    }


                 /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public bool Delete(HttpContext context)
    {
        bool result = false;
        dto = ConvertX.GetReqeustForm<UserDTO>();

        UserBAL bal = new UserBAL();
      result=  bal.Delete(dto);
      return result;
    }



    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public List<UserDTO> FindByCondition()
    {
        bool result = false;
        List<UserDTO> userList = null;

        dto = ConvertX.GetReqeustForm<UserDTO>();

        UserBAL bal = new UserBAL();
       dto.CreateBy = UserLOGIN.UserID;
        userList = bal.FindByObjList(dto);
        return userList;
    }


    public List<UserRoleDTO> FindUserRole()
    {
        bool result = false;
        List<UserRoleDTO> userRoleList = null;

        UserRoleDTO searchDto = ConvertX.GetReqeustForm<UserRoleDTO>();

        UserRoleBAL bal = new UserRoleBAL();
        userRoleList = bal.FindByObjList(searchDto);
        return userRoleList;
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}