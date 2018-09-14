<%@ WebHandler Language="C#" Class="T_PlanSpecPOHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Plan;
using DTO.PTT.Admin;
using DTO.Util;
using BAL.PTT.Plan;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using DTO.PTT;

public class T_PlanSpecPOHandler : IHttpHandler, IRequiresSessionState
{


    List<T_Planing_SpecPODTO> list = null;
    UserDTO UserLOGIN = null;
    T_Planing_SpecPODTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;

    List<ResponseDTO> responseList = null;
    public void ProcessRequest (HttpContext context) {

         UserLOGIN = AppConfig.GetUserLogin();
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
                    case "Add":

                        responseList = Validate(context);
                        if (responseList.Count == 0)
                        {
                            result = Action(context);
                        }
                        else {
                            json = new JavaScriptSerializer();
                            jsonString = json.Serialize(responseList);
                           
                          //  context.Response.StatusCode = 401;
                           // context.Response.Status = jsonString;
                            context.Response.Write(jsonString);
                            context.Response.End();
                            
                        }
                        break;
                    case "Delete": result = Action(context);
                        break;

                    case "UpdatePlan": result = Action(context);
                        break;

                    case "GetPlan": dto = GetPlanByCode();
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
        string startDate = "";
        string endDate = "";
        bool result = false;
        dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();

        dto.CreateBy = UserLOGIN.UserID;
        dto.UpdateBy = UserLOGIN.UserID;
        //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        T_Planing_SpecPOBAL bal = new T_Planing_SpecPOBAL();

        if (context.Request.Form["Action"].ToLower() == "add")
        {
            string currentDate=string.Format("{0}/{1}/{2}",DateTime.Now.Day.ToString("##00")
                                                         ,DateTime.Now.Month.ToString("##00")
                                                          ,DateTime.Now.Year.ToString("####0000"));
            startDate = dto.EventDate;
            endDate = dto.EventDate;
            
            if (dto.PlanType == "2") // spec
            {
                dto.SpecSDate = startDate;
                dto.SpecEDate = endDate;
            }
            else if (dto.PlanType == "3")  // PO
            {
                dto.POSDate = startDate;
                dto.POEDate = endDate;
            
            }
            else if (dto.PlanType == "4") // Action
            {
                dto.ActionSDate = startDate;
                dto.ActionEDate = endDate;
            }
        
            result = bal.Add(dto);
        }
        else if (context.Request.Form["Action"].ToLower() == "delete")
        {
            result = bal.Delete(dto);
        }
        else if (context.Request.Form["Action"] == "UpdatePlan")
        {
            result = bal.UpdateNewPlan(dto);
        }
        return result;
    }


    public List<ResponseDTO> Validate(HttpContext context)
    {
        DateTime activeDate = new DateTime();
        DateTime lastDate = new DateTime();
        DateTime lastSpecDate=new DateTime();
        DateTime lastPODate = new DateTime();
        DateTime lastActionDate = new DateTime();
        double lastComplete=0;
        
        T_Planing_SpecPOBAL bal = new T_Planing_SpecPOBAL();
        
        List<ResponseDTO> reponseList = new List<ResponseDTO>();
        T_Planing_SpecPODTO orgDto = null;
        ResponseDTO responseDto = null;

        dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();

        activeDate = ConvertX.ToDate(ConvertX.MMddYY(dto.EventDate));
      
        
        
        
     

        orgDto = bal.FindByCurrentStatus(dto);


        if (orgDto != null)
        {
            lastSpecDate = ConvertX.ToDate(orgDto.SpecEDate);
            lastPODate = ConvertX.ToDate(orgDto.POEDate);
            lastActionDate = ConvertX.ToDate(orgDto.ActionEDate);
            if (dto.PlanType == "2") // spec
            {
              
                lastDate = lastSpecDate;
                lastComplete = ConvertX.ToDouble(orgDto.SpecComplete);
            }
            else if (dto.PlanType == "3")  // PO
            {

              
                lastDate = lastPODate;
                lastComplete = ConvertX.ToDouble(orgDto.POComplete);
            }
            else if (dto.PlanType == "4") // Action
            {
              
                lastDate = lastActionDate;
                lastComplete = ConvertX.ToDouble(orgDto.ActionComplete);
            }

            if (activeDate <= lastDate)
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "Date more than " + string.Format("{0}/{1}/{2}", lastDate.Day, lastDate.Month, lastDate.Year) + "";
                responseDto.classElement = "txtEventDate";
                reponseList.Add(responseDto);
            
            }

            if (dto.PlanType == "3" && activeDate.Year <= lastSpecDate.Year && ConvertX.GetMonthWeekNumberOfYear(activeDate) <= ConvertX.GetMonthWeekNumberOfYear(lastSpecDate))
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "PO week more than Spec week (" + string.Format("{0}/{1}/{2}", lastSpecDate.Day, lastSpecDate.Month, lastSpecDate.Year) + ")";
                responseDto.classElement = "txtEventDate";
                reponseList.Add(responseDto);

            }

            if (dto.PlanType == "4" && activeDate.Year <= lastPODate.Year && ConvertX.GetMonthWeekNumberOfYear(activeDate) <= ConvertX.GetMonthWeekNumberOfYear(lastPODate))
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "Action week more than PO week (" + string.Format("{0}/{1}/{2}", lastPODate.Day, lastPODate.Month, lastPODate.Year) + ")";
                responseDto.classElement = "txtEventDate";
                reponseList.Add(responseDto);

            }


            if (dto.PlanType == "4" && activeDate.Year <= lastSpecDate.Year && ConvertX.GetMonthWeekNumberOfYear(activeDate) <= ConvertX.GetMonthWeekNumberOfYear(lastSpecDate))
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "Action week more than Spec week (" + string.Format("{0}/{1}/{2}", lastSpecDate.Day, lastSpecDate.Month, lastSpecDate.Year) + ")";
                responseDto.classElement = "txtEventDate";
                reponseList.Add(responseDto);

            }

            if (ConvertX.ToDouble(dto.Complete) < lastComplete)
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "Value more than " + lastComplete.ToString()+"";
                responseDto.classElement = "txtComplete";
                reponseList.Add(responseDto);

            }
               
        }
        

        return reponseList;
            
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public List<T_Planing_SpecPODTO> FindByCondition()
    {
        bool result = false;
        List<T_Planing_SpecPODTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();

        T_Planing_SpecPOBAL bal = new T_Planing_SpecPOBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    public T_Planing_SpecPODTO GetPlanByCode()
    {
        bool result = false;
        T_Planing_SpecPODTO obj = null;

        dto = ConvertX.GetReqeustForm<T_Planing_SpecPODTO>();

        T_Planing_SpecPOBAL bal = new T_Planing_SpecPOBAL();
        obj = bal.FindByObjHistory(dto);
        return obj;
    }

    

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}