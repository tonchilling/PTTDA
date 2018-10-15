using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DooPdfMerge;
using System.IO;
using System.Text;
using DTO.PTT.Report;
using DTO.PTT.Plan;
using DTO.Util;
using BAL.PTT.Plan;
using DTO.PTT.Admin;

public partial class UI_Report_MReport : System.Web.UI.Page
{
    PdfMerge mergePDF = null;
    T_PlaningBAL planBAL = null;
    TPlaningAllDTO planReportAllDTO = null;
    MemoryStream stream;
    UserDTO UserLOGIN = null;
    CrystalDecisions.CrystalReports.Engine.ReportDocument report = null;


    string reportType = "";
    string planPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];
    string actionPath = System.Configuration.ConfigurationManager.AppSettings["UploadAction"];
    string planOverAll = System.Configuration.ConfigurationManager.AppSettings["UploadOverAll"];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            UserLOGIN = AppConfig.GetUserLogin();

            //  Export();
            // ReportDocument crystalReport = new ReportDocument();
            //ExportReport(crystalReport);
            //  ReportDocument crystalReport = new ReportDocument();
            //  BindReport(crystalReport);


            reportType = Request.QueryString["RPTType"] != null ? Request.QueryString["RPTType"] : "";


            switch (reportType.ToLower())
            {

                case "exportplan": ExportPlanToExcel(); break;
                case "report1_overallprogress": ExportOverAllToExcel(); break;
                case "report1_summarycomplete": ExportSummaryCompletelyToExcel(); break;
                case "report1_summaryrisk": ExportSummaryRiskToExcel(); break;
                case "report2_summaryrepaire": ExportSummaryRepaireToExcel(); break;
                default: PDFMerge(); break;
            }

        }
    }

    void ExportPlan()
    {

        stream = new MemoryStream();

        DataTable exportPlanDT = null;
        DataTable exportPlanSubDT = null;

        planBAL = new T_PlaningBAL();

        try
        {
            
            report = new ReportDocument();

            T_PlaningDTO requestObj = new T_PlaningDTO();
            requestObj.CreateBy = UserLOGIN.UserID;
            requestObj.UpdateBy = UserLOGIN.UserID;
            requestObj.Year = "2018";
            exportPlanDT = DTO.Util.Utility.ToDataTable(planBAL.ExportPlan(requestObj));

            //48
            int specNumber = 0, poNumber = 0, actionNumber = 0;
            foreach (DataRow dr in exportPlanDT.Rows)
            {
                specNumber = Convert.ToInt32(dr["SpecWeeks"].ToString()) + 47;
                poNumber = Convert.ToInt32(dr["POWeeks"].ToString()) + specNumber;
                actionNumber = Convert.ToInt32(dr["ActionWeeks"].ToString()) + poNumber;

                if (Convert.ToInt32(dr["SpecWeeks"].ToString()) > 0)
                    dr[specNumber] = "22";


                if (Convert.ToInt32(dr["POWeeks"].ToString()) > 0)
                    dr[poNumber] = "33";

                if (Convert.ToInt32(dr["ActionWeeks"].ToString()) > 0)
                    dr[actionNumber] = "44";

            }
            exportPlanDT.TableName = "ExportPlan1";
            report = new ReportDocument();
            report.Load(Server.MapPath("~/UI/Report/RPT/ExportPlan.rpt"));
            //report.Load(Server.MapPath(@"~\UI\Report/RPT/ExportPlan.rpt"));

            /*   exportPlanDT = new DataTable();
               exportPlanDT.TableName = "ExportPlan1";
               exportPlanDT.Columns.Add("StartEndPipeline");
                exportPlanDT.Columns.Add("RouteCode");
                DataRow dr = exportPlanDT.NewRow();
                dr[0] = "DISTRIBUTION";
                dr[1] = "RC04022101";
                exportPlanDT.Rows.Add(dr);*/



            report.SetDataSource(exportPlanDT);

            if (report.Subreports.Count > 0)
            {


                exportPlanSubDT = exportPlanDT.Copy();
                exportPlanSubDT.TableName = "ExportPlan";
                /* exportPlanSubDT = new DataTable();
                 exportPlanSubDT.TableName = "ExportPlanSub1";

                 exportPlanSubDT.Columns.Add("StartEndPipeline");
                 exportPlanSubDT.Columns.Add("RouteCode");
                  dr = exportPlanSubDT.NewRow();
                 dr[0] = "DISTRIBUTION";
                 dr[1] = "RC04022101";
                 exportPlanSubDT.Rows.Add(dr);*/
                //  report.OpenSubreport("ExportPlanSub").SetDataSource(ds.Tables[1]);

                report.Subreports[0].Database.Tables[0].SetDataSource(exportPlanSubDT.DefaultView);

            }


            //  report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

            // System.IO.Stream tempStream =report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            System.IO.Stream tempStream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            tempStream.CopyTo(stream);

            byte[] output = stream.ToArray(); // simpler way of converting to array
            stream.Close();

            Response.ClearHeaders();

            //   Response.ContentType = "application/pdf";
            Response.ContentType = "application/vnd.ms-excel";

            Response.AddHeader("Content-Disposition",
                "attachment;filename=\"InspectionAll.xls\"");
            Response.BinaryWrite(output);
            Response.End();
        }
        catch (Exception e)
        {

           // Label1.Text = e.Message + "--" + e.StackTrace;
        }
        finally
        {

            report.Close();
            report.Dispose();

        }


    }




    #region Export to Excel
    public void ExportOverAllToExcel()
    {

        SummaryPlanReport result = new SummaryPlanReport();
        planBAL = new T_PlaningBAL();
        SearchDTO dto = ConvertX.GetFromQueryString<SearchDTO>();
        string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

        try
        {
            result = planBAL.GetReportSummaryPlanOverAllObjList(dto);
            BAL.PTT.Report.ExportToExcel2BAL exportToExcelBAL = new BAL.PTT.Report.ExportToExcel2BAL();
            string filename = string.Format("OverAllProgress{0}.xlsx", DateTime.Now.ToString("ddMMyyHHmmss"));
            byte[] bytes = exportToExcelBAL.ExportOverAllReportToExcel(result, desPath, filename);
            if (bytes != null)
            {
                Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();



            }
        }
        catch (Exception ex)
        {
           // Label1.Text = ex.ToString() + "--" + ex.StackTrace;
        }
        finally
        {

        }
    }


    public void ExportSummaryCompletelyToExcel()
    {

        /*  SummaryPlanReport result = new SummaryPlanReport();
          planBAL = new T_PlaningBAL();
          SearchDTO dto = ConvertX.GetFromQueryString<SearchDTO>();
          string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

          try
          {
              //GetReportSummaryPlanAllObjList
              result = planBAL.GetReportSummaryCompletelyObjList(dto);
              BAL.PTT.Report.ExportToExcelBAL exportToExcelBAL = new BAL.PTT.Report.ExportToExcelBAL();
              byte[] bytes = exportToExcelBAL.ExportSummaryCompletelyToExcel(result, desPath, "SummaryCompletelyReport.xlsx");
              if (bytes != null)
              {
                  Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                  Response.AddHeader("Content-Disposition", "attachment; filename=SummaryCompletelyReport.xlsx");
                  Response.BinaryWrite(bytes);
                  Response.Flush();
                  Response.End();



              }
          }
          catch (Exception ex)
          {
              Label1.Text = ex.ToString() + "--" + ex.StackTrace;
          }
          finally
          {

          }*/

        SummaryPlanReport result = new SummaryPlanReport();
        planBAL = new T_PlaningBAL();
        SearchDTO dto = ConvertX.GetFromQueryString<SearchDTO>();
        string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

        try
        {
            result = planBAL.GetReportSummaryCompletelyObjList(dto);
            BAL.PTT.Report.ExportToExcel2BAL exportToExcelBAL = new BAL.PTT.Report.ExportToExcel2BAL();
            string filename = string.Format("SummaryCompletely{0}.xlsx", DateTime.Now.ToString("ddMMyyHHmmss"));
            byte[] bytes = exportToExcelBAL.ExportSummaryCompletelyToExcel(result, desPath, filename, dto);
            if (bytes != null)
            {
                Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
           // Label1.Text = ex.ToString() + "--" + ex.StackTrace;
        }
        finally
        {

        }
    }


    public void ExportSummaryRiskToExcel()
    {

        /*  SummaryPlanReport result = new SummaryPlanReport();
          planBAL = new T_PlaningBAL();
          SearchDTO dto = ConvertX.GetFromQueryString<SearchDTO>();
          string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

          try
          {
              //GetReportSummaryPlanAllObjList
              result = planBAL.GetReportSummaryPlanRiskObjList(dto);
              BAL.PTT.Report.ExportToExcelBAL exportToExcelBAL = new BAL.PTT.Report.ExportToExcelBAL();
              byte[] bytes = exportToExcelBAL.ExportSummaryRiskToExcel(result, desPath, "SummaryRiskReport.xlsx");
              if (bytes != null)
              {
                  Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                  Response.AddHeader("Content-Disposition", "attachment; filename=SummaryRiskReport.xlsx");
                  Response.BinaryWrite(bytes);
                  Response.Flush();
                  Response.End();



              }
          }
          catch (Exception ex)
          {
              Label1.Text = ex.ToString() + "--" + ex.StackTrace;
          }
          finally
          {

          }*/

        SummaryPlanReport result = new SummaryPlanReport();
        planBAL = new T_PlaningBAL();
        SearchDTO dto = ConvertX.GetFromQueryString<SearchDTO>();
        string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

        try
        {
            result = planBAL.GetReportSummaryPlanRiskObjList(dto);
            BAL.PTT.Report.ExportToExcel2BAL exportToExcelBAL = new BAL.PTT.Report.ExportToExcel2BAL();
            string filename = string.Format("SummaryRisk{0}.xlsx", DateTime.Now.ToString("ddMMyyHHmmss"));
            byte[] bytes = exportToExcelBAL.ExportSummaryRiskReportToExcel(result, desPath, filename, dto);
            if (bytes != null)
            {
                Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
           // Label1.Text = ex.ToString() + "--" + ex.StackTrace;
        }
        finally
        {

        }
    }



    public void ExportSummaryRepaireToExcel()
    {

        /*   SummaryRepaireAll result = new SummaryRepaireAll();
           planBAL = new T_PlaningBAL();
           SearchDTO dto = ConvertX.GetFromQueryString<SearchDTO>();
           string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

           try
           {
               //GetReportSummaryPlanAllObjList
               result = planBAL.GetReportSummaryRepaireTableAndGraph(dto);
               BAL.PTT.Report.ExportToExcelBAL exportToExcelBAL = new BAL.PTT.Report.ExportToExcelBAL();
               byte[] bytes = exportToExcelBAL.ExportSummaryRepaireToExcel(result, desPath, "SummaryRepaireReport.xlsx");
               if (bytes != null)
               {
                   Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                   Response.AddHeader("Content-Disposition", "attachment; filename=SummaryRepaireReport.xlsx");
                   Response.BinaryWrite(bytes);
                   Response.Flush();
                   Response.End();



               }
           }
           catch (Exception ex)
           {
               Label1.Text = ex.ToString() + "--" + ex.StackTrace;
           }
           finally
           {

           }*/

        try
        {
            SummaryRepaireAll resultList = new SummaryRepaireAll();

            planBAL = new T_PlaningBAL();
            SummaryRepaireDTO dto = ConvertX.GetReqeustRealForm<SummaryRepaireDTO>();

            resultList = planBAL.GetReportSummaryRepaireTableAndGraph(dto);

            string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

            BAL.PTT.Report.ExportToExcel2BAL exportToExcelBAL = new BAL.PTT.Report.ExportToExcel2BAL();
            string filename = string.Format("SummaryRepaire{0}.xlsx", DateTime.Now.ToString("ddMMyyHHmmss"));
            byte[] bytes = exportToExcelBAL.ExportSummaryRepaireToExcel(resultList, desPath, filename);
            if (bytes != null)
            {
                Response.AddHeader("Content-Type", "application/vnd.ms-excel");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
           // Label1.Text = ex.ToString() + "--" + ex.StackTrace;
        }
        finally
        {

        }
    }



    void ExportPlanToExcel()
    {

        string path = "";
        string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

        T_PlaningDTO requestObj = new T_PlaningDTO();
        T_PlaningBAL planBAL = null;
        planBAL = new T_PlaningBAL();


        try
        {
            requestObj = ConvertX.GetFromQueryString<T_PlaningDTO>();
            requestObj.CreateBy = UserLOGIN.UserID;
            requestObj.UpdateBy = UserLOGIN.UserID;
            string filename = string.Format("ExportPlan_{0}.xlsx", DateTime.Now.ToString("ddMMyyHHmmss"));
            Byte[] b = planBAL.ExportPlanForExcel(requestObj, desPath, filename);




            //Send output stream to client window
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.BinaryWrite(b);
            Response.Flush();
            Response.End();

        }
        catch (Exception ex)
        {
          //  Label1.Text = ex.ToString() + "--" + ex.StackTrace;
        }
        finally
        {

        }
    }


    #endregion

    private void PDFMerge()
    {
        stream = new MemoryStream();

        FileStream fs = null;
        string fileName = "";
        string pdfName = "";
        string PID = "";
        FileStream fsObj;

        string msg = "";
        DataTable dtPlaningFile = null;
        DataSet ds = null;

        planBAL = new T_PlaningBAL();



        try
        {
            PID = Request.QueryString["PID"] != null ? Request.QueryString["PID"] : "PID";

            planReportAllDTO = planBAL.GetInspectionPlanAll(PID, planPath, actionPath);

            report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            string strDate = string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString("##00"));
            string strDateTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
            string urlPath = string.Format("{0}/{1}/{2}", planOverAll, strDate, PID);
            string rootPath = "";
            rootPath = string.Format("{0}/{1}/{2}", planOverAll
                                                        , string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString("##00"))
                                                          , PID);




            Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));

            Utility.DeleteAllFile(this.Server.MapPath(string.Format(rootPath)));


            if (planReportAllDTO != null)
            {

                #region TPlaing
                /*  DataRow dr;
                     dtPlaning = new DataTable("TPlaning");
                     dtPlaningFile = new DataTable("TPlaning_File");

                    dtPlaning.Columns.Add("PID");
                    dtPlaningFile.Columns.Add("PID");
                    dtPlaningFile.Columns.Add("File", typeof(byte[]));
                    dtPlaningFile.Columns.Add("File1", typeof(byte[]));
                    dtPlaningFile.Columns.Add("File2", typeof(byte[]));
                    dtPlaningFile.Columns.Add("File3", typeof(byte[]));
                    dtPlaningFile.Columns.Add("File4", typeof(byte[]));

                    dr = dtPlaning.NewRow();
                    dr["PID"] = "1";
                    dtPlaning.Rows.Add(dr);

                    dr = dtPlaningFile.NewRow();
                    dr["PID"] = "1";
                    dr["File1"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\img1.jpg"));
                    dr["File2"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\img3.jpg"));
                    dr["File3"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\gasflow.png"));
                    dtPlaningFile.Rows.Add(dr);
                    */



                report = new ReportDocument();
                report.Load(Server.MapPath("~/UI/Report/RPT/TPlaning.rpt"));

                report.SetDataSource(planReportAllDTO.T_PlaningDT);
                if (report.Subreports.Count > 0 && planReportAllDTO.T_Planing_FilesDT != null)
                {

                    foreach (DataRow drTemp in planReportAllDTO.T_Planing_FilesDT.Rows)
                    {
                        if (planReportAllDTO.T_Planing_FilesDT.Columns.Count >= 3 && drTemp["FileName1"] != null)
                        {
                            drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                        }

                        if (planReportAllDTO.T_Planing_FilesDT.Columns.Count > 4 && drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                        {
                            drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                        }


                        if (planReportAllDTO.T_Planing_FilesDT.Columns.Count > 5 && drTemp["FileName3"] != null)
                        {
                            drTemp["File3"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName3"].ToString()));
                        }


                        if (planReportAllDTO.T_Planing_FilesDT.Columns.Count > 6 && drTemp["FileName4"] != null)
                        {
                            drTemp["File4"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName4"].ToString()));
                        }

                    }
                    report.Subreports["TPlaingFile.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_FilesDT);

                }
                report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                fileName = string.Format("1Planing{0}.pdf", strDateTime);
                pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                Utility.DeleteFile(pdfName);
                fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                fsObj.Close();


                if (report != null)
                {
                    report.Close();
                    report.Dispose();
                }


                #endregion

                msg += "TPlaning";


                #region Site Survey



                if (planReportAllDTO.T_Planing_SiteSurveyDT != null && planReportAllDTO.T_Planing_SiteSurveyDT.Rows.Count > 0)
                {

                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/SiteSurvey.rpt"));
                    report.SetDataSource(planReportAllDTO.T_Planing_SiteSurveyDT);
                    if (report.Subreports.Count > 0
                         && planReportAllDTO.T_Planing_SiteSurvey_File1DT != null
                         && planReportAllDTO.T_Planing_SiteSurvey_File1DT.Rows.Count > 0)
                    {

                        foreach (DataRow drTemp in planReportAllDTO.T_Planing_SiteSurvey_File1DT.Rows)
                        {
                            if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                            {
                                drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                            }

                            if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                            {
                                drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                            }

                        }


                        foreach (DataRow drTemp in planReportAllDTO.T_Planing_SiteSurvey_File2DT.Rows)
                        {
                            if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                            {
                                drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                            }

                            if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                            {
                                drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                            }

                        }


                        report.Subreports["TPlaingFile.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_SiteSurvey_File1DT);
                        report.Subreports["TPlaingFile2.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_SiteSurvey_File2DT);

                    }
                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("2PlaningSiteSurvey{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }
                }

                #endregion
                msg += "/SiteSurvey";

                #region Site Prepairation



                if (planReportAllDTO.T_Planing_SitePreparationDT != null && planReportAllDTO.T_Planing_SitePreparationDT.Rows.Count > 0)
                {
                    #region Backup

                    /*   dtSitePreparationUnderground = new DataTable("SitePreparation_under");
                    dtPlaning = new DataTable("TPlaning");
                    dtPlaningFile = new DataTable("TPlaning_File");


                    dtPlaning.Columns.Add("PID");
                    dtPlaningFile.Columns.Add("PID");
                    dtPlaningFile.Columns.Add("File", typeof(byte[]));
                    dtPlaningFile.Columns.Add("File1", typeof(byte[]));
                    dtPlaningFile.Columns.Add("File2", typeof(byte[]));
                    dtPlaningFile.Columns.Add("File3", typeof(byte[]));
                    dtPlaningFile.Columns.Add("File4", typeof(byte[]));

                    dtSitePreparationUnderground.Columns.Add("PID");
                    dtSitePreparationUnderground.Columns.Add("chkFile", typeof(byte[]));
                    dtSitePreparationUnderground.Columns.Add("chkSubFile", typeof(byte[]));
                    dtSitePreparationUnderground.Columns.Add("Caption");
                    dtSitePreparationUnderground.Columns.Add("SubCaption");
                    dtSitePreparationUnderground.Columns.Add("SubCaptionText");



                    dr = dtPlaning.NewRow();
                    dr["PID"] = "1";
                    dtPlaning.Rows.Add(dr);

                    dr = dtPlaningFile.NewRow();
                    dr["PID"] = "1";
                    dr["File1"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\ptt1.jpg"));


                    dtPlaningFile.Rows.Add(dr);


                    dr = dtSitePreparationUnderground.NewRow();
                    dr["PID"] = "1";
                    dr["chkFile"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\chkbox.jpg"));
                    dr["Caption"] = "Foc";
                    dtSitePreparationUnderground.Rows.Add(dr);

                    dr = dtSitePreparationUnderground.NewRow();
                    dr["PID"] = "1";
                    dr["chkFile"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\unchkbox.jpg"));
                    dr["Caption"] = "Other Utility";

                    dtSitePreparationUnderground.Rows.Add(dr);

                    dr = dtSitePreparationUnderground.NewRow();
                    dr["PID"] = "1";
                    dr["chkSubFile"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\unchkbox.jpg"));
                    dr["SubCaption"] = "Pipeline";
                    dr["SubCaptionText"] = "";
                    dtSitePreparationUnderground.Rows.Add(dr);

                    dr = dtSitePreparationUnderground.NewRow();
                    dr["PID"] = "1";
                    dr["chkSubFile"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\chkbox.jpg"));
                    dr["SubCaption"] = "Other";
                    dr["SubCaptionText"] = "text box";
                    dtSitePreparationUnderground.Rows.Add(dr);



                    dr = dtSitePreparationUnderground.NewRow();
                    dr["PID"] = "1";
                    dr["chkFile"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\chkbox.jpg"));
                    dr["Caption"] = "Other";
                    dtSitePreparationUnderground.Rows.Add(dr);*/
                    #endregion
                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/SitePreparation.rpt"));
                    report.SetDataSource(planReportAllDTO.T_Planing_SitePreparationDT);
                    if (report.Subreports.Count > 0
                          && planReportAllDTO.T_Planing_SitePreparation_FileDT != null
                          && planReportAllDTO.T_Planing_SitePreparation_FileDT.Rows.Count > 0)
                    {

                        foreach (DataRow drTemp in planReportAllDTO.T_Planing_SitePreparation_FileDT.Rows)
                        {
                            if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                            {
                                drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                            }

                            if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                            {
                                drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                            }


                            if (drTemp["FileName3"] != null && drTemp["FileName3"].ToString() != "")
                            {
                                drTemp["File3"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName3"].ToString()));
                            }
                            if (drTemp["FileName4"] != null && drTemp["FileName4"].ToString() != "")
                            {
                                drTemp["File4"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName4"].ToString()));
                            }



                        }


                        report.Subreports["TPlaingFile.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_SitePreparation_FileDT);





                        if (planReportAllDTO.T_Planing_SitePreparation_UnderDT != null && planReportAllDTO.T_Planing_SitePreparation_UnderDT.Rows.Count > 0)
                        {
                            DataTable tempSitePreparation = planReportAllDTO.T_Planing_SitePreparation_UnderDT.Clone();
                            DataRow drTemp2;
                            DataView dv = new DataView(planReportAllDTO.T_Planing_SitePreparation_UnderDT);
                            dv.RowFilter = "ParentUID is null";



                            DataView dvSub = null;

                            foreach (DataRowView drr in dv)
                            {
                                drTemp2 = tempSitePreparation.NewRow();


                                drTemp2["UID"] = drr["UID"];
                                drTemp2["ParentUID"] = drr["ParentUID"];
                                drTemp2["IschkFile"] = drr["IschkFile"];
                                drTemp2["Caption"] = drr["Caption"];
                                drTemp2["IschkSubFile"] = drr["IschkSubFile"];
                                drTemp2["SubCaption"] = drr["SubCaption"];
                                drTemp2["SubCaptionText"] = drr["subCaptionText"];

                                drTemp2["chkFile"] = drr["chkFile"];
                                drTemp2["chkFileName"] = drr["chkFileName"];

                                drTemp2["chkSubFile"] = drr["chkSubFile"];
                                drTemp2["chkSubFileName"] = drr["chkSubFileName"];

                                tempSitePreparation.Rows.Add(drTemp2);

                                dvSub = new DataView(planReportAllDTO.T_Planing_SitePreparation_UnderDT);
                                dvSub.RowFilter = string.Format("ParentUID='{0}'", drTemp2["UID"]);

                                if (dvSub.Count > 0)
                                {
                                    foreach (DataRowView drSub in dvSub)
                                    {
                                        drTemp2 = tempSitePreparation.NewRow();


                                        drTemp2["UID"] = drSub["UID"];
                                        drTemp2["ParentUID"] = drSub["ParentUID"];
                                        drTemp2["IschkFile"] = drSub["IschkFile"];
                                        drTemp2["Caption"] = drSub["Caption"];
                                        drTemp2["IschkSubFile"] = drSub["IschkSubFile"];
                                        drTemp2["SubCaption"] = drSub["SubCaption"];
                                        drTemp2["SubCaptionText"] = drSub["subCaptionText"];
                                        drTemp2["chkFile"] = drSub["chkFile"];
                                        drTemp2["chkFileName"] = drSub["chkFileName"];
                                        drTemp2["chkSubFile"] = drSub["chkSubFile"];
                                        drTemp2["chkSubFileName"] = drSub["chkSubFileName"];
                                        tempSitePreparation.Rows.Add(drTemp2);

                                    }

                                }

                            }



                            tempSitePreparation.TableName = "SitePreparation_under";

                            foreach (DataRow drTemp in tempSitePreparation.Rows)
                            {
                                if (drTemp["chkFileName"] != null && drTemp["chkFileName"].ToString() != "")
                                {
                                    drTemp["chkFile"] = Utility.GetByteArray(this.Server.MapPath(drTemp["chkFileName"].ToString()));
                                }

                                if (drTemp["chkSubFileName"] != null && drTemp["chkSubFileName"].ToString() != "")
                                {
                                    drTemp["chkSubFile"] = Utility.GetByteArray(this.Server.MapPath(drTemp["chkSubFileName"].ToString()));
                                }
                            }



                            report.Subreports["SitePreparation_under.rpt"].Database.Tables[0].SetDataSource(tempSitePreparation);
                        }

                    }
                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("3PlaningSitePreparation{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }
                }

                #endregion
                msg += "/SitePrepaireation";

                #region Weather Collection

                DataTable dtWeatherCollection = new DataTable("WeatherCollection");




                if (planReportAllDTO.T_Planing_WeatherCollectionDT != null && planReportAllDTO.T_Planing_WeatherCollectionDT.Rows.Count > 0)

                {

                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/WeaterCollection.rpt"));
                    report.SetDataSource(planReportAllDTO.T_Planing_WeatherCollectionDT);

                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("4WeaterCollection{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }

                }
                #endregion


                msg += "/WeatherCollection";
                #region Before Coating Removal

                DataTable dtBeforCoatinRemoval = null;




                if (planReportAllDTO.T_Planing_BFRemovalDT != null && planReportAllDTO.T_Planing_BFRemovalDT.Rows.Count > 0)

                {


                    dtBeforCoatinRemoval = planReportAllDTO.T_Planing_BFRemovalDT.Copy();


                    dtBeforCoatinRemoval.Columns.Add("BFImg", typeof(byte[]));


                    dtBeforCoatinRemoval.Rows[0]["BFImg"] = Utility.GetByteArray(this.Server.MapPath(dtBeforCoatinRemoval.Rows[0]["DefectImgUrl"].ToString()));


                    if (planReportAllDTO.T_Planing_BFRemoval_ConditionDT != null && planReportAllDTO.T_Planing_BFRemoval_ConditionDT.Rows.Count > 0)
                    {
                        foreach (DataRow drTemp in planReportAllDTO.T_Planing_BFRemoval_ConditionDT.Rows)
                        {
                            drTemp["File"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName"].ToString()));
                        }
                    }



                    ds = new DataSet();

                    ds.Tables.Add(dtBeforCoatinRemoval);
                    ds.Tables.Add(planReportAllDTO.T_Planing_BFRemoval_ConditionDT);

                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/BeforeCoatingRemoval.rpt"));
                    report.SetDataSource(ds);
                    if (report.Subreports.Count > 0
                        && planReportAllDTO.T_Planing_BFRemoval_File1DT != null
                        && planReportAllDTO.T_Planing_BFRemoval_File1DT.Rows.Count > 0)
                    {

                        foreach (DataRow drTemp in planReportAllDTO.T_Planing_BFRemoval_File1DT.Rows)
                        {
                            if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                            {
                                drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                            }

                            if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                            {
                                drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                            }

                        }


                        if (planReportAllDTO.T_Planing_BFRemoval_File2DT != null
                        && planReportAllDTO.T_Planing_BFRemoval_File2DT.Rows.Count > 0)
                        {
                            foreach (DataRow drTemp in planReportAllDTO.T_Planing_BFRemoval_File2DT.Rows)
                            {
                                if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                                {
                                    drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                                }

                                if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                                {
                                    drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                                }

                            }
                        }


                        report.Subreports["TPlaingFile.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_BFRemoval_File1DT);
                        report.Subreports["TPlaingFile2.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_BFRemoval_File2DT);

                    }
                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("5BeforeCoatingRemoval{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }
                }

                #endregion

                msg += "/BeforeCoatingRemoval";

                #region After Coating Removal

                DataTable dtAfterCoatinRemoval = null;
                DataTable dtAfterCoatinRemovalDefect = null;

                if (planReportAllDTO.T_Planing_AFRemovalDT != null && planReportAllDTO.T_Planing_AFRemovalDT.Rows.Count > 0)

                {
                    dtAfterCoatinRemoval = planReportAllDTO.T_Planing_AFRemovalDT.Copy();
                   

                    dtAfterCoatinRemoval.Columns.Add("AFImg", typeof(byte[]));
                    dtAfterCoatinRemoval.Columns.Add("WTImg", typeof(byte[]));


                    dtAfterCoatinRemoval.Rows[0]["AFImg"] = Utility.GetByteArray(this.Server.MapPath(dtAfterCoatinRemoval.Rows[0]["DefectImgUrl"].ToString()));

                    dtAfterCoatinRemoval.Rows[0]["WTImg"] = Utility.GetByteArray(this.Server.MapPath(dtAfterCoatinRemoval.Rows[0]["WallThicknessImgUrl"].ToString()));




                    if (dtAfterCoatinRemovalDefect != null && dtAfterCoatinRemovalDefect.Rows.Count > 0)
                    {
                        dtAfterCoatinRemovalDefect = planReportAllDTO.T_Planing_AFRemoval_DefectDT.Copy();
                        dtAfterCoatinRemovalDefect.Columns.Add("File", typeof(byte[]));

                        foreach (DataRow drTemp in dtAfterCoatinRemovalDefect.Rows)
                        {
                            drTemp["File"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName"].ToString()));
                        }
                    }



                    ds = new DataSet();

                    ds.Tables.Add(dtAfterCoatinRemoval);

                    if (dtAfterCoatinRemovalDefect != null)
                        ds.Tables.Add(dtAfterCoatinRemovalDefect);

                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/AfterCoatingRemoval.rpt"));
                    report.SetDataSource(ds);

                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("6AfterCoatingRemoval{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }

                }

                msg += "/AfterCoatingRemoval";
                #region After Coating Removal Wall Thickness

                DataTable dtAfterCoatinRemovalThickness = null;

                if (dtAfterCoatinRemoval != null && dtAfterCoatinRemoval.Rows.Count > 0)

                {
                    if (planReportAllDTO.T_Planing_AFRemoval_WallThicknessDT != null && planReportAllDTO.T_Planing_AFRemoval_WallThicknessDT.Rows.Count > 0)
                    {
                        dtAfterCoatinRemovalThickness = planReportAllDTO.T_Planing_AFRemoval_WallThicknessDT.Copy();

                    }
                    ds = new DataSet();

                    ds.Tables.Add(dtAfterCoatinRemoval.Copy());

                    if (planReportAllDTO.T_Planing_AFRemoval_WallThicknessDT != null && planReportAllDTO.T_Planing_AFRemoval_WallThicknessDT.Rows.Count > 0)
                    {
                        ds.Tables.Add(dtAfterCoatinRemovalThickness);
                    }


                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/AfterCoatingRemoval_WallThickness.rpt"));
                    report.SetDataSource(ds);
                    if (report.Subreports.Count > 0)
                    {

                        // report.Subreports["TPlaingFile.rpt"].Database.Tables[0].SetDataSource(dtPlaningFile);


                    }
                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("7AfterCoatingRemovalWallThickness{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }


                }

                #endregion
                msg += "/AfterCoatingRemoval_WallThickness";

                #endregion


                #region AppliCoatng

                #region Before Coating Removal

                DataTable dtApplicoating = null;
                DataTable dtApplicoatingSurfaceProfile = null;
                DataTable dtApplicoatingInformation = null;


                if (planReportAllDTO.T_Planing_AppliedCoatingDT != null && planReportAllDTO.T_Planing_AppliedCoatingDT.Rows.Count > 0)
                {
                    dtApplicoating = planReportAllDTO.T_Planing_AppliedCoatingDT.Copy();


                    if (planReportAllDTO.T_Planing_AppliedCoating_SurfaceProfileDT != null)
                        dtApplicoatingSurfaceProfile = planReportAllDTO.T_Planing_AppliedCoating_SurfaceProfileDT.Copy();

                    if (planReportAllDTO.T_Planing_AppliedCoating_InformationDT != null)
                        dtApplicoatingInformation = planReportAllDTO.T_Planing_AppliedCoating_InformationDT.Copy();





                    dtApplicoating.Columns.Add("File", typeof(byte[]));
                    dtApplicoatingSurfaceProfile.Columns.Add("File", typeof(byte[]));


                    if (planReportAllDTO.T_Planing_AppliedCoating_SurfaceProfileDT != null && planReportAllDTO.T_Planing_AppliedCoating_SurfaceProfileDT.Rows.Count > 0)
                    {
                        foreach (DataRow drTemp in dtApplicoatingSurfaceProfile.Rows)
                        {
                            drTemp["File"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName"].ToString()));
                        }
                    }



                    ds = new DataSet();

                    ds.Tables.Add(dtApplicoating);
                    ds.Tables.Add(dtApplicoatingInformation);

                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/ApplieCoating.rpt"));
                    report.SetDataSource(ds);
                    if (report.Subreports.Count > 0 && dtApplicoatingSurfaceProfile != null && dtApplicoatingSurfaceProfile.Rows.Count > 0)
                    {

                        report.Subreports["ApplieCoating_SurfecProfile.rpt"].Database.Tables[0].SetDataSource(dtApplicoatingSurfaceProfile);


                    }
                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("8AppliCoating{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }


                }
                #endregion





                #endregion


                #region After Applied Coating 

                DataTable dtAfterAppliCoating = null;
                DataTable dtAfterAppliCoatingDryFlimThickness = null;
                dtPlaningFile = new DataTable("TPlaning_File");



                if (planReportAllDTO.T_Planing_AfterAppliedCoatingDT != null && planReportAllDTO.T_Planing_AfterAppliedCoatingDT.Rows.Count > 0)
                {
                    dtAfterAppliCoating = planReportAllDTO.T_Planing_AfterAppliedCoatingDT.Copy();

                    if (planReportAllDTO.T_Planing_AfterAppliedCoating_DryFilmThicknessDT != null)
                        dtAfterAppliCoatingDryFlimThickness = planReportAllDTO.T_Planing_AfterAppliedCoating_DryFilmThicknessDT.Copy();



                    ds = new DataSet();

                    ds.Tables.Add(dtAfterAppliCoating);
                    ds.Tables.Add(dtAfterAppliCoatingDryFlimThickness);

                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/AfterApplieCoating.rpt"));
                    report.SetDataSource(ds);
                    if (report.Subreports.Count > 0
                        && planReportAllDTO.T_Planing_AfterAppliedCoating_File1DT != null
                        && planReportAllDTO.T_Planing_AfterAppliedCoating_File1DT.Rows.Count > 0)
                    {

                        foreach (DataRow drTemp in planReportAllDTO.T_Planing_AfterAppliedCoating_File1DT.Rows)
                        {
                            if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                            {
                                drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                            }

                            if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                            {
                                drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                            }

                        }


                        if (planReportAllDTO.T_Planing_AfterAppliedCoating_File2DT != null && planReportAllDTO.T_Planing_AfterAppliedCoating_File2DT.Rows.Count > 0)
                        {
                            foreach (DataRow drTemp in planReportAllDTO.T_Planing_AfterAppliedCoating_File2DT.Rows)
                            {
                                if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                                {
                                    drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                                }

                                if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                                {
                                    drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                                }

                            }
                        }


                        report.Subreports["TPlaingFile.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_AfterAppliedCoating_File1DT);
                        report.Subreports["TPlaingFile2.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_AfterAppliedCoating_File2DT);

                    }
                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("91AfterAppliCoating{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }

                }





                #endregion


                #region Site Recovery

                DataTable dtSiteRecovery = null;




                if (planReportAllDTO.T_Planing_SiteRecoveryDT != null && planReportAllDTO.T_Planing_SiteRecoveryDT.Rows.Count > 0)
                {
                    dtSiteRecovery = planReportAllDTO.T_Planing_SiteRecoveryDT.Copy();



                    ds = new DataSet();

                    ds.Tables.Add(dtSiteRecovery);


                    report = new ReportDocument();
                    report.Load(Server.MapPath("~/UI/Report/RPT/SiteRecovery.rpt"));
                    report.SetDataSource(ds);
                    if (report.Subreports.Count > 0 && planReportAllDTO.T_Planing_SiteRecovery_File1DT != null && planReportAllDTO.T_Planing_SiteRecovery_File1DT.Rows.Count > 0)
                    {

                        foreach (DataRow drTemp in planReportAllDTO.T_Planing_SiteRecovery_File1DT.Rows)
                        {
                            if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                            {
                                drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                            }

                            if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                            {
                                drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                            }

                        }


                        foreach (DataRow drTemp in planReportAllDTO.T_Planing_SiteRecovery_File2DT.Rows)
                        {
                            if (drTemp["FileName1"] != null && drTemp["FileName1"].ToString() != "")
                            {
                                drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                            }

                            if (drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                            {
                                drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                            }

                        }


                        report.Subreports["TPlaingFile.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_SiteRecovery_File1DT);
                        report.Subreports["TPlaingFile2.rpt"].Database.Tables[0].SetDataSource(planReportAllDTO.T_Planing_SiteRecovery_File2DT);

                    }
                    report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

                    stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);



                    Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                    fileName = string.Format("92SiteRecovery{0}.pdf", strDateTime);
                    pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                    Utility.DeleteFile(pdfName);
                    fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                    fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                    fsObj.Close();


                    if (report != null)
                    {
                        report.Close();
                        report.Dispose();
                    }

                }
                #endregion


                stream.Close();
                stream.Flush();




                string[] files = Directory.GetFiles(Server.MapPath(rootPath.ToString()), "*.pdf");
                List<string> fileAll = new List<string>();
                fileAll.AddRange(files);

                fileAll.Sort();

                List<byte[]> filesByte = new List<byte[]>();
                foreach (string file in fileAll)
                {
                    filesByte.Add(File.ReadAllBytes(file));
                }

                string strDateTimeExport = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                string actionAll = string.Format("ActionAll{0}.pdf", strDateTimeExport);

                byte[] output = PdfMerger.MergeFiles(filesByte);



                Response.ClearHeaders();

                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition",
                    "attachment;filename=\"InspectionAll.pdf\"");
                Response.BinaryWrite(output);
                Response.End();
            }
            else
            {
               // Label1.Text = "Not found Inspection";
            }
        }
        catch (Exception ex)
        {
           // Label1.Text = "Step --- " + msg + "-----" + ex.ToString() + "--" + ex.StackTrace;

        }
        finally
        { }


    }

    private void BindReport(ReportDocument crystalReport)
    {
        MemoryStream oStream = null;


        /*  rd = New ReportDocument
                     rd.Load(Server.MapPath(reportInfo.ReportName))

                     If reportInfo.HasParameter Then
                         Dim parameterNames As SortedList = reportInfo.ReportParameter
                         Dim parameterName As String
                         For Each parameterName In parameterNames.GetKeyList
                             rd.DataDefinition.FormulaFields(parameterName).Text = "'" & parameterNames(parameterName) & "'"
                         Next
                         rd.DataDefinition.FormulaFields("pageTotal").Text = "'" & pageTotal & "'"
                     End If

                     rd.SetDataSource(ds)
           Dim rdPrintOptions As PrintOptions = rd.PrintOptions
                     rdPrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
         * 
         *   merge.AddDocument(rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
                    If Not rd Is Nothing Then
                        rd.Close()
                        rd.Dispose()
                    End If
         * 
         *     merge.EnablePagination = True
                merge.Merge(True)
         * 
         *     oStream = CType(rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), MemoryStream)
                Response.Clear()
                Response.Buffer = True
                Response.ContentType = "application/pdf"
                Response.BinaryWrite(oStream.ToArray)
                Response.End()
         * 
         *   Response.OutputStream.Flush()
                Response.OutputStream.Close()


         */

        try
        {
            mergePDF = new PdfMerge();

            crystalReport.Load(Server.MapPath("~/UI/Report/SummaryRepairReportRPT.rpt"));
            DataTable dsCustomers = GetData("select top 5 * from customers");
            crystalReport.SetDataSource(dsCustomers);

            crystalReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

            mergePDF.AddDocument(crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));



            if (crystalReport != null)
            {
                crystalReport.Close();
                crystalReport.Dispose();
            }


            DataTable tPlan = new DataTable("TPlaning");
            DataTable tPlanFile = new DataTable("TPlaningFile");

            tPlan.Columns.Add("PID", typeof(string));
            tPlanFile.Columns.Add("PID", typeof(string));
            tPlanFile.Columns.Add("File", typeof(byte[]));

            DataRow row;

            row = tPlan.NewRow();
            row["PID"] = "1";
            tPlan.Rows.Add(row);



            row = tPlanFile.NewRow();
            row["PID"] = "1";
            row["File"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\img1.jpg"));
            tPlanFile.Rows.Add(row);

            row = tPlanFile.NewRow();
            row["PID"] = "1";
            row["File"] = Utility.GetByteArray(this.Server.MapPath(@"~\img\img3.jpg"));
            tPlanFile.Rows.Add(row);


            crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/UI/Report/RPT2.rpt"));

            crystalReport.SetDataSource(tPlan);
            if (crystalReport.Subreports.Count > 0)
            {
                crystalReport.Subreports["MountingDimension.rpt"].Database.Tables[0].SetDataSource(tPlanFile);
            }
            crystalReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            mergePDF.AddDocument(crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));


            if (crystalReport != null)
            {
                crystalReport.Close();
                crystalReport.Dispose();
            }

            mergePDF.EnablePagination = true;
            mergePDF.Merge(false);

            //oStream = (MemoryStream)crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            // crystalReport.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, "SummaryRepair Report");
            //Response.Clear();
            //  Response.Buffer = true;
            // Response.ContentType = "application/pdf";
            // Response.BinaryWrite(oStream.ToArray());
            // Response.End();

            //  Response.OutputStream.Flush();
            // Response.OutputStream.Close();

            //  mergePDF.AddDocument(crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            /*  oStream=(MemoryStream)crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
              ExportFormatType format = new ExportFormatType();
                  Response.Clear();
                  Response.Buffer = true;
                  Response.ContentType = "application/pdf";
                  Response.BinaryWrite(oStream.ToArray());
                  Response.End();*/

            if (crystalReport != null)
            {
                crystalReport.Close();
                crystalReport.Dispose();
            }
        }
        catch (Exception ex)
        { }
        finally
        {
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            // oStream.Flush();
            // oStream.Close();


        }





    }


    private void ExportToExcel(ReportDocument crystalReport)
    {
        MemoryStream oStream = null;
        MemoryStream oStream2 = null;

        /*  rd = New ReportDocument
                     rd.Load(Server.MapPath(reportInfo.ReportName))

                     If reportInfo.HasParameter Then
                         Dim parameterNames As SortedList = reportInfo.ReportParameter
                         Dim parameterName As String
                         For Each parameterName In parameterNames.GetKeyList
                             rd.DataDefinition.FormulaFields(parameterName).Text = "'" & parameterNames(parameterName) & "'"
                         Next
                         rd.DataDefinition.FormulaFields("pageTotal").Text = "'" & pageTotal & "'"
                     End If

                     rd.SetDataSource(ds)
           Dim rdPrintOptions As PrintOptions = rd.PrintOptions
                     rdPrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
         * 
         *   merge.AddDocument(rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
                    If Not rd Is Nothing Then
                        rd.Close()
                        rd.Dispose()
                    End If
         * 
         *     merge.EnablePagination = True
                merge.Merge(True)
         * 
         *     oStream = CType(rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), MemoryStream)
                Response.Clear()
                Response.Buffer = True
                Response.ContentType = "application/pdf"
                Response.BinaryWrite(oStream.ToArray)
                Response.End()
         * 
         *   Response.OutputStream.Flush()
                Response.OutputStream.Close()


         */



        mergePDF = new PdfMerge();


        try
        {
            crystalReport.Load(Server.MapPath("~/UI/Report/SummaryRepairReportRPT.rpt"));
            DataTable dsCustomers = GetData("select top 5 * from customers");
            crystalReport.SetDataSource(dsCustomers);

            crystalReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

            //  mergePDF.AddDocument(crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel));

            oStream = (MemoryStream)crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);


            if (crystalReport != null)
            {
                crystalReport.Close();
                crystalReport.Dispose();
            }

            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + "test.xls");

            Response.BinaryWrite(oStream.ToArray());

            Response.End();

        }
        catch { }
        finally
        { }

        try
        {

            crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/UI/Report/RPT2.rpt"));
            crystalReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            oStream = (MemoryStream)crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);


            if (crystalReport != null)
            {
                crystalReport.Close();
                crystalReport.Dispose();
            }



            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + "test2.xls");

            Response.BinaryWrite(oStream.ToArray());

            Response.End();

        }
        catch { }
        finally
        { }

        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        oStream.Flush();
        oStream.Close();
        oStream.Dispose();





        /*         if(crystalReport!=null )
        {
        crystalReport.Close();
                        crystalReport.Dispose();
        }


                 crystalReport = new ReportDocument();
                 crystalReport.Load(Server.MapPath("~/UI/Report/RPT2.rpt"));
                 crystalReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                 mergePDF.AddDocument(crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));


                 if (crystalReport != null)
                 {
                     crystalReport.Close();
                     crystalReport.Dispose();
                 }
        
        mergePDF.EnablePagination = true;
            mergePDF.Merge(true);*/

        //oStream = (MemoryStream)crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

        // crystalReport.ExportToHttpResponse(ExportFormatType.CharacterSeparatedValues, Response, true, "SummaryRepair Report");
        //Response.Clear();
        //  Response.Buffer = true;
        // Response.ContentType = "application/pdf";
        // Response.BinaryWrite(oStream.ToArray());
        // Response.End();

        //  Response.OutputStream.Flush();
        // Response.OutputStream.Close();

        //  mergePDF.AddDocument(crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
        /*  oStream=(MemoryStream)crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
          ExportFormatType format = new ExportFormatType();
              Response.Clear();
              Response.Buffer = true;
              Response.ContentType = "application/pdf";
              Response.BinaryWrite(oStream.ToArray());
              Response.End();*/

        if (crystalReport != null)
        {
            crystalReport.Close();
            crystalReport.Dispose();
        }






    }


    private void ExportReport(ReportDocument crystalReport)
    {

        //declare a memorystream object that will hold out output
        MemoryStream oStream = null; ;

        //here's the instance of a valid report, one which we have already Load(ed)

        /**remember that a valid crystal report has to be loaded before you run this code**/

        //clear the response and set Buffer to true

        Response.Clear();

        Response.Buffer = true;

        /*  switch (ddlExportTypes.SelectedItem.Value)
          {

              case "1":

                  // ...Rich Text (RTF)

                  oStream = (MemoryStream)crReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.RichText);

                  Response.ContentType = "application/rtf";

                  break;

              case "2":

                  // ...Portable Document (PDF)


                  oStream = (MemoryStream)crReport.ExportToStream(ExportFormatType.PortableDocFormat);

                  Response.ContentType = "application/pdf";



                  break;

              case "3":

                  // ...MS Word (DOC)

                  oStream = (MemoryStream)crReport.ExportToStream(ExportFormatType.WordForWindows);

                  Response.ContentType = "application/doc";

                  break;

              case "4":

                  // ...MS Excel (XLS)

                  oStream = (MemoryStream)crReport.ExportToStream(ExportFormatType.Excel);

                  Response.ContentType = "application/vnd.ms-excel";

                  break;

              default:

                  //...Portable Document (PDF)

                  oStream = (MemoryStream)crReport.ExportToStream(ExportFormatType.PortableDocFormat);

                  Response.ContentType = "application/pdf";

                  break;

          }*/


        try
        {

            //write report to the Response stream
            string attachment = "attachment; filename=MyCsvLol.csv";
            crystalReport.Load(Server.MapPath("~/UI/Report/SummaryRepairReportRPT.rpt"));
            DataTable dsCustomers = GetData("select top 5 * from customers");
            crystalReport.SetDataSource(dsCustomers);
            PrintOptions rdPrintOptions = crystalReport.PrintOptions;
            rdPrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            oStream = (MemoryStream)crystalReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);


            //    oStream = (MemoryStream)crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "text/csv";
            //  Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(oStream.ToArray());

            Response.End();

        }

        catch (Exception ex)
        {

            // labelErrors.Text = "ERROR: " + Server.HtmlEncode(ex.Message.ToString());

        }

        finally
        {

            //clear stream

            oStream.Flush();

            oStream.Close();

            oStream.Dispose();

        }

    }

    public bool Export()
    {
        string attachment = "attachment; filename=SummaryRepairReport.csv";

        bool iCan = false;
        var sb = new StringBuilder();


        try
        {
            foreach (SummaryRepaireDTO dto in GetSummaryRepairReport())
            {
                string val = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                    dto.No,
            dto.Region,
            dto.RC,
            dto.PipelineSection,
            dto.KP,
            dto.RepairLength,
            dto.Digfrom,
            dto.RiskLevel,
            dto.CoatingType,
            dto.CoatingDMGType,
            dto.CoatingPoint,
            dto.PipelineDMGType,
            dto.PipelinePoint);
                sb.AppendLine(val);
            }


            byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
            if (bytes != null)
            {
                /* Response.Clear();
                 Response.ContentType = "text/csv";
                 Response.AddHeader("Content-Length", bytes.Length.ToString());
                 Response.AddHeader("Content-disposition", "attachment; filename=\"sample.csv" + "\"");
                 Response.BinaryWrite(bytes);
                 Response.Flush();
                 Response.End();
                 HttpContext.Current.Response.Clear();
                 HttpContext.Current.Response.Buffer = true;
                 HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
                 HttpContext.Current.Response.Charset = "utf-8";
                 HttpContext.Current.Response.ContentType = "application/text";
                 HttpContext.Current.Response.BinaryWrite(bytes);
                 HttpContext.Current.Response.Flush();
                 HttpContext.Current.Response.End();
                 */

                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Length", bytes.Length.ToString());
                Response.AddHeader("Content-disposition", "attachment; filename=\"sample.csv" + "\"");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();


            }


            /*  HttpContext.Current.Response.Clear();
              HttpContext.Current.Response.Buffer = true;
              HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
              HttpContext.Current.Response.Charset = "utf-8";
              HttpContext.Current.Response.ContentType = "application/text";
              HttpContext.Current.Response.Output.Write(sb.ToString());
              HttpContext.Current.Response.Flush();
              HttpContext.Current.Response.End();*/



            //   HttpContext.Current.Response.Write(sb.ToString());
            iCan = true;
        }
        catch (Exception ex)
        { }
        finally { }

        return iCan;
    }
    public List<SummaryRepaireDTO> GetSummaryRepairReport()
    {
        List<SummaryRepaireDTO> resultList = new List<SummaryRepaireDTO>();
        SummaryRepaireDTO dto = null;
        //  "1","3","5600","OCS3-BCS","52+290","5","CIPS/DCVG","","FBE","Note 1*","0","N/A","0",""
        dto = new SummaryRepaireDTO();


        dto.PipelineType = "Pipeline 1";
        dto.AssertOwner = "Assert Owner 1";
        dto.No = "1";
        dto.Region = "3";
        dto.RC = "5600";
        dto.PipelineSection = "OCS3-BCS";
        dto.KP = "52+290";
        dto.RepairLength = "5";
        dto.Digfrom = "CIPS/DCVG";
        dto.CoatingType = "FBE";
        dto.CoatingDMGType = "Note 1*";
        dto.CoatingPoint = "0";
        dto.PipelineDMGType = "N/A";
        dto.PipelinePoint = "0";
        resultList.Add(dto);

        dto = new SummaryRepaireDTO();

        dto.PipelineType = "Pipeline 1";
        dto.AssertOwner = "Assert Owner 1";
        dto.No = "1";
        dto.Region = "3";
        dto.RC = "5600";
        dto.PipelineSection = "OCS3-BCS";
        dto.KP = "52+290";
        dto.RepairLength = "5";
        dto.Digfrom = "CIPS/DCVG";
        dto.CoatingType = "FBE";
        dto.CoatingDMGType = "damage";
        dto.CoatingPoint = "0";
        dto.PipelineDMGType = "N/A";
        dto.PipelinePoint = "0";
        resultList.Add(dto);


        dto = new SummaryRepaireDTO();

        dto.PipelineType = "Pipeline 1";
        dto.AssertOwner = "Assert Owner 2";
        dto.No = "2";
        dto.Region = "3";
        dto.RC = "5600";
        dto.PipelineSection = "OCS2-BV6";
        dto.KP = "52+261";
        dto.RepairLength = "5";
        dto.Digfrom = "CIPS/DCVG";
        dto.CoatingType = "";
        dto.CoatingDMGType = "Note 1*";
        dto.CoatingPoint = "0";
        dto.PipelineDMGType = "N/A";
        dto.PipelinePoint = "0";
        resultList.Add(dto);


        dto = new SummaryRepaireDTO();
        dto.PipelineType = "Pipeline 1";
        dto.AssertOwner = "Assert Owner 2";
        dto.No = "3";
        dto.Region = "5";
        dto.RC = "4000";
        dto.PipelineSection = "BVW9 - RBMR";
        dto.KP = "194+196";
        dto.RepairLength = "10";
        dto.Digfrom = "CIPS/DCVG";
        dto.RiskLevel = "FBE";
        dto.CoatingType = "Blister";
        dto.CoatingDMGType = "Note 1*";
        dto.CoatingPoint = "0";
        dto.PipelineDMGType = "N/A";
        dto.PipelinePoint = "0";
        resultList.Add(dto);


        dto = new SummaryRepaireDTO();

        dto.PipelineType = "Pipeline 1";
        dto.AssertOwner = "Assert Owner 2";
        dto.No = "4";
        dto.Region = "5";
        dto.RC = "4000";
        dto.PipelineSection = "BVW9 - RBMR";
        dto.KP = "194+244";
        dto.RepairLength = "10";
        dto.Digfrom = "CIPS/DCVG";
        dto.RiskLevel = "FBE";
        dto.CoatingType = "Blister";
        dto.CoatingDMGType = "Note 1*";
        dto.CoatingPoint = "0";
        dto.PipelineDMGType = "N/A";
        dto.PipelinePoint = "0";
        resultList.Add(dto);



        return resultList;

    }

    private DataTable GetData(string query)
    {

        DataTable dt = new DataTable();

        dt.Columns.Add("No");
        dt.Columns.Add("PipelineType");
        dt.Columns.Add("AssertOwnerName");
        dt.Columns.Add("Region");
        dt.Columns.Add("RC");
        dt.Columns.Add("PipelineSection");
        dt.Columns.Add("KP");
        dt.Columns.Add("RepairLength");
        dt.Columns.Add("Digfrom");
        dt.Columns.Add("RiskLevel");
        dt.Columns.Add("CoatingType");
        dt.Columns.Add("CoatingDamageType");
        dt.Columns.Add("CoatingDmageNumber");
        dt.Columns.Add("PipelineDamageType");
        dt.Columns.Add("PipelineDamageNumber");

        dt.Columns.Add("Note");
        dt.Columns.Add("PipelineTypeID");
        dt.Columns.Add("AssertOwnerID");
        dt.Columns.Add("RegionID");
        dt.Columns.Add("PipelineSectionID");
        dt.Columns.Add("DigfromID");
        dt.Columns.Add("CoatingTypeID");
        dt.Columns.Add("DamageTypeID");

        DataRow dr = null;

        dr = dt.NewRow();
        dr["No"] = "1";
        dr["PipelineType"] = "PipelineType 1";
        dr["AssertOwnerName"] = "AssertOwner 1";
        dr["Region"] = "Region 1";
        dr["PipelineSection"] = "OCS3-BCS";
        dr["KP"] = "52+290";
        dr["RepairLength"] = "5";
        dr["Digfrom"] = "CPS/DCVG";
        dr["RiskLevel"] = "";
        dr["CoatingType"] = "FBE";
        dr["CoatingDamageType"] = "Note 1''";
        dr["CoatingDmageNumber"] = "0";
        dr["PipelineDamageType"] = "N/A";
        dr["PipelineDamageNumber"] = "0";

        dr["Note"] = "";
        dr["RegionID"] = "Region 1";
        dr["PipelineSectionID"] = "1";
        dr["DigfromID"] = "";
        dr["CoatingTypeID"] = "";
        dr["DamageTypeID"] = "";

        dr["PipelineTypeID"] = "1";
        dr["AssertOwnerID"] = "1";

        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["No"] = "1";
        dr["PipelineType"] = "PipelineType 1";
        dr["AssertOwnerName"] = "AssertOwner 2";
        dr["Region"] = "3";
        dr["PipelineSection"] = "OCS3-BCS";
        dr["KP"] = "52+290";
        dr["RepairLength"] = "5";
        dr["Digfrom"] = "CPS/DCVG";
        dr["RiskLevel"] = "";
        dr["CoatingType"] = "FBE";
        dr["CoatingDamageType"] = "Note 1''";
        dr["CoatingDmageNumber"] = "0";
        dr["PipelineDamageType"] = "N/A";
        dr["PipelineDamageNumber"] = "0";

        dr["Note"] = "";
        dr["RegionID"] = "3";
        dr["PipelineSectionID"] = "1";
        dr["DigfromID"] = "";
        dr["CoatingTypeID"] = "";
        dr["DamageTypeID"] = "";

        dr["PipelineTypeID"] = "1";
        dr["AssertOwnerID"] = "1";

        dt.Rows.Add(dr);


        dr = dt.NewRow();
        dr["No"] = "2";
        dr["PipelineType"] = "PipelineType 1";
        dr["AssertOwnerName"] = "AssertOwner 2";
        dr["Region"] = "Region 2";
        dr["PipelineSection"] = "ABCD";
        dr["KP"] = "52+290";
        dr["RepairLength"] = "5";
        dr["Digfrom"] = "CPS/DCVG";
        dr["RiskLevel"] = "";
        dr["CoatingType"] = "FBE";
        dr["CoatingDamageType"] = "Note 1''";
        dr["CoatingDmageNumber"] = "0";
        dr["PipelineDamageType"] = "N/A";
        dr["PipelineDamageNumber"] = "0";

        dr["Note"] = "";
        dr["RegionID"] = "3";
        dr["PipelineSectionID"] = "1";
        dr["DigfromID"] = "";
        dr["CoatingTypeID"] = "";
        dr["DamageTypeID"] = "";

        dr["PipelineTypeID"] = "1";
        dr["AssertOwnerID"] = "1";

        dt.Rows.Add(dr);


        dr = dt.NewRow();
        dr["No"] = "4";
        dr["PipelineType"] = "PipelineType 2";
        dr["AssertOwnerName"] = "AssertOwner 2";
        dr["Region"] = "Region 2";
        dr["PipelineSection"] = "ABCD";
        dr["KP"] = "52+290";
        dr["RepairLength"] = "5";
        dr["Digfrom"] = "CPS/DCVG";
        dr["RiskLevel"] = "";
        dr["CoatingType"] = "FBE";
        dr["CoatingDamageType"] = "Note 1''";
        dr["CoatingDmageNumber"] = "0";
        dr["PipelineDamageType"] = "N/A";
        dr["PipelineDamageNumber"] = "0";

        dr["Note"] = "";
        dr["RegionID"] = "3";
        dr["PipelineSectionID"] = "1";
        dr["DigfromID"] = "";
        dr["CoatingTypeID"] = "";
        dr["DamageTypeID"] = "";

        dr["PipelineTypeID"] = "1";
        dr["AssertOwnerID"] = "1";

        dt.Rows.Add(dr);

        return dt;


    }
}