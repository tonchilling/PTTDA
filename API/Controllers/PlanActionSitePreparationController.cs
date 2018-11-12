using BAL.PTT.Plan;
using DTO.PTT.Master;
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
    [RoutePrefix("api/PlanActionSitePreparation")]
    public class PlanActionSitePreparationController : ApiController
    {
        Logger logger = new Logger("PlanActionSitePreparationController");
        string planPath = System.Configuration.ConfigurationManager.AppSettings["SitePreparationPath"];
        T_Planing_Action_SitePreparationBAL bal = null;
        T_Planing_Action_SitePreparationMobileBAL mobileBal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_Action_SitePreparationBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SitePreparationDTO dto = null;
            List<T_Planing_Action_SitePreparationDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SitePreparationDTO>();

                logger.debug("Search dto :" + dto.ToString());
                objList = bal.FindByObjList(dto);

                foreach (T_Planing_Action_SitePreparationDTO mainDTO in objList)
                {
                    //Find detail and push to main object in list
                    T_Planing_Action_SitePreparationDTO detailDTO = new T_Planing_Action_SitePreparationDTO();
                    detailDTO.PID = mainDTO.PID;
                    detailDTO = bal.FindByPK(detailDTO);

                    mainDTO.UploadFileList = detailDTO.UploadFileList;

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
            bal = new T_Planing_Action_SitePreparationBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_SitePreparationDTO dto = null;
            List<T_Planing_File> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SitePreparationDTO>();

                logger.debug("PlanActionSitePreparationController SearchAllFiles dto:" + dto.ToString());
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
                logger.error("PlanActionSitePreparationController SearchAllFiles error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("SearchAllUndergrounds")]
        public HttpResponseMessage SearchAllUndergrounds()
        {
            bal = new T_Planing_Action_SitePreparationBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_SitePreparationDTO dto = null;
            List<M_UndergroundDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SitePreparationDTO>();

                logger.debug("PlanActionSitePreparationController SearchAllUndergrounds dto:" + dto.ToString());
                objList = bal.FindAllUndergrounds(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionSitePreparationController SearchAllUndergrounds error:" + ex.ToString());
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
            bal = new T_Planing_Action_SitePreparationBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SitePreparationDTO dto = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SitePreparationDTO>();

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
            mobileBal = new T_Planing_Action_SitePreparationMobileBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_PlaningActionSitePreparationMobileDTO dto = null;
            List<T_PlaningFileMobileDTO> fileList = null;

            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustFormExactly<T_PlaningActionSitePreparationMobileDTO>();

                M_UndergroundMobileDTO[] undergroundDTOList = new JavaScriptSerializer().Deserialize<M_UndergroundMobileDTO[]>(context.Request.Form["objList"]);
                dto.underGroundList = new List<M_UndergroundMobileDTO>();
                dto.underGroundList.AddRange(undergroundDTOList);

                dto.UploadFileList = deserializer.Deserialize<List<T_PlaningFileMobileDTO>>(context.Request.Form["fileList"]);

                if (dto.UploadFileList != null && dto.UploadFileList.Count > 0)
                {
                    foreach (T_PlaningFileMobileDTO file in dto.UploadFileList)
                    {
                        file.DesPath = context.Server.MapPath(planPath) + @"\" + file.PID + @"\" + file.UploadType;
                        file.FullPath = file.DesPath + @"\" + file.FileName;
                        logger.debug("Add file:" + file.ToString());
                    }
                }
                
                logger.debug("Add dto :" + dto.ToString());
                if(dto.underGroundList != null)
                {
                    foreach (M_UndergroundMobileDTO ud in dto.underGroundList)
                    {
                        logger.debug("Add underground :" + ud.ToString());
                    }
                }
                response.statusCode = mobileBal.AddFromMobile(dto);

                if (response.statusCode)
                {
                    response.statusText = "Success";
                    try {
                        // For new upload
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

                        // For delete old file
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
            bal = new T_Planing_Action_SitePreparationMobileBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SitePreparationDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SitePreparationDTO>();

                logger.debug("Delete dto :" + dto.ToString());

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
            bal = new T_Planing_Action_SitePreparationBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_SitePreparationDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SitePreparationDTO>();

                logger.debug("Delete dto :" + dto.ToString());

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