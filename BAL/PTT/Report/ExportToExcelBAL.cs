using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using DTO.Util;
using DTO.PTT.Report;
using System.Data;
using System.Reflection;


namespace BAL.PTT.Report
{
   public class ExportToExcelBAL
    {
        Application excelApp = null;
        Microsoft.Office.Interop.Excel.Workbook workbook = null;
        Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
        object misValue = System.Reflection.Missing.Value;
        int header = 10;
        int row = 1;
        int lastRow = 0;
        int col = 0;
        int month = 1;
        int SpecSWeek = 0;
        int SpecTotal = 0;


        int POSWeek = 0;
        int POTotal = 0;


        int ActionSWeek = 0;
        int Actiontotal = 0;
        string uploadPath = "";
        string pptLogo = "";
        Range rang = null;

        string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        string[] excelCols = { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ" };

        public Byte[] ExportPlan(List<ExportPlanHeader>  headerList,System.Data.DataTable dtGroup,
                                 System.Data.DataTable dtDetail,
                                 string desPath,string nameExcel)
        {
            string fullPath = "";

            string[] note = { "1. ข้อมูลการแบ่งประเภท Asset นำมาจากหน่วยงาน บท. และพศ." };
            string[] remark = { "Plan","Shift from previous year", "Actual", "Shift to next year" };
            string[] referenceDoc = { "1) F-รท.วรก.-0018_Main Pipeline Indirect Inspection and Integrity Assessment Plan" };


         


            DataView dv = null;
            pptLogo = HttpContext.Current.Request.PhysicalApplicationPath + "\\Img\\pttlogo.jpg";

            excelApp = new Application();




            excelApp.StandardFont = "Tahoma";
            excelApp.StandardFontSize = 10;

            workbook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

            row = 1 + header;

            #region header

            excelApp.Cells[1, 1] = "CM";

            rang = excelApp.get_Range(excelCols[1] + "1" + ":" + excelCols[2] + "5", Type.Missing);
            rang.Merge(Type.Missing);
            rang.WrapText = true;
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium,XlColorIndex.xlColorIndexAutomatic);



            

            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)excelApp.get_Range(excelCols[6] + "1" + ":" + excelCols[6] + "1", Type.Missing);
            float Left = (float)((double)oRange.Left);
            float Top = (float)((double)oRange.Top);
            const float ImageSize = 32;
            worksheet.Shapes.AddPicture(pptLogo, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);

            excelApp.Columns["A"].ColumnWidth = 3;
            excelApp.Columns["B"].ColumnWidth = 14;
            excelApp.Columns["C"].ColumnWidth = 18;
            excelApp.Columns["D"].ColumnWidth = 5;

            excelApp.Columns["BE"].ColumnWidth = 20;
            excelApp.Columns["I:BD"].ColumnWidth = 2;

            excelApp.get_Range(excelCols[3] + "1" + ":" + excelCols[8] + "1", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[3] + "1" + ":" + excelCols[8] + "1", Type.Missing).Borders.LineStyle = XlLineStyle.xlLineStyleNone;
            excelApp.get_Range(excelCols[3] + "2" + ":" + excelCols[8] + "2", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[3] + "2" + ":" + excelCols[8] + "2", Type.Missing).Borders.LineStyle = XlLineStyle.xlLineStyleNone;
            excelApp.get_Range(excelCols[3] + "2" + ":" + excelCols[8] + "2", Type.Missing).RowHeight = 24;
            excelApp.get_Range(excelCols[3] + "3" + ":" + excelCols[8] + "3", Type.Missing).Merge(Type.Missing);


            rang = excelApp.get_Range(excelCols[3] + "3" + ":" + excelCols[8] + "3", Type.Missing);
            rang.Value = "PTT Public Company Limited";
            rang.Font.Size = 14;
            rang.Font.Bold = true;
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.Borders.LineStyle = XlLineStyle.xlLineStyleNone;



            rang = excelApp.get_Range(excelCols[3] + "4" + ":" + excelCols[8] + "4", Type.Missing);
            rang.Merge(Type.Missing);
            rang.Borders.LineStyle = XlLineStyle.xlLineStyleNone;

            rang.Value = " Gas Business Unit";
            rang.Font.Size = 10;
            rang.Font.Bold = true;
            rang.Borders.LineStyle = XlLineStyle.xlLineStyleNone;
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;


            rang = excelApp.get_Range(excelCols[3] + "5" + ":" + excelCols[8] + "5", Type.Missing);
            rang.Merge(Type.Missing);
            rang.Borders.LineStyle = XlLineStyle.xlLineStyleNone;

            rang.Value = " Natural Gas Transmission";
            rang.Font.Size = 10;
            rang.Font.Bold = true;
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            excelApp.get_Range(excelCols[3] + "1" + ":" + excelCols[8] + "5", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);


