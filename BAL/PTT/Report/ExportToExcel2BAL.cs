using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

using DTO.Util;

using DTO.PTT.Report;
using System.IO;
using BAL.PTT.Util;
namespace BAL.PTT.Report
{
    public class ExportToExcel2BAL
    {
        Logger logger = new Logger("ExportToExcel2BAL");
        OpenExcelUtil openExcelUtil = null;
        string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        string[] excelCols = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ" };

        public ExportToExcel2BAL()
        {
            openExcelUtil = new OpenExcelUtil();
        }

        private static ForegroundColor TranslateForeground(System.Drawing.Color fillColor)
        {
            return new ForegroundColor()
            {
                Rgb = new HexBinaryValue()
                {
                    Value =
                              System.Drawing.ColorTranslator.ToHtml(
                              System.Drawing.Color.FromArgb(
                                  fillColor.A,
                                  fillColor.R,
                                  fillColor.G,
                                  fillColor.B)).Replace("#", "")
                }
            };
        }

        private void AddChartTitle(DocumentFormat.OpenXml.Drawing.Charts.Chart chart, string title)
        {
            var ctitle = chart.AppendChild(new Title());
            var chartText = ctitle.AppendChild(new ChartText());
            var richText = chartText.AppendChild(new RichText());

            var bodyPr = richText.AppendChild(new DocumentFormat.OpenXml.Drawing.BodyProperties());
            var lstStyle = richText.AppendChild(new DocumentFormat.OpenXml.Drawing.ListStyle());
            var paragraph = richText.AppendChild(new DocumentFormat.OpenXml.Drawing.Paragraph());

            var apPr = paragraph.AppendChild(new DocumentFormat.OpenXml.Drawing.ParagraphProperties());
            apPr.AppendChild(new DocumentFormat.OpenXml.Drawing.DefaultRunProperties());

            var run = paragraph.AppendChild(new DocumentFormat.OpenXml.Drawing.Run());
            run.AppendChild(new DocumentFormat.OpenXml.Drawing.RunProperties() { Language = "en-CA" });
            run.AppendChild(new DocumentFormat.OpenXml.Drawing.Text() { Text = title });
        }

        #region  Report
        public byte[] ExportOverAllReportToExcel(SummaryPlanReport summaryPlanReport, string desPath, string nameExcel)
        {
            MemoryStream stream = new MemoryStream();
            Row row = null;
            Cell cell = null;
            MergeCells mergeCells;
            int rowTotal = 100;
            try
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
                {
                    #region Instant object

                    openExcelUtil = new OpenExcelUtil();
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylePart.Stylesheet = openExcelUtil.GenerateStylesheet();
                    stylePart.Stylesheet.Save();

                    Worksheet ws = new Worksheet();

                    Columns lstColumns = new Columns();
                    lstColumns.Append(openExcelUtil.CreateColumnData(35, 35, 60));
                    lstColumns.Append(openExcelUtil.CreateColumnData(36, 44, 20));
                    lstColumns.Append(openExcelUtil.CreateColumnData(43, 43, 60));
                    lstColumns.Append(openExcelUtil.CreateColumnData(44, 44, 20));
                    lstColumns.Append(openExcelUtil.CreateColumnData(45, 45, 60));
                    lstColumns.Append(openExcelUtil.CreateColumnData(46, 47, 20));

                    ws.Append(lstColumns);

                    worksheetPart.Worksheet = ws;
                    mergeCells = new MergeCells();
                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "OverAll" };
                    SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
                    sheets.Append(sheet);
                    workbookPart.Workbook.Save();

                    #endregion

                    rowTotal = 100;

                    #region prepair Row
                    // Constructing header
                    for (int rr = 1; rr <= rowTotal; rr++)
                    {
                        row = new Row();
                        row.RowIndex = (UInt32)rr;

                        for (int cc = 0; cc < 57; cc++)
                        {
                            cell = openExcelUtil.ConstructCell("", CellValues.String, 0);
                            cell.CellReference = excelCols[cc] + rr;
                            cell.StyleIndex = 1;
                            row.Append(cell);
                        }
                        sheetData.AppendChild(row);
                    }
                    #endregion


                    #region Graph

                    // Add drawing part to WorksheetPart
                    DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                    worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                    worksheetPart.Worksheet.Save();

                    drawingsPart.WorksheetDrawing = new WorksheetDrawing();

                    workbookPart.Workbook.Save();

                    cell = openExcelUtil.GetCell(sheetData, "A", 2);
                    cell.CellValue = new CellValue("Summart plan report 1 - Overall inspection result");
                    cell.StyleIndex = 1;

                    mergeCells.Append(new MergeCell() { Reference = new StringValue("A2:AH2") });

                    exportDoughnutChart1(sheetData, cell, mergeCells, drawingsPart, summaryPlanReport, 1u);
                    exportDoughnutChart2(sheetData, cell, mergeCells, drawingsPart, summaryPlanReport, 2u);
                    exportDoughnutChart3(sheetData, cell, mergeCells, drawingsPart, summaryPlanReport, 3u);
                    exportDoughnutChart4(sheetData, cell, mergeCells, drawingsPart, summaryPlanReport, 4u);
                    exportDoughnutChart5(sheetData, cell, mergeCells, drawingsPart, summaryPlanReport, 5u);

                    exportOverAllDetail(sheetData, cell, mergeCells, summaryPlanReport);

                    drawingsPart.WorksheetDrawing.Save();

                    worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());

                    worksheetPart.Worksheet.Save();

