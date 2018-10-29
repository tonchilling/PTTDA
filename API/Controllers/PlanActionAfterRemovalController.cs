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
    [RoutePrefix("api/PlanActionAfterRemoval")]
    public class PlanActionAfterRemovalController : ApiController
    {
        Logger logger = new Logger("PlanActionAfterRemovalController");
        string planPath = System.Configuration.ConfigurationManager.AppSettings["AfterRemovalPath"];
        T_Planing_Action_AfterRemovalBAL bal = null;
        [HttpPost]
        [Route("Search")]
        public HttpResponseMessage Search()
        {
            bal = new T_Planing_Action_AfterRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AfterRemovalDTO dto = null;
            List<T_Planing_Action_AfterRemovalDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();

                objList = bal.FindByObjList(dto);

                foreach (T_Planing_Action_AfterRemovalDTO mainDTO in objList)
                {
                    //Find detail and push to main object in list
                    T_Planing_Action_AfterRemovalDTO detailDTO = new T_Planing_Action_AfterRemovalDTO();
                    detailDTO.PID = mainDTO.PID;
                    detailDTO = bal.FindByPK(detailDTO);

                    mainDTO.RepairLength = detailDTO.RepairLength;
                    mainDTO.WallThicknessNumber = detailDTO.WallThicknessNumber;
                    mainDTO.RepairLength = detailDTO.RepairLength;
                    mainDTO.DefectList = detailDTO.DefectList;
                    mainDTO.WallThicknessList = detailDTO.WallThicknessList;
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
            bal = new T_Planing_Action_AfterRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AfterRemovalDTO dto = null;
            List<T_Planing_File> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();

                logger.debug("PlanActionAfterRemovalController SearchAllFiles dto:" + dto.ToString());
                objList = bal.FindAllFiles(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionAfterRemovalController SearchAllFiles error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("SearchAllDefects")]
        public HttpResponseMessage SearchAllDefects()
        {
            bal = new T_Planing_Action_AfterRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AfterRemovalDTO dto = null;
            List<T_Planing_Action_AfterRemoval_DefectDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();

                logger.debug("PlanActionAfterRemovalController SearchAllDefects dto:" + dto.ToString());
                objList = bal.FindAllDefects(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionAfterRemovalController SearchAllDefects error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("SearchAllWallThickness")]
        public HttpResponseMessage SearchAllWallThickness()
        {
            bal = new T_Planing_Action_AfterRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AfterRemovalDTO dto = null;
            List<T_Planing_Action_AfterRemoval_WallThicknessDTO> objList = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();

                logger.debug("PlanActionAfterRemovalController SearchAllWallThickness dto:" + dto.ToString());
                objList = bal.FindAllWallThickness(dto);

                response.statusCode = true;
                response.data = objList;
            }
            catch (Exception ex)
            {
                logger.error("PlanActionAfterRemovalController SearchAllWallThickness error:" + ex.ToString());
                response.statusText = ex.ToString();
            }

            mapMessage = Request.CreateResponse(HttpStatusCode.OK, response);
            return mapMessage;
        }

        [HttpPost]
        [Route("View")]
        public HttpResponseMessage View()
        {
            bal = new T_Planing_Action_AfterRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AfterRemovalDTO dto = null;

            try
            {
                var context = HttpContext.Current;

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();

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
            var deserializer = new JavaScriptSerializer();
            T_Planing_Action_AfterRemovalMobileBAL mobileBal = new T_Planing_Action_AfterRemovalMobileBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_PlaningFileMobileDTO file = null;
            List<T_PlaningFileMobileDTO> fileList = new List<T_PlaningFileMobileDTO>();
            string savedFileName = "";
            T_Planing_Action_AfterRemovalMobileDTO dto = null;
            List<T_Planing_Action_AfterRemoval_DefectMobileDTO> defectList = null;
            List<T_Planing_Action_AfterRemoval_WallThicknessMobileDTO> wallThicknessList = null;

            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustFormExactly<T_Planing_Action_AfterRemovalMobileDTO>();
                string UserID = context.Request.Form["UserID"];
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;
                dto.CreatedBy = UserID;
                dto.UpdatedBy = UserID;
                
                defectList = deserializer.Deserialize<List<T_Planing_Action_AfterRemoval_DefectMobileDTO>>(context.Request.Form["defectInputList"]);
                wallThicknessList = deserializer.Deserialize<List<T_Planing_Action_AfterRemoval_WallThicknessMobileDTO>>(context.Request.Form["wallThicknessInputList"]);
                dto.DefectList = defectList; ;
                dto.WallThicknessList = wallThicknessList;
                
                if (context.Request.Files.Count > 0)
                {
                    int no = 1;
                    int fileType = 0;
                    
                    for (var i = 0; i < context.Request.Files.Count; i++)
                    {
                        string keyName = context.Request.Files.GetKey(i);
                        logger.debug("keyName :" + keyName);
                        
                        fileType = 1;
                        
                        file = new T_PlaningFileMobileDTO();

                        savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\";
                        no = Convert.ToInt32(keyName.Split('_')[1]);
                        
                        file.FullPath = savedFileName + System.IO.Path.GetFileName(context.Request.Files[i].FileName); ;
                        file.DesPath = savedFileName;
                        file.FileName = System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                        file.FileSize = context.Request.Files[i].ContentLength.ToString();
                        file.UploadDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year);
                        file.No = no.ToString();
                        file.PID = dto.PID;
                        file.UploadType = fileType.ToString();
                        file.PostFile = context.Request.Files[i];
                        
                        fileList.Add(file);
                    }
                    dto.UploadFileList = fileList;
                }
                
                dto.DefectNumber = dto.DefectList.Count.ToString();

                logger.debug("PlanActionAfterRemovalController Add dto:" + dto.ToString());
                if (dto.DefectList != null && dto.DefectList.Count > 0)
                {
                    foreach (T_Planing_Action_AfterRemoval_DefectMobileDTO defect in dto.DefectList)
                    {
                        logger.debug("PlanActionAfterRemovalController Add defect:" + defect.ToString());
                    }
                }
                if (dto.WallThicknessList != null && dto.WallThicknessList.Count > 0)
                {
                    foreach (T_Planing_Action_AfterRemoval_WallThicknessMobileDTO wall in dto.WallThicknessList)
                    {
                        logger.debug("PlanActionAfterRemovalController Add WallThickness:" + wall.ToString());
                    }
                }

                response.statusCode = mobileBal.AddFromMobile(dto);
                
                if (response.statusCode)
                {
                    response.statusText = "Success";
                    try {
                        // For new upload
                        if (fileList != null && fileList.Count > 0)
                        {
                            foreach (T_PlaningFileMobileDTO f in fileList)
                            {
                                if (DTO.PTT.Util.FileMng.HaveDirectory(f.DesPath))
                                {
                                    f.PostFile.SaveAs(f.FullPath);
                                }
                            }
                        }

                        // For delete old file
                        if (dto.DeleteDefectFiles != null && dto.DeleteDefectFiles.Length > 0)
                        {
                            foreach (var fileName in dto.DeleteDefectFiles.Split(','))
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
                        response.statusText = "Success but process file error :" + e.ToString();
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
        [Route("Add")]
        public HttpResponseMessage Add()
        {
            var deserializer = new JavaScriptSerializer();
            bal = new T_Planing_Action_AfterRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AfterRemovalDTO dto = null;
            List<T_Planing_Action_AfterRemoval_DefectDTO> defectList = null;
            List<T_Planing_Action_AfterRemoval_WallThicknessDTO> wallThicknessList = null;

            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();
                string UserID = context.Request.Form["UserID"];
                dto.CreateBy = UserID;
                dto.UpdateBy = UserID;
                dto.CreatedBy = UserID;
                dto.UpdatedBy = UserID;

                defectList = deserializer.Deserialize<List<T_Planing_Action_AfterRemoval_DefectDTO>>(context.Request.Form["defectInputList"]);
                wallThicknessList = deserializer.Deserialize<List<T_Planing_Action_AfterRemoval_WallThicknessDTO>>(context.Request.Form["wallThicknessInputList"]);
                dto.DefectList = defectList; ;
                dto.WallThicknessList = wallThicknessList;

                List<T_Planing_File> fileList = null;
                int fileCount = context.Request.Files.Count;
                if (fileCount > 0)
                {
                    int no = 1;
                    int fileType = 0;
                    fileList = new List<T_Planing_File>();

                    for (var i = 0; i < context.Request.Files.Count; i++)
                    {
                        string keyName = context.Request.Files.GetKey(i);
                        fileType = 1;
                        T_Planing_File file = new T_Planing_File();
                        string savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\";
                        no = Convert.ToInt32(keyName.Split('_')[1]);
                        file.FullPath = savedFileName + System.IO.Path.GetFileName(context.Request.Files[i].FileName); ;
                        file.DesPath = savedFileName;
                        file.FileName = System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                        file.FileSize = context.Request.Files[i].ContentLength.ToString();
                        file.UploadDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year);
                        file.No = no.ToString();
                        file.PID = dto.PID;
                        file.UploadType = fileType.ToString();
                        file.PostFile = context.Request.Files[i];

                        fileList.Add(file);
                    }
                    dto.UploadFileList = fileList;
                }

                dto.DefectNumber = dto.DefectList.Count.ToString();

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
                        if (dto.DeleteDefectFiles != null && dto.DeleteDefectFiles.Length > 0)
                        {
                            foreach (var fileName in dto.DeleteDefectFiles.Split(','))
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
            bal = new T_Planing_Action_AfterRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;
            
            T_Planing_Action_AfterRemovalDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();

                logger.debug("Delete dto:" + dto.ToString());
                List<T_Planing_File> fileList = bal.DeleteByKey(dto);

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
        */

        [HttpPost]
        [Route("Delete")]
        public HttpResponseMessage Delete()
        {
            bal = new T_Planing_Action_AfterRemovalBAL();
            ResposeType response = new ResposeType();
            HttpResponseMessage mapMessage = null;

            T_Planing_Action_AfterRemovalDTO dto = null;

            try
            {
                var context = HttpContext.Current;
                context.Response.ContentType = "multipart/form-data";

                dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();

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