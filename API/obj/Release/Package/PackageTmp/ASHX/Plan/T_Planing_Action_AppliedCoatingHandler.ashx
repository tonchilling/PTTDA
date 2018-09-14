<%@ WebHandler Language="C#" Class="T_Planing_Action_AppliedCoatingHandler" %>

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

public class T_Planing_Action_AppliedCoatingHandler : IHttpHandler, IRequiresSessionState
{


    List<T_Planing_Action_AppliedCoatingDTO> list = null;
    UserDTO userDto = null;
    T_Planing_Action_AppliedCoatingDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;
 
    string planPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"] + "/Action/AppliedCoating";
    
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


                    case "View": dto = View(context);
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
        string savedFileName = "";
        string Path = planPath;
        
        dto = new T_Planing_Action_AppliedCoatingDTO();
        dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();
        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        T_Planing_File file = null;
        List<T_Planing_File> fileList = new List<T_Planing_File>();
        List<T_Planing_Action_AppliedCoating_InformationDTO> coatingInfomationList = new List<T_Planing_Action_AppliedCoating_InformationDTO>();
        
        T_Planing_Action_AppliedCoatingBAL bal = new T_Planing_Action_AppliedCoatingBAL();

       
        
        if (context.Request.Form["Action"].ToLower() == "add")
        {

            dto.ID = "";
            dto.PID = "";

            dto.ID = context.Request.Form["ID"];
            dto.PID = context.Request.Form["PID"];

            int no = 1;
            int fileType =1;
            var deserializer = new JavaScriptSerializer();
            fileList = deserializer.Deserialize<List<T_Planing_File>>(context.Request.Form["surfaceList"]);
            coatingInfomationList = deserializer.Deserialize<List<T_Planing_Action_AppliedCoating_InformationDTO>>(context.Request.Form["coatingInfomationList"]);

            if (coatingInfomationList != null)
            {
                foreach (T_Planing_Action_AppliedCoating_InformationDTO coatingDto in coatingInfomationList)
                {
                    coatingDto.InfoType = "1";
                    coatingDto.InfoDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year.ToString());
                
                }
            }
            dto.CoatingInfoList = coatingInfomationList;
            if (context.Request.Files.Count > 0)
            {

                fileType = 1;
                
                savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\";
                
                for (var i = 0; i < context.Request.Files.Count; i++)
                {

                     savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\" + System.IO.Path.GetFileName(context.Request.Files[i].FileName);

                    file = fileList[i];
                    file.FullPath = savedFileName;
                    file.DesPath = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType;
                    file.FileName = System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                    file.FileSize = context.Request.Files[i].ContentLength.ToString();
                    file.UploadDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year);
                   // file.No = no.ToString();
                    file.PID = dto.PID;
                    file.UploadType = fileType.ToString();
                    file.PostFile = context.Request.Files[i];
                   
                    no++;

                    
                  //  fileList.Add(file);
                    
                    
                /*    savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\" + System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                    
                     string keyName = context.Request.Files.GetKey(i);
                    no = Convert.ToInt32(keyName.Split('_')[1]);
                    file = fileList.Find(data => data.No == no.ToString());


                    file.FullPath = savedFileName;
                    file.DesPath = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType;
                    file.FileName = System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                    file.FileSize = context.Request.Files[i].ContentLength.ToString();
                    file.UploadDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year);
                    file.No = no.ToString();
                    file.PID = dto.PID;
                    file.UploadType = fileType.ToString();
                    file.PostFile = context.Request.Files[i];*/
                   // file.Profile = fileList.Find(data => data.No == no.ToString()).Profile;
                 

                    
                   // fileList.Add(file);
                    
                }

                dto.UploadFileList = fileList;

            }
            
         
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
        }
        return result;
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public List<T_Planing_Action_AppliedCoatingDTO> FindByCondition()
    {
        bool result = false;
        List<T_Planing_Action_AppliedCoatingDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();
        dto.ID = "";
        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        T_Planing_Action_AppliedCoatingBAL bal = new T_Planing_Action_AppliedCoatingBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    public T_Planing_Action_AppliedCoatingDTO View(HttpContext context)
    {
        bool result = false;
        List<T_Planing_Action_AppliedCoatingDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_Action_AppliedCoatingDTO>();
        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
       // dto.ID = context.Request.Form["ID"];
        T_Planing_Action_AppliedCoatingBAL bal = new T_Planing_Action_AppliedCoatingBAL();
        dto = bal.FindByPK(dto);

        if (dto != null && dto.CoatingInfoList != null)
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