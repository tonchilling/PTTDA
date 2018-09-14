<%@ WebHandler Language="C#" Class="T_Planing_WeatherCollectionHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Plan;
using DTO.Util;
using BAL.PTT.Plan;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using DTO.PTT.Admin;


public class T_Planing_WeatherCollectionHandler : IHttpHandler, IRequiresSessionState
{


    List<T_Planing_WeatherCollectionDTO> list = null;

    T_Planing_WeatherCollectionDTO dto = null;
    bool result = false;
    UserDTO userDto = null;
    JavaScriptSerializer json = null;
  
    string planPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"] + "/Action/WeatherCollection";
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "multipart/form-data";
        //  context.Response.Expires = -1;
        string jsonString = "";

        //  context.Response.Write(DateTime.Now.Ticks.ToString());

        if (context.Request.Form.Count > 0)
        {

            userDto = (UserDTO)HttpContext.Current.Session["UserLogin"];
            if (context.Request.Form["Action"] != null)
            {
                switch (context.Request.Form["Action"])
                {
                    case "Add": result = Action(context);
                        break;
                    case "Delete": result = Action(context);
                        break;


                    case "View": dto = View(context);
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(dto);
                        context.Response.Write(jsonString);
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
        dto = ConvertX.GetReqeustForm<T_Planing_WeatherCollectionDTO>();

      
        T_Planing_WeatherCollectionBAL bal = new T_Planing_WeatherCollectionBAL();

       
        
        if (context.Request.Form["Action"].ToLower() == "add")
        {

            dto.ID = "";
            dto.PID = "";

            dto.ID = context.Request.Form["ID"];
            dto.PID = context.Request.Form["PID"];
            dto.CreateBy = userDto.UserID;
            dto.UpdateBy = userDto.UserID;
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
    public List<T_Planing_WeatherCollectionDTO> FindByCondition()
    {
        bool result = false;
        List<T_Planing_WeatherCollectionDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_WeatherCollectionDTO>();
        dto.ID = "";
        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        T_Planing_WeatherCollectionBAL bal = new T_Planing_WeatherCollectionBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    public T_Planing_WeatherCollectionDTO View(HttpContext context)
    {
        bool result = false;
        List<T_Planing_WeatherCollectionDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_WeatherCollectionDTO>();
        dto.ID = context.Request.Form["ID"];
        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        T_Planing_WeatherCollectionBAL bal = new T_Planing_WeatherCollectionBAL();
        dto = bal.FindByPK(dto);
        return dto;
    }
    
    

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}