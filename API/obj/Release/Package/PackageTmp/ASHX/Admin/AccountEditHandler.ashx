<%@ WebHandler Language="C#" Class="AccountEditHandler" %>

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
using BAL.PTT.Util;

public class AccountEditHandler : IHttpHandler, IRequiresSessionState
{
    List<UserDTO> list = null;
    List<UserRoleDTO> userRoleList = null;
    UserDTO dto = null;

    UserDTO tempDTO = null;

    bool result = false;
    JavaScriptSerializer json = null;
    string jsonString = "";
    PTTLDap lDap=null;
    string[] userTypeName={"PTT","PTT","PTT","Other"};
    string EncryptKey = System.Configuration.ConfigurationSettings.AppSettings["EncryptKey"];

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
                    case "Add": result = Action(context);
                        break;
                    case "SetUserGroup": result = SetDefaultUerGroup(context);

                        break;
                    case "Search": list = FindByCondition();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(list);
                        context.Response.Write(jsonString);
                        break;

                    case "Login":


                        lDap=new PTTLDap();
                        tempDTO=ConvertX.GetReqeustForm<UserDTO>();
                        bool isAutorize = true;
                        tempDTO.LDAP = true;
                        if (tempDTO.UserType == "0" || tempDTO.UserType == "1" || tempDTO.UserType == "2")
                        {
                            tempDTO.LDAP = lDap.Authenticated(userTypeName[ConvertX.ToInt(tempDTO.UserType)], tempDTO.UserLogin, tempDTO.Password);
                        }
                        //bool isAutorize = true;
                        if (isAutorize && tempDTO.LDAP)
                        {
                            dto = FindByLogin();
                            dto.LDAP = tempDTO.LDAP;
                            json = new JavaScriptSerializer();
                            jsonString = json.Serialize(dto);
                        } else if (!tempDTO.LDAP){
                            dto = new UserDTO();
                            dto.LDAP = tempDTO.LDAP;
                        }
                        if (dto != null)
                        {
                            CreateUserSession(dto);
                            context.Response.Write(jsonString);
                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            context.Response.StatusDescription = "Invalid user";
                        }
                        break;


                    case "VIEW": list = FindByCondition();
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


    public void CreateUserSession(UserDTO userLogin)
    {
        if (HttpContext.Current.Session["UserLogin"] != null)
        {
            HttpContext.Current.Session.Remove("UserLogin");
        }
        HttpContext.Current.Session.Add("UserLogin", userLogin);
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public bool Action(HttpContext context)
    {
        bool result = false;
        dto = ConvertX.GetReqeustForm<UserDTO>();
        if (dto.Password != "")
        {
            dto.Password = DTO.Util.DEncrypt.encrypt(dto.Password, EncryptKey);
        }
        dto.Position = context.Request.Form["selectPosition"].ToString();
        dto.PositionPSI = context.Request.Form["txtPositionPSI"].ToString();
        UserBAL bal = new UserBAL();
        result = bal.Add(dto);
        return result;
    }


    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public bool SetDefaultUerGroup(HttpContext context)
    {
        bool result = false;
        dto = ConvertX.GetReqeustForm<UserDTO>();

        UserBAL bal = new UserBAL();
        result = bal.SetDefaultUerGroup(dto);
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
        userList = bal.FindByObjList(dto);
        return userList;
    }

    public UserDTO FindByLogin()
    {
        bool result = false;
        UserDTO loginDTO = null;

        dto = ConvertX.GetReqeustForm<UserDTO>();
        dto.Password = DTO.Util.DEncrypt.encrypt(dto.Password, EncryptKey);
        UserBAL bal = new UserBAL();
        loginDTO = bal.UserLogin(dto);
        return loginDTO;
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