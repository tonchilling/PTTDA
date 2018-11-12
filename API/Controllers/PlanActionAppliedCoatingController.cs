using BAL.PTT.Plan;
using DTO.PTT.Plan;
using DTO.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace API.Controllers
{
    [RoutePrefix("api/PlanActionAppliedCoating")]
    public class PlanActionAppliedCoatingController : ApiController
    {
        Logger logger = new Logger("PlanActionAppliedCoatingController");
        string planPath = System.Configuration.ConfigurationManager.AppSettings["AppliedCoatingPath"];
        T_Planing_Action_AppliedCoatingBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            bal = new T_Planing_Action_AppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AppliedCoatingDTO dto = null;
            List<T_Planing_Action_AppliedCoatingDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();

                logger.debug("Search dto:" + dto.ToString());
                objList = bal.FindByObjList(dto);

                foreach (T_Planing_Action_AppliedCoatingDTO mainDTO in objList)
                {
                    //Find detail and push to main object in list
                    T_Planing_Action_AppliedCoatingDTO detailDTO = new T_Planing_Action_AppliedCoatingDTO();
                    detailDTO.PID = mainDTO.PID;
                    detailDTO = bal.FindByPK(detailDTO);

                    mainDTO.UploadFileList = detailDTO.UploadFileList;
                    mainDTO.CoatingInfoList = detailDTO.CoatingInfoList;

                    if (!ObjUtil.isEmpty(mainDTO.UploadFileList))
                    {
                        foreach (T_Planing_File file in mainDTO.UploadFileList)
                        {
                            file.HtmlFile = System.Web.VirtualPathUtility.ToAbsolute(planPath + "/" + file.PID + "/" + file.UploadType + "/" + file.FileName);
                            string fullPath = context.Server.MapPath(planPath) + @"\" + file.PID + @"\" + file.UploadType + @"\" + file.FileName;
                            file.Base64File = Utility.convertFileToBase64(fullPath);
                        }
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
        [Route("SearchAllFiles")]
        public HttpResponseMessage SearchAllFiles()
        {
            bal = new T_Planing_Action_AppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AppliedCoatingDTO dto = null;
            List<T_Planing_File> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();

                logger.debug("PlanActionAppliedCoatingController SearchAllFiles dto:" + dto.ToString());
                objList = bal.FindAllFiles(dto);

                if (!ObjUtil.isEmpty(objList))
                {
                    foreach (T_Planing_File file in objList)
                    {
                        file.HtmlFile = System.Web.VirtualPathUtility.ToAbsolute(planPath + "/" + file.PID + "/" + file.UploadType + "/" + file.FileName);
                        string fullPath = context.Server.MapPath(planPath) + @"\" + file.PID + @"\" + file.UploadType + @"\" + file.FileName;
                        file.Base64File = Utility.convertFileToBase64(fullPath);
                    }
                }

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionAppliedCoatingController SearchAllFiles error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("SearchAllInformations")]
        public HttpResponseMessage SearchAllInformations()
        {
            bal = new T_Planing_Action_AppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AppliedCoatingDTO dto = null;
            List<T_Planing_Action_AppliedCoating_InformationDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();

                logger.debug("PlanActionAppliedCoatingController SearchAllInformations dto:" + dto.ToString());
                objList = bal.FindAllImformations(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionAppliedCoatingController SearchAllInformations error:" + ex.ToString());
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
            bal = new T_Planing_Action_AppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AppliedCoatingDTO dto = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();

                logger.debug("View dto :" + dto.ToString());
                dto = bal.FindByPK(dto);

                if (dto != null && dto.UploadFileList != null)
                {
                    foreach (var uploadFile in dto.UploadFileList)
                    {
                        uploadFile.HtmlFile = System.Web.VirtualPathUtility.ToAbsolute(planPath + "/" + dto.PID + "/" + uploadFile.UploadType + "/" + uploadFile.FileName);
                        string fullPath = context.Server.MapPath(planPath) + @"\" + uploadFile.PID + @"\" + uploadFile.UploadType + @"\" + uploadFile.FileName;
                        uploadFile.Base64File = Utility.convertFileToBase64(fullPath);
                    }
                }

                response.statusCode = true;
                response.data = dto;
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
            var deserializer = new JavaScriptSerializer();
            T_Planing_Action_AppliedCoatingMobileBAL mobileBal = new T_Planing_Action_AppliedCoatingMobileBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AppliedCoatingMobileDTO dto = null;
            List<T_Planing_Action_AppliedCoating_InformationMobileDTO> coatingInfomationList = null;

            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustFormExactly<T_Planing_Action_AppliedCoatingMobileDTO>();

                //dto.ID = context.Request.Form["ID"];
                //dto.PID = context.Request.Form["PID"];

                string UserID = context.Request.Form["UserID"];
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;

                //fileList = deserializer.Deserialize<List<T_Planing_File>>(context.Request.Form["surfaceList"]);
                coatingInfomationList = deserializer.Deserialize<List<T_Planing_Action_AppliedCoating_InformationMobileDTO>>(context.Request.Form["coatingInfomationList"]);

                if (coatingInfomationList != null)
                {
                    foreach (T_Planing_Action_AppliedCoating_InformationMobileDTO coatingDto in coatingInfomationList)
                    {
                        coatingDto.InfoType = "1";
                        coatingDto.InfoDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year.ToString());

                    }
                }
                dto.CoatingInfoList = coatingInfomationList;

                dto.UploadFileList = deserializer.Deserialize<List<T_PlaningFileMobileDTO>>(context.Request.Form["fileList"]);
                                                
                logger.debug("PlanActionAppliedCoatingController Add dto:" + dto.ToString());

                if (dto.CoatingInfoList != null && dto.CoatingInfoList.Count > 0)
                {
                    foreach (T_Planing_Action_AppliedCoating_InformationMobileDTO coating in dto.CoatingInfoList)
                    {
                        logger.debug("PlanActionAppliedCoatingController Add coating:" + coating.ToString());
                    }
                }

                if (dto.UploadFileList != null && dto.UploadFileList.Count > 0)
                {
                    foreach (T_PlaningFileMobileDTO file in dto.UploadFileList)
                    {
                        file.DesPath = context.Server.MapPath(planPath) + @"\" + file.PID + @"\" + file.UploadType;
                        file.FullPath = file.DesPath + @"\" + file.FileName;
                        logger.debug("PlanActionAfterAppliedCoating Add file:" + file.ToString());
                    }
                }

                response.statusCode = mobileBal.AddFromMobile(dto);
                
                if (response.statusCode)
                {
                    response.statusText = "Success";
                    try {
                        // For new upload
                        if (dto.UploadFileList != null && dto.UploadFileList.Count > 0)
                        {
                            foreach (T_PlaningFileMobileDTO f in dto.UploadFileList)
                            {
                                if (DTO.PTT.Util.FileMng.HaveDirectory(f.DesPath))
                                {
                                    logger.debug("Save file to :" + f.FullPath);
                                    Utility.saveBase64File(f.FullPath, f.Base64File);
                                }
                            }
                        }

                        if (dto.DeleteFileNames != null && dto.DeleteFileNames.Length > 0)
                        {
                            foreach (var fileName in dto.DeleteFileNames.Split(','))
                            {
                                if (fileName != "")
                                {
                                    var realDesFile = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileName;
                                    DTO.PTT.Util.FileMng.DeleteFile(realDesFile);
                                }
                            }
                        }
                    }catch(Exception e)
                    {
                        response.statusText = "Success but upload error:" + e.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.error("Add error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        /*
        [HttpPost]
        [Route("Delete")]
        public HttpResponseMessage Delete()
        {
            bal = new T_Planing_Action_AppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AppliedCoatingDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();

                logger.debug("Delete dto:" + dto.ToString());
                List<T_Planing_File> fileList = bal.DeleteByPK(dto);

                response.statusCode = true;
                response.data = fileList;

                if (!ObjUtil.isEmpty(fileList))
                {
                    foreach (T_Planing_File f in fileList)
                    {
                        if (!ObjUtil.isEmpty(f.FileName))
                        {
                            var realDesFile = context.Server.MapPath(planPath) + @"\" + f.PID + @"\" + f.UploadType + @"\" + f.FileName;
                            DTO.PTT.Util.FileMng.DeleteFile(realDesFile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.error("Delete error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }*/

        [HttpPost]
        [Route("Delete")]
        public HttpResponseMessage Delete()
        {
            bal = new T_Planing_Action_AppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AppliedCoatingDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();

                logger.debug("Delete dto:" + dto.ToString());
                bal.Delete(dto);

                response.statusCode = true;
                response.data = "Delete success";                
            }
            catch (Exception ex)
            {
                logger.error("Delete error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

    }
}