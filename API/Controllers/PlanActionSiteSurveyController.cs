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
    [RoutePrefix("api/PlanActionSiteSurvey")]
    public class PlanActionSiteSurveyController : ApiController
    {
        Logger logger = new Logger("PlanActionSiteSurveyController");
        string planPath = System.Configuration.ConfigurationManager.AppSettings["SiteSurveyPath"];
        T_Planing_Action_SiteSurveyBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_Action_SiteSurveyBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteSurveyDTO dto = null;
            List<T_Planing_Action_SiteSurveyDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteSurveyDTO>();

                logger.debug("Search dto:" + dto.ToString());
                objList = bal.FindByObjList(dto);

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
            bal = new T_Planing_Action_SiteSurveyBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteSurveyDTO dto = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteSurveyDTO>();

                logger.debug("View dto:" + dto.ToString());
                dto = bal.FindByPK(dto);

                if (dto != null && dto.UploadFileList != null)
                {
                    foreach (var uploadFile in dto.UploadFileList)
                    {
                        uploadFile.HtmlFile = System.Web.VirtualPathUtility.ToAbsolute(planPath + "/" + dto.PID + "/" + uploadFile.UploadType + "/" + uploadFile.FileName);
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
            bal = new T_Planing_Action_SiteSurveyBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteSurveyDTO dto = null;
            List<T_Planing_File> fileList = null;

            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteSurveyDTO>();
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;

                int fileCount = context.Request.Files.Count;
                if (fileCount > 0)
                {
                    fileList = new List<T_Planing_File>();
                    int no = 1;
                    int fileType = 1;
                    
                    for (var i = 0; i < fileCount; i++)
                    {
                        string keyName = context.Request.Files.GetKey(i);
                        if (keyName.IndexOf("file1") > -1)
                        {
                            fileType = 1;
                        }
                        else if (keyName.IndexOf("file2") > -1)
                        {
                            fileType = 2;
                        }
                        string Path = planPath;

                        string savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\" + System.IO.Path.GetFileName(context.Request.Files[i].FileName);

                        T_Planing_File file = new T_Planing_File();
                        file.FullPath = savedFileName;
                        file.DesPath = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType;
                        file.FileName = System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                        file.FileSize = context.Request.Files[i].ContentLength.ToString();
                        file.UploadDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year);
                        file.No = no.ToString();
                        file.PID = dto.PID;
                        file.UploadType = fileType.ToString();
                        file.PostFile = context.Request.Files[i];
                        no++;

                        fileList.Add(file);
                    }
                    dto.UploadFileList = fileList;
                }

                logger.debug("Add dto:" + dto.ToString());
                response.statusCode = bal.Add(dto);
                
                if (response.statusCode)
                {
                    response.statusText = "Success";
                    try {
                        // For new upload
                        if (fileList != null && fileList.Count > 0)
                        {
                            foreach (T_Planing_File f in fileList)
                            {
                                if (DTO.PTT.Util.FileMng.HaveDirectory(f.DesPath))
                                {
                                    f.PostFile.SaveAs(f.FullPath);
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
            bal = new T_Planing_Action_SiteSurveyBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_SiteSurveyDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteSurveyDTO>();

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
            bal = new T_Planing_Action_SiteSurveyBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_SiteSurveyDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteSurveyDTO>();

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