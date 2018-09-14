<%@ WebHandler Language="C#" Class="ReportMHandler" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Script;
using DTO.PTT.Master;
using DTO.Util;
using BAL.PTT.Master;
using BAL.PTT.Plan;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Text;
using DTO.PTT.Report;


public class ReportMHandler : IHttpHandler, IRequiresSessionState
{

    T_PlaningBAL bal = null;
    List<M_AssertOwnerDTO> list = null;

    M_AssertOwnerDTO dto = null;
    bool result = false;
    JavaScriptSerializer json = null;
    BAL.PTT.Report.ExportToExcelBAL exportToExcelBAL = null;
    string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "multipart/form-data";
        //  context.Response.Expires = -1;


        //  context.Response.Write(DateTime.Now.Ticks.ToString());

        if (context.Request.Form.Count > 0)
        {

            if (context.Request.Form["Action"] != null)
            {
                switch (context.Request.Form["Action"])
                {
                    case "Search": result = Search(context);


                        break;

                    case "SRReport": result = GetSummaryRepairReport(context);


                        break;

                    case "SumCompletelyReport": result = GetSummaryCompletelyReport(context);


                        break;

                    case "SumOverAllReport": result = GetSummaryPlanOverAllReport(context);


                        break;

                    case "SumRiskReport": result = GetSummaryPlanRiskReport(context);


                        break;




                    case "QRReport": result = GetQuarterlyReport(context);


                        break;


                    case "ExportSummaryPlan": ExportSummaryPlan(context);//Export(context);


                        break;


                    case "ExportSRR": GetDataExportToCSV(context);//Export(context);


                        break;


                    case "ExportQR": GetSummaryCompletelyReport(context);//Export(context);


                        break;






                }
            }
            else
            {



            }
        }
    }

    public bool Search(HttpContext context)
    {
        string jsonString = "";
        json = new JavaScriptSerializer();
        jsonString = json.Serialize(GetSummaryRepairReport(context));
        context.Response.Write(jsonString);

        return true;
    }


    public bool GetDataExportToCSV(HttpContext context)
    {
        string jsonString = "";
        json = new JavaScriptSerializer();
        jsonString = json.Serialize(GetSummaryRepairReport(context));
        context.Response.Write(jsonString);

        return true;
    }







    public bool GetSummaryRepairReportOld(HttpContext context)
    {
        List<SummaryRepaireDTO> resultList = new List<SummaryRepaireDTO>();


        bal = new T_PlaningBAL();
        SummaryRepaireDTO dto = ConvertX.GetReqeustForm<SummaryRepaireDTO>();

        resultList = bal.GetReportSummaryRepaireObjList(dto);


        string jsonString = "";
        json = new JavaScriptSerializer();
        jsonString = json.Serialize(resultList);
        context.Response.Write(jsonString);


        return true;

    }


    public bool GetSummaryRepairReport(HttpContext context)
    {
        SummaryRepaireAll resultList = new SummaryRepaireAll();


        bal = new T_PlaningBAL();
        SummaryRepaireDTO dto = ConvertX.GetReqeustRealForm<SummaryRepaireDTO>();

        resultList = bal.GetReportSummaryRepaireTableAndGraph(dto);


        string jsonString = "";
        json = new JavaScriptSerializer();
        jsonString = json.Serialize(resultList);
        context.Response.Write(jsonString);


        return true;

    }


    public bool GetQuarterlyReport(HttpContext context)
    {
        List<QuaterlyReportDTO> resultList = new List<QuaterlyReportDTO>();


        bal = new T_PlaningBAL();
        QuaterlyReportDTO dto = ConvertX.GetReqeustForm<QuaterlyReportDTO>();

        resultList = bal.GetReportQuaterlyObjList(dto);

        string jsonString = "";
        json = new JavaScriptSerializer();
        jsonString = json.Serialize(resultList);
        context.Response.Write(jsonString);

        return true;

    }

    public bool GetSummaryCompletelyReport(HttpContext context)
    {
        List<ColumnReportDTO> resultList = new List<ColumnReportDTO>();
        SummaryPlanReport result = new SummaryPlanReport();

        bal = new T_PlaningBAL();
        SearchDTO dto = ConvertX.GetReqeustForm<SearchDTO>();

        //   resultList = bal.GetReportSummaryPlanObjList(dto);
        result = bal.GetReportSummaryCompletelyObjList(dto);
        string jsonString = "";
        json = new JavaScriptSerializer();
        jsonString = json.Serialize(result);
        context.Response.Write(jsonString);

        return true;

    }


    public bool GetSummaryPlanOverAllReport(HttpContext context)
    {
        List<DonutGraphReportDTO> resultList = new List<DonutGraphReportDTO>();
        SummaryPlanReport result = new SummaryPlanReport();

        bal = new T_PlaningBAL();
        SearchDTO dto = ConvertX.GetReqeustForm<SearchDTO>();

        //   resultList = bal.GetReportSummaryPlanObjList(dto);
        result = bal.GetReportSummaryPlanOverAllObjList(dto);
        string jsonString = "";
        json = new JavaScriptSerializer();
        jsonString = json.Serialize(result);
        context.Response.Write(jsonString);

        return true;

    }


    public bool GetSummaryPlanRiskReport(HttpContext context)
    {
        List<ColumnReportDTO> resultList = new List<ColumnReportDTO>();
        SummaryPlanReport result = new SummaryPlanReport();

        bal = new T_PlaningBAL();
        SearchDTO dto = ConvertX.GetReqeustForm<SearchDTO>();

        //   resultList = bal.GetReportSummaryPlanObjList(dto);
        result = bal.GetReportSummaryPlanRiskObjList(dto);
        string jsonString = "";
        json = new JavaScriptSerializer();
        jsonString = json.Serialize(result);
        context.Response.Write(jsonString);

        return true;

    }



    public void ExportSummaryPlan(HttpContext context)
    {

        SummaryPlanReport result = new SummaryPlanReport();
        bal = new T_PlaningBAL();
        SearchDTO dto = ConvertX.GetReqeustForm<SearchDTO>();

        result = bal.GetReportSummaryPlanOverAllObjList(dto);
        exportToExcelBAL = new BAL.PTT.Report.ExportToExcelBAL();
        byte[] bytes = exportToExcelBAL.ExportSummaryPlanToExcel(result,desPath,"SummaryPlanReport.xlsx");
        if (bytes != null)
        {
            context.Response.Clear();

            context.Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            context.Response.AddHeader("Content-Disposition", "attachment; filename=SummaryPlanReport.xlsx");
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();

            HttpContext.Current.ApplicationInstance.CompleteRequest();

            context.Response.Close();
            context.Response.End();



        }
    }




    public void ExportTest(HttpContext context)
    {

        byte[] bytes = Encoding.UTF8.GetBytes("tst,tt");
        if (bytes != null)
        {
            context.Response.Clear();
            context.Response.End();
            context.Response.ContentType = "text/csv";
            context.Response.AddHeader("Content-Length", bytes.Length.ToString());
            context.Response.AddHeader("Content-disposition", "attachment; filename=\"sample.csv" + "\"");
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();

        }
    }



    /// <summary>
    /// Insert / Update Account
    /// </summary>
    /// <returns></returns>
    public bool Action(HttpContext context)
    {
        bool result = false;
        dto = ConvertX.GetReqeustForm<M_AssertOwnerDTO>();

        //  dto.PositionPSI = context.Request.Form["selectPosition"].ToString();
        M_AssertOwnerBAL bal = new M_AssertOwnerBAL();

        if (context.Request.Form["Action"].ToLower() == "add")
        {
            //  dto.MENUGROUP_OID = context.Request.Form["selectMENUGROUP"].ToString();
            result = bal.Add(dto);
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
    public List<M_AssertOwnerDTO> FindByCondition()
    {
        bool result = false;
        List<M_AssertOwnerDTO> objList = null;

        dto = ConvertX.GetReqeustForm<M_AssertOwnerDTO>();

        M_AssertOwnerBAL bal = new M_AssertOwnerBAL();
        objList = bal.FindByObjList(dto);
        return objList;
    }




    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}