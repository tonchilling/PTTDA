using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL.PTT.Util;
using BAL.PTT.Report;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Text;
using DTO.PTT.Report;
using DTO.PTT.Plan;
using DTO.Util;
using BAL.PTT.Plan;
using DTO.PTT.Admin;

namespace API
{
    public partial class Default : System.Web.UI.Page
    {
        PTTLDap ldap = null;

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        void ExportToPDF()
        {
            System.Data.DataTable dt = new System.Data.DataTable("DataTable1");
            dt.Columns.Add("name");

            DataRow dr = dt.NewRow();
            dr[0] = "test";
            MemoryStream stream = new MemoryStream();
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("~/UI/Report/RPT/TPlaning.rpt"));
            report.SetDataSource(dt);
            stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);


            Response.ClearHeaders();

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition",
                "attachment;filename=\"InspectionAll.pdf\"");
            Response.BinaryWrite(stream.ToArray());
            Response.End();
        }


        void ExportToPDF2()
        {
            DataRow dr;
            System.Data.DataTable dtPlaning = new System.Data.DataTable("TPlaning");
            System.Data.DataTable dtPlaningFile = new System.Data.DataTable("TPlaning_File");

            try
            {

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



                MemoryStream stream = new MemoryStream();
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("~/UI/Report/RPT/TPlaning.rpt"));
                report.SetDataSource(dtPlaningFile);

                report.SetDataSource(dtPlaningFile);
                if (report.Subreports.Count > 0)
                {

                    //foreach (DataRow drTemp in dtPlaningFile.Rows)
                    //{
                    //    if (dtPlaningFile.Columns.Count >= 3 && drTemp["FileName1"] != null)
                    //    {
                    //        drTemp["File1"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName1"].ToString()));
                    //    }

                    //    if (dtPlaningFile.Columns.Count > 4 && drTemp["FileName2"] != null && drTemp["FileName2"].ToString() != "")
                    //    {
                    //        drTemp["File2"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName2"].ToString()));
                    //    }


                    //    if (dtPlaningFile.Columns.Count > 5 && drTemp["FileName3"] != null)
                    //    {
                    //        drTemp["File3"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName3"].ToString()));
                    //    }


                    //    if (dtPlaningFile.Columns.Count > 6 && drTemp["FileName4"] != null)
                    //    {
                    //        drTemp["File4"] = Utility.GetByteArray(this.Server.MapPath(drTemp["FileName4"].ToString()));
                    //    }

                    //}
                    report.Subreports["TPlaingFile.rpt"].Database.Tables[0].SetDataSource(dtPlaningFile);

                }


                stream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                string planOverAll = System.Configuration.ConfigurationManager.AppSettings["UploadOverAll"];

                string rootPath = planOverAll;


                Utility.HaveDirectory(this.Server.MapPath(string.Format(rootPath)));
                string fileName = string.Format("1Planing{0}.pdf", "222");
                string pdfName = this.Server.MapPath(string.Format(rootPath)) + "\\" + fileName;
                Utility.DeleteFile(pdfName);
                FileStream fsObj = new FileStream(pdfName, FileMode.Create, FileAccess.Write);
                fsObj.Write(stream.ToArray(), 0, System.Convert.ToInt32(stream.ToArray().Length));
                fsObj.Close();


                if (report != null)
                {
                    report.Close();
                    report.Dispose();
                }




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
            catch (Exception ex)
            {
                Label1.Text = ex.Message + "---" + ex.StackTrace;
            }
            finally { }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            ldap = new PTTLDap();
            bool loginLoDap = ldap.Authenticated(TextBox1.Text, TextBox2.Text, TextBox3.Text);
            Label1.Text = loginLoDap ? "Pass" : "Failed";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = "";
            string desPath = System.Configuration.ConfigurationManager.AppSettings["UploadPlan"];

            T_PlaningDTO requestObj = new T_PlaningDTO();
            T_PlaningBAL planBAL = null;
            planBAL = new T_PlaningBAL();
            requestObj.PID = "194,198";
            requestObj.Year = "2018";
            requestObj.CreateBy = "4F12E624-F166-4046-839E-EF24F2E12E43";
            requestObj.UpdateBy = "4F12E624-F166-4046-839E-EF24F2E12E43";
            Byte[] b = planBAL.ExportPlanForExcel(requestObj, desPath, "test.xlsx");




            //Send output stream to client window
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            Response.AddHeader("Content-Disposition", "attachment; filename=test.xlsx");
            Response.BinaryWrite(b);
            Response.Flush();
            Response.End();



            // ExportToPDF();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string lbLabel = "";


            /*


                Microsoft.Office.Interop.Excel.Application excelApp = null;
                Microsoft.Office.Interop.Excel.Workbook workbook = null;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
                object misValue = System.Reflection.Missing.Value;

                try
                {
                    excelApp = new Microsoft.Office.Interop.Excel.Application();

                lbLabel += "OK Application--";
                excelApp.StandardFont = "Tahoma";
                excelApp.StandardFontSize = 10;

                workbook = excelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                lbLabel += "OK Workbook&WorkSheet--";


                    worksheet.SaveAs("E:\\PTT-Direct-Assessment_Test\\Upload\\" + "test.xlsx");
                    lbLabel += "OK SaveAs--";
                    excelApp.Application.Quit();
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
                catch(Exception ex)
                {
                    lbLabel += "Error"+ ex.Message;

                }
                finally
                {

                    Label1.Text = lbLabel;
                //////////////////////


                }*/
            // bal.ExportPlan(dtHeader, dtDetail, "test.xlsx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ExportToExcel2BAL bal = new ExportToExcel2BAL();
            // Byte[] b  =bal.CreateExcelDoc("test.xlsx");
            /* Byte[] b = bal.ExportPlan("test.xls");

         */

            // Byte[] b = bal.ExportStackColumn100();

            //Send output stream to client window
            //Response.AddHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            //Response.AddHeader("Content-Disposition", "attachment; filename=test.xlsx");
            //Response.BinaryWrite(b);
            //Response.Flush();
            //Response.End();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DTO.PTT.Services.spatialReference sp = new DTO.PTT.Services.spatialReference();
            sp.wkid = "32647";


            DTO.PTT.Services.geometry geom = new DTO.PTT.Services.geometry();
            geom.x = "748874.9600000003";
            geom.y = "1425623.8499999999";
            DTO.PTT.Services.features feat = new DTO.PTT.Services.features();
            feat.geometry = geom;

            DTO.PTT.Services.GPServer gmp = new DTO.PTT.Services.GPServer();
            gmp.geometryType = "esriGeometryPoint";
            gmp.spatialReference = sp;
            gmp.features = new List<DTO.PTT.Services.features>() { feat };

            /*  {
                  "geometryType": "esriGeometryPoint",
      "spatialReference": {
                      "wkid": 32647 },
      "features":
      [{ "geometry": {
      "x":748874.9600000003,
      "y":1425623.8499999999} }] }

       {"geometryType":"esriGeometryPoint",
        "spatialReference":{"wkid":"32647"},
        "features":[{"geometry":{
        "x":"748874.9600000003",
        "y":"1425623.8499999999"}}]}
               */


            string Util = DTO.Util.ConvertX.GetRequest(" http://pipelinegis/arcgis/rest/services/GEOPROCESSING/DA_LOCATE_KP_FROM_SERIES/GPServer", gmp);
            Label1.Text = Util;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {

            //DateTime dtStart = DateTime.Now;

            //string value = "";
            //// Open the document for editing.
            //using (SpreadsheetDocument spreadsheetDocument =
            //    SpreadsheetDocument.Open("D:\\test.xlsx", false))
            //{
            //    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            //    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            //    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
            //    string text;
            //    foreach (Row r in sheetData.Elements<Row>())
            //    {
            //        foreach (Cell c in r.Elements<Cell>())
            //        {
            //            text = c.CellValue.Text;
            //            value += text+",";
            //        }
            //        value += "<br>";
            //    }
            //    DateTime dtEndDate = DateTime.Now;
            //    double minuteSpend = (dtEndDate - dtStart).TotalMinutes;
            //    Label1.Text = string.Format("Spending {0} minute", minuteSpend) +value;
            //}
        }
    }
}