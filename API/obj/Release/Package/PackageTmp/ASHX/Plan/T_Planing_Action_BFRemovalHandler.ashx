<%@ WebHandler Language="C#" Class="T_Planing_Action_BFRemovalHandler" %>

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

public class T_Planing_Action_BFRemovalHandler : IHttpHandler, IRequiresSessionState
{


    List<T_Planing_Action_BFRemovalDTO> list = null;
    List<T_Planing_Action_BFRemoval_ConditionDTO> removalCondtionList = null;
    T_Planing_Action_BFRemovalDTO dto = null;
    bool result = false;
    UserDTO userDto = null;
    JavaScriptSerializer json = null;

    string planPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"] + "/Action/BFRemoval";

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
        dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();
        string savedFileName = "";
        string Path = planPath;
        T_Planing_Action_BFRemovalBAL bal = new T_Planing_Action_BFRemovalBAL();
        T_Planing_File file = null;
        List<T_Planing_File> fileList = new List<T_Planing_File>();

        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        dto.Degree = context.Request.Form["txtDegree"];
        dto.DegreeLength = context.Request.Form["txtDegreeLength"];

        var bytes = Convert.FromBase64String(dto.DefectImg);

        dto.DefectImgUrl =planPath + "/" + dto.PID + "/BFDefect.jpg";
            Utility.HaveDirectory(context.Server.MapPath(planPath + "/" + dto.PID ));
        using (var imgFile=new System.IO.FileStream( context.Server.MapPath(dto.DefectImgUrl),System.IO.FileMode.Create))
        {
            imgFile.Write(bytes,0,bytes.Length);
            imgFile.Flush();
        }
        if (context.Request.Form["Action"].ToLower() == "add")
        {

            var deserializer = new JavaScriptSerializer();
            removalCondtionList = deserializer.Deserialize<List<T_Planing_Action_BFRemoval_ConditionDTO>>(context.Request.Form["defectList"]);


            // T_Planing_Action_BFRemoval_ConditionDTO[] defectlist =
            //     (T_Planing_Action_BFRemoval_ConditionDTO[])json_serializer.DeserializeObject(context.Request.Form["defectList"]);

            // List<>T_Planing_Action_BFRemoval_ConditionDTO defectlist =  json_serializer.DeserializeObject<T_Planing_Action_BFRemoval_ConditionDTO>(context.Request.Form["defectList"]);
            if (context.Request.Files.Count > 0)
            {



                int no = 1;
                int fileType = 0;


                for (var i = 0; i < context.Request.Files.Count; i++)
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




                    file = new T_Planing_File();
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

                    // context.Request.Files[0].SaveAs(savedFileName);
                }
                dto.UploadFileList = fileList;

            }

            dto.ConditionList = removalCondtionList;

            dto.HolidayTest = dto.ConditionList.Count.ToString();
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
        }
        return result;
    }

    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public List<T_Planing_Action_BFRemovalDTO> FindByCondition()
    {
        bool result = false;
        List<T_Planing_Action_BFRemovalDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();

        T_Planing_Action_BFRemovalBAL bal = new T_Planing_Action_BFRemovalBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    public T_Planing_Action_BFRemovalDTO View()
    {
        bool result = false;
        List<T_Planing_Action_BFRemovalDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_Action_BFRemovalDTO>();
        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        T_Planing_Action_BFRemovalBAL bal = new T_Planing_Action_BFRemovalBAL();
        dto = bal.FindByPK(dto);

        if (dto != null && dto.UploadFileList != null)
        {

            foreach (var uploadFile in dto.UploadFileList)
            {
                uploadFile.HtmlFile = System.Web.VirtualPathUtility.ToAbsolute(planPath + "/" + dto.PID + "/" + uploadFile.UploadType + "/" + uploadFile.FileName);
            }

        }

        if (dto != null && dto.ConditionList != null)
        {

            foreach (var uploadFile in dto.ConditionList)
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