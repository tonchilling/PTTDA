<%@ WebHandler Language="C#" Class="T_PlaningHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Master;
using DTO.PTT.Plan;
using DTO.PTT.Report;
using DTO.Util;
using DTO.PTT.Admin;
using BAL.PTT.Plan;
using API;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public  class T_PlaningHandler : IHttpHandler, IRequiresSessionState
{


    List<T_PlaningDTO> list = null;

    T_PlaningDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;
    string jsonString = "";
    UserDTO UserLOGIN = null;

    public void ProcessRequest (HttpContext context) {

        UserLOGIN = AppConfig.GetUserLogin();
        // context.Response.ContentType = "multipart/form-data";
        context.Response.ContentType = "text/plain";
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
                    case "AddReview": result = Action(context);
                        break;
                    case "Draft": result = DraftToSession(context);
                        break;

                    case "ClearPlan": result = Action(context);
                        break;


                    case "Delete": result = Action(context);
                        break;




                    case "Search": list = FindByCondition();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(list);
                        context.Response.Write(jsonString);
                        break;

                    case "View": list = FindByConditionV2();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(list);
                        context.Response.Write(jsonString);
                        break;


                    case "GetProgressPlan":
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(GetProgressPlan());
                        context.Response.Write(jsonString);
                        break;

                    case "GetCaptionPlan":
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(GetCaptionPlan());
                        context.Response.Write(jsonString);
                        break;




                }
            }
            else
            {



            }
        }
    }







    void PlanSessionManaging(HttpContext context, T_PlaningDTO dto)
    {
        if (context.Session["TPlan"] != null)
        {
            context.Session.Remove("TPlan");
        }


        context.Session.Add("TPlan", dto);

    }


    public bool DraftToSession(HttpContext context)
    {
        bool result = false;



        string tabNumber = context.Request.Form["tab"];
        T_PlaningDTO planingDTO = context.Session["TPlan"] != null ? (T_PlaningDTO)context.Session["TPlan"] : GetRequestToObject(context);
        List<T_Planing_DefectDTO> objOrgList = null;
        List<T_Planing_DefectDTO> objOutputList = null;
        json = new JavaScriptSerializer();

        // Collecting Data
        switch(tabNumber)
        {
            case "3" : planingDTO.CoatingDefectList = GetDefect(context, planingDTO.CoatingDefectList);

                objOutputList = new List<T_Planing_DefectDTO>();

                foreach (T_Planing_DefectDTO dto in planingDTO.CoatingDefectList)
                {
                    objOutputList.Add(dto.clone());
                }
                jsonString = json.Serialize(objOutputList);

                break;
            case "4" :planingDTO.PipeDefectList = GetDefect(context, planingDTO.PipeDefectList);
                objOrgList = planingDTO.PipeDefectList;

                objOutputList = new List<T_Planing_DefectDTO>();

                foreach (T_Planing_DefectDTO dto in planingDTO.PipeDefectList)
                {
                    objOutputList.Add(dto.clone());
                }
                jsonString = json.Serialize(objOutputList);

                break;
            case "5": planingDTO.EnvironmentList = GetEnvironment(context, planingDTO.EnvironmentList);
                jsonString = json.Serialize(planingDTO.EnvironmentList);
                break;
        }


        // Saving Data to Session
        PlanSessionManaging(context, planingDTO);

        context.Response.Write(jsonString);







        return result;
    }

    List<T_Planing_EnvironmentDTO> GetEnvironment(HttpContext context, List<T_Planing_EnvironmentDTO> envirommentList)
    {

        T_Planing_EnvironmentDTO environmentDTO = null;
        T_Planing_EnvironmentDTO deleteENVByDto = null;

        List<T_Planing_EnvironmentDTO> myResultList = envirommentList;
        environmentDTO = ConvertX.GetReqeustForm<T_Planing_EnvironmentDTO>();

        if (context.Request.Form["Step"].Trim().ToLower().Equals("add"))
        {

            if (myResultList == null)
            {
                environmentDTO.No = 1;

                myResultList = new List<T_Planing_EnvironmentDTO>();


            }
            else
            {
                //Add existing coating defect 
                environmentDTO.No = myResultList.Count + 1;
            }

            myResultList.Add(environmentDTO);

        }
        else if (context.Request.Form["Step"].Trim().ToLower().Equals("delete"))
        {
            string No = context.Request.Form["No"];
            deleteENVByDto = myResultList.Find(o => o.No.ToString() == No);
            if (deleteENVByDto != null)
            {
                myResultList.Remove(deleteENVByDto);
            }

        }

        return myResultList;
    }

    List<T_Planing_DefectDTO> GetDefect(HttpContext context, List<T_Planing_DefectDTO> planList)
    {
        HttpPostedFile postFile = null;
        T_Planing_DefectDTO defectDTO = null;
        T_Planing_DefectDTO deleteByDto = null;

        List<T_Planing_DefectDTO> myResultList = planList;

        defectDTO = ConvertX.GetReqeustForm<T_Planing_DefectDTO>();

        if (context.Request.Form["Step"].Trim().ToLower().Equals("add"))
        {

            if (context.Request.Files.Count > 0)
            {



                foreach (string fileUploadName in context.Request.Files)
                {
                    if (fileUploadName.ToLower().IndexOf("defect") > -1)
                    {
                        postFile = context.Request.Files[fileUploadName];
                        var fileName = System.IO.Path.GetFileName(postFile.FileName);
                        var ext = System.IO.Path.GetExtension(postFile.FileName);
                        //  fileName = string.Format("{0}.{1}", Guid.NewGuid(), ext);
                        postFile.SaveAs(context.Server.MapPath("~/Files/" + fileName));

                        if (fileUploadName.ToLower().Equals("defect-0"))
                        {
                            defectDTO.FileName1 = fileName;
                            defectDTO.File1 = postFile;
                        }
                        if (fileUploadName.ToLower().Equals("defect-1"))
                        {
                            defectDTO.FileName2 = fileName;
                            defectDTO.File2 = postFile;
                        }
                        if (fileUploadName.ToLower().Equals("defect-2"))
                        {
                            defectDTO.FileName3 = fileName;
                            defectDTO.File3 = postFile;
                        }
                        if (fileUploadName.ToLower().Equals("defect-3"))
                        {
                            defectDTO.FileName4 = fileName;
                            defectDTO.File4 = postFile;
                        }
                    }

                }


            }

            ///Create new coating defect
            if (defectDTO.No == 0)
            {


                if (myResultList == null)
                {
                    defectDTO.No = 1;

                    myResultList = new List<T_Planing_DefectDTO>();


                }
                else
                {
                    //Add existing coating defect 
                    defectDTO.No = myResultList.Count + 1;
                }
                myResultList.Add(defectDTO);




            }
        } if (context.Request.Form["Step"].Trim().ToLower().Equals("delete"))
        {

            string No = context.Request.Form["No"];
            deleteByDto = myResultList.Find(o => o.No.ToString() == No);
            if (deleteByDto != null)
            {
                myResultList.Remove(deleteByDto);
            }

        }




        return myResultList;


    }

    T_PlaningDTO GetRequestToObject(HttpContext context)
    {
        HttpPostedFile postFile = null;
        T_PlaningDTO planingDTO = ConvertX.GetReqeustForm<T_PlaningDTO>();
        if (context.Request.Files.Count > 0)
        {


            foreach (string fileUploadName in context.Request.Files)
            {
                if (fileUploadName.ToLower().IndexOf("defect") > -1)
                {
                    postFile = context.Request.Files[fileUploadName];
                    var fileName = System.IO.Path.GetFileName(postFile.FileName);
                    var ext = System.IO.Path.GetExtension(postFile.FileName);
                    // fileName = string.Format("{0}.{1}", Guid.NewGuid(), ext);
                    postFile.SaveAs(context.Server.MapPath("~/Files/" + fileName));

                    if (fileUploadName.ToLower().Equals("defect-0"))
                    {
                        planingDTO.FileName1 = fileName;
                    }
                    if (fileUploadName.ToLower().Equals("defect-1"))
                    {
                        planingDTO.FileName2 = fileName;
                    }
                    if (fileUploadName.ToLower().Equals("defect-2"))
                    {
                        planingDTO.FileName3 = fileName;
                    }
                    if (fileUploadName.ToLower().Equals("defect-3"))
                    {
                        planingDTO.FileName4 = fileName;
                    }
                }

            }


        }

        return planingDTO;

    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public bool Action(HttpContext context)
    {
        bool result = false;

        T_PlaningDTO planingDTO = GetRequestToObject(context);
        T_Planing_CoatingRepairDTO planingCoatingRepairDTO = ConvertX.GetReqeustForm<T_Planing_CoatingRepairDTO>();

        planingDTO.CreateBy = UserLOGIN.UserID;
        planingDTO.UpdateBy = UserLOGIN.UserID;


        //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        T_PlaningBAL bal = new T_PlaningBAL();

        if (context.Request.Form["Action"].ToLower() == "add")
        {
            //  dto.MENUGROUP_OID = context.Request.Form["selectMENUGROUP"].ToString();
            result = bal.Add(planingDTO, planingCoatingRepairDTO, null, null, null);
        } else if (context.Request.Form["Action"].ToLower() == "addreview")
        {
            result = bal.UpdateReview(planingDTO);
        }
        else if (context.Request.Form["Action"].ToLower() == "delete")
        {
            result = bal.Delete(planingDTO);
        }
        else if (context.Request.Form["Action"].ToLower() == "clearplan")
        {
            result = bal.ClearAlll(dto);
        }      else if (context.Request.Form["Action"].ToLower() == "loadplansetting")
        {

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
        T_PlaningDTO obj= null;

        dto = ConvertX.GetReqeustForm<T_PlaningDTO>();

        T_PlaningBAL bal = new T_PlaningBAL();
        obj = bal.FindByPK(dto);
        return obj;
    }



    public  List<ExportPlanHeader> GetCaptionPlan()
    {
        bool result = false;
        List<ExportPlanHeader> objList= null;


        T_PlaningBAL bal = new T_PlaningBAL();
        objList = bal.CaptionPlanAll();
        return objList;
    }



    public List<T_PlaningDTO> FindByConditionV2()
    {
        bool result = false;
        List<T_PlaningDTO> objList = null;

        dto = ConvertX.GetReqeustRealForm<T_PlaningDTO>();
        dto.CreateBy = UserLOGIN.UserID;
        dto.UpdateBy = UserLOGIN.UserID;
        /* if (UserLOGIN.RoleLevel == "1")
         {
             dto.CreateBy = UserLOGIN.UserID;
             dto.UpdateBy = UserLOGIN.UserID;
         }*/

        if (dto.Year == "")
        {
            dto.Year = DateTime.Now.Year.ToString();
        }
        T_PlaningBAL bal = new T_PlaningBAL();
        objList = bal.FindByObjListV2(dto);
        return objList;
    }



    public List<ColumnReportDTO> GetProgressPlan()
    {
        bool result = false;
        List<ColumnReportDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_PlaningDTO>();

        if (UserLOGIN.RoleLevel == "1")
        {
            dto.CreateBy = UserLOGIN.UserID;
            dto.UpdateBy = UserLOGIN.UserID;
        }
        dto.CreateBy = UserLOGIN.UserID;
        T_PlaningBAL bal = new T_PlaningBAL();
        objList = bal.GetGraphProgress(dto);
        return objList;
    }





    public bool IsReusable {
        get {
            return false;
        }
    }

}