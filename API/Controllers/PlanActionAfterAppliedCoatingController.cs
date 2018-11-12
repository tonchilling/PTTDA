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
    [RoutePrefix("api/PlanActionAfterAppliedCoating")]
    public class PlanActionAfterAppliedCoatingController : ApiController
    {
        Logger logger = new Logger("PlanActionAfterAppliedCoatingController");
        string planPath = System.Configuration.ConfigurationManager.AppSettings["AfterAppliedCoatingPath"];
        T_Planing_Action_AfterAppliedCoatingBAL bal = null;

        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            bal = new T_Planing_Action_AfterAppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AfterAppliedCoatingDTO dto = null;
            List<T_Planing_Action_AfterAppliedCoatingDTO> objList = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterAppliedCoatingDTO>();

                objList = bal.FindByObjList(dto);

                foreach (T_Planing_Action_AfterAppliedCoatingDTO mainDTO in objList)
                {
                    //Find detail and push to main object in list
                    T_Planing_Action_AfterAppliedCoatingDTO detailDTO = new T_Planing_Action_AfterAppliedCoatingDTO();
                    detailDTO.PID = mainDTO.PID;
                    detailDTO = bal.FindByPK(detailDTO);

                    mainDTO.UploadFileList = detailDTO.UploadFileList;
                    mainDTO.DryFilmThicknessList = detailDTO.DryFilmThicknessList;

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
            bal = new T_Planing_Action_AfterAppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AfterAppliedCoatingDTO dto = null;
            List<T_Planing_File> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterAppliedCoatingDTO>();

                logger.debug("PlanActionAfterAppliedCoatingController SearchAllFiles dto:" + dto.ToString());
                objList = bal.FindAllFiles(dto);

                if (!ObjUtil.isEmpty(objList))
                {
                    foreach(T_Planing_File file in objList)
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
                logger.error("PlanActionAfterAppliedCoatingController SearchAllFiles error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("SearchAllDryFilms")]
        public HttpResponseMessage SearchAllDryFilms()
        {
            bal = new T_Planing_Action_AfterAppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AfterAppliedCoatingDTO dto = null;
            List<T_Planing_Action_AfterAppliedCoating_DryFilmDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterAppliedCoatingDTO>();

                logger.debug("PlanActionAfterAppliedCoatingController SearchAllDryFilms dto:" + dto.ToString());
                objList = bal.FindAllDryFilms(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionAfterAppliedCoatingController SearchAllDryFilms error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("View")]
        public HttpResponseMessage View()
        {
            bal = new T_Planing_Action_AfterAppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AfterAppliedCoatingDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterAppliedCoatingDTO>();

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
            T_Planing_Action_AfterAppliedCoatingMobileBAL mobileBal = new T_Planing_Action_AfterAppliedCoatingMobileBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            bool result = false;
            T_Planing_Action_AfterAppliedCoatingMobileDTO dto = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustFormExactly<T_Planing_Action_AfterAppliedCoatingMobileDTO>();
                string UserID = context.Request.Form["UserID"];
                if (ObjUtil.isEmpty(UserID))
                {
                    throw new Exception("UserID is require");
                }
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;
                List<T_Planing_Action_AfterAppliedCoating_DryFilmMobileDTO> DryFilmList = deserializer.Deserialize<List<T_Planing_Action_AfterAppliedCoating_DryFilmMobileDTO>>(context.Request.Form["DryFilmList"]);

                if (!ObjUtil.isEmpty(DryFilmList))
                {
                    foreach(T_Planing_Action_AfterAppliedCoating_DryFilmMobileDTO dryFilm in DryFilmList)
                    {
                        dryFilm.CreateBy = UserID;
                        dryFilm.UpdateBy = UserID;
                    }
                }

                dto.DryFilmThicknessList = DryFilmList;
                
                dto.UploadFileList = deserializer.Deserialize<List<T_PlaningFileMobileDTO>>(context.Request.Form["fileList"]);

                if (dto.UploadFileList != null && dto.UploadFileList.Count > 0)
                {
                    foreach (T_PlaningFileMobileDTO file in dto.UploadFileList)
                    {
                        file.DesPath = context.Server.MapPath(planPath) + @"\" + file.PID + @"\" + file.UploadType;
                        file.FullPath = file.DesPath + @"\" + file.FileName;
                        logger.debug("PlanActionAfterAppliedCoating Add file:" + file.ToString());
                    }
                }

                logger.debug("PlanActionAfterAppliedCoating Add dto:" + dto.ToString());
                if (dto.DryFilmThicknessList != null && dto.DryFilmThicknessList.Count > 0)
                {
                    foreach (T_Planing_Action_AfterAppliedCoating_DryFilmMobileDTO dryFilm in dto.DryFilmThicknessList)
                    {
                        logger.debug("PlanActionAfterAppliedCoating Add DryFilmThickness:" + dryFilm.ToString());
                    }
                }
                
                result = mobileBal.AddFromMobile(dto);

                if (result)
                {
                    response.statusCode = true;
                    response.statusText = "Success";
                    try
                    {
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
                    }
                    catch (Exception e)
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
            bal = new T_Planing_Action_AfterAppliedCoatingBAL();
            T_Planing_Action_AfterAppliedCoatingDTO dto = null;
            List<T_Planing_File> fileList = null;
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data"; 
                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterAppliedCoatingDTO>();

                logger.debug("Delete dto :" + dto.ToString());

                fileList = bal.DeleteByPK(dto);

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
        }

        [HttpPost]
        [Route("DeleteFile")]
        public HttpResponseMessage DeleteFile()
        {
            bal = new T_Planing_Action_AfterAppliedCoatingBAL();
            T_Planing_File dto = null;
            List<T_Planing_File> fileList = null;
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data"; 
                dto = ConvertX.GetReqeustForm<T_Planing_File>();

                logger.debug("DeleteFile dto :" + dto.ToString());

                fileList = bal.DeleteFile(dto);
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
                logger.error("DeleteFile error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }
        */
        [HttpPost]
        [Route("DeleteDryFilmList")]
        public HttpResponseMessage DeleteDryFilmList()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_Action_AfterAppliedCoatingBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            response.statusCode = false;
            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";
                
                List<T_Planing_Action_AfterAppliedCoating_DryFilmDTO> deleteDryfilmList = deserializer.Deserialize<List<T_Planing_Action_AfterAppliedCoating_DryFilmDTO>>(context.Request.Form["DeleteDryFilmList"]);
                logger.debug("DeleteDryFilmList :" + deleteDryfilmList);

                if (deleteDryfilmList != null && deleteDryfilmList.Count > 0)
                {
                    response.statusCode = bal.DeleteDryFilm(deleteDryfilmList);
                }                
            }
            catch (Exception ex)
            {
                logger.error("DeleteDryFilmList error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

    }
}