<%@ WebHandler Language="C#" Class="T_Planing_Action_SiteRecoveryHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Plan;
using DTO.Util;
using BAL.PTT.Plan;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using DTO.PTT.Admin;

public class T_Planing_Action_SiteRecoveryHandler : IHttpHandler, IRequiresSessionState
{


    List<T_Planing_Action_SiteRecoveryDTO> list = null;
    UserDTO userDto = null;
    T_Planing_Action_SiteRecoveryDTO dto = null;
    bool result = false;
    
    JavaScriptSerializer json = null;

    string planPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"] + "/Action/SiteRecovery";

    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "multipart/form-data";
        //  context.Response.Expires = -1;
        string jsonString = "";

        //  context.Response.Write(DateTime.Now.Ticks.ToString());

        if (context.Request.Form.Count > 0)
        {
            userDto = (UserDTO)HttpContext.Current.Session["UserLogin"];

            if (context.Request.Form["Action"] != null)
            {
                switch (context.Request.Form["Action"])
                {
                    case "Add": result = Action(context);
                        break;
                    case "Delete": result = Action(context);
                        break;

                    case "Approve": result = Action(context);
                        break;
                    case "Reject": result = Action(context);
                        break;
                        
                    case "View": dto = View();
                        json = new JavaScriptSerializer();
                        jsonString = json.Serialize(dto);
                        context.Response.Write(jsonString);
                        break;
                        
                    case "Search": list = FindByCondition();
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
        dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();
        var deserializer = new JavaScriptSerializer();
      
        T_Planing_Action_SiteRecoveryBAL bal = new T_Planing_Action_SiteRecoveryBAL();
        T_Planing_File file = null;
        List<T_Planing_File> fileList = new List<T_Planing_File>();

      
        if (context.Request.Form["Action"].ToLower() == "add")
        {


         
            if (context.Request.Files.Count > 0)
            {
              

              
                int no = 1;
                int fileType =1;
                
                
                for (var i = 0; i < context.Request.Files.Count; i++)
                {


                  string keyName =  context.Request.Files.GetKey(i);


                  if (keyName.IndexOf("file1") > -1)
                  {
                      fileType = 1;

                  }
                  else if (keyName.IndexOf("file2") > -1)
                  {
                      fileType = 2;
                  }
                    string Path = planPath;

                    string savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\"+ System.IO.Path.GetFileName(context.Request.Files[i].FileName);

                    file = new T_Planing_File();
                    file.FullPath = savedFileName;
                    file.DesPath = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType;
                    file.FileName = System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                    file.FileSize = context.Request.Files[i].ContentLength.ToString();
                    file.UploadDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year);
                    file.No = no.ToString();
                    file.PID = dto.PID;
                    file.UploadType=fileType.ToString();
                    file.PostFile = context.Request.Files[i];
                    no++;
            
                        fileList.Add(file);
               
                     // context.Request.Files[0].SaveAs(savedFileName);
                }
                dto.UploadFileList = fileList;
              
            }

            dto.CreateBy = userDto.UserID;
            dto.UpdateBy = userDto.UserID;
         
            result = bal.Add(dto);


            if (result)
            {

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

            }
            
            
        }
        else if (context.Request.Form["Action"].ToLower() == "delete")
        {

            result = bal.Delete(dto);
        }  else if (context.Request.Form["Action"].ToLower() == "approve")
        {

        


           if (userDto.RoleLevel == "1")
           {
               dto.Approval1 = userDto.UserID;
               dto.ApproveStatus = userDto.RoleLevel;
               dto.ApprovalDate1 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                  , DateTime.Now.Day.ToString("##00")
                                                   , DateTime.Now.Year.ToString());
           }
           else if (userDto.RoleLevel == "2")
           {

               dto.Approval2= userDto.UserID;
               dto.ApproveStatus = userDto.RoleLevel;
               dto.ApprovalDate2 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                  , DateTime.Now.Day.ToString("##00")
                                                   , DateTime.Now.Year.ToString());
           }

           else if (userDto.RoleLevel == "3" || userDto.RoleLevel == "4" || userDto.RoleLevel == "5")
           {
               dto.Approval3 = userDto.UserID;
               dto.ApproveStatus = "3";
               dto.ApprovalDate3 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                  , DateTime.Now.Day.ToString("##00")
                                                   , DateTime.Now.Year.ToString());
           }

           dto.CreateBy = userDto.UserID;
           dto.UpdateBy = userDto.UserID;
            result = bal.Approve(dto);
        }
        else if (context.Request.Form["Action"].ToLower() == "reject")
        {




            if (userDto.RoleLevel == "1")
            {
                dto.Rejecter = userDto.UserID;
                dto.RejectStatus = userDto.RoleLevel;
              /*  dto.ApprovalDate1 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                   , DateTime.Now.Day.ToString("##00")
                                                    , DateTime.Now.Year.ToString());*/
            }
            else if (userDto.RoleLevel == "2")
            {

                dto.Rejecter = userDto.UserID;
                dto.RejectStatus = userDto.RoleLevel;
              /*  dto.ApprovalDate2 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                   , DateTime.Now.Day.ToString("##00")
                                                    , DateTime.Now.Year.ToString());*/
            }

            else if (userDto.RoleLevel == "3" || userDto.RoleLevel == "4" || userDto.RoleLevel == "5")
            {
                dto.Rejecter = userDto.UserID;
                dto.RejectStatus = "3";
               /* dto.ApprovalDate3 = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00")
                                                   , DateTime.Now.Day.ToString("##00")
                                                    , DateTime.Now.Year.ToString());*/
            }

            dto.CreateBy = userDto.UserID;
            dto.UpdateBy = userDto.UserID;
            result = bal.Reject(dto);
        }
        return result;
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public List<T_Planing_Action_SiteRecoveryDTO> FindByCondition()
    {
        bool result = false;
        List<T_Planing_Action_SiteRecoveryDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();

        T_Planing_Action_SiteRecoveryBAL bal = new T_Planing_Action_SiteRecoveryBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    public T_Planing_Action_SiteRecoveryDTO View()
    {
        bool result = false;
        List<T_Planing_Action_SiteRecoveryDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_Action_SiteRecoveryDTO>();
        dto.CreateBy = userDto.UserID;
        T_Planing_Action_SiteRecoveryBAL bal = new T_Planing_Action_SiteRecoveryBAL();
        dto = bal.FindByPK(dto);

        if (dto != null && dto.UploadFileList != null)
        {

            foreach (var uploadFile in dto.UploadFileList)
            {
                uploadFile.HtmlFile = System.Web.VirtualPathUtility.ToAbsolute(planPath + "/" + dto.PID + "/" + uploadFile.UploadType + "/" + uploadFile.FileName);
            }

        }
        
        return dto;
    }
    
    

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}