            excelApp.get_Range(excelCols[3] + "1" + ":" + excelCols[8] + "5", Type.Missing).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));


            excelApp.get_Range(excelCols[9] + "1" + ":" + excelCols[9] + "1", Type.Missing).Value = "Direct Assessment PL reinforcement/repair  and Coating Repair Action Plan";
            rang = excelApp.get_Range(excelCols[9] + "1" + ":" + excelCols[57] + "1", Type.Missing);
          
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.Font.Size = 14;
            rang.Font.Bold = true;
            rang.Merge(Type.Missing);
            rang.Borders.LineStyle = XlLineStyle.xlLineStyleNone;


           

            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);


            rang = excelApp.get_Range(excelCols[9] + "2" + ":" + excelCols[9] + "2", Type.Missing);
            rang.Value = "Prepared by";
            excelApp.get_Range(excelCols[9] + "2" + ":" + excelCols[21] + "2", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[9] + "2" + ":" + excelCols[21] + "2", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignCenter;


            excelApp.get_Range(excelCols[9] + "3" + ":" + excelCols[21] + "3", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[9] + "4" + ":" + excelCols[21] + "4", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[9] + "5" + ":" + excelCols[21] + "5", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[9] + "5" + ":" + excelCols[21] + "5", Type.Missing).Value = "Pipeline Maintenance Manager";
            excelApp.get_Range(excelCols[9] + "5" + ":" + excelCols[21] + "5", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignCenter;

            excelApp.get_Range(excelCols[9] + "2" + ":" + excelCols[21] + "5", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);
            excelApp.get_Range(excelCols[9] + "2" + ":" + excelCols[21] + "5", Type.Missing).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));



            excelApp.get_Range(excelCols[22] + "2" + ":" + excelCols[22] + "2", Type.Missing).Value = "Checked by";
            excelApp.get_Range(excelCols[22] + "2" + ":" + excelCols[35] + "2", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[22] + "2" + ":" + excelCols[35] + "2", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            excelApp.get_Range(excelCols[22] + "3" + ":" + excelCols[35] + "3", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[22] + "4" + ":" + excelCols[35] + "4", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[22] + "5" + ":" + excelCols[35] + "5", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[22] + "5" + ":" + excelCols[35] + "5", Type.Missing).Value = "Pipeline Maintenance Manager";
            excelApp.get_Range(excelCols[22] + "5" + ":" + excelCols[35] + "5", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignCenter;

            excelApp.get_Range(excelCols[22] + "2" + ":" + excelCols[35] + "5", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);
            excelApp.get_Range(excelCols[22] + "2" + ":" + excelCols[35] + "5", Type.Missing).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));


            excelApp.get_Range(excelCols[36] + "2" + ":" + excelCols[36] + "2", Type.Missing).Value = "Approved by";
            excelApp.get_Range(excelCols[36] + "2" + ":" + excelCols[48] + "2", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[36] + "2" + ":" + excelCols[48] + "2", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            excelApp.get_Range(excelCols[36] + "3" + ":" + excelCols[48] + "3", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[36] + "4" + ":" + excelCols[48] + "4", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[36] + "5" + ":" + excelCols[48] + "5", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[36] + "5" + ":" + excelCols[48] + "5", Type.Missing).Value = "Natural Gas Transmission EVP";
            excelApp.get_Range(excelCols[36] + "5" + ":" + excelCols[48] + "5", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignCenter;

            excelApp.get_Range(excelCols[36] + "2" + ":" + excelCols[48] + "5", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);
            excelApp.get_Range(excelCols[36] + "2" + ":" + excelCols[48] + "5", Type.Missing).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));



            ExportPlanHeader fromHeader = headerList.Where(a => a.Subject.ToLower() == "from").ToList().FirstOrDefault();


            excelApp.get_Range(excelCols[49] + "2" + ":" + excelCols[49] + "2", Type.Missing).Value = "From :";
            excelApp.get_Range(excelCols[49] + "2" + ":" + excelCols[56] + "2", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[49] + "2" + ":" + excelCols[56] + "2", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignRight;

            if (fromHeader != null)
            {
                rang = excelApp.get_Range("BE2", Type.Missing);
                rang.Value = fromHeader.Text;
            }

            rang = excelApp.get_Range("BE5", Type.Missing);
            rang.Value = string.Format("{0}/{1}/{2}",DateTime.Now.Day,DateTime.Now.Month,DateTime.Now.Year);

            excelApp.get_Range(excelCols[49] + "3" + ":" + excelCols[49] + "3", Type.Missing).Value = "Page :";
            excelApp.get_Range(excelCols[49] + "3" + ":" + excelCols[56] + "3", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[49] + "3" + ":" + excelCols[56] + "3", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignRight;

            excelApp.get_Range(excelCols[49] + "4" + ":" + excelCols[49] + "4", Type.Missing).Value = "Revision :";
            excelApp.get_Range(excelCols[49] + "4" + ":" + excelCols[56] + "4", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[49] + "4" + ":" + excelCols[56] + "4", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignRight;


            excelApp.get_Range(excelCols[49] + "5" + ":" + excelCols[49] + "5", Type.Missing).Value = "Date of issued :";
            excelApp.get_Range(excelCols[49] + "5" + ":" + excelCols[56] + "5", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[49] + "5" + ":" + excelCols[56] + "5", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignRight;


            excelApp.get_Range(excelCols[49] + "2" + ":" + excelCols[56] + "5", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);




            





            //Sub menu

            rang = excelApp.get_Range("A6:BE7", Type.Missing);
            rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 153));

            rang.Font.Bold = true;

            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);


            excelApp.get_Range(excelCols[1] + "6" + ":" + excelCols[1] + "6", Type.Missing).Value = "Item";
            excelApp.get_Range(excelCols[1] + "6" + ":" + excelCols[1] + "6", Type.Missing).Orientation = XlOrientation.xlUpward;
            excelApp.get_Range(excelCols[1] + "6" + ":" + excelCols[1] + "7", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[1] + "6" + ":" + excelCols[1] + "7", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);


            excelApp.get_Range(excelCols[2] + "6" + ":" + excelCols[2] + "6", Type.Missing).Value = "RC";
           
            excelApp.get_Range(excelCols[2] + "6" + ":" + excelCols[2] + "7", Type.Missing).Merge(Type.Missing);
            excelApp.get_Range(excelCols[2] + "6" + ":" + excelCols[2] + "7", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            excelApp.get_Range(excelCols[2] + "6" + ":" + excelCols[2] + "7", Type.Missing).VerticalAlignment = XlVAlign.xlVAlignCenter;
            excelApp.get_Range(excelCols[2] + "6" + ":" + excelCols[2] + "7", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);





            rang = excelApp.get_Range(excelCols[3] + "6" + ":" + excelCols[3] + "6", Type.Missing);
            rang.Value = "Pipeline Section";

            rang = excelApp.get_Range(excelCols[3] + "6" + ":" + excelCols[4] + "6", Type.Missing);
            rang.Merge(Type.Missing);
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);


            rang = excelApp.get_Range(excelCols[3] + "7" + ":" + excelCols[3] + "7", Type.Missing);
            rang.Value = "Start - End";
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);

            rang = excelApp.get_Range(excelCols[4] + "7" + ":" + excelCols[4] + "7", Type.Missing);
            rang.Value = "KP";
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);








            excelApp.get_Range(excelCols[5] + "6" + ":" + excelCols[5] + "6", Type.Missing).Value = "Region";
            rang = excelApp.get_Range(excelCols[5] + "6" + ":" + excelCols[5] + "7", Type.Missing);
            rang.Merge(Type.Missing);
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);




            excelApp.get_Range(excelCols[6] + "6" + ":" + excelCols[6] + "6", Type.Missing).Value = "Dig from";
            rang = excelApp.get_Range(excelCols[6] + "6" + ":" + excelCols[6] + "7", Type.Missing);
            rang.Merge(Type.Missing);
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);


            excelApp.get_Range(excelCols[7] + "6" + ":" + excelCols[7] + "6", Type.Missing).Value = "Severity";
            rang = excelApp.get_Range(excelCols[7] + "6" + ":" + excelCols[7] + "7", Type.Missing);
            rang.Merge(Type.Missing);
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);



            excelApp.get_Range(excelCols[8] + "6" + ":" + excelCols[8] + "6", Type.Missing).Value = "Progress";
            rang = excelApp.get_Range(excelCols[8] + "6" + ":" + excelCols[8] + "7", Type.Missing);
            rang.Merge(Type.Missing);
            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;
            rang.BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);





            col = 0;
            int start = 9;
     
            for (month = 0; month < 12; month++)
            {


                col = (4 * month) + start;
                excelApp.get_Range(excelCols[col] + "6" + ":" + excelCols[col] + "6", Type.Missing).Value = months[month];

                excelApp.get_Range(excelCols[col] + "6" + ":" + excelCols[col + 3] + "6", Type.Missing).Merge(Type.Missing);
                excelApp.get_Range(excelCols[col] + "6" + ":" + excelCols[col + 3] + "6", Type.Missing).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelApp.get_Range(excelCols[col] + "6" + ":" + excelCols[col + 3] + "6", Type.Missing).VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelApp.get_Range(excelCols[col] + "6" + ":" + excelCols[col + 3] + "6", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);


                int week = 0;
                for (week =0; week < 4; week++)
                {
                    excelApp.get_Range(excelCols[col + week] + "7" + ":" + excelCols[col + week] + "7", Type.Missing).Value = (week+1);
                    excelApp.get_Range(excelCols[col + week] + "7" + ":" + excelCols[col + week] + "7", Type.Missing).Borders.LineStyle = XlLineStyle.xlDash;
                }
             
               
            }


            excelApp.get_Range(excelCols[57] + "2" + ":" + excelCols[57] + "5", Type.Missing).BorderAround(Type.Missing, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic);
            //  excelApp.get_Range(excelCols[9] + "7" + ":" + excelCols[12] + "7", Type.Missing).Borders(Type.Missing, XlBorderWeight.xlHairline, XlColorIndex.xlColorIndexAutomatic);

            #endregion

            #region detail


            row = 8;
            if (dtGroup != null && dtGroup.Rows.Count > 0)
            {
                foreach(DataRow dr in dtGroup.Rows)
                {
                    dv = new DataView(dtDetail);
                    dv.RowFilter = string.Format("PipelineID='{0}'", dr["PipelineID"].ToString());
                    dv.Sort = "RouteCode,RegionName,Progress desc";


                    rang = excelApp.get_Range(excelCols[1] + row.ToString() + ":" + excelCols[57] + row.ToString(), Type.Missing);
                    rang.Merge(Type.Missing);
                    rang.Value = dr["PipelineName"].ToString();
                    rang.Borders.LineStyle = XlLineStyle.xlContinuous;
           
                    rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(248, 249, 193));
                  

                    int rRow = 1;
                    foreach (DataRowView drr in dv)
                    {
                        row++;

                        rang= excelApp.get_Range(excelCols[1] + row.ToString() + ":" + excelCols[57] + row.ToString(), Type.Missing);
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                        if (drr["Progress"].ToString().Trim().ToLower().Equals("actual"))
                        {

                            rang = excelApp.get_Range(excelCols[1] + row.ToString() + ":" + excelCols[1] + row.ToString(), Type.Missing);
                            rang.Value = rRow.ToString();
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                            rang = excelApp.get_Range(excelCols[2] + row.ToString() + ":" + excelCols[2] + row.ToString(), Type.Missing);
                            rang.Value = drr["RouteCode"].ToString();
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;




                            rang = excelApp.get_Range(excelCols[3] + row.ToString() + ":" + excelCols[3] + row.ToString(), Type.Missing);
                            rang.Value = drr["PipelineName"].ToString();
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;



                            rang = excelApp.get_Range(excelCols[4] + row.ToString() + ":" + excelCols[4] + row.ToString(), Type.Missing);
                            rang.Value = drr["KP"].ToString();
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                            rang = excelApp.get_Range(excelCols[5] + row.ToString() + ":" + excelCols[5] + row.ToString(), Type.Missing);
                            rang.Value = drr["RegionName"].ToString();
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                            rang = excelApp.get_Range(excelCols[6] + row.ToString() + ":" + excelCols[6] + row.ToString(), Type.Missing);
                            rang.Value = drr["DIGFromName"].ToString();
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;





                            rang = excelApp.get_Range(excelCols[7] + row.ToString() + ":" + excelCols[6] + row.ToString(), Type.Missing);
                            rang.Value = drr["RiskScoreName"].ToString();
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            rang.VerticalAlignment = XlVAlign.xlVAlignCenter;






                          
                            if (drr["RiskScoreName"].ToString().Trim().ToLower().Equals("high"))
                            {
                              
                                rang.Font.Color= System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                                rang.Font.Bold = true;
                            }
                            rRow++;

                        }

                        excelApp.get_Range(excelCols[8] + row.ToString() + ":" + excelCols[8] + row.ToString(), Type.Missing).Value = drr["Progress"].ToString();
                        excelApp.get_Range(excelCols[8] + row.ToString() + ":" + excelCols[8] + row.ToString(), Type.Missing).Borders.LineStyle = XlLineStyle.xlContinuous;

                        if ( drr["Progress"].ToString().Trim().ToLower().Equals("actual"))
                        {
                            excelApp.get_Range(excelCols[1] + (row - 1).ToString() + ":" + excelCols[1] + row.ToString(), Type.Missing).Merge(Type.Missing);
                            excelApp.get_Range(excelCols[2] + (row - 1).ToString() + ":" + excelCols[2] + row.ToString(), Type.Missing).Merge(Type.Missing);
                            excelApp.get_Range(excelCols[3] + (row - 1).ToString() + ":" + excelCols[3] + row.ToString(), Type.Missing).Merge(Type.Missing);
                            excelApp.get_Range(excelCols[4] + (row - 1).ToString() + ":" + excelCols[4] + row.ToString(), Type.Missing).Merge(Type.Missing);
                            excelApp.get_Range(excelCols[5] + (row - 1).ToString() + ":" + excelCols[5] + row.ToString(), Type.Missing).Merge(Type.Missing);
                            excelApp.get_Range(excelCols[6] + (row - 1).ToString() + ":" + excelCols[6] + row.ToString(), Type.Missing).Merge(Type.Missing);
                            excelApp.get_Range(excelCols[7] + (row - 1).ToString() + ":" + excelCols[7] + row.ToString(), Type.Missing).Merge(Type.Missing);
                            rRow++;
                        }


                        col = 8;
                        if (drr["SpecSWeek"] !=null && drr["SpecTotal"] !=null
                             && drr["SpecTotal"].ToString()!="")
                        {
                            SpecSWeek = Utility.ConvertToInt(drr["SpecSWeek"].ToString());
                            SpecTotal = Utility.ConvertToInt(drr["SpecTotal"].ToString());
                            excelApp.get_Range(excelCols[col+ SpecSWeek] + row.ToString() + ":" + excelCols[col + SpecSWeek] + row.ToString(), Type.Missing).Value = "Spec";

                            rang = excelApp.get_Range(excelCols[col + SpecSWeek] + row.ToString() + ":" + excelCols[col + SpecSWeek + (SpecTotal - 1)] + row.ToString(), Type.Missing);
                            rang.Merge(Type.Missing);
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                            if (drr["Progress"].ToString().Trim().ToLower().Equals("plan"))
                            {
                                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(122, 192, 236));
                            }
                            else {
                                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(114, 225, 129));
                            }
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                        }


                        if (drr["POSWeek"] != null && drr["POTotal"] != null
                            && drr["POTotal"].ToString() != "")
                        {
                            POSWeek = Utility.ConvertToInt(drr["POSWeek"].ToString());
                            POTotal = Utility.ConvertToInt(drr["POTotal"].ToString());
                            excelApp.get_Range(excelCols[col + POSWeek] + row.ToString() + ":" + excelCols[col + POSWeek] + row.ToString(), Type.Missing).Value = "PO";


                            rang = excelApp.get_Range(excelCols[col + POSWeek] + row.ToString() + ":" + excelCols[col + POSWeek + (POTotal - 1)] + row.ToString(), Type.Missing);
                            rang.Merge(Type.Missing);
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                            if (drr["Progress"].ToString().Trim().ToLower().Equals("plan"))
                            {
                                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(85, 180, 240));
                            }
                            else {
                                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(79, 219, 98));
                            }
                        }


                        if (drr["ActionSWeek"] != null && drr["ActionTotal"] != null
                          && drr["ActionTotal"].ToString() != "")
                        {
                            ActionSWeek = Utility.ConvertToInt(drr["ActionSWeek"].ToString());
                            Actiontotal = Utility.ConvertToInt(drr["ActionTotal"].ToString());
                            excelApp.get_Range(excelCols[col + ActionSWeek] + row.ToString() + ":" + excelCols[col + ActionSWeek] + row.ToString(), Type.Missing).Value = "Acion";

                            rang = excelApp.get_Range(excelCols[col + ActionSWeek] + row.ToString() + ":" + excelCols[col + ActionSWeek + (Actiontotal - 1)] + row.ToString(), Type.Missing);
                            if (Actiontotal > 1)
                            {
                                rang.Merge(Type.Missing);

                            }
                            else {
                               
                            }
                            rang.Columns.AutoFit();
                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            if (drr["Progress"].ToString().Trim().ToLower().Equals("plan"))
                            {
                                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(50, 159, 228));
                            }
                            else
                            {
                                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(38, 200, 61));
                            }


                        }




                        /*dr["SpecSWeek"] = "1";
                        dr["POSWeek"] = "5";
                        dr["ActionSWeek"] = "9";

                        dr["Spec"] = "4";
                        dr["PO"] = "4";
                        dr["Action"] = "4";*/



                    }
                    row++;

                }

                lastRow = row;
            }

            #endregion

            #region footer

            lastRow = row;
            excelApp.get_Range(excelCols[1] + (row).ToString() + ":" + excelCols[1] + row.ToString(), Type.Missing).Value = "Note :";
            excelApp.get_Range(excelCols[1] + (row).ToString() + ":" + excelCols[8] + row.ToString(), Type.Missing).Merge(Type.Missing);


            excelApp.get_Range(excelCols[9] + (row).ToString() + ":" + excelCols[9] + row.ToString(), Type.Missing).Value = "Remark :";
            excelApp.get_Range(excelCols[9] + (row).ToString() + ":" + excelCols[36] + row.ToString(), Type.Missing).Merge(Type.Missing);



            excelApp.get_Range(excelCols[37] + (row).ToString() + ":" + excelCols[37] + row.ToString(), Type.Missing).Value = "Reference Documents :";
            excelApp.get_Range(excelCols[37] + (row).ToString() + ":" + excelCols[57] + row.ToString(), Type.Missing).Merge(Type.Missing);


            row++;

            rang = excelApp.get_Range(excelCols[1] + (lastRow).ToString() + ":" + excelCols[8] + (row+4).ToString(), Type.Missing);
            rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));

            rang = excelApp.get_Range(excelCols[9] + (lastRow).ToString() + ":" + excelCols[36] + (row + 4).ToString(), Type.Missing);
            rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));


            rang = excelApp.get_Range(excelCols[37] + (lastRow).ToString() + ":" + excelCols[57] + (row + 4), Type.Missing);
            rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));


            int rowRemark = row;



           List<ExportPlanHeader> noteFooter= headerList.Where(a => a.Subject.ToLower()=="note").ToList();
            List<ExportPlanHeader> remarkFooter = headerList.Where(a => a.Subject.ToLower() == "remark").ToList();
            List<ExportPlanHeader> referenceFooter = headerList.Where(a => a.Subject.ToLower() == "reference").ToList();

            for (int rowTemp = 0; rowTemp < 4; rowTemp++)
            {
                if (noteFooter.Count > rowTemp)
                {
                    excelApp.get_Range(excelCols[1] + (row).ToString() + ":" + excelCols[1] + row.ToString(), Type.Missing).Value =string.Format("{0}.{1}", rowTemp+1, noteFooter[rowTemp].Text);
                }

                if (remarkFooter.Count > rowTemp)
                {
                    if ((rowTemp) % 2 == 0 )
                    {
                        if (rowTemp > 0)
                        {
                            rowRemark++;
                        }

                      

                        excelApp.get_Range(excelCols[9] + (rowRemark).ToString() + ":" + excelCols[9] + rowRemark.ToString(), Type.Missing).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml(remarkFooter[rowTemp].Color));
                        excelApp.get_Range(excelCols[10] + (rowRemark).ToString() + ":" + excelCols[10] + rowRemark.ToString(), Type.Missing).Value = remarkFooter[rowTemp].Text;
                        excelApp.get_Range(excelCols[10] + (rowRemark).ToString() + ":" + excelCols[21] + rowRemark.ToString(), Type.Missing).Merge(Type.Missing);
                        
                    }
                    else {
                        excelApp.get_Range(excelCols[22] + (rowRemark).ToString() + ":" + excelCols[22] + rowRemark.ToString(), Type.Missing).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.ColorTranslator.FromHtml(remarkFooter[rowTemp].Color));
                        excelApp.get_Range(excelCols[23] + (rowRemark).ToString() + ":" + excelCols[23] + rowRemark.ToString(), Type.Missing).Value = remark[rowTemp];
                        excelApp.get_Range(excelCols[23] + (rowRemark).ToString() + ":" + excelCols[36] + rowRemark.ToString(), Type.Missing).Merge(Type.Missing);

                    }
                   
                }

                if (referenceFooter.Count> rowTemp)
                {
                    excelApp.get_Range(excelCols[37] + (row).ToString() + ":" + excelCols[37] + row.ToString(), Type.Missing).Value = string.Format("{0}.{1}", rowTemp + 1, referenceFooter[rowTemp].Text); 
                }
                    excelApp.get_Range(excelCols[1] + (row).ToString() + ":" + excelCols[8] + row.ToString(), Type.Missing).Merge(Type.Missing);

               
                excelApp.get_Range(excelCols[37] + (row).ToString() + ":" + excelCols[57] + row.ToString(), Type.Missing).Merge(Type.Missing);
                row++;
            }


           
           

            rang = excelApp.get_Range(excelCols[1] + (lastRow).ToString() + ":" + excelCols[8] + row.ToString(), Type.Missing);
            rang.BorderAround(Type.Missing, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
          //  rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));



            rang = excelApp.get_Range(excelCols[9] + (lastRow).ToString() + ":" + excelCols[36] + row.ToString(), Type.Missing);
            rang.BorderAround(Type.Missing, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
           // rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));

            rang = excelApp.get_Range(excelCols[37] + (lastRow).ToString() + ":" + excelCols[57] + row.ToString(), Type.Missing);
            rang.BorderAround(Type.Missing, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic);
           // rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 255));




            #endregion

            #region Export to excel file

            FileInfo myFile;

            
            uploadPath = HttpContext.Current.Server.MapPath(desPath);
            fullPath = uploadPath +"\\"+ nameExcel;
            if (Utility.HaveDirectory(uploadPath))
            {
                myFile = new FileInfo(fullPath);
                if (myFile != null)
                {
                    myFile.Delete();
                }
                myFile = null;
            }

            
                // save file
                worksheet.SaveAs(fullPath);
                excelApp.Application.Quit();
                excelApp.Quit();

                //////////////////////
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(excelApp);


            System.IO.FileStream fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Open);
            Byte[] b = new byte[fs.Length];
            fs.Read(b, 0, (int)fs.Length);
            fs.Close();


            myFile = new FileInfo(fullPath);
            if (myFile != null)
            {
                myFile.Delete();
            }
            myFile = null;


            #endregion
            return b;
        }



        public byte[] ExportSummaryPlanToExcel(SummaryPlanReport summaryPlanReport,string desPath, string nameExcel)
        {
            Byte[] byteOutput = null;
            FileInfo myFile = null;
            string fullPath = "";
            _Chart graph = null;
            Range range = null;
            List<ProgressGraphDto> results = null;
            int row = 0;
            Range rangeStart = null;
            try {


                excelApp = new Application();




                excelApp.StandardFont = "Tahoma";
                excelApp.StandardFontSize = 10;

                workbook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];



                #region  Write Chart

                excelApp.get_Range( "B5:B5", Type.Missing).Value = "ความครบถ้วนของการดำเนินงาน";
                range= excelApp.get_Range("B5:C5", Type.Missing);
                range.Merge(Type.Missing);



                //Graph 1
                row = 6;
                results = summaryPlanReport.RawGraphReport;
                if(results!=null && results.Count>0)
                {
                    foreach (ProgressGraphDto dto in results)
                    {

                        excelApp.get_Range("B"+ row, Type.Missing).Value = dto.name;
                        excelApp.get_Range("C" + row, Type.Missing).Value = dto.Complete;
                        row++;
                    }



                    #region Set cell sheet to chart's axis

                    rangeStart = excelApp.get_Range("B13:B13", Type.Missing);
                    WriteChartDoughnut((Microsoft.Office.Interop.Excel.ChartObjects)worksheet.ChartObjects(Type.Missing)
                               , rangeStart
                               , excelApp.get_Range("B6:C" + (6 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("B6:B" + (6 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("C6:C" + (6 + (results.Count - 1)), Type.Missing)
                               , "ความครบถ้วนของการดำเนินงาน");

                    #endregion


                }





                //Graph 2
                row = 6;

                excelApp.get_Range("T5:T5", Type.Missing).Value = "ผลการประเมินความเสี่ยง";
                range = excelApp.get_Range("T5:U5", Type.Missing);
                range.Merge(Type.Missing);


                results = summaryPlanReport.RawRiskGraphBeforeReport;
                if (results != null && results.Count > 0)
                {
                    foreach (ProgressGraphDto dto in results)
                    {

                        excelApp.get_Range("T" + row, Type.Missing).Value = dto.name;
                        excelApp.get_Range("U" + row, Type.Missing).Value = dto.Complete;
                        row++;
                    }


                    #region Set cell sheet to chart's axis

                    rangeStart = excelApp.get_Range("H2:H2", Type.Missing);
                    WriteChartDoughnut((Microsoft.Office.Interop.Excel.ChartObjects)worksheet.ChartObjects(Type.Missing)
                               , rangeStart
                               , excelApp.get_Range("T6:U" + (6 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("T6:T" + (6 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("U6:U" + (6 + (results.Count - 1)), Type.Missing)
                               , "ผลการประเมินความเสี่ยง");

                    #endregion



                }




                //Graph 3
                row = 15;

                excelApp.get_Range("T14:T14", Type.Missing).Value = "Coating defect type";
                range = excelApp.get_Range("T14:U14", Type.Missing);
                range.Merge(Type.Missing);


                results = summaryPlanReport.RawRiskGraphCoatingTypeReport;
                if (results != null && results.Count > 0)
                {
                    foreach (ProgressGraphDto dto in results)
                    {

                        excelApp.get_Range("T" + row, Type.Missing).Value = dto.name;
                        excelApp.get_Range("U" + row, Type.Missing).Value = dto.Complete;
                        row++;
                    }


                    #region Set cell sheet to chart's axis

                    rangeStart = excelApp.get_Range("N2:N2", Type.Missing);
                    WriteChartDoughnut((Microsoft.Office.Interop.Excel.ChartObjects)worksheet.ChartObjects(Type.Missing)
                               , rangeStart
                               , excelApp.get_Range("T15:U" + (15 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("T15:T" + (15 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("U15:U" + (15 + (results.Count - 1)), Type.Missing)
                               , "Coating defect type");

                    #endregion

                }




                //Graph 4
                row = 29;

                excelApp.get_Range("T28:T28", Type.Missing).Value = "ผลการประเมินความเสี่ยง";
                range = excelApp.get_Range("T28:U28", Type.Missing);
                range.Merge(Type.Missing);


                results = summaryPlanReport.RawRiskGraphAfterReport;
                if (results != null && results.Count > 0)
                {
                    foreach (ProgressGraphDto dto in results)
                    {

                        excelApp.get_Range("T" + row, Type.Missing).Value = dto.name;
                        excelApp.get_Range("U" + row, Type.Missing).Value = dto.Complete;
                        row++;
                    }

                    #region Set cell sheet to chart's axis

                    rangeStart = excelApp.get_Range("H25:H25", Type.Missing);
                    WriteChartDoughnut((Microsoft.Office.Interop.Excel.ChartObjects)worksheet.ChartObjects(Type.Missing)
                               , rangeStart
                               , excelApp.get_Range("T29:U" + (29 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("T29:T" + (29 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("U29:U" + (29 + (results.Count - 1)), Type.Missing)
                               , "ผลการประเมินความเสี่ยง");

                    #endregion




                }



                //Graph 5
                row = 34;

                excelApp.get_Range("T33:T33", Type.Missing).Value = "Pipeline defect type";
                range = excelApp.get_Range("T33:U33", Type.Missing);
                range.Merge(Type.Missing);


                results = summaryPlanReport.RawRiskGraphPipelineTypeReport;
                if (results != null && results.Count > 0)
                {
                    foreach (ProgressGraphDto dto in results)
                    {

                        excelApp.get_Range("T" + row, Type.Missing).Value = dto.name;
                        excelApp.get_Range("U" + row, Type.Missing).Value = dto.Complete;
                        row++;
                    }


                    #region Set cell sheet to chart's axis

                    rangeStart = excelApp.get_Range("N25:N25", Type.Missing);
                    WriteChartDoughnut((Microsoft.Office.Interop.Excel.ChartObjects)worksheet.ChartObjects(Type.Missing)
                               , rangeStart
                               , excelApp.get_Range("T34:U" + (34 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("T34:T" + (34 + (results.Count - 1)), Type.Missing)
                               , excelApp.get_Range("U34:U" + (34 + (results.Count - 1)), Type.Missing)
                               , "Pipeline defect type");

                    #endregion


                }








                #endregion


                row = 50;
                #region Write table

                //   Customer type   Inspection date Route code  Section KP.	Region Dig form Defect type severity   Defect type Pipeline severity   Status

                rang = excelApp.get_Range("AA"+row + ":AM" + (row+1), Type.Missing);
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                rang = excelApp.get_Range("AA" + row + ":AM" + row , Type.Missing);
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(50, 159, 228));


                rang = excelApp.get_Range("AA" + (row + 1)+ ":AM" + (row + 1), Type.Missing);
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(152, 208, 242));


                rang = excelApp.get_Range("AH" + row, Type.Missing);
                rang.Value = "Coating Inspection Result";
                rang = excelApp.get_Range("AH" + row + ":AI" + row, Type.Missing);
                rang.Merge(Type.Missing);
                


                rang = excelApp.get_Range("AJ" + row, Type.Missing);
                rang.Value = "Pipeline Inspection Result";
                rang = excelApp.get_Range("AJ" + row + ":AK" + row, Type.Missing);
                rang.Merge(Type.Missing);




                rang = excelApp.get_Range("AA" + (row + 1), Type.Missing);
                rang.Value = "Customer type";
                rang.Columns.AutoFit();

                rang = excelApp.get_Range("AB" + (row + 1), Type.Missing);
                rang.Value = "Inspection date";
                rang.Columns.AutoFit();


                rang = excelApp.get_Range("AC" + (row + 1), Type.Missing);
                rang.Value = "Route code";
                rang.Columns.AutoFit();

                rang = excelApp.get_Range("AD" + (row + 1), Type.Missing);
                rang.Value = "Section";
                rang.Columns.AutoFit();



                rang = excelApp.get_Range("AE" + (row + 1), Type.Missing);
                rang.Value = "KP";
                rang.Columns.AutoFit();

                rang = excelApp.get_Range("AF" + (row + 1), Type.Missing);
                rang.Value = "Region";
                rang.Columns.AutoFit();

                rang = excelApp.get_Range("AG" + (row + 1), Type.Missing);
                rang.Value = "Dig form";
                rang.Columns.AutoFit();

                rang = excelApp.get_Range("AH" + (row + 1), Type.Missing);
                rang.Value = "Defect type";
                rang.Columns.AutoFit();

                rang = excelApp.get_Range("AI" + (row + 1), Type.Missing);
                rang.Value = "severity";
                rang.Columns.AutoFit();

                rang = excelApp.get_Range("AJ" + (row + 1), Type.Missing);
                rang.Value = "Defect type";
                rang.Columns.AutoFit();



                rang = excelApp.get_Range("AK" + (row + 1), Type.Missing);
                rang.Value = "Pipeline";
                rang.Columns.AutoFit();


                rang = excelApp.get_Range("AL" + (row + 1), Type.Missing);
                rang.Value = "severity";
                rang.Columns.AutoFit();


                rang = excelApp.get_Range("AM" + (row + 1), Type.Missing);
                rang.Value = "Status";
                rang.Columns.AutoFit();

                row = 52;

                if (summaryPlanReport.OverAllTableReport != null && summaryPlanReport.OverAllTableReport.Count > 0)
                {

                    foreach (SummaryPlanOverAllProgressDto dto in summaryPlanReport.OverAllTableReport)
                    {
                        rang = excelApp.get_Range("AA"+ row, Type.Missing);
                        rang.Value = dto.AssetOwner;
                       // rang.Columns.AutoFit();
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        rang = excelApp.get_Range("AB" + row, Type.Missing);
                        rang.Value = dto.InspectionDate;
                       // rang.Columns.AutoFit();
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        rang = excelApp.get_Range("AC" + row, Type.Missing);
                        rang.Value = dto.RouteCodeName;
                       // rang.Columns.AutoFit();
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        rang = excelApp.get_Range("AD" + row, Type.Missing);
                        rang.Value = dto.Section;
                        //rang.Columns.AutoFit();
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        rang = excelApp.get_Range("AE" + row, Type.Missing);
                        rang.Value = dto.KP;
                      //  rang.Columns.AutoFit();
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        rang = excelApp.get_Range("AF" + row, Type.Missing);
                        rang.Value = dto.RegionName;
                        //rang.Columns.AutoFit();
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        rang = excelApp.get_Range("AG" + row, Type.Missing);
                        rang.Value = dto.DigFrom;
                        //rang.Columns.AutoFit();
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;



                        rang = excelApp.get_Range("AH" + row, Type.Missing);
                        rang.Value = dto.CoatingDefectType;
                        rang.WrapText = true;
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        rang = excelApp.get_Range("AI" + row, Type.Missing);
                        rang.Value = dto.CoatingServerity;
                        rang.WrapText = true;
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        rang = excelApp.get_Range("AJ" + row, Type.Missing);
                        rang.Value = dto.PipelineDefectType;
                        rang.WrapText = true;
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        rang = excelApp.get_Range("AK" + row, Type.Missing);
                        rang.Value = dto.PipelineServerity;
                        rang.WrapText = true;
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        rang = excelApp.get_Range("AL" + row, Type.Missing);
                        rang.Value = dto.Status;
      
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        row++;
                    }

                }

              
              //  rang.Columns.AutoFit();
                #endregion






                #region Export to excel file




                uploadPath = HttpContext.Current.Server.MapPath(desPath);
                fullPath = uploadPath + "\\" + nameExcel;
                if (Utility.HaveDirectory(uploadPath))
                {
                    myFile = new FileInfo(fullPath);
                    if (myFile != null)
                    {
                        myFile.Delete();
                    }
                    myFile = null;
                }


                // save file
                worksheet.SaveAs(fullPath);
                excelApp.Application.Quit();
                excelApp.Quit();
                GC.Collect();
                //////////////////////
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(excelApp);


                System.IO.FileStream fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Open);
                byteOutput = new byte[fs.Length];
                fs.Read(byteOutput, 0, (int)fs.Length);
                fs.Close();


                myFile = new FileInfo(fullPath);
                if (myFile != null)
                {
                    myFile.Delete();
                }
                myFile = null;


                #endregion


            }
            catch (Exception ex)
            { }
            finally
            {

                //if (excelApp != null && workbook != null)
                //{
                //    workbook.Close(false, misValue, misValue);
                //    GC.Collect();
                //    excelApp = null;
                //    releaseObject(worksheet);
                //    releaseObject(workbook);
                //    releaseObject(excelApp);
                //}
            }


            return byteOutput;


        }

        public byte[] ExportSummaryCompletelyToExcel(SummaryPlanReport summaryPlanReport, string desPath, string nameExcel)
        {
            Byte[] byteOutput = null;
            FileInfo myFile = null;
            string fullPath = "";
            _Chart graph = null;
            Range range = null;
            List<SummaryCompletelyByRegionDto> results = null;
            int row = 0;
            int lastColumn = 0;
            Range rangeStart = null;
            int totalRegions = 0;
            string year = "2018";

            Microsoft.Office.Interop.Excel.Axes xlAxisCategory, xlAxisValue;
            try
            {

                totalRegions = summaryPlanReport.regionList.Count;
                excelApp = new Application();




                excelApp.StandardFont = "Tahoma";
                excelApp.StandardFontSize = 10;

                workbook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];






                row = 30;
                #region Write table

                lastColumn = 2;

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[9] + (row + 1 + (totalRegions)), Type.Missing);
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[9] + (row + 1), Type.Missing);
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(50, 159, 228));


                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Region";

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Merge(Type.Missing);
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;



                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "PM";
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Transmission";


                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Estimate";
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "this year";


                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Postpone to ";
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "this year";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Q1";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Q2";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Q3";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Q4";





                row = 32;
                if (summaryPlanReport.SumaryCompletelyByRegionTable != null && summaryPlanReport.SumaryCompletelyByRegionTable.Count > 0)
                {
                    foreach (SummaryCompletelyByRegionDto dto in summaryPlanReport.SumaryCompletelyByRegionTable)
                    {
                        lastColumn = 2;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = dto.RegionName;
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Actual) >0 ? Utility.ConvertToInt(dto.Actual).ToString() + "%":"";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Plan) > 0 ?  Utility.ConvertToInt(dto.Plan).ToString() + "%" :"";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.PostPone) > 0 ?  Utility.ConvertToInt(dto.PostPone).ToString() + "%" : ""; ;
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q1) > 0 ?  Utility.ConvertToInt(dto.Q1).ToString() + "%" : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q2) > 0 ?  Utility.ConvertToInt(dto.Q2).ToString() + "%" : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q3) > 0 ?  Utility.ConvertToInt(dto.Q3).ToString() + "%" : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q4) > 0 ?  Utility.ConvertToInt(dto.Q4).ToString() + "%" : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        row++;
                    }


                }


                #region By Assert Owner
                /*        row = 30;

                        lastColumn = 11;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn + 8 + totalRegions] + (row + 1 + (summaryPlanReport.TableReport.Count)), Type.Missing);
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                        rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                        rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn + 8 + totalRegions] + (row + 1), Type.Missing);
                        rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(50, 159, 228));


                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = "PM";
                        rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                        rang.Value = summaryPlanReport.TableReport[0].AssetOwner;

                        for (int i = 1; i <= totalRegions; i++)
                        {
                            rang = excelApp.get_Range(excelCols[lastColumn + i] + row, Type.Missing);
                            rang.Value = summaryPlanReport.regionList[i - 1].Name;

                        }

                        lastColumn = lastColumn + totalRegions;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = "Estimate";
                        rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                        rang.Value = "this year";

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = "Postpone";
                        rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                        rang.Value = "to next year";

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = "Plan";


                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = "Q1";

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = "Q2";

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = "Q3";


                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = "Q4";



                        rang.Columns.AutoFit();


                        row = 32;
                        if (summaryPlanReport.TableReport != null && summaryPlanReport.TableReport.Count > 0)
                        {
                            System.Data.DataTable dt = Utility.ToDataTable(summaryPlanReport.TableReport);
                            int postPone = 0;
                            foreach (DataRow dr in dt.Rows)
                            {
                                lastColumn = 11;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dr["Total"].ToString();
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(145, 201, 87));


                                for (int i = 1; i <= totalRegions; i++)
                                {
                                    rang = excelApp.get_Range(excelCols[lastColumn + i] + row, Type.Missing);
                                    rang.Value = dr[summaryPlanReport.regionList[i - 1].RegionCode].ToString();

                                }

                                lastColumn = lastColumn + totalRegions;






                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dr["EstimateYear"].ToString();


                                lastColumn++;
                                postPone = Utility.ConvertToInt(dr["PostPone"].ToString());
                                //postPone = 100 - (Utility.ConvertToInt(dr["Total"].ToString()) - Utility.ConvertToInt(dr["PostPone"].ToString())); 
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dr["PostPone"].ToString(); //dr["PostPone"].ToString();


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = 100 - (Utility.ConvertToInt(dr["Total"].ToString()) - postPone);


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dr["Q1"].ToString();

                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dr["Q2"].ToString();

                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dr["Q3"].ToString();


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dr["Q4"].ToString();


                                row++;
                            }
                        }


                        */

                #endregion
                //  rang.Columns.AutoFit();
                #endregion




                #region  Write Chart

                //excelApp.get_Range("B2:B2", Type.Missing).Value = "PM Transmission " + year;
                //range = excelApp.get_Range("B2:C2", Type.Missing);
                //range.Merge(Type.Missing);





                results = summaryPlanReport.SumaryCompletelyByRegionTable;
                if (results != null && results.Count > 0)
                {



                    #region Set cell sheet to chart's axis

                    rangeStart = excelApp.get_Range("B2:B2", Type.Missing);
                    /*  WriteChartDoughnut((Microsoft.Office.Interop.Excel.ChartObjects)worksheet.ChartObjects(Type.Missing)
                                   , rangeStart
                                   , excelApp.get_Range("A32:H" + (32 + (results.Count - 1)), Type.Missing)
                                   , excelApp.get_Range("A32:A" + (32 + (results.Count - 1)), Type.Missing)
                                   , excelApp.get_Range("C6:C" + (32 + (results.Count - 1)), Type.Missing)
                                   , "ความครบถ้วนของการดำเนินงาน");
  */


                    Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)worksheet.ChartObjects(Type.Missing).Add(rangeStart.Left, rangeStart.Top, 500, 250);

                    Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;



                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xl3DColumnStacked100;
                    chartPage.HasTitle = true;
                    chartPage.HasLegend = true;

                    chartPage.Legend.Position = XlLegendPosition.xlLegendPositionTop;
                    chartPage.ChartTitle.Text = "PM Transmission " + year;
                    chartPage.ChartTitle.Font.Size = 10;

                    //  Microsoft.Office.Interop.Excel.Axis xAxis = (Microsoft.Office.Interop.Excel.Axis)chartPage.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);

                    //  Microsoft.Office.Interop.Excel.Axis yAxis = (Microsoft.Office.Interop.Excel.Axis)chartPage.Axes(XlAxisType.xlValue, XlAxisGroup.xlSecondary);

                    // xlAxisCategory = (Microsoft.Office.Interop.Excel.Axis)chartPage.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);


                    chartPage.SetSourceData(excelApp.get_Range("B32:B" + (32 + (results.Count - 1)), Type.Missing), misValue);


                    Microsoft.Office.Interop.Excel.Axis xAxis = (Microsoft.Office.Interop.Excel.Axis)chartPage.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
                    xAxis.CategoryNames = "";

                    Microsoft.Office.Interop.Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();


                    Series ser = seriesCollection.NewSeries();
                    ser.Name = "Actual";

                    ser = seriesCollection.NewSeries();
                    ser.Name = "Plan";

                    ser = seriesCollection.NewSeries();
                    ser.Name = "PostPone";

                    ser = seriesCollection.NewSeries();
                    ser.Name = "Q1";
                    ser.MarkerStyle = XlMarkerStyle.xlMarkerStyleSquare;
                    ser = seriesCollection.NewSeries();
                    ser.Name = "Q2";
                    ser.MarkerStyle = XlMarkerStyle.xlMarkerStyleSquare;
                    ser = seriesCollection.NewSeries();
                    ser.Name = "Q3";
                    ser.MarkerStyle = XlMarkerStyle.xlMarkerStyleSquare;
                    ser = seriesCollection.NewSeries();
                    ser.Name = "Q4";
                    ser.MarkerStyle = XlMarkerStyle.xlMarkerStyleSquare;



                

                    Microsoft.Office.Interop.Excel.SeriesCollection serie = (Microsoft.Office.Interop.Excel.SeriesCollection)chartPage.SeriesCollection(Missing.Value);

                    int countReal = 0;
                    string valueY = string.Empty, valueX = string.Empty;
                    int count = 1;
                    Series mys;
                    while (count <= serie.Count)
                    {
                         mys = (Series)serie.Item(count);
                       
                        mys.XValues = excelApp.get_Range("B32:B" + (32 + (results.Count - 1)), Type.Missing);
                        mys.Values = excelApp.get_Range(string.Format("{0}32", ConvertNo2ColExcel(count+1 )), string.Format("{0}{1}", ConvertNo2ColExcel((count+1)), (32 + (results.Count - 1))));

                        if (count > 4)
                        {
                           // mys.AxisGroup = Microsoft.Office.Interop.Excel.XlAxisGroup.xlSecondary;

                          //  mys.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlLineMarkers;

                            mys.ChartType = XlChartType.xlLineMarkers;
                            //  mys.ChartType = XlChartType.xlLine;
                            //  s1.MarkerStyle = XlMarkerStyle.xlMarkerStyleCircle;
                            mys.MarkerStyle = XlMarkerStyle.xlMarkerStyleDash;
                            
                           // mys.MarkerBackgroundColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                            mys.MarkerForegroundColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 0, 0));
                            mys.MarkerSize = 15;
                            mys.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                            mys.Format.Line.Transparency = 0;
                          mys.Format.Line.Weight = 1;
                          //  mys.DataLabels(0).HasSeriesName = true;




                        }
                        else {
                            mys.ChartType = XlChartType.xlColumnStacked100;
                        }

                        // mys.MarkerStyle = XlMarkerStyle.xlMarkerStyleDash;
                        // mys.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowPercent, true, true, false, false, false, false, true);
                        count += 1;
                    }


                    chartPage.ApplyDataLabels(
      Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel,
      false, false, false, true, false, false, false,
      false, false);



                    
                    mys = (Series)serie.Item(1);
                    mys.Delete();
                    Legend chartLengend = (Legend)chartPage.Legend;

                    serie = (Microsoft.Office.Interop.Excel.SeriesCollection)chartPage.SeriesCollection(Missing.Value);

                    for (int i = serie.Count;i > 0; i--)
                    {
                        if (serie.Item(i).Name=="Q1" 
                            || serie.Item(i).Name == "Q2"
                            || serie.Item(i).Name == "Q3"
                             || serie.Item(i).Name == "Q4")
                        {
                             chartLengend.LegendEntries(i).Delete();
                        }

                    }
                    //    series1.Name = "";
                    //  series1.XValues = excelApp.get_Range("A32:A" + (32 + (results.Count - 1)), Type.Missing);
                    // series1.Values = excelApp.get_Range("B32:B" + (32 + (results.Count - 1)), Type.Missing);



                    Axis vertAxis = (Axis)chartPage.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);

                 
                   




                    chartPage.Refresh();



                    #endregion


                }
    








        #endregion

        #region Export to excel file




        uploadPath = HttpContext.Current.Server.MapPath(desPath);
                fullPath = uploadPath + "\\" + nameExcel;
                if (Utility.HaveDirectory(uploadPath))
                {
                    myFile = new FileInfo(fullPath);
                    if (myFile != null)
                    {
                        myFile.Delete();
                    }
                    myFile = null;
                }


                // save file
                worksheet.SaveAs(fullPath);
                excelApp.Application.Quit();
                excelApp.Quit();
                GC.Collect();
                //////////////////////
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(excelApp);


                System.IO.FileStream fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Open);
                byteOutput = new byte[fs.Length];
                fs.Read(byteOutput, 0, (int)fs.Length);
                fs.Close();


                myFile = new FileInfo(fullPath);
                if (myFile != null)
                {
                    myFile.Delete();
                }
                myFile = null;


                #endregion


            }
            catch (Exception ex)
            { }
            finally
            {

                //if (excelApp != null && workbook != null)
                //{
                //    workbook.Close(false, misValue, misValue);
                //    GC.Collect();
                //    excelApp = null;
                //    releaseObject(worksheet);
                //    releaseObject(workbook);
                //    releaseObject(excelApp);
                //}
            }


            return byteOutput;


        }




        public byte[] ExportSummaryRiskToExcel(SummaryPlanReport summaryPlanReport, string desPath, string nameExcel)
        {
            Byte[] byteOutput = null;
            FileInfo myFile = null;
            string fullPath = "";
            _Chart graph = null;
            Range range = null;
            List<SummaryPlanRiskDto> results = null;
            int row = 0;
            int lastColumn = 0;
            Range rangeStart = null;
            int totalRegions = 0;
            string year = "2018";

            Microsoft.Office.Interop.Excel.Axes xlAxisCategory, xlAxisValue;
            try
            {

             
                excelApp = new Application();




                excelApp.StandardFont = "Tahoma";
                excelApp.StandardFontSize = 10;

                workbook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];






                row = 30;
                #region Write table

                lastColumn = 2;
                int endColumn = 17;



                for (int col = lastColumn; col <= endColumn; col++)
                {
                    excelApp.Columns[excelCols[lastColumn]].ColumnWidth = 21;

                  
                }

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[endColumn] + (row + 1 ), Type.Missing);
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[endColumn] + (row + 1), Type.Missing);
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(50, 159, 228));


                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Region";

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Merge(Type.Missing);
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;



                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "ไตรมาส 1";

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn+2] + row , Type.Missing);
                rang.Merge(Type.Missing);

                rang.WrapText = true;
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;




               
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Low Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(102, 179, 255));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Medium Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 193, 7));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "High Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 53, 69));







                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "ไตรมาส 2";

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn + 2] + row, Type.Missing);
                rang.Merge(Type.Missing);
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;





                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Low Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(102, 179, 255));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Medium Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 193, 7));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "High Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 53, 69));






                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "ไตรมาส 3";

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn + 2] + row, Type.Missing);
                rang.Merge(Type.Missing);
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;





                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Low Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(102, 179, 255));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Medium Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 193, 7));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "High Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 53, 69));




                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "ไตรมาส 4";

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn + 2] + row, Type.Missing);
                rang.Merge(Type.Missing);
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;





                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Low Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(102, 179, 255));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Medium Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 193, 7));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "High Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 53, 69));




                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "Total";

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn + 2] + row, Type.Missing);
                rang.Merge(Type.Missing);
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;





                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Low Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(102, 179, 255));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Medium Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 193, 7));

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "High Risk";
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 53, 69));







                row = 32;
                if (summaryPlanReport.RiskTableReport != null && summaryPlanReport.RiskTableReport.Count > 0)
                {
                    foreach (SummaryPlanRiskDto dto in summaryPlanReport.RiskTableReport)
                    {
                        lastColumn = 2;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = dto.RegionName;
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q1Low) > 0 ? Utility.ConvertToInt(dto.Q1Low).ToString()  : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q1Medium) > 0 ? Utility.ConvertToInt(dto.Q1Medium).ToString()  : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q1High) > 0 ? Utility.ConvertToInt(dto.Q1High).ToString(): ""; ;
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q2Low) > 0 ? Utility.ConvertToInt(dto.Q2Low).ToString()  : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q2Medium) > 0 ? Utility.ConvertToInt(dto.Q2Medium).ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q2High) > 0 ? Utility.ConvertToInt(dto.Q2High).ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q3Low) > 0 ? Utility.ConvertToInt(dto.Q3Low).ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q3Medium) > 0 ? Utility.ConvertToInt(dto.Q3Medium).ToString()  : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q3High) > 0 ? Utility.ConvertToInt(dto.Q3High).ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q4Low) > 0 ? Utility.ConvertToInt(dto.Q4Low).ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;



                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q4Medium) > 0 ? Utility.ConvertToInt(dto.Q4Medium).ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = Utility.ConvertToInt(dto.Q4High) > 0 ? Utility.ConvertToInt(dto.Q4High).ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;



                        lastColumn++;

                        int lowTotal = Utility.ConvertToInt(dto.Q1Low) + Utility.ConvertToInt(dto.Q2Low) + Utility.ConvertToInt(dto.Q3Low) + Utility.ConvertToInt(dto.Q4Low);
                        int mediumTotal = Utility.ConvertToInt(dto.Q1Medium) + Utility.ConvertToInt(dto.Q2Medium) + Utility.ConvertToInt(dto.Q3Medium) + Utility.ConvertToInt(dto.Q4Medium);
                        int highTotal = Utility.ConvertToInt(dto.Q1High) + Utility.ConvertToInt(dto.Q2High) + Utility.ConvertToInt(dto.Q3High) + Utility.ConvertToInt(dto.Q4High);

                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = lowTotal > 0 ? lowTotal.ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;



                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = mediumTotal > 0 ? mediumTotal.ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                        lastColumn++;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = highTotal > 0 ? highTotal.ToString() : "";
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;




                        row++;
                    }


                }



                #endregion




                #region  Write Chart





                results = summaryPlanReport.RiskTableReport;
                if (results != null && results.Count > 0)
                {



                    #region Set cell sheet to chart's axis

                    rangeStart = excelApp.get_Range("B2:B2", Type.Missing);


                    Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)worksheet.ChartObjects(Type.Missing).Add(rangeStart.Left, rangeStart.Top, 500, 250);

                    Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;



                    chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnStacked;
                    chartPage.HasTitle = true;
                    chartPage.HasLegend = true;

                    chartPage.Legend.Position = XlLegendPosition.xlLegendPositionTop;
                    chartPage.ChartTitle.Text = "ผลประเมินความเสี่ยง " + year;
                    chartPage.ChartTitle.Font.Size = 10;

                   
                    chartPage.SetSourceData(excelApp.get_Range("B32:B" + (32 + (results.Count - 1)), Type.Missing), misValue);


                    Microsoft.Office.Interop.Excel.Axis xAxis = (Microsoft.Office.Interop.Excel.Axis)chartPage.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
                    xAxis.CategoryNames = "";

                    Microsoft.Office.Interop.Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();


                    Series ser = seriesCollection.NewSeries();
                    ser.Name = "Low";
                    

                    ser = seriesCollection.NewSeries();
                    ser.Name = "Medium";

                    ser = seriesCollection.NewSeries();
                    ser.Name = "High";

                  





                    Microsoft.Office.Interop.Excel.SeriesCollection serie = (Microsoft.Office.Interop.Excel.SeriesCollection)chartPage.SeriesCollection(Missing.Value);
                 
                    int countReal = 0;
                    string valueY = string.Empty, valueX = string.Empty;
                    int count = 1;
                    Series mys;

                    mys = (Series)serie.Item(1);
                    mys.Delete();

                    int startValueColumn = 15;
                    while (count <= serie.Count)
                    {
                        mys = (Series)serie.Item(count);
                       
                        mys.XValues = excelApp.get_Range("B32:B" + (32 + (results.Count - 1)), Type.Missing); // excelApp.get_Range(string.Format("C32, F32, I32, L32 : L{0}, F{0}, I{0}, L{0}", (32 + (results.Count - 1))), Type.Missing);

                        string startCells = string.Format("{1}{0}", 32, excelCols[startValueColumn]);

                        string endCells = string.Format("{1}{0}", (32 + (results.Count - 1)), excelCols[startValueColumn]);

                        mys.Values = excelApp.get_Range(startCells, endCells);

                        if (mys.Name == "Low")
                        {
                            mys.Format.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(102, 179, 255));
                        } else if (mys.Name == "Medium")
                        {
                            mys.Format.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 193, 7));
                        }
                        else if (mys.Name == "High")
                        {
                            mys.Format.Fill.ForeColor.RGB = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 53, 69));
                        }




                        startValueColumn++;

                        count += 1;
                    }


                /*    chartPage.ApplyDataLabels(
      Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowLabel,
      false, false, false, true, false, false, false,
      false, false);*/




                  

                    serie = (Microsoft.Office.Interop.Excel.SeriesCollection)chartPage.SeriesCollection(Missing.Value);
                    count = 1;
                    while (count <= serie.Count)
                    {
                        mys = (Series)serie.Item(count);
                        mys.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowValue, true, true, false, false, false, false, true);
                        count++;
                    }

                    chartPage.Refresh();



                    #endregion


                }









                #endregion

                #region Export to excel file




                uploadPath = HttpContext.Current.Server.MapPath(desPath);
                fullPath = uploadPath + "\\" + nameExcel;
                if (Utility.HaveDirectory(uploadPath))
                {
                    myFile = new FileInfo(fullPath);
                    if (myFile != null)
                    {
                        myFile.Delete();
                    }
                    myFile = null;
                }


                // save file
                worksheet.SaveAs(fullPath);
                excelApp.Application.Quit();
                excelApp.Quit();
                GC.Collect();
                //////////////////////
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(excelApp);


                System.IO.FileStream fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Open);
                byteOutput = new byte[fs.Length];
                fs.Read(byteOutput, 0, (int)fs.Length);
                fs.Close();


                myFile = new FileInfo(fullPath);
                if (myFile != null)
                {
                    myFile.Delete();
                }
                myFile = null;


                #endregion


            }
            catch (Exception ex)
            { }
            finally
            {

                //if (excelApp != null && workbook != null)
                //{
                //    workbook.Close(false, misValue, misValue);
                //    GC.Collect();
                //    excelApp = null;
                //    releaseObject(worksheet);
                //    releaseObject(workbook);
                //    releaseObject(excelApp);
                //}
            }


            return byteOutput;


        }



        public byte[] ExportSummaryRepaireToExcel(SummaryRepaireAll dtoReport, string desPath, string nameExcel)
        {
            Byte[] byteOutput = null;
            FileInfo myFile = null;
            string fullPath = "";
            _Chart graph = null;
            Range range = null;
            List<SummaryCompletelyByRegionDto> results = null;
            int row = 0;
            int lastColumn = 0;
            Range rangeStart = null;
            int maxCol = 15;
            string year = "2018";
            int rowNumber = 0;

            Microsoft.Office.Interop.Excel.Axes xlAxisCategory, xlAxisValue;
            try
            {

              
                excelApp = new Application();




                excelApp.StandardFont = "Tahoma";
                excelApp.StandardFontSize = 10;

                workbook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];






                row = 30;
                #region Write table

                lastColumn = 2;

                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[maxCol] + (row + 1 ), Type.Missing);
                rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[maxCol] + (row + 1), Type.Missing);
                rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(50, 159, 228));


                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                rang.Value = "No";

              /*  rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Merge(Type.Missing);
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;
                */


                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Region";


                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "RC";


                lastColumn++;

                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Pipeline Section";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "KP";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Repair Length(m)";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Dig from";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Risk level";


                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row), Type.Missing);
                rang.Value = "Coating Inspection Result";
                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn+2] + row, Type.Missing);
                rang.Merge(Type.Missing);
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;

                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "type";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Damage type";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "จำนวนจุด";

                lastColumn++;


                rang = excelApp.get_Range(excelCols[lastColumn] + (row), Type.Missing);
                rang.Value = "Pipeline Inspection Result";
                rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[lastColumn + 2] + row, Type.Missing);
                rang.Merge(Type.Missing);
                rang.WrapText = true;
                rang.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                rang.VerticalAlignment = XlVAlign.xlVAlignCenter;


                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Damage type";

                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "จำนวนจุด";


                lastColumn++;
                rang = excelApp.get_Range(excelCols[lastColumn] + (row + 1), Type.Missing);
                rang.Value = "Note";




                row = 32;
                rowNumber = 1;
                if (dtoReport.Table!= null && dtoReport.Table.Count > 0)
                {
                    var pipelineGroupList = dtoReport.Table.GroupBy(u=> u.PipelineType).Select(gr=>gr.ToList()).ToList();


                    foreach (var objList in pipelineGroupList)
                    {
                        lastColumn = 2;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = objList[0].PipelineType;
                        rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[maxCol] + row, Type.Missing);
                        rang.Merge(Type.Missing);
                        rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(40, 167, 69));
                        rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                        row++;

                        var assertOwnerList = objList.GroupBy(u => u.AssertOwner).Select(gr => gr.ToList()).ToList();

                        foreach (var inspectionList in assertOwnerList)
                        {
                            lastColumn = 2;
                            rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                            rang.Value = inspectionList[0].AssertOwner;
                            rang = excelApp.get_Range(excelCols[lastColumn] + row + ":" + excelCols[maxCol] + row, Type.Missing);
                            rang.Merge(Type.Missing);

                            rang.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(150, 237, 170));

                            rang.Borders.LineStyle = XlLineStyle.xlContinuous;
                            row++;

                            foreach (SummaryRepaireDTO dto in inspectionList)
                            {
                                lastColumn = 2;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = rowNumber;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.Region;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.RouteCode;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.PipelineSection;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.KP;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.RepairLength;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.Digfrom;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.RiskLevel;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.CoatingType;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.CoatingDMGType;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.CoatingPoint;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;




                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.PipelineDMGType;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.PipelinePoint;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;

                                lastColumn++;
                                rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                                rang.Value = dto.Note;
                                rang.Borders.LineStyle = XlLineStyle.xlContinuous;


                                rowNumber++;
                                row++;
                            }
                        }
                    }

                    for (int col = 2; col <= 15; col++)
                    {
                        rang = excelApp.get_Range(excelCols[col]+"31", Type.Missing);
                        rang.Columns.AutoFit();

                    }

                }



                #endregion




                #region  Write Chart





                List<SummaryRepaireDTO> sumForGraph = new List<SummaryRepaireDTO>();

                    if (dtoReport.Table != null && dtoReport.Table.Count > 0)
                  {

                    row = 32;
                    rowNumber = 1;
                    lastColumn = 20;

                    var regionGroupList = dtoReport.Table.GroupBy(u => u.Region).Select(gr => gr.ToList()).ToList();

                 
                        foreach (var objList in  regionGroupList)
                    {

                        decimal sumByRegion = 0;
                        SummaryRepaireDTO dto = new SummaryRepaireDTO();

                        dto.Region = objList[0].Region;

                        foreach (SummaryRepaireDTO sumDto in objList)
                        {
                            sumByRegion += Utility.ConvertToDecimal(sumDto.RepairLength);
                        }
                        dto.RepairLength = sumByRegion.ToString();
                        sumForGraph.Add(dto);

                      
                        row++;
                    }


                  




                    rangeStart = excelApp.get_Range("B2:B2", Type.Missing);


                      Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)worksheet.ChartObjects(Type.Missing).Add(rangeStart.Left, rangeStart.Top, 500, 250);

                      Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;



                      chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnStacked;
                      chartPage.HasTitle = true;
                      chartPage.HasLegend = true;

                      chartPage.Legend.Position = XlLegendPosition.xlLegendPositionTop;
                      chartPage.ChartTitle.Text = "Summmary Repaire Report";
                      chartPage.ChartTitle.Font.Size = 10;



                    Microsoft.Office.Interop.Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();
                    Microsoft.Office.Interop.Excel.Series series1 = null;



                    foreach (SummaryRepaireDTO sumDto in sumForGraph)
                    {
                        rang = excelApp.get_Range(excelCols[lastColumn] + row, Type.Missing);
                        rang.Value = sumDto.Region;

                        rang = excelApp.get_Range(excelCols[lastColumn + 1] + row, Type.Missing);
                        rang.Value = sumDto.RepairLength;

                        row++;



                    }






                    chartPage.SetSourceData(excelApp.get_Range(string.Format("{0}32:{1}{2}", excelCols[lastColumn], excelCols[lastColumn+1],row)), misValue);

                    Microsoft.Office.Interop.Excel.SeriesCollection  serie = (Microsoft.Office.Interop.Excel.SeriesCollection)chartPage.SeriesCollection(Missing.Value);
                  //  Series mys = (Series)serie.Item(1);

                 //   mys.Name = "";

                    chartPage.Legend.Clear();

                    // series1.XValues = excelApp.get_Range(string.Format("{0}32:{0}",excelCols[lastColumn]) + (row));
                    //  series1.Values = excelApp.get_Range(string.Format("{0}32:{0}", excelCols[lastColumn+1]) + (row));







                    chartPage.Refresh();



            

                  }










                #endregion

                #region Export to excel file




                uploadPath = HttpContext.Current.Server.MapPath(desPath);
                fullPath = uploadPath + "\\" + nameExcel;
                if (Utility.HaveDirectory(uploadPath))
                {
                    myFile = new FileInfo(fullPath);
                    if (myFile != null)
                    {
                        myFile.Delete();
                    }
                    myFile = null;
                }


                // save file
                worksheet.SaveAs(fullPath);
                excelApp.Application.Quit();
                excelApp.Quit();
                GC.Collect();
                //////////////////////
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(excelApp);


                System.IO.FileStream fs = new System.IO.FileStream(fullPath, System.IO.FileMode.Open);
                byteOutput = new byte[fs.Length];
                fs.Read(byteOutput, 0, (int)fs.Length);
                fs.Close();


                myFile = new FileInfo(fullPath);
                if (myFile != null)
                {
                    myFile.Delete();
                }
                myFile = null;


                #endregion


            }
            catch (Exception ex)
            { }
            finally
            {

                //if (excelApp != null && workbook != null)
                //{
                //    workbook.Close(false, misValue, misValue);
                //    GC.Collect();
                //    excelApp = null;
                //    releaseObject(worksheet);
                //    releaseObject(workbook);
                //    releaseObject(excelApp);
                //}
            }


            return byteOutput;


        }

        private string ConvertNo2ColExcel(int value)
        {
            string result = string.Empty;
            int frontValue = 0;

            string[] colName = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            if (value > 26)
            {
                frontValue = value % 25;

                result = string.Format("{0}{1}", colName[((value - 1) / 26) - 1], colName[(((value - 1) % 26) + 1)]);
            }
            else
            {
                result = colName[value - 1];
            }
            return result;
        }




        private void WriteChartDoughnut(Microsoft.Office.Interop.Excel.ChartObjects myCharts,
                                    Range rangeChartStart,Range rangTotal,
                                    Range rangeDataText, Range rangeDataValue, string chartTile)
        {



           

            Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)myCharts.Add(rangeChartStart.Left, rangeChartStart.Top, 250,250);

            Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;



            chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlDoughnut;
            chartPage.HasTitle = true;
            chartPage.ChartTitle.Text = chartTile;
            chartPage.ChartTitle.Font.Size = 10;

           

            Microsoft.Office.Interop.Excel.SeriesCollection seriesCollection = chartPage.SeriesCollection();
            Microsoft.Office.Interop.Excel.Series series1 = seriesCollection.NewSeries();
            series1.Name = "";
            series1.XValues = rangeDataText;
            series1.Values = rangeDataValue;






            chartPage.SetSourceData(rangTotal, misValue);


            Microsoft.Office.Interop.Excel.Axis axis = chartPage.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue, Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary) as Microsoft.Office.Interop.Excel.Axis;

            series1.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowPercent, true, true, false, false, false, false, true);


            chartPage.Refresh();

        }

        private System.Drawing.Color MyColor(int iColor)
        {
            System.Drawing.Color myColor = new System.Drawing.Color();
            switch (iColor)
            {
                case 0: myColor = System.Drawing.Color.GreenYellow; break;
                case 1: myColor = System.Drawing.Color.Green; break;
                case 2: myColor = System.Drawing.Color.Brown; break;
                case 3: myColor = System.Drawing.Color.Blue; break;
                case 4: myColor = System.Drawing.Color.Black; break;
                case 5: myColor = System.Drawing.Color.Aqua; break;
                case 6: myColor = System.Drawing.Color.Violet; break;
                default: myColor = System.Drawing.Color.White; break;
            }
            return myColor;
        }


        void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //Response.Write(ex.ToString());
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }



    }
}
