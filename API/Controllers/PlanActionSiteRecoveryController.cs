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
    [RoutePrefix("api/PlanActionSiteRecovery")]
    public class PlanActionSiteRecoveryController : ApiController
    {
        Logger logger = new Logger("PlanActionSiteRecoveryController");
        string planPath = System.Configuration.ConfigurationManager.AppSettings["SiteRecoveryPath"];
        T_Planing_Action_SiteRecoveryBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_Action_SiteRecoveryBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteRecoveryDTO dto = null;
            List<T_Planing_Action_SiteRecoveryDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();

                logger.debug("Search dto :" + dto.ToString());
                objList = bal.FindByObjList(dto);

                foreach (T_Planing_Action_SiteRecoveryDTO mainDTO in objList)
                {
                    //Find detail and push to main object in list
                    T_Planing_Action_SiteRecoveryDTO detailDTO = new T_Planing_Action_SiteRecoveryDTO();
                    detailDTO.PID = mainDTO.PID;
                    detailDTO = bal.FindByPK(detailDTO);

                    mainDTO.UploadFileList = detailDTO.UploadFileList;
                    mainDTO.LogApporveHistorys = detailDTO.LogApporveHistorys;

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
            bal = new T_Planing_Action_SiteRecoveryBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_SiteRecoveryDTO dto = null;
            List<T_Planing_File> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();

                logger.debug("PlanActionSiteRecoveryController SearchAllFiles dto:" + dto.ToString());
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
                logger.error("PlanActionSiteRecoveryController SearchAllFiles error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("SearchAllApprovalHistory")]
        public HttpResponseMessage SearchAllApprovalHistory()
        {
            bal = new T_Planing_Action_SiteRecoveryBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_SiteRecoveryDTO dto = null;
            List<T_Planing_ApprovalHistoryDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();

                logger.debug("PlanActionSiteRecoveryController SearchAllApprovalHistory dto:" + dto.ToString());
                objList = bal.FindAllApprovalHistory(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionSiteRecoveryController SearchAllApprovalHistory error:" + ex.ToString());
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
            bal = new T_Planing_Action_SiteRecoveryBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteRecoveryDTO dto = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();

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
            T_Planing_Action_SiteRecoveryMobileBAL mobileBal = new T_Planing_Action_SiteRecoveryMobileBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteRecoveryMobileDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustFormExactly<T_Planing_Action_SiteRecoveryMobileDTO>();

                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;

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
                                
                logger.debug("PlanActionSiteRecoveryController Add dto:" + dto.ToString());

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
            bal = new T_Planing_Action_SiteRecoveryBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteRecoveryDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();

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
            bal = new T_Planing_Action_SiteRecoveryBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_SiteRecoveryDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();

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

        [HttpPost]
        [Route("Approve")]
        public HttpResponseMessage Approve()
        {
            bal = new T_Planing_Action_SiteRecoveryBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteRecoveryDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                string RoleLevel = context.Request.Form["RoleLevel"];
                if (ObjUtil.isEmpty(RoleLevel))
                {
                    throw new Exception("RoleLevel is require");
                }

                if (RoleLevel == "1")
                {
                    dto.Approval1 = UserID;
                    dto.ApproveStatus = RoleLevel;
                    dto.ApprovalDate1 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                       , DateTime.Now.Day.ToString("##00")
                                                       , DateTime.Now.Year.ToString());
                }
                else if (RoleLevel == "2")
                {
                    dto.Approval2 = UserID;
                    dto.ApproveStatus = RoleLevel;
                    dto.ApprovalDate2 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                       , DateTime.Now.Day.ToString("##00")
                                                       , DateTime.Now.Year.ToString());
                }
                else if (RoleLevel == "3" || RoleLevel == "4" || RoleLevel == "5")
                {
                    dto.Approval3 = UserID;
                    dto.ApproveStatus = "3";
                    dto.ApprovalDate3 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                       , DateTime.Now.Day.ToString("##00")
                                                       , DateTime.Now.Year.ToString());
                }
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;
                logger.debug("Approve dto :" + dto.ToString());
                response.statusCode = bal.Approve(dto);
            }
            catch (Exception ex)
            {
                logger.error("Approve error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("Reject")]
        public HttpResponseMessage Reject()
        {
            bal = new T_Planing_Action_SiteRecoveryBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteRecoveryDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                string RoleLevel = context.Request.Form["RoleLevel"];
                if (ObjUtil.isEmpty(RoleLevel))
                {
                    throw new Exception("RoleLevel is require");
                }

                if (RoleLevel == "1")
                {
                    dto.Rejecter = UserID;
                    dto.RejectStatus = RoleLevel;
                }
                else if (RoleLevel == "2")
                {
                    dto.Rejecter = UserID;
                    dto.RejectStatus = RoleLevel;
                }
                else if (RoleLevel == "3" || RoleLevel == "4" || RoleLevel == "5")
                {
                    dto.Rejecter = UserID;
                    dto.RejectStatus = "3";
                }

                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;

                logger.debug("Reject dto :" + dto.ToString());
                response.statusCode = bal.Reject(dto);
            }
            catch (Exception ex)
            {
                logger.error("Reject error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }
    }
}