<%@ WebHandler Language="C#" Class="M_RegionHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Master;
using DTO.Util;
using DTO.PTT;
using BAL.PTT.Master;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class M_RegionHandler : IHttpHandler, IRequiresSessionState
{


    List<M_RegionDTO> list = null;
    List<Select2DTO> select2List = null;
    M_RegionDTO dto = null;
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

                    case "LoadSelect2": select2List = Select2ByCondition();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(select2List);
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
        dto = ConvertX.GetReqeustForm<M_RegionDTO>();

        //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        M_RegionBAL bal = new M_RegionBAL();

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
    public List<M_RegionDTO> FindByCondition()
    {
        bool result = false;
        List<M_RegionDTO> objList = null;

        dto = ConvertX.GetReqeustForm<M_RegionDTO>();

        M_RegionBAL bal = new M_RegionBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    public List<Select2DTO> Select2ByCondition()
    {
        bool result = false;
        List<Select2DTO> objList = null;

        dto = ConvertX.GetReqeustForm<M_RegionDTO>();

        M_RegionBAL bal = new M_RegionBAL();
        objList = bal.Select2ByObjList(dto);
        return objList;
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}