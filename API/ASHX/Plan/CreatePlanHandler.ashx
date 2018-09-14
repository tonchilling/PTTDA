<%@ WebHandler Language="C#" Class="CreatePlanHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Master;
using DTO.Util;
using DTO.PTT.Plan;
using DTO.PTT.Admin;
using BAL.PTT.Plan;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using DTO.PTT.Plan;
using DTO.PTT;

public class CreatePlanHandler : IHttpHandler, IRequiresSessionState
{


    List<T_PlaningDTO> list = null;
    UserDTO UserLOGIN = null;
    T_PlaningDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;
          List<ResponseDTO> responseList = null;
    string planPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "multipart/form-data";
        //  context.Response.Expires = -1;
        string jsonString = "";

        //  context.Response.Write(DateTime.Now.Ticks.ToString());

        UserLOGIN = AppConfig.GetUserLogin();
        if (context.Request.Form.Count > 0)
        {

            if (context.Request.Form["Action"] != null)
            {
                switch (context.Request.Form["Action"].ToLower())
                {
                    case "add":

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
                    case "delete": result = Action(context);
                        break;
                    case "edit": dto = FindByPK();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(dto);
                        context.Response.Write(jsonString);
                        break;
                    case "timeline": dto = FindByPK();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(dto);
                        context.Response.Write(jsonString);
                        break;
                    case "search": list = FindByCondition();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(list);
                        context.Response.Write(jsonString);
                        break;

                             case "GetGPS":
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
        List<T_Planing_File> fileList = new List<T_Planing_File>();
        T_Planing_File file = null;
        dto = ConvertX.GetReqeustForm<T_PlaningDTO>();


        dto.CreateBy = UserLOGIN.UserID;
        dto.UpdateBy = UserLOGIN.UserID;

        //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        T_PlaningBAL bal = new T_PlaningBAL();

        if (context.Request.Form["Action"].ToLower() == "add")
        {


            if (context.Request.Files.Count > 0)
            {
                int no=1;
                for (var i = 0; i < context.Request.Files.Count;i++ )
                {
                    string Path = planPath;
                    string savedFileName = context.Server.MapPath(planPath) + @"\" + System.IO.Path.GetFileName(context.Request.Files[i].FileName);

                    file = new T_Planing_File();
                    file.FullPath = savedFileName;
                    file.FileName = System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                    file.FileSize = context.Request.Files[i].ContentLength.ToString();
                    file.UploadDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year);
                    file.No = no.ToString();
                    file.PID = "";
                    file.PostFile = context.Request.Files[i];
                    no++;

                    fileList.Add(file);
                    //  context.Request.Files[0].SaveAs(savedFileName);
                }
                dto.UploadFileList = fileList;
            }

            result = bal.Add(dto);

            if (result)
            {

                // For new upload
                if (fileList != null && fileList.Count > 0)
                {
                    foreach (T_Planing_File f in fileList)
                    {
                        file.DesPath = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\";

                        if (DTO.PTT.Util.FileMng.HaveDirectory(f.DesPath))
                        {
                            f.FullPath = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + System.IO.Path.GetFileName(f.PostFile.FileName);
                            f.PostFile.SaveAs(f.FullPath);
                        }
                    }

                }

                // For delete old file
                if (dto.DeleteFileNames != null && dto.DeleteFileNames.Length > 0)
                {
                    foreach (var fileName in dto.DeleteFileNames.Split(','))
                    {
                        var realDesFile = context.Server.MapPath(planPath) + @"\" + fileName;
                        DTO.PTT.Util.FileMng.DeleteFile(realDesFile);
                    }

                }

            }


            //  dto.MENUGROUP_OID = context.Request.Form["selectMENUGROUP"].ToString();

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
    public List<T_PlaningDTO> FindByCondition()
    {
        bool result = false;
        List<T_PlaningDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_PlaningDTO>();

        T_PlaningBAL bal = new T_PlaningBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }


    public T_PlaningDTO FindByPK()
    {
        bool result = false;
        T_PlaningDTO obj = null;

        dto = ConvertX.GetReqeustForm<T_PlaningDTO>();

        T_PlaningBAL bal = new T_PlaningBAL();
        obj = bal.FindByPK(dto);

        if (obj != null && obj.UploadFileList != null)
        {

            foreach (var uploadFile in obj.UploadFileList)
            {
                uploadFile.HtmlFile = System.Web.VirtualPathUtility.ToAbsolute(planPath + "/" + dto.PID + "/" + uploadFile.FileName);
            }

        }

        return obj;
    }



    public bool IsReusable {
        get {
            return false;
        }
    }



    public List<ResponseDTO> Validate(HttpContext context)
    {
        DateTime activeDate = new DateTime();
        DateTime lastDate = new DateTime();
        DateTime startSpecDate=new DateTime();
        DateTime startPODate = new DateTime();
        DateTime startActionDate = new DateTime();

        DateTime lastSpecDate=new DateTime();
        DateTime lastPODate = new DateTime();
        DateTime lastActionDate = new DateTime();

        double lastComplete=0;

        T_Planing_SpecPOBAL bal = new T_Planing_SpecPOBAL();

        List<ResponseDTO> reponseList = new List<ResponseDTO>();
        T_PlaningDTO orgDto = null;
        ResponseDTO responseDto = null;

        dto = ConvertX.GetReqeustForm<T_PlaningDTO>();








        if (dto != null)
        {
            startSpecDate = ConvertX.ToDate( ConvertX.MMddYY(dto.SpecSDate));
            startPODate = ConvertX.ToDate( ConvertX.MMddYY(dto.POSDate));
            startActionDate = ConvertX.ToDate( ConvertX.MMddYY(dto.ActionSDate));


            lastSpecDate = ConvertX.ToDate( ConvertX.MMddYY(dto.SpecEDate));
            lastPODate = ConvertX.ToDate( ConvertX.MMddYY(dto.POEDate));
            lastActionDate = ConvertX.ToDate( ConvertX.MMddYY(dto.ActionEDate));


            if (ConvertX.GetMonthWeekNumberOfYear(startPODate  ) <= ConvertX.GetMonthWeekNumberOfYear(startSpecDate)
                || ConvertX.GetMonthWeekNumberOfYear(lastPODate) <= ConvertX.GetMonthWeekNumberOfYear(lastSpecDate))
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "- PO date or week more than Spec date or week.";
                responseDto.classElement = "PO";
                reponseList.Add(responseDto);

            }

            if (ConvertX.GetMonthWeekNumberOfYear(startActionDate) <= ConvertX.GetMonthWeekNumberOfYear(startPODate)
               || ConvertX.GetMonthWeekNumberOfYear(lastActionDate) <= ConvertX.GetMonthWeekNumberOfYear(lastPODate))
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "- Action date or week more than PO date or week.";
                responseDto.classElement = "Action";
                reponseList.Add(responseDto);

            }


             if (ConvertX.GetMonthWeekNumberOfYear(startActionDate  ) <= ConvertX.GetMonthWeekNumberOfYear(startSpecDate)
                || ConvertX.GetMonthWeekNumberOfYear(lastActionDate) <= ConvertX.GetMonthWeekNumberOfYear(lastSpecDate))
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "- Action date or week  more than Spec date or week  ";
                responseDto.classElement = "Action";
                reponseList.Add(responseDto);



            }


            if (lastSpecDate < startSpecDate)
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                responseDto.text = "- Spec EndDate more than StartDate ";
                responseDto.classElement = "Spec";
                reponseList.Add(responseDto);

            }

            if (lastPODate <= startPODate)
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
               responseDto.text = "- PO EndDate more than StartDate ";
                responseDto.classElement = "PO";
                reponseList.Add(responseDto);

            }


            if (lastActionDate <= startActionDate)
            {
                responseDto = new ResponseDTO();
                responseDto.status = false;
                 responseDto.text = "- Action EndDate more than StartDate ";
                responseDto.classElement = "Action";
                reponseList.Add(responseDto);

            }


        }


        return reponseList;

    }

}