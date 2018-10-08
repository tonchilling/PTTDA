using BAL.PTT.Plan;
using DTO.PTT.Plan;
using DTO.PTT.Report;
using DTO.PTT.Util;
using DTO.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace API.Controllers
{
    [RoutePrefix("api/Plan")]
    public class PlanController : ApiController
    {
        Logger logger = new Logger("PlanController");
        T_PlaningBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_PlaningBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_PlaningDTO dto = null;
            List<T_PlaningDTO> objList = null;
            
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_PlaningDTO>();
                logger.debug("Search dto :" + dto.ToString());

                objList = bal.FindByObjList(dto);


                if (!ObjUtil.isEmpty(objList))
                {
                    foreach (T_PlaningDTO obj in objList)
                    {
                        obj.SpecSDate = ConvertX.DDMMYY(obj.SpecSDate);
                        obj.SpecEDate = ConvertX.DDMMYY(obj.SpecEDate);

                        obj.POSDate = ConvertX.DDMMYY(obj.POSDate);
                        obj.POEDate = ConvertX.DDMMYY(obj.POEDate);

                        obj.ActionSDate = ConvertX.DDMMYY(obj.ActionSDate);
                        obj.ActionEDate = ConvertX.DDMMYY(obj.ActionEDate);
                    }
                }

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("Search error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }
        
        [HttpPost]
        [Route("View")]
        public HttpResponseMessage View()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_PlaningBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_PlaningDTO dto = null;
            List<T_PlaningDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_PlaningDTO>();
                if (dto.Year == null || "".Equals(dto.Year))
                {
                    dto.Year = DateTime.Now.Year.ToString();
                }
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;

                logger.debug("View dto :" + dto.ToString());

                objList = bal.FindByObjListV2(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("View error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage Add()
        {
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            try
            {
                var context = HttpContext.Current;

                T_PlaningMobileDTO planingDTO = GetRequestToObjectMobile(context);
                T_PlaningCoatingRepairMobileDTO planingCoatingRepairDTO = ConvertX.GetReqeustForm<T_PlaningCoatingRepairMobileDTO>();

                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                planingDTO.CreateBy = UserID;
                planingDTO.UpdateBy = UserID;
                planingCoatingRepairDTO.CreateBy = UserID;
                planingCoatingRepairDTO.UpdateBy = UserID;

                T_PlaningMobileBAL mobileBal = new T_PlaningMobileBAL();

                logger.debug("PlanController Add planingDTO:" + planingDTO.ToString());
                logger.debug("PlanController Add planingCoatingRepairDTO:" + planingCoatingRepairDTO.ToString());

                string TPID = mobileBal.AddFromMobile(planingDTO, planingCoatingRepairDTO, null, null, null);

                response.statusCode = true;
                response.statusText = "TPID";
                response.data = TPID;
            }
            catch (Exception ex)
            {
                logger.error("Add error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("Delete")]
        public HttpResponseMessage Delete()
        {
            bal = new T_PlaningBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            try
            {
                var context = HttpContext.Current;

                T_PlaningDTO planingDTO = GetRequestToObject(context);
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                planingDTO.CreateBy = UserID;
                planingDTO.UpdateBy = UserID;

                response.statusCode = bal.Delete(planingDTO);
            }
            catch (Exception ex)
            {
                logger.error("Delete error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("ClearPlan")]
        public HttpResponseMessage ClearPlan()
        {
            bal = new T_PlaningBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            try
            {
                var context = HttpContext.Current;

                T_PlaningDTO planingDTO = GetRequestToObject(context);
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                planingDTO.CreateBy = UserID;
                planingDTO.UpdateBy = UserID;

                response.statusCode = bal.ClearAlll(planingDTO);
            }
            catch (Exception ex)
            {
                logger.error("ClearPlan error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("GetProgressPlan")]
        public HttpResponseMessage GetProgressPlan()
        {
            bal = new T_PlaningBAL();

            T_PlaningDTO dto = null;
            List<ColumnReportDTO> objList = null;

            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            try
            {
                var context = HttpContext.Current;
                
                dto = ConvertX.GetReqeustForm<T_PlaningDTO>();
                string RoleLevel = context.Request.Form["RoleLevel"];
                if (ObjUtil.isEmpty(RoleLevel))
                {
                    throw new Exception("RoleLevel is require");
                }
                if (RoleLevel == "1")
                {
                    string UserID = context.Request.Form["UserID"];
                    if (ObjUtil.isEmpty(UserID))
                    {
                        throw new Exception("UserID is require");
                    }
                    dto.CreateBy = UserID;
                    dto.UpdateBy = UserID;
                }
                T_PlaningBAL bal = new T_PlaningBAL();
                objList = bal.GetGraphProgress(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("GetProgressPlan error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("Draft")]
        public HttpResponseMessage DraftToSession()
        {
            var deserializer = new JavaScriptSerializer();
            JavaScriptSerializer json = new JavaScriptSerializer();
            string jsonString = "";
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            try
            {
                var context = HttpContext.Current;

                string tabNumber = context.Request.Form["tab"];
                T_PlaningDTO planingDTO = context.Session["TPlan"] != null ? (T_PlaningDTO)context.Session["TPlan"] : GetRequestToObject(context);
                List<T_Planing_DefectDTO> objOrgList = null;
                List<T_Planing_DefectDTO> objOutputList = null;

                switch (tabNumber)
                {
                    case "3":
                        planingDTO.CoatingDefectList = GetDefect(context, planingDTO.CoatingDefectList);

                        objOutputList = new List<T_Planing_DefectDTO>();

                        foreach (T_Planing_DefectDTO dto in planingDTO.CoatingDefectList)
                        {
                            objOutputList.Add(dto.clone());
                        }
                        jsonString = json.Serialize(objOutputList);

                        break;
                    case "4":
                        planingDTO.PipeDefectList = GetDefect(context, planingDTO.PipeDefectList);
                        objOrgList = planingDTO.PipeDefectList;

                        objOutputList = new List<T_Planing_DefectDTO>();

                        foreach (T_Planing_DefectDTO dto in planingDTO.PipeDefectList)
                        {
                            objOutputList.Add(dto.clone());
                        }
                        jsonString = json.Serialize(objOutputList);

                        break;
                    case "5":
                        planingDTO.EnvironmentList = GetEnvironment(context, planingDTO.EnvironmentList);
                        jsonString = json.Serialize(planingDTO.EnvironmentList);
                        break;
                }

                response.statusCode = true;
                response.data = jsonString;
            }
            catch (Exception ex)
            {
                logger.error("DraftToSession error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
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
                        logger.debug("Save file as :" + context.Server.MapPath("~/Files/" + fileName));
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

        T_PlaningMobileDTO GetRequestToObjectMobile(HttpContext context)
        {
            HttpPostedFile postFile = null;
            T_PlaningMobileDTO planingDTO = ConvertX.GetReqeustForm<T_PlaningMobileDTO>();
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
                        logger.debug("Save file as :" + context.Server.MapPath("~/Files/" + fileName));
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
            }
            if (context.Request.Form["Step"].Trim().ToLower().Equals("delete"))
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
        
    }
}