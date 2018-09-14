<%@ WebHandler Language="C#" Class="T_Planing_Action_AfterRemovalHandler" %>

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

public class T_Planing_Action_AfterRemovalHandler : IHttpHandler, IRequiresSessionState
{


    List<T_Planing_Action_AfterRemovalDTO> list = null;
    List<T_Planing_Action_AfterRemoval_DefectDTO> defectList = null;
    List<T_Planing_Action_AfterRemoval_WallThicknessDTO> wallThicknessList = null;
    T_Planing_Action_AfterRemovalDTO dto = null;
    bool result = false;
    UserDTO userDto = null;
    JavaScriptSerializer json = null;

    string planPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"] + "/Action/AfterRemoval";

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
        dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();
        string savedFileName = "";
        string Path = planPath;
        T_Planing_Action_AfterRemovalBAL bal = new T_Planing_Action_AfterRemovalBAL();
        T_Planing_File file = null;
        List<T_Planing_File> fileList = new List<T_Planing_File>();

        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        dto.Degree = context.Request.Form["txtDegree"];
        dto.DegreeLength = context.Request.Form["txtDegreeLength"];
        if (context.Request.Form["Action"].ToLower() == "add")
        {

            var deserializer = new JavaScriptSerializer();
            defectList = deserializer.Deserialize<List<T_Planing_Action_AfterRemoval_DefectDTO>>(context.Request.Form["defectInputList"]);
            wallThicknessList = deserializer.Deserialize<List<T_Planing_Action_AfterRemoval_WallThicknessDTO>>(context.Request.Form["wallThicknessInputList"]);
            dto.DefectList = defectList; ;
            dto.WallThicknessList = wallThicknessList;
            // T_Planing_Action_AfterRemoval_ConditionDTO[] defectlist =
            //     (T_Planing_Action_AfterRemoval_ConditionDTO[])json_serializer.DeserializeObject(context.Request.Form["defectList"]);

            // List<>T_Planing_Action_AfterRemoval_ConditionDTO defectlist =  json_serializer.DeserializeObject<T_Planing_Action_AfterRemoval_ConditionDTO>(context.Request.Form["defectList"]);
            if (context.Request.Files.Count > 0)
            {



                int no = 1;
                int fileType =0;


                for (var i = 0; i < context.Request.Files.Count; i++)
                {


                    string keyName =  context.Request.Files.GetKey(i);


                    fileType = 1;




                    file = new T_Planing_File();

                    savedFileName = context.Server.MapPath(planPath) + @"\" + dto.PID + @"\" + fileType + @"\" ;
                    no = Convert.ToInt32(keyName.Split('_')[1]);



                    file.FullPath = savedFileName+ System.IO.Path.GetFileName(context.Request.Files[i].FileName);;
                    file.DesPath = savedFileName;
                    file.FileName = System.IO.Path.GetFileName(context.Request.Files[i].FileName);
                    file.FileSize = context.Request.Files[i].ContentLength.ToString();
                    file.UploadDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString("##00"), DateTime.Now.Day.ToString("##00"), DateTime.Now.Year);
                    file.No = no.ToString();
                    file.PID = dto.PID;
                    file.UploadType=fileType.ToString();
                    file.PostFile = context.Request.Files[i];


                    fileList.Add(file);

                    // context.Request.Files[0].SaveAs(savedFileName);
                }
                dto.UploadFileList = fileList;

            }

            var bytes = Convert.FromBase64String(dto.DefectImgBase64);
            dto.DefectImgUrl =planPath + "/" + dto.PID + "/AFDefect.jpg";

           Utility.HaveDirectory(context.Server.MapPath(planPath + "/" + dto.PID ));
            using (var imgFile=new System.IO.FileStream( context.Server.MapPath(dto.DefectImgUrl),System.IO.FileMode.Create))
            {
                imgFile.Write(bytes,0,bytes.Length);
                imgFile.Flush();

            }

            try
            {
                bytes = null;

                bytes = Convert.FromBase64String(dto.WallThicknessImgBase64);
                dto.WallThicknessImgUrl = planPath + "/" + dto.PID + "/WallThickness.jpg";


                using (var imgFile = new System.IO.FileStream(context.Server.MapPath(dto.WallThicknessImgUrl), System.IO.FileMode.Create))
                {
                    imgFile.Write(bytes, 0, bytes.Length);
                    imgFile.Flush();

                }

            }
            catch (Exception ex)
            {


            }




            dto.DefectNumber = dto.DefectList.Count.ToString();
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
    public List<T_Planing_Action_AfterRemovalDTO> FindByCondition()
    {
        bool result = false;
        List<T_Planing_Action_AfterRemovalDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();
        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        T_Planing_Action_AfterRemovalBAL bal = new T_Planing_Action_AfterRemovalBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }

    public T_Planing_Action_AfterRemovalDTO View()
    {
        bool result = false;
        List<T_Planing_Action_AfterRemovalDTO> objList = null;

        dto = ConvertX.GetReqeustForm<T_Planing_Action_AfterRemovalDTO>();
        dto.CreateBy = userDto.UserID;
        dto.UpdateBy = userDto.UserID;
        T_Planing_Action_AfterRemovalBAL bal = new T_Planing_Action_AfterRemovalBAL();
        dto = bal.FindByPK(dto);

        if (dto != null && dto.DefectList != null)
        {

            foreach (var uploadFile in dto.DefectList)
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