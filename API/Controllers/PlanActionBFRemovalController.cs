﻿using BAL.PTT.Plan;
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
    [RoutePrefix("api/PlanActionBFRemoval")]
    public class PlanActionBFRemovalController : ApiController
    {
        Logger logger = new Logger("PlanActionBFRemovalController");
        string planPath = System.Configuration.ConfigurationManager.AppSettings["BFRemovalPath"];
        T_Planing_Action_BFRemovalBAL bal = null;
        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_Action_BFRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_BFRemovalDTO dto = null;
            List<T_Planing_Action_BFRemovalDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();

                logger.debug("Search dto:" + dto.ToString());
                objList = bal.FindByObjList(dto);

                foreach(T_Planing_Action_BFRemovalDTO bfDTO in objList)
                {
                    //Find detail and push to main object in list
                    T_Planing_Action_BFRemovalDTO detailDTO = new T_Planing_Action_BFRemovalDTO();
                    detailDTO.PID = bfDTO.PID;
                    detailDTO = bal.FindByPK(detailDTO);

                    bfDTO.ConditionList = detailDTO.ConditionList;
                    bfDTO.UploadFileList = detailDTO.UploadFileList;
                    bfDTO.UploadDefectFileList = detailDTO.UploadDefectFileList;

                    if (!ObjUtil.isEmpty(bfDTO.UploadFileList))
                    {
                        foreach (T_Planing_File file in bfDTO.UploadFileList)
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
            bal = new T_Planing_Action_BFRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_BFRemovalDTO dto = null;
            List<T_Planing_File> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();

                logger.debug("PlanActionBFRemovalController SearchAllFiles dto:" + dto.ToString());
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
                logger.error("PlanActionBFRemovalController SearchAllFiles error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("SearchAllConditions")]
        public HttpResponseMessage SearchAllConditions()
        {
            bal = new T_Planing_Action_BFRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_BFRemovalDTO dto = null;
            List<T_Planing_Action_BFRemoval_ConditionDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();

                logger.debug("PlanActionBFRemovalController SearchAllConditions dto:" + dto.ToString());
                objList = bal.FindAllImformations(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionBFRemovalController SearchAllConditions error:" + ex.ToString());
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
            bal = new T_Planing_Action_BFRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_BFRemovalDTO dto = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();

                logger.debug("View dto:" + dto.ToString());
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
            T_Planing_Action_BFRemovalMobileBAL mobileBal = new T_Planing_Action_BFRemovalMobileBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_BFRemovalMobileDTO dto = null;
            List<T_Planing_Action_BFRemoval_ConditionMobileDTO> removalCondtionList = null;
            string savedFileName = "";
            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustFormExactly<T_Planing_Action_BFRemovalMobileDTO>();

                string UserID = context.Request.Form["UserID"];
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;
                dto.CreatedBy = UserID;
                dto.UpdatedBy = UserID;

                removalCondtionList = deserializer.Deserialize<List<T_Planing_Action_BFRemoval_ConditionMobileDTO>>(context.Request.Form["defectList"]);

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

                dto.ConditionList = removalCondtionList;

                dto.HolidayTest = dto.ConditionList.Count.ToString();
                logger.debug("PlanActionBFRemovalController Add dto:" + dto.ToString());
                if (dto.ConditionList != null && dto.ConditionList.Count > 0)
                {
                    foreach(T_Planing_Action_BFRemoval_ConditionMobileDTO condition in dto.ConditionList ){
                        logger.debug("PlanActionBFRemovalController Add condition:" + condition.ToString());
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
                        response.statusText = "Success but process file error :" + e.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.error("PlanActionBFRemovalController Add error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        /*
        [HttpPost]
        [Route("Add")]
        public HttpResponseMessage Add()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_Action_BFRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_BFRemovalDTO dto = null;
            List<T_Planing_Action_BFRemoval_ConditionDTO> removalCondtionList = null;
            List<T_Planing_File> fileList = null;
            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();

                string UserID = context.Request.Form["UserID"];
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;
                dto.CreatedBy = UserID;
                dto.UpdatedBy = UserID;

                removalCondtionList = deserializer.Deserialize<List<T_Planing_Action_BFRemoval_ConditionDTO>>(context.Request.Form["defectList"]);

                int fileCount = context.Request.Files.Count;
                if (fileCount > 0)
                {
                    fileList = new List<T_Planing_File>();
                    int no = 1;
                    int fileType = 0;

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
                        else if (keyName.ToLower().IndexOf("defectfile") > -1)
                        {
                            fileType = 3;
                        }

                        T_Planing_File file = new T_Planing_File();
                        string savedFileName = "";
                        if (fileType != 3)
                        {
                            savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\";
                        }
                        else
                        {
                            savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\";
                            no = Convert.ToInt32(keyName.Split('_')[1]);
                        }

                        file.FullPath = savedFileName + System.IO.Path.GetFileName(context.Request.Files[i].FileName); ;
                        file.DesPath = savedFileName;
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

                dto.ConditionList = removalCondtionList;
                dto.HolidayTest = dto.ConditionList.Count.ToString();

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

        [HttpPost]
        [Route("Delete")]
        public HttpResponseMessage Delete()
        {
            bal = new T_Planing_Action_BFRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_BFRemovalDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();

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
            bal = new T_Planing_Action_BFRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_BFRemovalDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                //context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();

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