                    #endregion
                }

            }
            catch (Exception ex)
            { logger.error("ExportOverAllReportToExcel error :" + ex.ToString()); }

            return stream.ToArray();
        }

        public void exportDoughnutChart1(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, uint drowingId)
        {
            cell = openExcelUtil.GetCell(sheetData, "C", 24);
            cell.CellValue = new CellValue("ความครบถ้วนของการดำเนินงาน");
            cell.StyleIndex = 1;
            mergeCells.Append(new MergeCell() { Reference = new StringValue("C24:D24") });

            //Graph 1
            int lRow = 25;
            List<ProgressGraphDto> results = summaryPlanReport.RawGraphReport;
            if (results != null && results.Count > 0)
            {
                foreach (ProgressGraphDto dto in results)
                {

                    cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
                    cell.CellValue = new CellValue(dto.name);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(dto.Complete.ToString());
                    cell.StyleIndex = 1;

                    lRow++;
                }

            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            //chart.Legend = new Legend();
            AddChartTitle(chart, "ความครบถ้วนของการดำเนินงาน");

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());

            DoughnutChart doughnutChart = plotArea.AppendChild(new DoughnutChart(new VaryColors()));

            /*
            PieChart pieChart = plotArea.AppendChild(new PieChart(
                    new VaryColors()
                ));*/

            doughnutChart.AppendChild(new DataLabels(
                            new ShowLegendKey() { Val = true },
                            new ShowValue() { Val = false },
                            new ShowCategoryName() { Val = true },
                            new ShowSeriesName() { Val = false },
                            new ShowPercent() { Val = true },
                            new ShowBubbleSize() { Val = true }
                        ));
            doughnutChart.AppendChild<HoleSize>(new HoleSize() { Val = 40 });

            PieChartSeries pieChartSeries = doughnutChart.AppendChild<PieChartSeries>(
                new PieChartSeries(
                    new Index() { Val = new UInt32Value((uint)100) },
                    new Order() { Val = new UInt32Value((uint)0) },
                    new SeriesText(new NumericValue() { Text = "Test" })
                )
            );
            
            string formulaVal = "OverAll!$D$25:$D$27";
            DocumentFormat.OpenXml.Drawing.Charts.Values values = pieChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = pieChartSeries.AppendChild(new CategoryAxisData());

            // Category
            // Constructing the chart category
            string formulaCat = "OverAll!$C$25:$C$27";

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            //Color for data point
            uint datapointIndex = 0;
            foreach (ProgressGraphDto dto in results)
            {
                pieChartSeries.AppendChild(
                    new DocumentFormat.OpenXml.Drawing.Charts.DataPoint(
                        new ChartShapeProperties(
                            new DocumentFormat.OpenXml.Drawing.SolidFill(
                                new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = dto.color.Replace("#", "") }
                            )
                        ),
                        new Index() { Val = datapointIndex }
                    )
                );

                datapointIndex++;
            }
            
            chartPart.ChartSpace.Save();

            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("0"),
                    new ColumnOffset("0"),
                    new RowId("4"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("6"),
                    new ColumnOffset("0"),
                    new RowId("22"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = drowingId,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());
        }

        public void exportDoughnutChart2(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, uint drowingId)
        {
            cell = openExcelUtil.GetCell(sheetData, "J", 24);
            cell.CellValue = new CellValue("ผลการประเมินความเสี่ยง");
            cell.StyleIndex = 1;
            mergeCells.Append(new MergeCell() { Reference = new StringValue("J24:K24") });

            //Graph 1
            int lRow = 25;
            List<ProgressGraphDto> results = summaryPlanReport.RawRiskGraphBeforeReport;
            if (results != null && results.Count > 0)
            {
                foreach (ProgressGraphDto dto in results)
                {

                    cell = openExcelUtil.GetCell(sheetData, "J", (uint)lRow);
                    cell.CellValue = new CellValue(dto.name);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "K", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(dto.Complete.ToString());
                    cell.StyleIndex = 1;

                    lRow++;
                }

            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            //chart.Legend = new Legend();
            AddChartTitle(chart, "ผลการประเมินความเสี่ยง");

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());

            DoughnutChart doughnutChart = plotArea.AppendChild(new DoughnutChart(new VaryColors()));

            /*
            PieChart pieChart = plotArea.AppendChild(new PieChart(
                    new VaryColors()
                ));*/

            doughnutChart.AppendChild(new DataLabels(
                            new ShowLegendKey() { Val = true },
                            new ShowValue() { Val = false },
                            new ShowCategoryName() { Val = true },
                            new ShowSeriesName() { Val = false },
                            new ShowPercent() { Val = true },
                            new ShowBubbleSize() { Val = true }
                        ));
            doughnutChart.AppendChild<HoleSize>(new HoleSize() { Val = 40 });

            PieChartSeries pieChartSeries = doughnutChart.AppendChild<PieChartSeries>(
                new PieChartSeries(
                    new Index() { Val = new UInt32Value((uint)100) },
                    new Order() { Val = new UInt32Value((uint)0) },
                    new SeriesText(new NumericValue() { Text = "Test" })
                )
            );


            string formulaVal = "OverAll!$K$25:$K$27";
            DocumentFormat.OpenXml.Drawing.Charts.Values values = pieChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = pieChartSeries.AppendChild(new CategoryAxisData());

            // Category
            // Constructing the chart category
            string formulaCat = "OverAll!$J$25:$J$27";

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            //Color for data point
            uint datapointIndex = 0;
            foreach (ProgressGraphDto dto in results)
            {
                pieChartSeries.AppendChild(
                    new DocumentFormat.OpenXml.Drawing.Charts.DataPoint(
                        new ChartShapeProperties(
                            new DocumentFormat.OpenXml.Drawing.SolidFill(
                                new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = dto.color.Replace("#", "") }
                            )
                        ),
                        new Index() { Val = datapointIndex }
                    )
                );

                datapointIndex++;
            }

            chartPart.ChartSpace.Save();

            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("7"),
                    new ColumnOffset("0"),
                    new RowId("4"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("13"),
                    new ColumnOffset("0"),
                    new RowId("22"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = drowingId,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());
        }

        public void exportDoughnutChart3(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, uint drowingId)
        {
            cell = openExcelUtil.GetCell(sheetData, "Q", 24);
            cell.CellValue = new CellValue("Coating defect type");
            cell.StyleIndex = 1;
            mergeCells.Append(new MergeCell() { Reference = new StringValue("Q24:R24") });

            //Graph 1
            int lRow = 25;
            List<ProgressGraphDto> results = summaryPlanReport.RawRiskGraphCoatingTypeReport;
            if (results != null && results.Count > 0)
            {
                foreach (ProgressGraphDto dto in results)
                {

                    cell = openExcelUtil.GetCell(sheetData, "Q", (uint)lRow);
                    cell.CellValue = new CellValue(dto.name);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "R", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(dto.Complete.ToString());
                    cell.StyleIndex = 1;

                    lRow++;
                }

            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            //chart.Legend = new Legend();
            AddChartTitle(chart, "Coating defect type");

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());

            DoughnutChart doughnutChart = plotArea.AppendChild(new DoughnutChart(new VaryColors()));

            /*
            PieChart pieChart = plotArea.AppendChild(new PieChart(
                    new VaryColors()
                ));*/

            doughnutChart.AppendChild(new DataLabels(
                            new ShowLegendKey() { Val = true },
                            new ShowValue() { Val = false },
                            new ShowCategoryName() { Val = true },
                            new ShowSeriesName() { Val = false },
                            new ShowPercent() { Val = true },
                            new ShowBubbleSize() { Val = true }
                        ));
            doughnutChart.AppendChild<HoleSize>(new HoleSize() { Val = 40 });

            PieChartSeries pieChartSeries = doughnutChart.AppendChild<PieChartSeries>(
                new PieChartSeries(
                    new Index() { Val = new UInt32Value((uint)100) },
                    new Order() { Val = new UInt32Value((uint)0) },
                    new SeriesText(new NumericValue() { Text = "Test" })
                )
            );

            int lastRow = 25 + results.Count - 1;

            string formulaVal = "OverAll!$R$25:$R$" + lastRow;
            DocumentFormat.OpenXml.Drawing.Charts.Values values = pieChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = pieChartSeries.AppendChild(new CategoryAxisData());

            // Category
            // Constructing the chart category
            string formulaCat = "OverAll!$Q$25:$Q$" + lastRow;

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            //Color for data point
            uint datapointIndex = 0;
            foreach (ProgressGraphDto dto in results)
            {
                pieChartSeries.AppendChild(
                    new DocumentFormat.OpenXml.Drawing.Charts.DataPoint(
                        new ChartShapeProperties(
                            new DocumentFormat.OpenXml.Drawing.SolidFill(
                                new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = dto.color.Replace("#", "") }
                            )
                        ),
                        new Index() { Val = datapointIndex }
                    )
                );

                datapointIndex++;
            }

            chartPart.ChartSpace.Save();

            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("14"),
                    new ColumnOffset("0"),
                    new RowId("4"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("20"),
                    new ColumnOffset("0"),
                    new RowId("22"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = drowingId,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());
        }

        public void exportDoughnutChart4(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, uint drowingId)
        {
            cell = openExcelUtil.GetCell(sheetData, "X", 24);
            cell.CellValue = new CellValue("ผลการประเมินความเสี่ยง");
            cell.StyleIndex = 1;
            mergeCells.Append(new MergeCell() { Reference = new StringValue("X24:Y24") });

            //Graph 1
            int lRow = 25;
            List<ProgressGraphDto> results = summaryPlanReport.RawRiskGraphAfterReport;
            if (results != null && results.Count > 0)
            {
                foreach (ProgressGraphDto dto in results)
                {

                    cell = openExcelUtil.GetCell(sheetData, "X", (uint)lRow);
                    cell.CellValue = new CellValue(dto.name);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "Y", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(dto.Complete.ToString());
                    cell.StyleIndex = 1;

                    lRow++;
                }

            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            //chart.Legend = new Legend();
            AddChartTitle(chart, "ผลการประเมินความเสี่ยง");

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());

            DoughnutChart doughnutChart = plotArea.AppendChild(new DoughnutChart(new VaryColors()));

            /*
            PieChart pieChart = plotArea.AppendChild(new PieChart(
                    new VaryColors()
                ));*/

            doughnutChart.AppendChild(new DataLabels(
                            new ShowLegendKey() { Val = true },
                            new ShowValue() { Val = false },
                            new ShowCategoryName() { Val = true },
                            new ShowSeriesName() { Val = false },
                            new ShowPercent() { Val = true },
                            new ShowBubbleSize() { Val = true }
                        ));
            doughnutChart.AppendChild<HoleSize>(new HoleSize() { Val = 40 });

            PieChartSeries pieChartSeries = doughnutChart.AppendChild<PieChartSeries>(
                new PieChartSeries(
                    new Index() { Val = new UInt32Value((uint)100) },
                    new Order() { Val = new UInt32Value((uint)0) },
                    new SeriesText(new NumericValue() { Text = "Test" })
                )
            );

            int lastRow = 25 + results.Count - 1;

            string formulaVal = "OverAll!$Y$25:$Y$" + lastRow;
            DocumentFormat.OpenXml.Drawing.Charts.Values values = pieChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = pieChartSeries.AppendChild(new CategoryAxisData());

            // Category
            // Constructing the chart category
            string formulaCat = "OverAll!$X$25:$X$" + lastRow;

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            //Color for data point
            uint datapointIndex = 0;
            foreach (ProgressGraphDto dto in results)
            {
                pieChartSeries.AppendChild(
                    new DocumentFormat.OpenXml.Drawing.Charts.DataPoint(
                        new ChartShapeProperties(
                            new DocumentFormat.OpenXml.Drawing.SolidFill(
                                new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = dto.color.Replace("#", "") }
                            )
                        ),
                        new Index() { Val = datapointIndex }
                    )
                );

                datapointIndex++;
            }

            chartPart.ChartSpace.Save();

            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("21"),
                    new ColumnOffset("0"),
                    new RowId("4"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("27"),
                    new ColumnOffset("0"),
                    new RowId("22"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = drowingId,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());
        }

        public void exportDoughnutChart5(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, uint drowingId)
        {
            cell = openExcelUtil.GetCell(sheetData, "AD", 24);
            cell.CellValue = new CellValue("Pipeline defect type");
            cell.StyleIndex = 1;
            mergeCells.Append(new MergeCell() { Reference = new StringValue("AD24:AE24") });

            //Graph 1
            int lRow = 25;
            List<ProgressGraphDto> results = summaryPlanReport.RawRiskGraphPipelineTypeReport;
            if (results != null && results.Count > 0)
            {
                foreach (ProgressGraphDto dto in results)
                {

                    cell = openExcelUtil.GetCell(sheetData, "AD", (uint)lRow);
                    cell.CellValue = new CellValue(dto.name);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AE", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(dto.Complete.ToString());
                    cell.StyleIndex = 1;

                    /*
                    Columns lstColumns = new Columns();
                    lstColumns.Append(openExcelUtil.CreateColumnData(50, 51, 50));
                    ws.Append(lstColumns);*/

                    cell = openExcelUtil.GetCell(sheetData, "AI", (uint)lRow);
                    cell.CellValue = new CellValue(getGraph5Dese(dto.name));
                    cell.StyleIndex = 1;

                    lRow++;
                }

            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            //chart.Legend = new Legend();
            AddChartTitle(chart, "Pipeline defect type");

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());

            DoughnutChart doughnutChart = plotArea.AppendChild(new DoughnutChart(new VaryColors()));

            /*
            PieChart pieChart = plotArea.AppendChild(new PieChart(
                    new VaryColors()
                ));*/

            doughnutChart.AppendChild(new DataLabels(
                            new ShowLegendKey() { Val = true },
                            new ShowValue() { Val = false },
                            new ShowCategoryName() { Val = true },
                            new ShowSeriesName() { Val = false },
                            new ShowPercent() { Val = true },
                            new ShowBubbleSize() { Val = true }
                        ));
            doughnutChart.AppendChild<HoleSize>(new HoleSize() { Val = 40 });

            PieChartSeries pieChartSeries = doughnutChart.AppendChild<PieChartSeries>(
                new PieChartSeries(
                    new Index() { Val = new UInt32Value((uint)100) },
                    new Order() { Val = new UInt32Value((uint)0) },
                    new SeriesText(new NumericValue() { Text = "Test" })
                )
            );

            int lastRow = 25 + results.Count - 1;

            string formulaVal = "OverAll!$AE$25:$AE$" + lastRow;
            DocumentFormat.OpenXml.Drawing.Charts.Values values = pieChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = pieChartSeries.AppendChild(new CategoryAxisData());

            // Category
            // Constructing the chart category
            string formulaCat = "OverAll!$AD$25:$AD$" + lastRow;

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            //Color for data point
            uint datapointIndex = 0;
            foreach (ProgressGraphDto dto in results)
            {
                pieChartSeries.AppendChild(
                    new DocumentFormat.OpenXml.Drawing.Charts.DataPoint(
                        new ChartShapeProperties(
                            new DocumentFormat.OpenXml.Drawing.SolidFill(
                                new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = dto.color.Replace("#", "") }
                            )
                        ),
                        new Index() { Val = datapointIndex }
                    )
                );

                datapointIndex++;
            }

            chartPart.ChartSpace.Save();

            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("28"),
                    new ColumnOffset("0"),
                    new RowId("4"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("34"),
                    new ColumnOffset("0"),
                    new RowId("22"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = drowingId,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());
        }

        public void exportOverAllDetail(SheetData sheetData, Cell cell, MergeCells mergeCells, SummaryPlanReport summaryPlanReport)
        {
            int lRow = 2;

            cell = openExcelUtil.GetCell(sheetData, "AJ", (uint)lRow);
            cell.StyleIndex = 1;
            mergeCells.Append(new MergeCell() { Reference = new StringValue("AJ" + lRow + ":AP" + lRow) });

            cell = openExcelUtil.GetCell(sheetData, "AQ", (uint)lRow);
            cell.CellValue = new CellValue("Coating Inspection Result");
            cell.StyleIndex = 1;
            mergeCells.Append(new MergeCell() { Reference = new StringValue("AQ" + lRow + ":AR" + lRow) });

            cell = openExcelUtil.GetCell(sheetData, "AS", (uint)lRow);
            cell.CellValue = new CellValue("Pipeline Inspection Result");
            cell.StyleIndex = 1;
            mergeCells.Append(new MergeCell() { Reference = new StringValue("AS" + lRow + ":AT" + lRow) });

            lRow++;

            #region OverAllTableReport header
            cell = openExcelUtil.GetCell(sheetData, "AJ", (uint)lRow);
            cell.CellValue = new CellValue("Customer Type");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AK", (uint)lRow);
            cell.CellValue = new CellValue("Inspection Date");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AL", (uint)lRow);
            cell.CellValue = new CellValue("Route Code");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AM", (uint)lRow);
            cell.CellValue = new CellValue("Section");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AN", (uint)lRow);
            cell.CellValue = new CellValue("KP");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AO", (uint)lRow);
            cell.CellValue = new CellValue("Region");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AP", (uint)lRow);
            cell.CellValue = new CellValue("Dig From");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AQ", (uint)lRow);
            cell.CellValue = new CellValue("Defect Type");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AR", (uint)lRow);
            cell.CellValue = new CellValue("Serverity");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AS", (uint)lRow);
            cell.CellValue = new CellValue("Defect Type");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AT", (uint)lRow);
            cell.CellValue = new CellValue("Serverity");
            cell.StyleIndex = 1;

            cell = openExcelUtil.GetCell(sheetData, "AU", (uint)lRow);
            cell.CellValue = new CellValue("Status");
            cell.StyleIndex = 1;
            #endregion
            lRow++;

            List<SummaryPlanOverAllProgressDto> results = summaryPlanReport.OverAllTableReport;
            if (results != null && results.Count > 0)
            {
                foreach (SummaryPlanOverAllProgressDto dto in results)
                {
                    #region OverAllTableReport list
                    cell = openExcelUtil.GetCell(sheetData, "AJ", (uint)lRow);
                    cell.CellValue = new CellValue(dto.AssetOwner);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AK", (uint)lRow);
                    cell.CellValue = new CellValue(dto.InspectionDate.ToString());
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AL", (uint)lRow);
                    cell.CellValue = new CellValue(dto.RouteCode);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AM", (uint)lRow);
                    cell.CellValue = new CellValue(dto.Section);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AN", (uint)lRow);
                    cell.CellValue = new CellValue(dto.KP);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AO", (uint)lRow);
                    cell.CellValue = new CellValue(dto.RegionName);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AP", (uint)lRow);
                    cell.CellValue = new CellValue(dto.DigFrom);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AQ", (uint)lRow);
                    cell.CellValue = new CellValue(dto.CoatingDefectType);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AR", (uint)lRow);
                    cell.CellValue = new CellValue(dto.CoatingServerity);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AS", (uint)lRow);
                    cell.CellValue = new CellValue(dto.PipelineDefectType);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AT", (uint)lRow);
                    cell.CellValue = new CellValue(dto.PipelineServerity);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "AU", (uint)lRow);
                    cell.CellValue = new CellValue(dto.Status);
                    cell.StyleIndex = 1;

                    lRow++;
                    #endregion
                }

            }
        }

        public byte[] ExportSummaryCompletelyToExcel(SummaryPlanReport summaryPlanReport, string desPath, string nameExcel, SearchDTO dto)
        {
            MemoryStream stream = new MemoryStream();
            Row row = null;
            Cell cell = null;
            MergeCells mergeCells;
            int rowTotal = 100;
            try
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
                {
                    #region Instant object

                    openExcelUtil = new OpenExcelUtil();
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylePart.Stylesheet = openExcelUtil.generateSummayColpletelyStylesheet();
                    stylePart.Stylesheet.Save();

                    Worksheet ws = new Worksheet();

                    Columns lstColumns = new Columns();
                    lstColumns.Append(openExcelUtil.CreateColumnData(35, 35, 60));

                    ws.Append(lstColumns);

                    worksheetPart.Worksheet = ws;
                    mergeCells = new MergeCells();
                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "SummaryCompletely" };
                    SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
                    sheets.Append(sheet);
                    workbookPart.Workbook.Save();

                    #endregion

                    rowTotal = 100;

                    #region prepair Row
                    // Constructing header
                    for (int rr = 1; rr <= rowTotal; rr++)
                    {
                        row = new Row();
                        row.RowIndex = (UInt32)rr;

                        for (int cc = 0; cc < 57; cc++)
                        {
                            cell = openExcelUtil.ConstructCell("", CellValues.String, 0);
                            cell.CellReference = excelCols[cc] + rr;
                            cell.StyleIndex = 1;
                            row.Append(cell);
                        }
                        sheetData.AppendChild(row);
                    }
                    #endregion


                    #region Graph

                    // Add drawing part to WorksheetPart
                    DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                    worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                    worksheetPart.Worksheet.Save();

                    drawingsPart.WorksheetDrawing = new WorksheetDrawing();

                    workbookPart.Workbook.Save();

                    exportStackedColumnSummaryCompletelyChart(sheetData, cell, mergeCells, drawingsPart, summaryPlanReport, dto);

                    exportStackedColumnSummaryCompletelyQuoterChart(sheetData, cell, mergeCells, drawingsPart, summaryPlanReport, dto);

                    drawingsPart.WorksheetDrawing.Save();

                    worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());

                    worksheetPart.Worksheet.Save();

                    #endregion
                }

            }
            catch (Exception ex)
            { logger.error("ExportSummaryCompletelyToExcel error :" + ex.ToString()); }

            return stream.ToArray();
        }

        public void exportStackedColumnSummaryCompletelyChart(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, SearchDTO searchDto)
        {
            int lRow = 45;
            #region Header
            cell = openExcelUtil.GetCell(sheetData, "B", (uint)lRow);
            cell.CellValue = new CellValue("Region");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
            cell.CellValue = new CellValue("PM");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
            cell.CellValue = new CellValue("Estimate");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
            cell.CellValue = new CellValue("Postpone to");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
            cell.CellValue = new CellValue("Q1");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
            cell.CellValue = new CellValue("Q2");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
            cell.CellValue = new CellValue("Q3");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
            cell.CellValue = new CellValue("Q4");
            cell.StyleIndex = 2;

            mergeCells.Append(new MergeCell() { Reference = new StringValue("B" + lRow + ":B" + (lRow + 1)) });

            lRow++;

            cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
            cell.CellValue = new CellValue("Transmission");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
            cell.CellValue = new CellValue("This year");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
            cell.CellValue = new CellValue("This year");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
            cell.StyleIndex = 2;

            lRow++;
            #endregion

            //Graph 1
            if (summaryPlanReport.SumaryCompletelyByRegionTable != null && summaryPlanReport.SumaryCompletelyByRegionTable.Count > 0)
            {
                foreach (SummaryCompletelyByRegionDto dto in summaryPlanReport.SumaryCompletelyByRegionTable)
                {
                    #region Record
                    cell = openExcelUtil.GetCell(sheetData, "B", (uint)lRow);
                    cell.CellValue = new CellValue(dto.RegionName);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Actual) > 0 ? (Utility.ConvertToDecimal(dto.Actual) / 100).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Plan) > 0 ? (Utility.ConvertToDecimal(dto.Plan) / 100).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.PostPone) > 0 ? (Utility.ConvertToDecimal(dto.PostPone) / 100).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q1) > 0 ? (Utility.ConvertToDecimal(dto.Q1) / 100).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q2) > 0 ? (Utility.ConvertToDecimal(dto.Q2) / 100).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q3) > 0 ? (Utility.ConvertToDecimal(dto.Q3) / 100).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q4) > 0 ? (Utility.ConvertToDecimal(dto.Q4) / 100).ToString() : "");
                    cell.StyleIndex = 1;

                    lRow++;
                    #endregion
                }
            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            chart.Legend = new Legend(new LegendPosition() { Val = new EnumValue<LegendPositionValues>(LegendPositionValues.TopRight) });
            AddChartTitle(chart, "PM Transmission " + searchDto.Year);

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());
            ManualLayout manualLayout = layout.AppendChild(new ManualLayout());
            manualLayout.Top = new Top() { Val = 0.2 };
            manualLayout.Width = new Width() { Val = 0.9};
            manualLayout.Height = new Height() { Val = 0.8 };

            BarChart barChart = plotArea.AppendChild(new BarChart(
                        new BarDirection() { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                        new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.PercentStacked) },
                        new VaryColors() { Val = false }
                    ));

            // Constructing header
            Row row = new Row();
            barChart.AppendChild(new Overlap() { Val = 100 });
            barChart.AppendChild(new GapWidth() { Val = 250 });

            String color = "#546BC1";
            ColumnReportDTO columnReportDTO = summaryPlanReport.GraphReport.Where(o => o.name == "Actual").ToList().FirstOrDefault();
            if (columnReportDTO != null && columnReportDTO.color != null)
            {
                color = columnReportDTO.color;
            }

            // Create chart series
            BarChartSeries barChartSeries = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)0 },
                    new Order() { Val = (uint)0 },
                    new SeriesText(new NumericValue() { Text = "Actual" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = color.Replace("#", "") }
                        )
                    )
                ));

            /*
            barChartSeries.ChartShapeProperties = new ChartShapeProperties();
            var outline = barChartSeries.ChartShapeProperties.AppendChild<DocumentFormat.OpenXml.Drawing.Outline>(new DocumentFormat.OpenXml.Drawing.Outline());
            var solid = outline.AppendChild<DocumentFormat.OpenXml.Drawing.SolidFill>(new DocumentFormat.OpenXml.Drawing.SolidFill());
            solid.AppendChild<DocumentFormat.OpenXml.Drawing.RgbColorModelHex>(new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = new HexBinaryValue() { Value = "ff0000" } });
            */

            //Series Value
            string formulaVal = "SummaryCompletely!$C$47:$C$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values = barChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = barChartSeries.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category
            string formulaCat = "SummaryCompletely!$B$47:$B$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            color = "#546BC1";
            columnReportDTO = summaryPlanReport.GraphReport.Where(o => o.name == "Plan").ToList().FirstOrDefault();
            if (columnReportDTO != null && columnReportDTO.color != null)
            {
                color = columnReportDTO.color;
            }

            BarChartSeries barChartSeries2 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)1 },
                    new Order() { Val = (uint)1 },
                    new SeriesText(new NumericValue() { Text = "Plan" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = color.Replace("#", "") }
                        )
                    )
                ));
            //Series Value
            string formulaVal2 = "SummaryCompletely!$D$47:$D$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values2 = barChartSeries2.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values2.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal2 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData2 = barChartSeries2.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference2 = categoryAxisData2.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            color = "#546BC1";
            columnReportDTO = summaryPlanReport.GraphReport.Where(o => o.name == "Postpone").ToList().FirstOrDefault();
            if (columnReportDTO != null && columnReportDTO.color != null)
            {
                color = columnReportDTO.color;
            }

            BarChartSeries barChartSeries3 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)2 },
                    new Order() { Val = (uint)2 },
                    new SeriesText(new NumericValue() { Text = "Postpone" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = color.Replace("#", "") }
                        )
                    )
                ));
            //Series Value
            string formulaVal3 = "SummaryCompletely!$E$47:$E$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values3 = barChartSeries3.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values3.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal3 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData3 = barChartSeries3.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference3 = categoryAxisData3.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            barChart.AppendChild(new DataLabels(
                                new ShowLegendKey() { Val = true },
                                new ShowValue() { Val = false },
                                new ShowCategoryName() { Val = false },
                                new ShowSeriesName() { Val = true },
                                new ShowPercent() { Val = false },
                                new ShowBubbleSize() { Val = false }
                            ));
            barChart.Append(new AxisId() { Val = 48650112u });
            barChart.Append(new AxisId() { Val = 48672768u });

            // Adding Category Axis
            plotArea.AppendChild(
                new CategoryAxis(
                    new AxisId() { Val = 48650112u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48672768u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new AutoLabeled() { Val = true },
                    new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) }
                ));

            // Adding Value Axis
            plotArea.AppendChild(
                new ValueAxis(
                    new AxisId() { Val = 48672768u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                    new MajorGridlines(),
                    new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                    {
                        FormatCode = "General",
                        SourceLinked = true
                    },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48650112u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }
                ));

            chart.Append(
                    new PlotVisibleOnly() { Val = true },
                    new DisplayBlanksAs() { Val = new EnumValue<DisplayBlanksAsValues>(DisplayBlanksAsValues.Gap) },
                    new ShowDataLabelsOverMaximum() { Val = false }
                );

            chartPart.ChartSpace.Save();

            // Positioning the chart on the spreadsheet
            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("1"),
                    new ColumnOffset("0"),
                    new RowId("2"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("17"),
                    new ColumnOffset("0"),
                    new RowId("21"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = 2u,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());

        }

        public void exportStackedColumnSummaryCompletelyQuoterChart(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, SearchDTO searchDto)
        {
            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            chart.Legend = new Legend(new LegendPosition() { Val = new EnumValue<LegendPositionValues>(LegendPositionValues.TopRight) });
            AddChartTitle(chart, "PM Transmission " + searchDto.Year);

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());
            ManualLayout manualLayout = layout.AppendChild(new ManualLayout());
            manualLayout.Top = new Top() { Val = 0.2 };
            manualLayout.Width = new Width() { Val = 0.9 };
            manualLayout.Height = new Height() { Val = 0.8 };

            BarChart barChart = plotArea.AppendChild(new BarChart(
                        new BarDirection() { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                        new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.PercentStacked) },
                        new VaryColors() { Val = false }
                    ));

            // Constructing header
            Row row = new Row();
            barChart.AppendChild(new Overlap() { Val = 100 });
            barChart.AppendChild(new GapWidth() { Val = 250 });

            String color = "#546BC1";
            ColumnReportDTO columnReportDTO = summaryPlanReport.GraphReport.Where(o => o.name == "Q1").ToList().FirstOrDefault();
            if (columnReportDTO != null && columnReportDTO.color != null)
            {
                color = columnReportDTO.color;
            }

            // Create chart series
            BarChartSeries barChartSeriesQ1 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)0 },
                    new Order() { Val = (uint)0 },
                    new SeriesText(new NumericValue() { Text = "Q1" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = color.Replace("#", "") }
                        )
                    )
                ));

            //Series Value
            string formulaCat = "SummaryCompletely!$B$47:$B$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            string formulaValQ1 = "SummaryCompletely!$F$47:$F$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values valuesQ1 = barChartSeriesQ1.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            valuesQ1.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaValQ1 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisDataQ1 = barChartSeriesQ1.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReferenceQ1 = categoryAxisDataQ1.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            color = "#546BC1";
            columnReportDTO = summaryPlanReport.GraphReport.Where(o => o.name == "Q2").ToList().FirstOrDefault();
            if (columnReportDTO != null && columnReportDTO.color != null)
            {
                color = columnReportDTO.color;
            }

            BarChartSeries barChartSeriesQ2 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)1 },
                    new Order() { Val = (uint)1 },
                    new SeriesText(new NumericValue() { Text = "Q2" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = color.Replace("#", "") }
                        )
                    )
                ));
            //Series Value
            string formulaValQ2 = "SummaryCompletely!$G$47:$G$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values valuesQ2 = barChartSeriesQ2.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            valuesQ2.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaValQ2 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisDataQ2 = barChartSeriesQ2.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReferenceQ2 = categoryAxisDataQ2.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            color = "#546BC1";
            columnReportDTO = summaryPlanReport.GraphReport.Where(o => o.name == "Q3").ToList().FirstOrDefault();
            if (columnReportDTO != null && columnReportDTO.color != null)
            {
                color = columnReportDTO.color;
            }

            BarChartSeries barChartSeriesQ3 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)2 },
                    new Order() { Val = (uint)2 },
                    new SeriesText(new NumericValue() { Text = "Q3" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = color.Replace("#", "") }
                        )
                    )
                ));
            //Series Value
            string formulaValQ3 = "SummaryCompletely!$H$47:$H$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values valuesQ3 = barChartSeriesQ3.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            valuesQ3.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaValQ3 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisDataQ3 = barChartSeriesQ3.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReferenceQ3 = categoryAxisDataQ3.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            color = "#546BC1";
            columnReportDTO = summaryPlanReport.GraphReport.Where(o => o.name == "Q4").ToList().FirstOrDefault();
            if (columnReportDTO != null && columnReportDTO.color != null)
            {
                color = columnReportDTO.color;
            }

            BarChartSeries barChartSeriesQ4 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)3 },
                    new Order() { Val = (uint)3 },
                    new SeriesText(new NumericValue() { Text = "Q4" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = color.Replace("#", "") }
                        )
                    )
                ));
            //Series Value
            string formulaValQ4 = "SummaryCompletely!$I$47:$I$" + (47 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values valuesQ4 = barChartSeriesQ4.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            valuesQ4.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaValQ4 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisDataQ4 = barChartSeriesQ4.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReferenceQ4 = categoryAxisDataQ4.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            barChart.AppendChild(new DataLabels(
                                new ShowLegendKey() { Val = true },
                                new ShowValue() { Val = false },
                                new ShowCategoryName() { Val = false },
                                new ShowSeriesName() { Val = true },
                                new ShowPercent() { Val = false },
                                new ShowBubbleSize() { Val = false }
                            ));
            barChart.Append(new AxisId() { Val = 48650113u });
            barChart.Append(new AxisId() { Val = 48672769u });

            // Adding Category Axis
            plotArea.AppendChild(
                new CategoryAxis(
                    new AxisId() { Val = 48650113u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48672769u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new AutoLabeled() { Val = true },
                    new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) }
                ));

            // Adding Value Axis
            plotArea.AppendChild(
                new ValueAxis(
                    new AxisId() { Val = 48672769u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                    new MajorGridlines(),
                    new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                    {
                        FormatCode = "General",
                        SourceLinked = true
                    },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48650113u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }
                ));

            chart.Append(
                    new PlotVisibleOnly() { Val = true },
                    new DisplayBlanksAs() { Val = new EnumValue<DisplayBlanksAsValues>(DisplayBlanksAsValues.Gap) },
                    new ShowDataLabelsOverMaximum() { Val = false }
                );

            chartPart.ChartSpace.Save();

            // Positioning the chart on the spreadsheet
            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("1"),
                    new ColumnOffset("0"),
                    new RowId("22"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("17"),
                    new ColumnOffset("0"),
                    new RowId("41"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = 3u,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());

        }

        public void exportStackedColumnSummaryCompletelyChartBak(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, SearchDTO searchDto)
        {
            int lRow = 30;
            #region Header
            cell = openExcelUtil.GetCell(sheetData, "B", (uint)lRow);
            cell.CellValue = new CellValue("Region");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
            cell.CellValue = new CellValue("PM");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
            cell.CellValue = new CellValue("Estimate");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
            cell.CellValue = new CellValue("Postpone to");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
            cell.CellValue = new CellValue("Q1");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
            cell.CellValue = new CellValue("Q2");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
            cell.CellValue = new CellValue("Q3");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
            cell.CellValue = new CellValue("Q4");
            cell.StyleIndex = 2;

            mergeCells.Append(new MergeCell() { Reference = new StringValue("B" + lRow + ":B" + (lRow + 1)) });

            lRow++;

            cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
            cell.CellValue = new CellValue("Transmission");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
            cell.CellValue = new CellValue("This year");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
            cell.CellValue = new CellValue("This year");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
            cell.StyleIndex = 2;

            lRow++;
            #endregion

            //Graph 1
            if (summaryPlanReport.SumaryCompletelyByRegionTable != null && summaryPlanReport.SumaryCompletelyByRegionTable.Count > 0)
            {
                foreach (SummaryCompletelyByRegionDto dto in summaryPlanReport.SumaryCompletelyByRegionTable)
                {
                    #region Record
                    cell = openExcelUtil.GetCell(sheetData, "B", (uint)lRow);
                    cell.CellValue = new CellValue(dto.RegionName);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Actual) > 0 ? Utility.ConvertToInt(dto.Actual).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Plan) > 0 ? Utility.ConvertToInt(dto.Plan).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.PostPone) > 0 ? Utility.ConvertToInt(dto.PostPone).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q1) > 0 ? Utility.ConvertToInt(dto.Q1).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q2) > 0 ? Utility.ConvertToInt(dto.Q2).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q3) > 0 ? Utility.ConvertToInt(dto.Q3).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q4) > 0 ? Utility.ConvertToInt(dto.Q4).ToString() : "");
                    cell.StyleIndex = 1;

                    lRow++;
                    #endregion
                }
            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            //chart.Legend = new Legend();
            AddChartTitle(chart, "PM Transmission " + searchDto.Year);

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());

            BarChart barChart = plotArea.AppendChild(new BarChart(
                        new BarDirection() { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                        new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.Stacked) },
                        new VaryColors() { Val = false }
                    ));

            // Constructing header
            Row row = new Row();
            barChart.AppendChild(new Overlap() { Val = 100 });
            barChart.AppendChild(new GapWidth() { Val = 250 });

            // Create chart series
            BarChartSeries barChartSeries = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)0 },
                    new Order() { Val = (uint)0 },
                    new SeriesText(new NumericValue() { Text = "Actual" })
                ));

            /*
            barChartSeries.ChartShapeProperties = new ChartShapeProperties();
            var outline = barChartSeries.ChartShapeProperties.AppendChild<DocumentFormat.OpenXml.Drawing.Outline>(new DocumentFormat.OpenXml.Drawing.Outline());
            var solid = outline.AppendChild<DocumentFormat.OpenXml.Drawing.SolidFill>(new DocumentFormat.OpenXml.Drawing.SolidFill());
            solid.AppendChild<DocumentFormat.OpenXml.Drawing.RgbColorModelHex>(new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = new HexBinaryValue() { Value = "ff0000" } });
            */

            //Series Value
            string formulaVal = "SummaryCompletely!$C$32:$C$" + (32 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values = barChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = barChartSeries.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category
            string formulaCat = "SummaryCompletely!$B$32:$B$" + (32 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });


            BarChartSeries barChartSeries2 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)1 },
                    new Order() { Val = (uint)1 },
                    new SeriesText(new NumericValue() { Text = "Plan" })
                ));
            //Series Value
            string formulaVal2 = "SummaryCompletely!$D$32:$D$" + (32 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values2 = barChartSeries2.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values2.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal2 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData2 = barChartSeries2.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference2 = categoryAxisData2.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });


            BarChartSeries barChartSeries3 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)2 },
                    new Order() { Val = (uint)2 },
                    new SeriesText(new NumericValue() { Text = "Postpone" })
                ));
            //Series Value
            string formulaVal3 = "SummaryCompletely!$E$32:$E$" + (32 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values3 = barChartSeries3.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values3.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal3 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData3 = barChartSeries3.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference3 = categoryAxisData3.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });


            BarChartSeries barChartSeries4 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)3 },
                    new Order() { Val = (uint)3 },
                    new SeriesText(new NumericValue() { Text = "Q1" })
                ));
            //Series Value
            string formulaVal4 = "SummaryCompletely!$F$32:$F$" + (32 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values4 = barChartSeries4.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values4.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal4 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData4 = barChartSeries4.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference4 = categoryAxisData4.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });


            BarChartSeries barChartSeries5 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)4 },
                    new Order() { Val = (uint)4 },
                    new SeriesText(new NumericValue() { Text = "Q2" })
                ));
            //Series Value
            string formulaVal5 = "SummaryCompletely!$G$32:$G$" + (32 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values5 = barChartSeries5.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values5.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal5 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData5 = barChartSeries5.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference5 = categoryAxisData5.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });


            BarChartSeries barChartSeries6 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)5 },
                    new Order() { Val = (uint)5 },
                    new SeriesText(new NumericValue() { Text = "Q3" })
                ));
            //Series Value
            string formulaVal6 = "SummaryCompletely!$H$32:$H$" + (32 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values6 = barChartSeries6.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values6.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal6 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData6 = barChartSeries6.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference6 = categoryAxisData6.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });


            BarChartSeries barChartSeries7 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)6 },
                    new Order() { Val = (uint)6 },
                    new SeriesText(new NumericValue() { Text = "Q4" })
                ));
            //Series Value
            string formulaVal7 = "SummaryCompletely!$I$32:$I$" + (32 + summaryPlanReport.SumaryCompletelyByRegionTable.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values7 = barChartSeries7.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values7.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal6 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData7 = barChartSeries7.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference7 = categoryAxisData7.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            barChart.AppendChild(new DataLabels(
                                new ShowLegendKey() { Val = true },
                                new ShowValue() { Val = false },
                                new ShowCategoryName() { Val = false },
                                new ShowSeriesName() { Val = true },
                                new ShowPercent() { Val = false },
                                new ShowBubbleSize() { Val = false }
                            ));

            barChart.Append(new AxisId() { Val = 48650112u });
            barChart.Append(new AxisId() { Val = 48672768u });

            // Adding Category Axis
            plotArea.AppendChild(
                new CategoryAxis(
                    new AxisId() { Val = 48650112u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48672768u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new AutoLabeled() { Val = true },
                    new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) }
                ));

            // Adding Value Axis
            plotArea.AppendChild(
                new ValueAxis(
                    new AxisId() { Val = 48672768u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                    new MajorGridlines(),
                    new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                    {
                        FormatCode = "General",
                        SourceLinked = true
                    },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48650112u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }
                ));

            chart.Append(
                    new PlotVisibleOnly() { Val = true },
                    new DisplayBlanksAs() { Val = new EnumValue<DisplayBlanksAsValues>(DisplayBlanksAsValues.Gap) },
                    new ShowDataLabelsOverMaximum() { Val = false }
                );

            chartPart.ChartSpace.Save();

            // Positioning the chart on the spreadsheet
            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("1"),
                    new ColumnOffset("0"),
                    new RowId("2"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("17"),
                    new ColumnOffset("0"),
                    new RowId("21"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = 2u,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());

        }

        public byte[] ExportSummaryRiskReportToExcel(SummaryPlanReport summaryPlanReport, string desPath, string nameExcel, SearchDTO dto)
        {
            MemoryStream stream = new MemoryStream();
            Row row = null;
            Cell cell = null;
            MergeCells mergeCells;
            int rowTotal = 100;
            try
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
                {
                    #region Instant object

                    openExcelUtil = new OpenExcelUtil();
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylePart.Stylesheet = openExcelUtil.generateSummayPlanRiskStylesheet();
                    stylePart.Stylesheet.Save();

                    Worksheet ws = new Worksheet();

                    Columns lstColumns = new Columns();
                    lstColumns.Append(openExcelUtil.CreateColumnData(35, 35, 60));

                    ws.Append(lstColumns);

                    worksheetPart.Worksheet = ws;
                    mergeCells = new MergeCells();
                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "SummaryRisk" };
                    SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
                    sheets.Append(sheet);
                    workbookPart.Workbook.Save();

                    #endregion

                    rowTotal = 100;

                    #region prepair Row
                    // Constructing header
                    for (int rr = 1; rr <= rowTotal; rr++)
                    {
                        row = new Row();
                        row.RowIndex = (UInt32)rr;

                        for (int cc = 0; cc < 57; cc++)
                        {
                            cell = openExcelUtil.ConstructCell("", CellValues.String, 0);
                            cell.CellReference = excelCols[cc] + rr;
                            cell.StyleIndex = 1;
                            row.Append(cell);
                        }
                        sheetData.AppendChild(row);
                    }
                    #endregion


                    #region Graph

                    // Add drawing part to WorksheetPart
                    DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                    worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                    worksheetPart.Worksheet.Save();

                    drawingsPart.WorksheetDrawing = new WorksheetDrawing();

                    workbookPart.Workbook.Save();

                    exportStackedColumnSummaryRiskChart(sheetData, cell, mergeCells, drawingsPart, summaryPlanReport, dto);

                    drawingsPart.WorksheetDrawing.Save();

                    worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());

                    worksheetPart.Worksheet.Save();

                    #endregion
                }

            }
            catch (Exception ex)
            { logger.error("ExportSummaryRiskReportToExcel error :" + ex.ToString()); }

            return stream.ToArray();
        }

        public void exportStackedColumnSummaryRiskChart(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryPlanReport summaryPlanReport, SearchDTO searchDto)
        {
            int lRow = 25;
            #region Header
            cell = openExcelUtil.GetCell(sheetData, "B", (uint)lRow);
            cell.CellValue = new CellValue("Region");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
            cell.CellValue = new CellValue("ไตรมาส 1");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
            cell.CellValue = new CellValue("ไตรมาส 2");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
            cell.CellValue = new CellValue("ไตรมาส 3");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "L", (uint)lRow);
            cell.CellValue = new CellValue("ไตรมาส 4");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "O", (uint)lRow);
            cell.CellValue = new CellValue("Total");
            cell.StyleIndex = 2;

            mergeCells.Append(new MergeCell() { Reference = new StringValue("C" + lRow + ":E" + lRow) });
            mergeCells.Append(new MergeCell() { Reference = new StringValue("F" + lRow + ":H" + lRow) });
            mergeCells.Append(new MergeCell() { Reference = new StringValue("I" + lRow + ":K" + lRow) });
            mergeCells.Append(new MergeCell() { Reference = new StringValue("L" + lRow + ":N" + lRow) });
            mergeCells.Append(new MergeCell() { Reference = new StringValue("O" + lRow + ":Q" + lRow) });

            mergeCells.Append(new MergeCell() { Reference = new StringValue("B" + lRow + ":B" + (lRow + 1)) });

            lRow++;

            cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
            cell.CellValue = new CellValue("Low Risk");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
            cell.CellValue = new CellValue("Medium Risk");
            cell.StyleIndex = 3;

            cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
            cell.CellValue = new CellValue("High Risk");
            cell.StyleIndex = 4;

            cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
            cell.CellValue = new CellValue("Low Risk");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
            cell.CellValue = new CellValue("Medium Risk");
            cell.StyleIndex = 3;

            cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
            cell.CellValue = new CellValue("High Risk");
            cell.StyleIndex = 4;

            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
            cell.CellValue = new CellValue("Low Risk");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "J", (uint)lRow);
            cell.CellValue = new CellValue("Medium Risk");
            cell.StyleIndex = 3;

            cell = openExcelUtil.GetCell(sheetData, "K", (uint)lRow);
            cell.CellValue = new CellValue("High Risk");
            cell.StyleIndex = 4;

            cell = openExcelUtil.GetCell(sheetData, "L", (uint)lRow);
            cell.CellValue = new CellValue("Low Risk");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "M", (uint)lRow);
            cell.CellValue = new CellValue("Medium Risk");
            cell.StyleIndex = 3;

            cell = openExcelUtil.GetCell(sheetData, "N", (uint)lRow);
            cell.CellValue = new CellValue("High Risk");
            cell.StyleIndex = 4;

            cell = openExcelUtil.GetCell(sheetData, "O", (uint)lRow);
            cell.CellValue = new CellValue("Low Risk");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "P", (uint)lRow);
            cell.CellValue = new CellValue("Medium Risk");
            cell.StyleIndex = 3;

            cell = openExcelUtil.GetCell(sheetData, "Q", (uint)lRow);
            cell.CellValue = new CellValue("High Risk");
            cell.StyleIndex = 4;

            lRow++;
            #endregion

            //Graph 1
            List<SummaryPlanRiskDto> results = summaryPlanReport.RiskTableReport;
            if (results != null && results.Count > 0)
            {
                foreach (SummaryPlanRiskDto dto in results)
                {
                    #region Record
                    cell = openExcelUtil.GetCell(sheetData, "B", (uint)lRow);
                    cell.CellValue = new CellValue(dto.RegionName);
                    cell.StyleIndex = 1;


                    cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q1Low) > 0 ? Utility.ConvertToInt(dto.Q1Low).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q1Medium) > 0 ? Utility.ConvertToInt(dto.Q1Medium).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q1High) > 0 ? Utility.ConvertToInt(dto.Q1High).ToString() : "");
                    cell.StyleIndex = 1;


                    cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q2Low) > 0 ? Utility.ConvertToInt(dto.Q2Low).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q2Medium) > 0 ? Utility.ConvertToInt(dto.Q2Medium).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q2High) > 0 ? Utility.ConvertToInt(dto.Q2High).ToString() : "");
                    cell.StyleIndex = 1;


                    cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q3Low) > 0 ? Utility.ConvertToInt(dto.Q3Low).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "J", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q3Medium) > 0 ? Utility.ConvertToInt(dto.Q3Medium).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "K", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q3High) > 0 ? Utility.ConvertToInt(dto.Q3High).ToString() : "");
                    cell.StyleIndex = 1;


                    cell = openExcelUtil.GetCell(sheetData, "L", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q4Low) > 0 ? Utility.ConvertToInt(dto.Q4Low).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "M", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q4Medium) > 0 ? Utility.ConvertToInt(dto.Q4Medium).ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "N", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(Utility.ConvertToInt(dto.Q4High) > 0 ? Utility.ConvertToInt(dto.Q4High).ToString() : "");
                    cell.StyleIndex = 1;

                    int lowTotal = Utility.ConvertToInt(dto.Q1Low) + Utility.ConvertToInt(dto.Q2Low) + Utility.ConvertToInt(dto.Q3Low) + Utility.ConvertToInt(dto.Q4Low);
                    int mediumTotal = Utility.ConvertToInt(dto.Q1Medium) + Utility.ConvertToInt(dto.Q2Medium) + Utility.ConvertToInt(dto.Q3Medium) + Utility.ConvertToInt(dto.Q4Medium);
                    int highTotal = Utility.ConvertToInt(dto.Q1High) + Utility.ConvertToInt(dto.Q2High) + Utility.ConvertToInt(dto.Q3High) + Utility.ConvertToInt(dto.Q4High);

                    cell = openExcelUtil.GetCell(sheetData, "O", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(lowTotal > 0 ? lowTotal.ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "P", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(mediumTotal > 0 ? mediumTotal.ToString() : "");
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "Q", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(highTotal > 0 ? highTotal.ToString() : "");
                    cell.StyleIndex = 1;

                    #endregion
                    lRow++;
                }

            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            chart.Legend = new Legend(new LegendPosition() { Val = new EnumValue<LegendPositionValues>(LegendPositionValues.TopRight) });
            AddChartTitle(chart, "ผลประเมินความเสี่ยง " + searchDto.Year);

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());
            ManualLayout manualLayout = layout.AppendChild(new ManualLayout());
            manualLayout.Top = new Top() { Val = 0.2 };
            manualLayout.Width = new Width() { Val = 0.9 };
            manualLayout.Height = new Height() { Val = 0.8 };

            BarChart barChart = plotArea.AppendChild(new BarChart(
                        new BarDirection() { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                        new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.Stacked) },
                        new VaryColors() { Val = false }
                    ));

            // Constructing header
            Row row = new Row();
            barChart.AppendChild(new Overlap() { Val = 100 });
            barChart.AppendChild(new GapWidth() { Val = 250 });
            
            // Create chart series
            BarChartSeries barChartSeries = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)0 },
                    new Order() { Val = (uint)0 },
                    new SeriesText(new NumericValue() { Text = "Low" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = "5B9BD5" }
                        )
                    )
                ));
            
            /*
            barChartSeries.ChartShapeProperties = new ChartShapeProperties();
            var outline = barChartSeries.ChartShapeProperties.AppendChild<DocumentFormat.OpenXml.Drawing.Outline>(new DocumentFormat.OpenXml.Drawing.Outline());
            var solid = outline.AppendChild<DocumentFormat.OpenXml.Drawing.SolidFill>(new DocumentFormat.OpenXml.Drawing.SolidFill());
            solid.AppendChild<DocumentFormat.OpenXml.Drawing.RgbColorModelHex>(new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = new HexBinaryValue() { Value = "ff0000" } });
            */

            //Series Value
            string formulaVal = "SummaryRisk!$O$27:$O$" + (27 + results.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values = barChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = barChartSeries.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category
            string formulaCat = "SummaryRisk!$B$27:$B$" + (27 + results.Count - 1);

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            BarChartSeries barChartSeries2 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)1 },
                    new Order() { Val = (uint)1 },
                    new SeriesText(new NumericValue() { Text = "Medium" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = "ED7D31" }
                        )
                    )
                ));
            //Series Value
            string formulaVal2 = "SummaryRisk!$P$27:$P$" + (27 + results.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values2 = barChartSeries2.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values2.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal2 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData2 = barChartSeries2.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference2 = categoryAxisData2.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            BarChartSeries barChartSeries3 = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)2 },
                    new Order() { Val = (uint)2 },
                    new SeriesText(new NumericValue() { Text = "High" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = "A5A5A5" }
                        )
                    )
                ));
            //Series Value
            string formulaVal3 = "SummaryRisk!$Q$27:$Q$" + (27 + results.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values3 = barChartSeries3.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values3.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal3 }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData3 = barChartSeries3.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category

            StringReference stringReference3 = categoryAxisData3.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            barChart.AppendChild(new DataLabels(
                                new ShowLegendKey() { Val = true },
                                new ShowValue() { Val = false },
                                new ShowCategoryName() { Val = false },
                                new ShowSeriesName() { Val = false },
                                new ShowPercent() { Val = false },
                                new ShowBubbleSize() { Val = false }
                            ));

            barChart.Append(new AxisId() { Val = 48650112u });
            barChart.Append(new AxisId() { Val = 48672768u });

            // Adding Category Axis
            plotArea.AppendChild(
                new CategoryAxis(
                    new AxisId() { Val = 48650112u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48672768u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new AutoLabeled() { Val = true },
                    new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) }
                ));

            // Adding Value Axis
            plotArea.AppendChild(
                new ValueAxis(
                    new AxisId() { Val = 48672768u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                    new MajorGridlines(),
                    new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                    {
                        FormatCode = "General",
                        SourceLinked = true
                    },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48650112u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }
                ));

            chart.Append(
                    new PlotVisibleOnly() { Val = true },
                    new DisplayBlanksAs() { Val = new EnumValue<DisplayBlanksAsValues>(DisplayBlanksAsValues.Gap) },
                    new ShowDataLabelsOverMaximum() { Val = false }
                );

            chartPart.ChartSpace.Save();

            // Positioning the chart on the spreadsheet
            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("1"),
                    new ColumnOffset("0"),
                    new RowId("2"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("17"),
                    new ColumnOffset("0"),
                    new RowId("21"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = 2u,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());
        }

        public byte[] ExportSummaryRepaireToExcel(SummaryRepaireAll summaryRepareReport, string desPath, string nameExcel)
        {
            MemoryStream stream = new MemoryStream();
            Row row = null;
            Cell cell = null;
            MergeCells mergeCells;
            int rowTotal = 100;
            try
            {
                logger.debug("Start ExportSummaryRepaireToExcel summaryRepareReport:"+ summaryRepareReport.ToString());
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
                {
                    #region Instant object

                    openExcelUtil = new OpenExcelUtil();
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylePart.Stylesheet = openExcelUtil.generateSummaryRiskStylesheet();
                    stylePart.Stylesheet.Save();

                    Worksheet ws = new Worksheet();

                    Columns lstColumns = new Columns();
                    lstColumns.Append(openExcelUtil.CreateColumnData(35, 35, 60));

                    ws.Append(lstColumns);

                    worksheetPart.Worksheet = ws;
                    mergeCells = new MergeCells();
                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "SummaryRepaire" };
                    SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
                    sheets.Append(sheet);
                    workbookPart.Workbook.Save();

                    #endregion

                    rowTotal = 100;

                    #region prepair Row
                    // Constructing header
                    for (int rr = 1; rr <= rowTotal; rr++)
                    {
                        row = new Row();
                        row.RowIndex = (UInt32)rr;

                        for (int cc = 0; cc < 57; cc++)
                        {
                            cell = openExcelUtil.ConstructCell("", CellValues.String, 0);
                            cell.CellReference = excelCols[cc] + rr;
                            cell.StyleIndex = 1;
                            row.Append(cell);
                        }
                        sheetData.AppendChild(row);
                    }
                    #endregion


                    #region Graph

                    // Add drawing part to WorksheetPart
                    DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                    worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                    worksheetPart.Worksheet.Save();

                    drawingsPart.WorksheetDrawing = new WorksheetDrawing();

                    workbookPart.Workbook.Save();

                    exportSummaryRepairChart(sheetData, cell, mergeCells, drawingsPart, summaryRepareReport);

                    drawingsPart.WorksheetDrawing.Save();

                    worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());

                    worksheetPart.Worksheet.Save();

                    #endregion
                }

            }
            catch (Exception ex)
            { logger.error("ExportSummaryRepaireToExcel error :" + ex.ToString()); }

            return stream.ToArray();
        }

        public void exportSummaryRepairChart(SheetData sheetData, Cell cell, MergeCells mergeCells, DrawingsPart drawingsPart, SummaryRepaireAll summaryRepareReport)
        {
            int lRow = 1;
            #region Header
            cell = openExcelUtil.GetCell(sheetData, "A", (uint)lRow);
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
            cell.CellValue = new CellValue("Coating Inspection Result");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "L", (uint)lRow);
            cell.CellValue = new CellValue("Pipeline Inspection Result");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "N", (uint)lRow);
            cell.StyleIndex = 2;

            mergeCells.Append(new MergeCell() { Reference = new StringValue("A" + lRow + ":H" + lRow) });
            mergeCells.Append(new MergeCell() { Reference = new StringValue("I" + lRow + ":K" + lRow) });
            mergeCells.Append(new MergeCell() { Reference = new StringValue("L" + lRow + ":M" + lRow) });

            lRow++;

            cell = openExcelUtil.GetCell(sheetData, "A", (uint)lRow);
            cell.CellValue = new CellValue("No.");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "B", (uint)lRow);
            cell.CellValue = new CellValue("Region");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
            cell.CellValue = new CellValue("RC");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
            cell.CellValue = new CellValue("Pipeline Section");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
            cell.CellValue = new CellValue("KP");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
            cell.CellValue = new CellValue("Repair Length(m)");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
            cell.CellValue = new CellValue("Dig from");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
            cell.CellValue = new CellValue("Risk level");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
            cell.CellValue = new CellValue("type");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "J", (uint)lRow);
            cell.CellValue = new CellValue("dmg type");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "K", (uint)lRow);
            cell.CellValue = new CellValue("จำนวนจุด");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "L", (uint)lRow);
            cell.CellValue = new CellValue("Damage type");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "M", (uint)lRow);
            cell.CellValue = new CellValue("จำนวนจุด");
            cell.StyleIndex = 2;

            cell = openExcelUtil.GetCell(sheetData, "N", (uint)lRow);
            cell.CellValue = new CellValue("Note");
            cell.StyleIndex = 2;

            lRow++;
            #endregion

            int rowNumber = 1;
            if (summaryRepareReport.Table != null && summaryRepareReport.Table.Count > 0)
            {
                #region Table deatil
                var pipelineGroupList = summaryRepareReport.Table.GroupBy(u => u.PipelineType).Select(gr => gr.ToList()).ToList();

                foreach (var objList in pipelineGroupList)
                {
                    cell = openExcelUtil.GetCell(sheetData, "A", (uint)lRow);
                    cell.CellValue = new CellValue(objList[0].PipelineType);
                    cell.StyleIndex = 3;

                    mergeCells.Append(new MergeCell() { Reference = new StringValue("A" + lRow + ":N" + lRow) });

                    lRow++;

                    var assertOwnerList = objList.GroupBy(u => u.AssertOwner).Select(gr => gr.ToList()).ToList();

                    foreach (var inspectionList in assertOwnerList)
                    {
                        cell = openExcelUtil.GetCell(sheetData, "A", (uint)lRow);
                        cell.CellValue = new CellValue(inspectionList[0].AssertOwner);
                        cell.StyleIndex = 4;

                        mergeCells.Append(new MergeCell() { Reference = new StringValue("A" + lRow + ":N" + lRow) });
                        lRow++;

                        foreach (SummaryRepaireDTO dto in inspectionList)
                        {
                            cell = openExcelUtil.GetCell(sheetData, "A", (uint)lRow);
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                            cell.CellValue = new CellValue(rowNumber.ToString());
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "B", (uint)lRow);
                            cell.CellValue = new CellValue(dto.Region);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
                            cell.CellValue = new CellValue(dto.RC);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "D", (uint)lRow);
                            cell.CellValue = new CellValue(dto.PipelineSection);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "E", (uint)lRow);
                            cell.CellValue = new CellValue(dto.KP);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                            cell.CellValue = new CellValue(dto.RepairLength);
                            cell.StyleIndex = 5;

                            cell = openExcelUtil.GetCell(sheetData, "G", (uint)lRow);
                            cell.CellValue = new CellValue(dto.Digfrom);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "H", (uint)lRow);
                            cell.CellValue = new CellValue(dto.RiskLevel);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "I", (uint)lRow);
                            cell.CellValue = new CellValue(dto.CoatingType);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "J", (uint)lRow);
                            cell.CellValue = new CellValue(dto.CoatingDMGType);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "K", (uint)lRow);
                            cell.CellValue = new CellValue(dto.CoatingPoint);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "L", (uint)lRow);
                            cell.CellValue = new CellValue(dto.PipelineDMGType);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "M", (uint)lRow);
                            cell.CellValue = new CellValue(dto.PipelinePoint);
                            cell.StyleIndex = 1;

                            cell = openExcelUtil.GetCell(sheetData, "N", (uint)lRow);
                            cell.CellValue = new CellValue(dto.Note);
                            cell.StyleIndex = 1;

                            rowNumber++;
                            lRow++;
                        }
                    }
                }
                #endregion
            }

            List<SummaryRepaireDTO> sumForGraph = new List<SummaryRepaireDTO>();

            if (summaryRepareReport.Table != null && summaryRepareReport.Table.Count > 0)
            {
                var regionGroupList = summaryRepareReport.Table.GroupBy(u => u.Region).Select(gr => gr.ToList()).ToList();

                //Prepare summary
                decimal sumAll = 0;
                foreach (var objList in regionGroupList)
                {
                    decimal sumByRegion = 0;
                    SummaryRepaireDTO dto = new SummaryRepaireDTO();

                    dto.Region = objList[0].Region;

                    foreach (SummaryRepaireDTO sumDto in objList)
                    {
                        sumByRegion += Utility.ConvertToDecimal(sumDto.RepairLength);
                        sumAll += Utility.ConvertToDecimal(sumDto.RepairLength);
                    }
                    dto.RepairLength = sumByRegion.ToString();
                    sumForGraph.Add(dto);
                }

                //Write summary
                cell = openExcelUtil.GetCell(sheetData, "C", (uint)lRow);
                cell.CellValue = new CellValue("Total Length");
                cell.StyleIndex = 1;

                mergeCells.Append(new MergeCell() { Reference = new StringValue("C" + lRow + ":E" + lRow) });

                cell = openExcelUtil.GetCell(sheetData, "F", (uint)lRow);
                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                cell.CellValue = new CellValue(sumAll.ToString());
                cell.StyleIndex = 5;

                //Reset row
                lRow = 1;
                cell = openExcelUtil.GetCell(sheetData, "Q", (uint)lRow);
                cell.CellValue = new CellValue("Region");
                cell.StyleIndex = 2;

                cell = openExcelUtil.GetCell(sheetData, "R", (uint)lRow);
                cell.CellValue = new CellValue("Repair length (m)");
                cell.StyleIndex = 2;

                lRow++;
                foreach (SummaryRepaireDTO sumDto in sumForGraph)
                {
                    cell = openExcelUtil.GetCell(sheetData, "Q", (uint)lRow);
                    cell.CellValue = new CellValue(sumDto.Region);
                    cell.StyleIndex = 1;

                    cell = openExcelUtil.GetCell(sheetData, "R", (uint)lRow);
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                    cell.CellValue = new CellValue(sumDto.RepairLength);
                    cell.StyleIndex = 1;
                    lRow++;
                }
            }

            // Add a new chart and set the chart language
            ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
            chartPart.ChartSpace = new ChartSpace();
            chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
            Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
            //chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title
            chart.Legend = new Legend(new LegendPosition() { Val = new EnumValue<LegendPositionValues>(LegendPositionValues.TopRight) });
            AddChartTitle(chart, "Summary Repair Report");

            // Create a new Clustered Column Chart
            PlotArea plotArea = chart.AppendChild(new PlotArea());
            Layout layout = plotArea.AppendChild(new Layout());
            ManualLayout manualLayout = layout.AppendChild(new ManualLayout());
            manualLayout.Top = new Top() { Val = 0.2 };
            manualLayout.Width = new Width() { Val = 0.9 };
            manualLayout.Height = new Height() { Val = 0.8 };

            BarChart barChart = plotArea.AppendChild(new BarChart(
                        new BarDirection() { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                        new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.Clustered) },
                        new VaryColors() { Val = false }
                    ));

            // Constructing header
            Row row = new Row();

            /*
            barChart.AppendChild(new Overlap() { Val = 100 });
            barChart.AppendChild(new GapWidth() { Val = 250 });
            */

            String color = "#546BC1";
            ColumnReportDTO columnReportDTO = summaryRepareReport.Graph.Where(o => o.name == "Region").ToList().FirstOrDefault();
            if(columnReportDTO != null && columnReportDTO.color != null)
            {
                color = columnReportDTO.color;
            }

            // Create chart series
            BarChartSeries barChartSeries = barChart.AppendChild(new BarChartSeries(
                    new Index() { Val = (uint)0 },
                    new Order() { Val = (uint)0 },
                    new SeriesText(new NumericValue() { Text = "Region" }),
                    new ChartShapeProperties(
                        new DocumentFormat.OpenXml.Drawing.SolidFill(
                            new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = color.Replace("#","") }
                        )
                    )
                ));

            /*
            barChartSeries.ChartShapeProperties = new ChartShapeProperties();
            var outline = barChartSeries.ChartShapeProperties.AppendChild<DocumentFormat.OpenXml.Drawing.Outline>(new DocumentFormat.OpenXml.Drawing.Outline());
            var solid = outline.AppendChild<DocumentFormat.OpenXml.Drawing.SolidFill>(new DocumentFormat.OpenXml.Drawing.SolidFill());
            solid.AppendChild<DocumentFormat.OpenXml.Drawing.RgbColorModelHex>(new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = new HexBinaryValue() { Value = "ff0000" } });
            */

            //Series Value
            string formulaVal = "SummaryRepaire!$R$2:$R$" + (2 + sumForGraph.Count - 1);
            DocumentFormat.OpenXml.Drawing.Charts.Values values = barChartSeries.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

            values.AppendChild(new NumberReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
            });

            // Adding category axis to the chart
            CategoryAxisData categoryAxisData = barChartSeries.AppendChild(new CategoryAxisData());
            // Category
            // Constructing the chart category
            string formulaCat = "SummaryRepaire!$Q$2:$Q$" + (2 + sumForGraph.Count - 1);

            StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
            {
                Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
            });

            barChart.AppendChild(new DataLabels(
                                new ShowLegendKey() { Val = true },
                                new ShowValue() { Val = true },
                                new ShowCategoryName() { Val = false },
                                new ShowSeriesName() { Val = false },
                                new ShowPercent() { Val = false },
                                new ShowBubbleSize() { Val = false }
                            ));

            barChart.Append(new AxisId() { Val = 48650112u });
            barChart.Append(new AxisId() { Val = 48672768u });

            // Adding Category Axis
            plotArea.AppendChild(
                new CategoryAxis(
                    new AxisId() { Val = 48650112u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48672768u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new AutoLabeled() { Val = true },
                    new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) }
                ));

            // Adding Value Axis
            plotArea.AppendChild(
                new ValueAxis(
                    new AxisId() { Val = 48672768u },
                    new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                    new Delete() { Val = false },
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                    new MajorGridlines(),
                    new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                    {
                        FormatCode = "General",
                        SourceLinked = true
                    },
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = 48650112u },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }
                ));

            chart.Append(
                    new PlotVisibleOnly() { Val = true },
                    new DisplayBlanksAs() { Val = new EnumValue<DisplayBlanksAsValues>(DisplayBlanksAsValues.Gap) },
                    new ShowDataLabelsOverMaximum() { Val = false }
                );

            chartPart.ChartSpace.Save();

            // Positioning the chart on the spreadsheet
            TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                    new ColumnId("20"),
                    new ColumnOffset("0"),
                    new RowId("0"),
                    new RowOffset("0")
                ));

            twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                    new ColumnId("28"),
                    new ColumnOffset("0"),
                    new RowId("21"),
                    new RowOffset("0")
                ));

            // Append GraphicFrame to TwoCellAnchor
            GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
            graphicFrame.Macro = string.Empty;

            graphicFrame.Append(new NonVisualGraphicFrameProperties(
                    new NonVisualDrawingProperties()
                    {
                        Id = 2u,
                        Name = "Sample Chart"
                    },
                    new NonVisualGraphicFrameDrawingProperties()
                ));

            graphicFrame.Append(new Transform(
                    new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                    new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                ));

            graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                            new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                        )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                ));

            twoCellAnchor.Append(new ClientData());
        }

        public String getGraph5Dese(String name)
        {
            if ("Pit".Equals(name))
            {
                return "Pit = Pitting Corrosion (การกัดกร่อนลักษณะคล้ายรูเข็ม)";
            }
            else if ("Uni".Equals(name))
            {
                return "Uni = Uniform corrosion (การกัดกร่อนเฉพาะจุด)";
            }
            else if ("GD".Equals(name))
            {
                return "GD = Dent with Gouge (รอยบุบพร้อมรอยข่วน)";
            }
            else if ("CR".Equals(name))
            {
                return "CR = Crack(รอยแตกบนผิวท่อ)";
            }
            else if ("GC".Equals(name))
            {
                return "GC = General Corrosion (การกัดกร่อนทั่วสภาพพื้นผิว)";
            }
            else if ("G".Equals(name))
            {
                return "G = Gouge (รอยข่วน)";
            }
            else if ("SWD".Equals(name))
            {
                return "SWD = Seam Weld Defect (สิ่งผิดปกติบนแนวเชื่อมตามยาว)";
            }
            else if ("GWD".Equals(name))
            {
                return "GWD = Girth Weld Defect (สิ่งผิดปกติบนแนวเชื่อมตามเส้นรอบวง)";
            }
            else if ("PD".Equals(name))
            {
                return "PD = Plain Dent (รอยบุบ)";
            }
            else if ("KD".Equals(name))
            {
                return "KD = Kinked Dent (รอบบุบพับ)";
            }
            else
            {
                return "";
            }
        }

        public byte[] ExportPlan(List<ExportPlanHeader> headerList, System.Data.DataTable dtGroup,
                                 System.Data.DataTable dtDetail,
                                 string desPath, string nameExcel)
        {
            openExcelUtil = new OpenExcelUtil();
            MemoryStream stream = new MemoryStream();
            List<Student> students = new List<Student>();
            Initizalize(students);
            Row row = null;
            Cell cell = null;
            int lastRow = 0;
            DataView dv = null;
            int rowTotal = 0;

            int SpecSWeek = 0;
            int SpecTotal = 0;


            int POSWeek = 0;
            int POTotal = 0;


            int ActionSWeek = 0;

            int colDetail = 0;

            int Actiontotal = 0;
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                #region Instant object


                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = openExcelUtil.GenerateStylesheet();
                stylePart.Stylesheet.Save();

                Worksheet ws = new Worksheet();

                Columns lstColumns = new Columns();
                lstColumns.Append(openExcelUtil.CreateColumnData(9, 56, 4));
                lstColumns.Append(openExcelUtil.CreateColumnData(57, 57, 20));

                ws.Append(lstColumns);
                worksheetPart.Worksheet = ws;
                MergeCells mergeCells = new MergeCells();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "ExportPlaning" };
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());
                sheets.Append(sheet);
                workbookPart.Workbook.Save();


                #endregion

                rowTotal = (13 + dtGroup.Rows.Count + dtDetail.Rows.Count);


                #region prepair Row
                // Constructing header
                for (int rr = 1; rr <= rowTotal; rr++)
                {
                    row = new Row();
                    row.RowIndex = (UInt32)rr;
                    if (rr == 1 || rr == 3)
                    {
                        row.Height = 18;
                        row.CustomHeight = true;
                    }
                    if (rr == 2)
                    {
                        row.Height = 36;
                        row.CustomHeight = true;

                    }

                    for (int cc = 0; cc < 57; cc++)
                    {
                        cell = openExcelUtil.ConstructCell("", CellValues.String, 1);
                        cell.CellReference = excelCols[cc] + rr;
                        cell.StyleIndex = 1;
                        row.Append(cell);
                    }



                    sheetData.AppendChild(row);
                }

                #endregion


                #region Header

                cell = openExcelUtil.GetCell(sheetData, "A", 1);
                cell.CellValue = new CellValue("CM");


                cell = openExcelUtil.GetCell(sheetData, "C", 3);
                cell.CellValue = new CellValue("PTT Public Company Limited");
                cell.StyleIndex = 3;
                cell = openExcelUtil.GetCell(sheetData, "C", 4);
                cell.CellValue = new CellValue("Gas Business Unit");


                cell = openExcelUtil.GetCell(sheetData, "C", 5);
                cell.CellValue = new CellValue("Natural Gas Transmission");


                cell = openExcelUtil.GetCell(sheetData, "I", 1);
                cell.CellValue = new CellValue(" Direct Assessment PL reinforcement/ repair  and Coating Repair Action Plan");
                cell.StyleIndex = 2;

                cell = openExcelUtil.GetCell(sheetData, "I", 2);
                cell.CellValue = new CellValue(" Prepared by");

                cell = openExcelUtil.GetCell(sheetData, "I", 5);
                cell.CellValue = new CellValue("Pipeline Maintenance Manager");

                cell = openExcelUtil.GetCell(sheetData, "V", 2);
                cell.CellValue = new CellValue("Checked by");

                cell = openExcelUtil.GetCell(sheetData, "V", 5);
                cell.CellValue = new CellValue("Pipeline Maintenance Manager");


                cell = openExcelUtil.GetCell(sheetData, "AJ", 2);
                cell.CellValue = new CellValue("Approved by");

                cell = openExcelUtil.GetCell(sheetData, "AJ", 5);
                cell.CellValue = new CellValue("Natural Gas Transmission EVP");


                cell = openExcelUtil.GetCell(sheetData, "AW", 2);
                cell.CellValue = new CellValue("From :");
                cell.StyleIndex = 6;
                cell = openExcelUtil.GetCell(sheetData, "AW", 3);
                cell.CellValue = new CellValue("Page :");
                cell.StyleIndex = 6;
                cell = openExcelUtil.GetCell(sheetData, "AW", 4);
                cell.CellValue = new CellValue("Revision :");
                cell.StyleIndex = 6;
                cell = openExcelUtil.GetCell(sheetData, "AW", 5);
                cell.CellValue = new CellValue("Date of issued :");
                cell.StyleIndex = 6;

                ExportPlanHeader fromHeader = headerList.Where(a => a.Subject.ToLower() == "from").ToList().FirstOrDefault();
                cell = openExcelUtil.GetCell(sheetData, "BE", 2);
                cell.CellValue = new CellValue(fromHeader.Text);
                cell.StyleIndex = 5;


                cell = openExcelUtil.GetCell(sheetData, "BE", 5);
                cell.CellValue = new CellValue(string.Format("{0}/{1}/{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                cell.StyleIndex = 5;

                #endregion



                #region Sub Header

                cell = openExcelUtil.GetCell(sheetData, "A", 6);
                cell.CellValue = new CellValue("Item");
                cell.StyleIndex = 4;

                cell = openExcelUtil.GetCell(sheetData, "B", 6);
                cell.CellValue = new CellValue("RC");
                cell.StyleIndex = 4;

                cell = openExcelUtil.GetCell(sheetData, "C", 6);
                cell.CellValue = new CellValue("Pipeline Section");
                cell.StyleIndex = 4;
                cell = openExcelUtil.GetCell(sheetData, "C", 7);
                cell.CellValue = new CellValue("Start - End");
                cell.StyleIndex = 4;

                cell = openExcelUtil.GetCell(sheetData, "D", 7);
                cell.CellValue = new CellValue("KP");
                cell.StyleIndex = 4;



                cell = openExcelUtil.GetCell(sheetData, "E", 6);
                cell.CellValue = new CellValue("Region");
                cell.StyleIndex = 4;


                cell = openExcelUtil.GetCell(sheetData, "F", 6);
                cell.CellValue = new CellValue("Dig from");
                cell.StyleIndex = 4;

                cell = openExcelUtil.GetCell(sheetData, "G", 6);
                cell.CellValue = new CellValue("Severity");
                cell.StyleIndex = 4;


                cell = openExcelUtil.GetCell(sheetData, "H", 6);
                cell.CellValue = new CellValue("Progress");
                cell.StyleIndex = 4;

                int month = 0;
                for (int tempCol = 8; tempCol <= 52; tempCol += 4)
                {
                    cell = openExcelUtil.GetCell(sheetData, excelCols[tempCol], 6);
                    cell.CellValue = new CellValue(months[month]);
                    cell.StyleIndex = 4;

                    mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}6:{1}6", excelCols[tempCol], excelCols[tempCol + 3])) });

                    month++;
                }

                int week = 1;
                for (int tempCol = 8; tempCol <= 55; tempCol++)
                {
                    cell = openExcelUtil.GetCell(sheetData, excelCols[tempCol], 7);
                    cell.CellValue = new CellValue(week.ToString());
                    cell.StyleIndex = 4;
                    week++;
                    if (week > 4)
                        week = 1;
                }

                #endregion



                #region Fill data

                lastRow = 8;
                int no = 1;
                if (dtGroup != null && dtGroup.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtGroup.Rows)
                    {
                        dv = new DataView(dtDetail);
                        dv.RowFilter = string.Format("PipelineID='{0}'", dr["PipelineID"].ToString());
                        dv.Sort = "RouteCode,RegionName,Progress desc";

                        cell = openExcelUtil.GetCell(sheetData, excelCols[0], (uint)lastRow);
                        cell.CellValue = new CellValue(dr["PipelineName"].ToString());
                        cell.StyleIndex = 7;

                        mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{2}:{1}{2}", excelCols[0], excelCols[55], lastRow)) });


                        lastRow++;
                        foreach (DataRowView drr in dv)
                        {
                            if (drr["Progress"].ToString().Trim().ToLower().Equals("plan"))
                            {


                                cell = openExcelUtil.GetCell(sheetData, excelCols[0], (uint)lastRow);
                                cell.CellValue = new CellValue(no.ToString());
                                cell.StyleIndex = 1;
                                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{1}:{0}{2}", excelCols[0], lastRow, lastRow + 1)) });


                                cell = openExcelUtil.GetCell(sheetData, excelCols[1], (uint)lastRow);
                                cell.CellValue = new CellValue(drr["RouteCode"].ToString());
                                cell.StyleIndex = 1;



                                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{1}:{0}{2}", excelCols[1], lastRow, lastRow + 1)) });





                                cell = openExcelUtil.GetCell(sheetData, excelCols[2], (uint)lastRow);
                                cell.CellValue = new CellValue(drr["PipelineName"].ToString());
                                cell.StyleIndex = 1;
                                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{1}:{0}{2}", excelCols[2], lastRow, lastRow + 1)) });





                                cell = openExcelUtil.GetCell(sheetData, excelCols[3], (uint)lastRow);
                                cell.CellValue = new CellValue(drr["KP"].ToString());
                                cell.StyleIndex = 1;


                                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{1}:{0}{2}", excelCols[3], lastRow, lastRow + 1)) });




                                cell = openExcelUtil.GetCell(sheetData, excelCols[4], (uint)lastRow);
                                cell.CellValue = new CellValue(drr["RegionName"].ToString());
                                cell.StyleIndex = 1;
                                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{1}:{0}{2}", excelCols[4], lastRow, lastRow + 1)) });



                                cell = openExcelUtil.GetCell(sheetData, excelCols[5], (uint)lastRow);
                                cell.CellValue = new CellValue(drr["DIGFromName"].ToString());
                                cell.StyleIndex = 1;
                                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{1}:{0}{2}", excelCols[5], lastRow, lastRow + 1)) });



                                cell = openExcelUtil.GetCell(sheetData, excelCols[6], (uint)lastRow);
                                cell.CellValue = new CellValue(drr["RiskScoreName"].ToString());
                                cell.StyleIndex = 1;

                                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{1}:{0}{2}", excelCols[6], lastRow, lastRow + 1)) });




                            }
                            cell = openExcelUtil.GetCell(sheetData, excelCols[7], (uint)lastRow);
                            cell.CellValue = new CellValue(drr["Progress"].ToString());
                            cell.StyleIndex = 1;



                            colDetail = 7;
                            if (drr["SpecSWeek"] != null && drr["SpecTotal"] != null
                                 && drr["SpecTotal"].ToString() != "")
                            {
                                SpecSWeek = Utility.ConvertToInt(drr["SpecSWeek"].ToString());
                                SpecTotal = Utility.ConvertToInt(drr["SpecTotal"].ToString());

                                cell = openExcelUtil.GetCell(sheetData, excelCols[colDetail + SpecSWeek], (uint)lastRow);
                                cell.CellValue = new CellValue(string.Format("Spec({0}%)", Utility.ConvertToDecimal(drr["SpecComplete"].ToString()).ToString("##0")));


                                if (drr["Progress"].ToString().Trim().ToLower().Equals("plan"))
                                {
                                    cell.StyleIndex = 8;
                                }
                                else
                                {
                                    cell.StyleIndex = 11;
                                }

                                if (SpecTotal > 0)
                                    mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{2}:{1}{2}", excelCols[colDetail + SpecSWeek], excelCols[colDetail + SpecSWeek + (SpecTotal - 1)], lastRow)) });



                            }

                            if (drr["POSWeek"] != null && drr["POTotal"] != null
                               && drr["POTotal"].ToString() != "")
                            {
                                POSWeek = Utility.ConvertToInt(drr["POSWeek"].ToString());
                                POTotal = Utility.ConvertToInt(drr["POTotal"].ToString());

                                cell = openExcelUtil.GetCell(sheetData, excelCols[colDetail + POSWeek], (uint)lastRow);

                                cell.CellValue = new CellValue(string.Format("PO({0}%)", Utility.ConvertToDecimal(drr["POComplete"].ToString()).ToString("##0")));

                                if (drr["Progress"].ToString().Trim().ToLower().Equals("plan"))
                                {
                                    cell.StyleIndex = 9;
                                }
                                else
                                {
                                    cell.StyleIndex = 12;
                                }

                                if (POTotal > 0)
                                    mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{2}:{1}{2}", excelCols[colDetail + POSWeek], excelCols[colDetail + POSWeek + (POTotal - 1)], lastRow)) });



                            }

                            if (drr["ActionSWeek"] != null && drr["ActionTotal"] != null
                                                    && drr["ActionTotal"].ToString() != "")
                            {

                                ActionSWeek = Utility.ConvertToInt(drr["ActionSWeek"].ToString());
                                Actiontotal = Utility.ConvertToInt(drr["ActionTotal"].ToString());

                                cell = openExcelUtil.GetCell(sheetData, excelCols[colDetail + ActionSWeek], (uint)lastRow);

                                cell.CellValue = new CellValue(string.Format("Action({0}%)", Utility.ConvertToDecimal(drr["ActionComplete"].ToString()).ToString("##0")));

                                if (drr["Progress"].ToString().Trim().ToLower().Equals("plan"))
                                {
                                    cell.StyleIndex = 10;
                                }
                                else
                                {
                                    cell.StyleIndex = 13;
                                }

                                if (Actiontotal > 0)
                                    mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("{0}{2}:{1}{2}", excelCols[colDetail + ActionSWeek], excelCols[colDetail + ActionSWeek + (Actiontotal - 1)], lastRow)) });



                            }



                            no++;

                            lastRow++;
                        }

                    }
                }



                #endregion
                #region Footer
                lastRow++;
                cell = openExcelUtil.GetCell(sheetData, "A", (uint)lastRow);
                cell.CellValue = new CellValue("Note :");
                cell.StyleIndex = 5;

                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("A{0}:H{0}", (uint)lastRow)) });

                cell = openExcelUtil.GetCell(sheetData, "I", (uint)lastRow);
                cell.CellValue = new CellValue("Remark :");
                cell.StyleIndex = 5;

                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("I{0}:AJ{0}", (uint)lastRow)) });


                cell = openExcelUtil.GetCell(sheetData, "AK", (uint)lastRow);
                cell.CellValue = new CellValue("Reference Documents :");
                cell.StyleIndex = 5;

                mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("AK{0}:BE{0}", (uint)lastRow)) });



                List<ExportPlanHeader> noteFooter = headerList.Where(a => a.Subject.ToLower() == "note").ToList();
                List<ExportPlanHeader> remarkFooter = headerList.Where(a => a.Subject.ToLower() == "remark").ToList();
                List<ExportPlanHeader> referenceFooter = headerList.Where(a => a.Subject.ToLower() == "reference").ToList();

                lastRow++;
                int noteRow = lastRow;
                if (noteFooter.Count > 0)
                {

                    foreach (ExportPlanHeader note in noteFooter)
                    {
                        cell = openExcelUtil.GetCell(sheetData, "A", (uint)noteRow);
                        cell.CellValue = new CellValue(note.Text);
                        cell.StyleIndex = 5;
                        mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("A{0}:H{0}", (uint)noteRow)) });
                        noteRow++;
                    }
                }

                int remarkRow = lastRow;
                if (remarkFooter != null && remarkFooter.Count > 0)
                {

                    int countRow = 0;
                    foreach (ExportPlanHeader remark in remarkFooter)
                    {
                        if ((countRow) % 2 == 0)
                        {
                            if (countRow > 0)
                            {
                                remarkRow++;

                            }

                            cell = openExcelUtil.GetCell(sheetData, "I", (uint)remarkRow);
                            cell.StyleIndex = (uint)Utility.ConvertToInt(remark.StyleID);



                            cell = openExcelUtil.GetCell(sheetData, "J", (uint)remarkRow);
                            cell.CellValue = new CellValue(remark.Text);
                            cell.StyleIndex = 5;
                            mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("J{0}:U{0}", (uint)remarkRow)) });

                        }
                        else
                        {
                            cell = openExcelUtil.GetCell(sheetData, "V", (uint)remarkRow);
                            cell.StyleIndex = (uint)Utility.ConvertToInt(remark.StyleID);


                            cell = openExcelUtil.GetCell(sheetData, "W", (uint)remarkRow);
                            cell.CellValue = new CellValue(remark.Text);
                            cell.StyleIndex = 5;
                            mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("W{0}:AJ{0}", (uint)remarkRow)) });

                        }
                        countRow++;
                    }
                }

                int refRow = lastRow;
                if (referenceFooter.Count > 0)
                {

                    foreach (ExportPlanHeader reference in referenceFooter)
                    {
                        cell = openExcelUtil.GetCell(sheetData, "AK", (uint)refRow);
                        cell.CellValue = new CellValue(reference.Text);
                        cell.StyleIndex = 5;
                        mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("AK{0}:BE{0}", (uint)refRow)) });
                        refRow++;
                    }
                }



                if (noteRow < rowTotal + noteFooter.Count)
                {
                    while (noteRow < rowTotal + (noteFooter.Count))
                    {
                        mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("A{0}:H{0}", (uint)noteRow)) });
                        noteRow++;
                    }


                }


                remarkRow++;
                if (remarkRow < (rowTotal + (remarkFooter.Count / 2)))
                {
                    while (remarkRow < (rowTotal + (remarkFooter.Count / 2) - 1))
                    {
                        mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("I{0}:AJ{0}", (uint)remarkRow)) });
                        remarkRow++;
                    }


                }

                if (refRow < rowTotal + referenceFooter.Count)
                {
                    while (refRow < rowTotal + (referenceFooter.Count))
                    {
                        mergeCells.Append(new MergeCell() { Reference = new StringValue(string.Format("AK{0}:BE{0}", (uint)refRow)) });
                        refRow++;
                    }


                }




                #endregion


                #region Merge

                mergeCells.Append(new MergeCell() { Reference = new StringValue("A1:B5") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("C1:H1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("C2:H2") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("C3:H3") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("C4:H4") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("C5:H5") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("I1:BD1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("I2:U2") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("I3:U3") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("I4:U4") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("I5:U5") });

                mergeCells.Append(new MergeCell() { Reference = new StringValue("V2:AI2") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("V3:AI3") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("V4:AI4") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("V5:AI5") });

                mergeCells.Append(new MergeCell() { Reference = new StringValue("AJ2:AV2") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AJ3:AV3") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AJ4:AV4") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AJ5:AV5") });

                mergeCells.Append(new MergeCell() { Reference = new StringValue("AW2:BD2") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AW3:BD3") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AW4:BD4") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AW5:BD5") });


                mergeCells.Append(new MergeCell() { Reference = new StringValue("C6:D6") });

                mergeCells.Append(new MergeCell() { Reference = new StringValue("A6:A7") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("B6:B7") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("E6:E7") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("F6:f7") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("G6:G7") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("H6:H7") });
                worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());


                #endregion







                var dataBeforeProtection = worksheetPart.Worksheet.Descendants<Row>().First().Descendants<Cell>().First().CellValue.InnerText;
                worksheetPart.Worksheet.RemoveAllChildren<SheetProtection>();
                var dataAfterProtection = worksheetPart.Worksheet.Descendants<Row>().First().Descendants<Cell>().First().CellValue.InnerText;

                worksheetPart.Worksheet.Save();
            }

            return stream.ToArray();
        }


        #endregion








        public byte[] CreateExcelDoc(string fileName)
        {



            MemoryStream stream = new MemoryStream();
            List<Student> students = new List<Student>();
            Initizalize(students);

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Students" };

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Add drawing part to WorksheetPart
                DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                worksheetPart.Worksheet.Save();

                drawingsPart.WorksheetDrawing = new WorksheetDrawing();

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                // Add a new chart and set the chart language
                ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
                chartPart.ChartSpace = new ChartSpace();
                chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
                Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
                chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title

                // Create a new Clustered Column Chart
                PlotArea plotArea = chart.AppendChild(new PlotArea());
                Layout layout = plotArea.AppendChild(new Layout());

                BarChart barChart = plotArea.AppendChild(new BarChart(
                        new BarDirection() { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                        new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.Clustered) },
                        new VaryColors() { Val = false }
                    ));

                // Constructing header
                Row row = new Row();
                int rowIndex = 1;

                row.AppendChild(openExcelUtil.ConstructCell(string.Empty, CellValues.String));

                foreach (var month in Months.Short)
                {
                    row.AppendChild(openExcelUtil.ConstructCell(month, CellValues.String));
                }

                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);
                rowIndex++;

                // Create chart series
                for (int i = 0; i < students.Count; i++)
                {
                    BarChartSeries barChartSeries = barChart.AppendChild(new BarChartSeries(
                        new Index() { Val = (uint)i },
                        new Order() { Val = (uint)i },
                        new SeriesText(new NumericValue() { Text = students[i].Name })
                    ));

                    // Adding category axis to the chart
                    CategoryAxisData categoryAxisData = barChartSeries.AppendChild(new CategoryAxisData());

                    // Category
                    // Constructing the chart category
                    string formulaCat = "Students!$B$1:$G$1";

                    StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
                    {
                        Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
                    });

                    StringCache stringCache = stringReference.AppendChild(new StringCache());
                    stringCache.Append(new PointCount() { Val = (uint)Months.Short.Length });

                    for (int j = 0; j < Months.Short.Length; j++)
                    {
                        stringCache.AppendChild(new NumericPoint() { Index = (uint)j }).Append(new NumericValue(Months.Short[j]));
                    }
                }

                var chartSeries = barChart.Elements<BarChartSeries>().GetEnumerator();

                for (int i = 0; i < students.Count; i++)
                {
                    row = new Row();

                    row.AppendChild(openExcelUtil.ConstructCell(students[i].Name, CellValues.String));

                    chartSeries.MoveNext();

                    string formulaVal = string.Format("Students!$B${0}:$G${0}", rowIndex);
                    DocumentFormat.OpenXml.Drawing.Charts.Values values = chartSeries.Current.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

                    NumberReference numberReference = values.AppendChild(new NumberReference()
                    {
                        Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
                    });

                    NumberingCache numberingCache = numberReference.AppendChild(new NumberingCache());
                    numberingCache.Append(new PointCount() { Val = (uint)Months.Short.Length });

                    for (uint j = 0; j < students[i].Values.Length; j++)
                    {
                        var value = students[i].Values[j];

                        row.AppendChild(openExcelUtil.ConstructCell(value.ToString(), CellValues.Number));

                        numberingCache.AppendChild(new NumericPoint() { Index = j }).Append(new NumericValue(value.ToString()));
                    }

                    sheetData.AppendChild(row);
                    rowIndex++;
                }

                barChart.AppendChild(new DataLabels(
                                    new ShowLegendKey() { Val = false },
                                    new ShowValue() { Val = false },
                                    new ShowCategoryName() { Val = false },
                                    new ShowSeriesName() { Val = false },
                                    new ShowPercent() { Val = false },
                                    new ShowBubbleSize() { Val = false }
                                ));

                barChart.Append(new AxisId() { Val = 48650112u });
                barChart.Append(new AxisId() { Val = 48672768u });

                // Adding Category Axis
                plotArea.AppendChild(
                    new CategoryAxis(
                        new AxisId() { Val = 48650112u },
                        new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                        new Delete() { Val = false },
                        new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                        new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                        new CrossingAxis() { Val = 48672768u },
                        new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                        new AutoLabeled() { Val = true },
                        new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) }
                    ));

                // Adding Value Axis
                plotArea.AppendChild(
                    new ValueAxis(
                        new AxisId() { Val = 48672768u },
                        new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                        new Delete() { Val = false },
                        new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                        new MajorGridlines(),
                        new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                        {
                            FormatCode = "General",
                            SourceLinked = true
                        },
                        new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                        new CrossingAxis() { Val = 48650112u },
                        new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                        new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }
                    ));

                chart.Append(
                        new PlotVisibleOnly() { Val = true },
                        new DisplayBlanksAs() { Val = new EnumValue<DisplayBlanksAsValues>(DisplayBlanksAsValues.Gap) },
                        new ShowDataLabelsOverMaximum() { Val = false }
                    );

                chartPart.ChartSpace.Save();

                // Positioning the chart on the spreadsheet
                TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

                twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                        new ColumnId("0"),
                        new ColumnOffset("0"),
                        new RowId((rowIndex + 2).ToString()),
                        new RowOffset("0")
                    ));

                twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                        new ColumnId("8"),
                        new ColumnOffset("0"),
                        new RowId((rowIndex + 12).ToString()),
                        new RowOffset("0")
                    ));

                // Append GraphicFrame to TwoCellAnchor
                GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
                graphicFrame.Macro = string.Empty;

                graphicFrame.Append(new NonVisualGraphicFrameProperties(
                        new NonVisualDrawingProperties()
                        {
                            Id = 2u,
                            Name = "Sample Chart"
                        },
                        new NonVisualGraphicFrameDrawingProperties()
                    ));

                graphicFrame.Append(new Transform(
                        new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                        new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                    ));

                graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                        new DocumentFormat.OpenXml.Drawing.GraphicData(
                                new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                            )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                    ));

                twoCellAnchor.Append(new ClientData());

                drawingsPart.WorksheetDrawing.Save();

                worksheetPart.Worksheet.Save();
            }

            return stream.ToArray();
        }


        public byte[] CreatePieChartDoc(string fileName)
        {



            MemoryStream stream = new MemoryStream();
            List<Student> students = new List<Student>();
            Initizalize(students);

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Students" };

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Add drawing part to WorksheetPart
                DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                worksheetPart.Worksheet.Save();

                drawingsPart.WorksheetDrawing = new WorksheetDrawing();

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                // Add a new chart and set the chart language
                ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
                chartPart.ChartSpace = new ChartSpace();
                chartPart.ChartSpace.AppendChild(new EditingLanguage() { Val = "en-US" });
                Chart chart = chartPart.ChartSpace.AppendChild(new Chart());
                chart.AppendChild(new AutoTitleDeleted() { Val = true }); // We don't want to show the chart title

                // Create a new Clustered Column Chart
                PlotArea plotArea = chart.AppendChild(new PlotArea());
                Layout layout = plotArea.AppendChild(new Layout());

                PieChart barChart = plotArea.AppendChild(new PieChart(

                        new BarDirection() { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                        new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.Clustered) },
                        new VaryColors() { Val = false }
                    ));

                // Constructing header
                Row row = new Row();
                int rowIndex = 1;

                row.AppendChild(openExcelUtil.ConstructCell(string.Empty, CellValues.String));

                foreach (var month in Months.Short)
                {
                    row.AppendChild(openExcelUtil.ConstructCell(month, CellValues.String));
                }

                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);
                rowIndex++;

                // Create chart series
                for (int i = 0; i < students.Count; i++)
                {
                    PieChartSeries barChartSeries = barChart.AppendChild(new PieChartSeries(
                        new Index() { Val = (uint)i },
                        new Order() { Val = (uint)i },
                        new SeriesText(new NumericValue() { Text = students[i].Name })
                    ));

                    // Adding category axis to the chart
                    CategoryAxisData categoryAxisData = barChartSeries.AppendChild(new CategoryAxisData());

                    // Category
                    // Constructing the chart category
                    string formulaCat = "Students!$B$1:$G$1";

                    StringReference stringReference = categoryAxisData.AppendChild(new StringReference()
                    {
                        Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaCat }
                    });

                    StringCache stringCache = stringReference.AppendChild(new StringCache());
                    stringCache.Append(new PointCount() { Val = (uint)Months.Short.Length });

                    for (int j = 0; j < Months.Short.Length; j++)
                    {
                        stringCache.AppendChild(new NumericPoint() { Index = (uint)j }).Append(new NumericValue(Months.Short[j]));
                    }
                }

                var chartSeries = barChart.Elements<PieChartSeries>().GetEnumerator();

                for (int i = 0; i < students.Count; i++)
                {
                    row = new Row();

                    row.AppendChild(openExcelUtil.ConstructCell(students[i].Name, CellValues.String));

                    chartSeries.MoveNext();

                    string formulaVal = string.Format("Students!$B${0}:$G${0}", rowIndex);
                    DocumentFormat.OpenXml.Drawing.Charts.Values values = chartSeries.Current.AppendChild(new DocumentFormat.OpenXml.Drawing.Charts.Values());

                    NumberReference numberReference = values.AppendChild(new NumberReference()
                    {
                        Formula = new DocumentFormat.OpenXml.Drawing.Charts.Formula() { Text = formulaVal }
                    });

                    NumberingCache numberingCache = numberReference.AppendChild(new NumberingCache());
                    numberingCache.Append(new PointCount() { Val = (uint)Months.Short.Length });

                    for (uint j = 0; j < students[i].Values.Length; j++)
                    {
                        var value = students[i].Values[j];

                        row.AppendChild(openExcelUtil.ConstructCell(value.ToString(), CellValues.Number));

                        numberingCache.AppendChild(new NumericPoint() { Index = j }).Append(new NumericValue(value.ToString()));
                    }

                    sheetData.AppendChild(row);
                    rowIndex++;
                }

                barChart.AppendChild(new DataLabels(
                                    new ShowLegendKey() { Val = false },
                                    new ShowValue() { Val = false },
                                    new ShowCategoryName() { Val = false },
                                    new ShowSeriesName() { Val = false },
                                    new ShowPercent() { Val = false },
                                    new ShowBubbleSize() { Val = false }
                                ));

                barChart.Append(new AxisId() { Val = 48650112u });
                barChart.Append(new AxisId() { Val = 48672768u });

                // Adding Category Axis
                plotArea.AppendChild(
                    new CategoryAxis(
                        new AxisId() { Val = 48650112u },
                        new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                        new Delete() { Val = false },
                        new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                        new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                        new CrossingAxis() { Val = 48672768u },
                        new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                        new AutoLabeled() { Val = true },
                        new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) }
                    ));

                // Adding Value Axis
                plotArea.AppendChild(
                    new ValueAxis(
                        new AxisId() { Val = 48672768u },
                        new Scaling(new Orientation() { Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax) }),
                        new Delete() { Val = false },
                        new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                        new MajorGridlines(),
                        new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                        {
                            FormatCode = "General",
                            SourceLinked = true
                        },
                        new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                        new CrossingAxis() { Val = 48650112u },
                        new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                        new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }
                    ));

                chart.Append(
                        new PlotVisibleOnly() { Val = true },
                        new DisplayBlanksAs() { Val = new EnumValue<DisplayBlanksAsValues>(DisplayBlanksAsValues.Gap) },
                        new ShowDataLabelsOverMaximum() { Val = false }
                    );

                chartPart.ChartSpace.Save();

                // Positioning the chart on the spreadsheet
                TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild(new TwoCellAnchor());

                twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(
                        new ColumnId("0"),
                        new ColumnOffset("0"),
                        new RowId((rowIndex + 2).ToString()),
                        new RowOffset("0")
                    ));

                twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(
                        new ColumnId("8"),
                        new ColumnOffset("0"),
                        new RowId((rowIndex + 12).ToString()),
                        new RowOffset("0")
                    ));

                // Append GraphicFrame to TwoCellAnchor
                GraphicFrame graphicFrame = twoCellAnchor.AppendChild(new GraphicFrame());
                graphicFrame.Macro = string.Empty;

                graphicFrame.Append(new NonVisualGraphicFrameProperties(
                        new NonVisualDrawingProperties()
                        {
                            Id = 2u,
                            Name = "Sample Chart"
                        },
                        new NonVisualGraphicFrameDrawingProperties()
                    ));

                graphicFrame.Append(new Transform(
                        new DocumentFormat.OpenXml.Drawing.Offset() { X = 0L, Y = 0L },
                        new DocumentFormat.OpenXml.Drawing.Extents() { Cx = 0L, Cy = 0L }
                    ));

                graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Graphic(
                        new DocumentFormat.OpenXml.Drawing.GraphicData(
                                new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) }
                            )
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                    ));

                twoCellAnchor.Append(new ClientData());

                drawingsPart.WorksheetDrawing.Save();

                worksheetPart.Worksheet.Save();
            }

            return stream.ToArray();
        }


        private void Initizalize(List<Student> students)
        {
            students.AddRange(new Student[] {
                new Student
                {
                    Name = "Liza",
                    Values = new byte[] { 10, 25, 30, 15, 20, 19 }
                },
                new Student
                {
                    Name = "Macy",
                    Values = new byte[] { 20, 15, 26, 30, 10, 15 }
                }
            });
        }




    }
}


