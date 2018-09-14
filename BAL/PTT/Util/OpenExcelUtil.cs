using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace BAL.PTT.Util
{


    public class OpenExcelUtil
    {


        public Column CreateColumnData(UInt32 StartColumnIndex, UInt32 EndColumnIndex, double ColumnWidth)
        {
            Column column;
            column = new Column();
            column.Min = StartColumnIndex;
            column.Max = EndColumnIndex;
            column.Width = ColumnWidth;
            column.CustomWidth = true;
            return column;
        }


        public Cell GetCell(SheetData sheetData, string columnName, uint rowIndex)
        {
            Row row = GetRow(sheetData, rowIndex);

            if (row == null)
                return null;

            return row.Elements<Cell>().Where(c => string.Compare
                      (c.CellReference.Value, columnName +
                      rowIndex, true) == 0).First();
        }

        // Given a worksheet and a row index, return the row.
        public Row GetRow(SheetData sheetData, uint rowIndex)
        {
            return sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }


        public void AddBold(SpreadsheetDocument document, Cell c)
        {
            Fonts fs = AddFont(document.WorkbookPart.WorkbookStylesPart.Stylesheet.Fonts);
            AddCellFormat(document.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats, document.WorkbookPart.WorkbookStylesPart.Stylesheet.Fonts);
            c.StyleIndex = (UInt32)(document.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats.Elements<CellFormat>().Count() - 1);


        }

        public Fonts AddFont(Fonts fs)
        {
            Font font2 = new Font();
            Bold bold1 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = 11D };
            Color color2 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName2 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering2 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme2 = new FontScheme() { Val = FontSchemeValues.Minor };

            font2.Append(bold1);
            font2.Append(fontSize2);
            font2.Append(color2);
            font2.Append(fontName2);
            font2.Append(fontFamilyNumbering2);
            font2.Append(fontScheme2);

            fs.Append(font2);
            return fs;


        }
        public uint InsertBorder(WorkbookPart workbookPart, Border border)
        {
            Borders borders = workbookPart.WorkbookStylesPart.Stylesheet.Elements<Borders>().First();
            borders.Append(border);
            return (uint)borders.Count++;
        }
        public void AddCellFormat(CellFormats cf, Fonts fs)
        {
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = 0, FontId = (UInt32)(fs.Elements<Font>().Count() - 1), FillId = 0, BorderId = 0, FormatId = 0, ApplyFill = true };
            cf.Append(cellFormat2);
        }
        public void AddbackgroundFormat(SpreadsheetDocument document, Cell c)
        {
            Fills fs = AddFill(document.WorkbookPart.WorkbookStylesPart.Stylesheet.Fills);
            AddCellFormat(document.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats, document.WorkbookPart.WorkbookStylesPart.Stylesheet.Fills);
            c.StyleIndex = (UInt32)(document.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats.Elements<CellFormat>().Count() - 1);
        }
        public Fills AddFill(Fills fills1)
        {
            Fill fill1 = new Fill();

            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor1 = new ForegroundColor() { Rgb = "FFFFFF00" };
            BackgroundColor backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };

            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);

            fill1.Append(patternFill1);
            fills1.Append(fill1);
            return fills1;
        }
        public void AddCellFormat(CellFormats cf, Fills fs)
        {
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = 0, FontId = 0, FillId = (UInt32)(fs.Elements<Fill>().Count() - 1), BorderId = 0, FormatId = 0, ApplyFill = true };
            cf.Append(cellFormat2);
        }
        public Cell ConstructCell(string value, CellValues dataType, uint styleIndex = 0)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType),

                StyleIndex = styleIndex
            };
        }

        public Borders GenerateBorder()
        {
            Borders borders = new Borders(
        new Border(), // index 0 default
        new Border( // index 1 black border
            new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
            new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
            new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
            new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
            new DiagonalBorder())
    );

            return borders;
        }

        public Fonts generateFonts()
        {
            Fonts fonts = new Fonts(
                new Font( // Index 0 - Default
                    new FontSize() { Val = 10 }
                ),
                new Font( // Index 1 - Bold
                    new FontSize() { Val = 10 },
                    new Bold()
                ),
                new Font( // Index 2 - Italic
                    new FontSize() { Val = 10 },
                    new Italic()
                ),
                new Font( // Index 3 - Big
                    new FontSize() { Val = 12 }
                ),
                new Font( // Index 4 - Big bold
                    new FontSize() { Val = 10 },
                    new Bold()
                ),
                new Font( // Index 5 - Big italic
                    new FontSize() { Val = 10 },
                    new Italic()
                ),
                new Font( // Index 6 - Blue
                    new FontSize() { Val = 10 },
                    new Color() { Rgb = "FF0070C0" }
                ),
                new Font( // Index 7 - Blue Bold
                    new FontSize() { Val = 10 },
                    new Bold(),
                    new Color() { Rgb = "FF0070C0" }
                )
            );
            return fonts;
        }
        public Fills generateFills()
        {
            Fills fills = new Fills(
                new Fill( // Index 0 - Default
                    new PatternFill() { PatternType = PatternValues.None }
                ),
                new Fill( // Index 1 - Solid White
                    new PatternFill(
                        new ForegroundColor() { Rgb = "00000000" },
                        new BackgroundColor() { Indexed = (UInt32Value)64U }
                    )
                    { PatternType = PatternValues.Solid }
                ),
                new Fill( // Index 2 - Solid Blue
                    new PatternFill(
                        new ForegroundColor() { Rgb = "FF0070C0" },
                        new BackgroundColor() { Indexed = (UInt32Value)64U }
                    )
                    { PatternType = PatternValues.Solid }
                ),
                new Fill( // Index 3 - Solid Yellow
                    new PatternFill(
                        new ForegroundColor() { Rgb = "FFFFFF00" },
                        new BackgroundColor() { Indexed = (UInt32Value)64U }
                    )
                    { PatternType = PatternValues.Solid }
                ),
                new Fill( // Index 4 - Solid Red
                    new PatternFill(
                        new ForegroundColor() { Rgb = "FFFF0000" },
                        new BackgroundColor() { Indexed = (UInt32Value)64U }
                    )
                    { PatternType = PatternValues.Solid }
                ),
                new Fill( // Index 5 - Solid Green 
                    new PatternFill(
                        new ForegroundColor() { Rgb = "FF28a745" },
                        new BackgroundColor() { Indexed = (UInt32Value)64U }
                    )
                    { PatternType = PatternValues.Solid }
                ),
                new Fill( // Index 6 - Solid Green light
                    new PatternFill(
                        new ForegroundColor() { Rgb = "FF20c997" },
                        new BackgroundColor() { Indexed = (UInt32Value)64U }
                    )
                    { PatternType = PatternValues.Solid }
                )
            );
            return fills;
        }
        public Borders generateBorders()
        {
            Borders borders = new Borders(
                new Border(), // index 0 default
                new Border(   // index 1 black border
                    new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                    new DiagonalBorder()
                )
            );
            return borders;
        }

        public Stylesheet generateSummayColpletelyStylesheet()
        {
            Stylesheet stylesheet = new Stylesheet();
            stylesheet.AppendChild(generateFonts());
            stylesheet.AppendChild(generateFills());
            stylesheet.AppendChild(generateBorders());

            stylesheet.NumberingFormats = new NumberingFormats();
            DocumentFormat.OpenXml.Spreadsheet.NumberingFormat nf2decimal = new DocumentFormat.OpenXml.Spreadsheet.NumberingFormat();
            nf2decimal.NumberFormatId = UInt32Value.FromUInt32(3453);
            nf2decimal.FormatCode = StringValue.FromString("0%");

            stylesheet.NumberingFormats.AppendChild(nf2decimal);

            CellFormats cellFormats = new CellFormats(
            #region CellFormats
                new CellFormat()                    // 0 default
                {
                    FontId = 0,     //Defalut
                    FillId = 0,     //Defalut
                    BorderId = 0,   //Defalut
                    ApplyBorder = false,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 1 Normal
                {
                    FontId = 0,     //Defalut
                    FillId = 0,     //Defalut
                    BorderId = 1,   //Black border
                    NumberFormatId = nf2decimal.NumberFormatId,
                    ApplyNumberFormat = BooleanValue.FromBoolean(true),
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 2 Blue
                {
                    FontId = 4,     //Big bold
                    FillId = 2,     //Solid Blue
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 3 Yellow
                {
                    FontId = 4,     //Big bold
                    FillId = 3,     //Solid Yellow
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 4 Red
                {
                    FontId = 4,     //Big bold
                    FillId = 4,     //Solid Red
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                }
                #endregion
            );

            stylesheet.AppendChild(cellFormats);
            return stylesheet;
        }
        public Stylesheet generateSummayPlanRiskStylesheet()
        {
            CellFormats cellFormats = new CellFormats(
            #region CellFormats
                new CellFormat()                    // 0 default
                {
                    FontId = 0,     //Defalut
                    FillId = 0,     //Defalut
                    BorderId = 0,   //Defalut
                    ApplyBorder = false,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 1 Normal
                {
                    FontId = 0,     //Defalut
                    FillId = 0,     //Defalut
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 2 Blue
                {
                    FontId = 4,     //Big bold
                    FillId = 2,     //Solid Blue
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 3 Yellow
                {
                    FontId = 4,     //Big bold
                    FillId = 3,     //Solid Yellow
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 4 Red
                {
                    FontId = 4,     //Big bold
                    FillId = 4,     //Solid Red
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                }
                #endregion
            );
            return new Stylesheet(generateFonts(), generateFills(), generateBorders(), cellFormats);
        }
        public Stylesheet generateSummaryRiskStylesheet()
        {
            CellFormats cellFormats = new CellFormats(
            #region CellFormats
                new CellFormat()                    // 0 default
                {
                    FontId = 0,     //Defalut
                    FillId = 0,     //Defalut
                    BorderId = 0,   //Defalut
                    ApplyBorder = false,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 1 Normal
                {
                    FontId = 0,     //Defalut
                    FillId = 0,     //Defalut
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 2 Blue
                {
                    FontId = 4,     //Big bold
                    FillId = 2,     //Solid Blue
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Center,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 3 Green
                {
                    FontId = 4,     //Big bold
                    FillId = 5,     //Solid Yellow
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Left,
                        WrapText = true
                    }
                },
                new CellFormat()                    // 4 Green light
                {
                    FontId = 4,     //Big bold
                    FillId = 6,     //Solid Red
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Left,
                        WrapText = true
                    }
                }, new CellFormat()                    // 5 Normal right
                {
                    FontId = 0,     //Defalut
                    FillId = 0,     //Defalut
                    BorderId = 1,   //Black border
                    ApplyBorder = true,
                    Alignment = new Alignment()
                    {
                        Vertical = VerticalAlignmentValues.Center,
                        Horizontal = HorizontalAlignmentValues.Right,
                        WrapText = true
                    }
                }
                #endregion
            );
            return new Stylesheet(generateFonts(), generateFills(), generateBorders(), cellFormats);
        }

        public Stylesheet GenerateStylesheet()
        {
            Stylesheet styleSheet = null;

            Fonts fonts = new Fonts(
                new Font( // Index 0 - default
                    new FontSize() { Val = 10 }

                ),
                new Font( // Index 1 - subheader
                    new FontSize() { Val = 12 },
                    new Bold(),
                    new Color() { Rgb = "000000" }

                ),
                 new Font( // Index 3 - HeaderTable
                    new FontSize() { Val = 10 },
                    new Bold(),
                    new Color() { Rgb = "000000" }

                ),

                new Font( // Index 4 - header
                    new FontSize() { Val = 14 },
                    new Bold(),
                    new Color() { Rgb = "000000" }

                ));



            // FillId = 0
            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };
            fill1.Append(patternFill1);

            // FillId = 1
            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };
            fill2.Append(patternFill2);

            // FillId = 2,RED
            Fill fill3 = new Fill();
            PatternFill patternFill3 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor1 = new ForegroundColor() { Rgb = "FFFF0000" };
            BackgroundColor backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill3.Append(foregroundColor1);
            patternFill3.Append(backgroundColor1);
            fill3.Append(patternFill3);

            // FillId = 3,BLUE
            Fill fill4 = new Fill();
            PatternFill patternFill4 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor2 = new ForegroundColor() { Rgb = "FF0070C0" };
            BackgroundColor backgroundColor2 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill4.Append(foregroundColor2);
            patternFill4.Append(backgroundColor2);
            fill4.Append(patternFill4);

            // FillId = 4,YELLO
            Fill fill5 = new Fill();
            PatternFill patternFill5 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor3 = new ForegroundColor() { Rgb = "FFFFFF99" };
            BackgroundColor backgroundColor3 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill5.Append(foregroundColor3);
            patternFill5.Append(backgroundColor3);
            fill5.Append(patternFill5);


            // FillId = 5,YELLO low
            Fill fill6 = new Fill();
            PatternFill patternFill6 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor4 = new ForegroundColor() { Rgb = "FFFAF9D5" };
            BackgroundColor backgroundColor4 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill6.Append(foregroundColor4);
            patternFill6.Append(backgroundColor4);
            fill6.Append(patternFill6);



            Fills fills = new Fills();
            fills.Append(fill1);
            fills.Append(fill2);
            fills.Append(fill3);
            fills.Append(fill4);
            fills.Append(fill5);
            fills.Append(fill6);



            // FillId = 6,Plan-Spec
            Fill fill7 = new Fill();
            patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            foregroundColor1 = new ForegroundColor() { Rgb = "FF7AC0EC" };
            backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill7.Append(patternFill1);
            fills.Append(fill7);


            // FillId = 7,Plan-PO
            fill7 = new Fill();
            patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            foregroundColor1 = new ForegroundColor() { Rgb = "FF55B4F0" };
            backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill7.Append(patternFill1);
            fills.Append(fill7);


            // FillId = 8,Plan-Action
            fill7 = new Fill();
            patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            foregroundColor1 = new ForegroundColor() { Rgb = "FF329FE4" };
            backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill7.Append(patternFill1);
            fills.Append(fill7);


            // FillId = 9,Actual-Spec
            fill7 = new Fill();
            patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            foregroundColor1 = new ForegroundColor() { Rgb = "FF72E181" };
            backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill7.Append(patternFill1);
            fills.Append(fill7);

            // FillId = 10,Actual-PO
            fill7 = new Fill();
            patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            foregroundColor1 = new ForegroundColor() { Rgb = "FF4FDB62" };
            backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill7.Append(patternFill1);
            fills.Append(fill7);

            // FillId = 11,Actual-Action
            fill7 = new Fill();
            patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            foregroundColor1 = new ForegroundColor() { Rgb = "FF26C83D" };
            backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill7.Append(patternFill1);
            fills.Append(fill7);


            // FillId = 12,Shift from previos
            fill7 = new Fill();
            patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            foregroundColor1 = new ForegroundColor() { Rgb = "FFF48989" };
            backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill7.Append(patternFill1);
            fills.Append(fill7);


            // FillId = 13,Shift to next year
            fill7 = new Fill();
            patternFill1 = new PatternFill() { PatternType = PatternValues.Solid };
            foregroundColor1 = new ForegroundColor() { Rgb = "FFF02E2E" };
            backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };
            patternFill1.Append(foregroundColor1);
            patternFill1.Append(backgroundColor1);
            fill7.Append(patternFill1);
            fills.Append(fill7);






            Borders borders = new Borders(
                    new Border(), // index 0 default
                    new Border( // index 1 black border
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder()),
                    new Border( // index 2 black border
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                );


            CellFormats cellFormats = new CellFormats(
                    new CellFormat(), // 0 default
                    new CellFormat
                    {
                        FontId = 0,
                        FillId = 0,
                        BorderId = 1,
                        ApplyBorder = true,
                        Alignment = new Alignment()
                        {
                            Vertical = VerticalAlignmentValues.Center,
                            Horizontal = HorizontalAlignmentValues.Center,
                            WrapText = true
                        }
                    }, // 1 body
                    new CellFormat
                    {
                        FontId = 3,
                        FillId = 0,
                        BorderId = 1,
                        ApplyFill = true,
                        Alignment = new Alignment()
                        {
                            Vertical = VerticalAlignmentValues.Center,
                            Horizontal = HorizontalAlignmentValues.Center,
                            WrapText = true
                        }
                    },// 2 header
                       new CellFormat
                       {
                           FontId = 1,
                           FillId = 0,
                           BorderId = 1,
                           ApplyFill = true,
                           Alignment = new Alignment()
                           {
                               Vertical = VerticalAlignmentValues.Center,
                               Horizontal = HorizontalAlignmentValues.Center,
                               WrapText = true
                           }
                       }
                       ,// 3 sub header
                                              new CellFormat
                                              {
                                                  FontId = 2,
                                                  FillId = 4,
                                                  BorderId = 1,
                                                  ApplyFill = true,
                                                  Alignment = new Alignment()
                                                  {
                                                      Vertical = VerticalAlignmentValues.Center,
                                                      Horizontal = HorizontalAlignmentValues.Center,
                                                      WrapText = true
                                                  }
                                              } //4 Table Header
                     , new CellFormat
                     {
                         FontId = 0,
                         FillId = 0,
                         BorderId = 1,
                         ApplyBorder = true,
                         Alignment = new Alignment()
                         {
                             Vertical = VerticalAlignmentValues.Center,
                             Horizontal = HorizontalAlignmentValues.Left,
                             WrapText = true
                         }
                     },//5 keep left
                      new CellFormat
                      {
                          FontId = 0,
                          FillId = 0,
                          BorderId = 1,
                          ApplyBorder = true,
                          Alignment = new Alignment()
                          {
                              Vertical = VerticalAlignmentValues.Center,
                              Horizontal = HorizontalAlignmentValues.Right,
                              WrapText = true
                          }
                      }// 6 keep right
                       ,
                                              new CellFormat
                                              {
                                                  FontId = 2,
                                                  FillId = 5,
                                                  BorderId = 1,
                                                  ApplyFill = true,
                                                  Alignment = new Alignment()
                                                  {
                                                      Vertical = VerticalAlignmentValues.Center,
                                                      Horizontal = HorizontalAlignmentValues.Left,
                                                      WrapText = true
                                                  }
                                              }// 7 sub table pipeline

                              , new CellFormat
                              {
                                  FontId = 0,
                                  FillId = 6,
                                  BorderId = 1,
                                  ApplyFill = true,
                                  Alignment = new Alignment()
                                  {
                                      Vertical = VerticalAlignmentValues.Center,
                                      Horizontal = HorizontalAlignmentValues.Center,
                                      WrapText = true
                                  }
                              }// 8 Plan-Spec
                                , new CellFormat
                                {
                                    FontId = 0,
                                    FillId = 7,
                                    BorderId = 1,
                                    ApplyFill = true,
                                    Alignment = new Alignment()
                                    {
                                        Vertical = VerticalAlignmentValues.Center,
                                        Horizontal = HorizontalAlignmentValues.Center,
                                        WrapText = true
                                    }
                                }// 9 Plan-PO

                                  , new CellFormat
                                  {
                                      FontId = 0,
                                      FillId = 8,
                                      BorderId = 1,
                                      ApplyFill = true,
                                      Alignment = new Alignment()
                                      {
                                          Vertical = VerticalAlignmentValues.Center,
                                          Horizontal = HorizontalAlignmentValues.Center,
                                          WrapText = true
                                      }
                                  }// 10 Plan-Action


                                   , new CellFormat
                                   {
                                       FontId = 0,
                                       FillId = 9,
                                       BorderId = 1,
                                       ApplyFill = true,
                                       Alignment = new Alignment()
                                       {
                                           Vertical = VerticalAlignmentValues.Center,
                                           Horizontal = HorizontalAlignmentValues.Center,
                                           WrapText = true
                                       }
                                   }// 11 Actual-Spec
                                , new CellFormat
                                {
                                    FontId = 0,
                                    FillId = 10,
                                    BorderId = 1,
                                    ApplyFill = true,
                                    Alignment = new Alignment()
                                    {
                                        Vertical = VerticalAlignmentValues.Center,
                                        Horizontal = HorizontalAlignmentValues.Center,
                                        WrapText = true
                                    }
                                }// 12 Actual-PO

                                  , new CellFormat
                                  {
                                      FontId = 0,
                                      FillId = 11,
                                      BorderId = 1,
                                      ApplyFill = true,
                                      Alignment = new Alignment()
                                      {
                                          Vertical = VerticalAlignmentValues.Center,
                                          Horizontal = HorizontalAlignmentValues.Center,
                                          WrapText = true
                                      }
                                  }// 13 Actual-Action
                                   , new CellFormat
                                   {
                                       FontId = 0,
                                       FillId = 12,
                                       BorderId = 1,
                                       ApplyFill = true,
                                       Alignment = new Alignment()
                                       {
                                           Vertical = VerticalAlignmentValues.Center,
                                           Horizontal = HorizontalAlignmentValues.Center,
                                           WrapText = true
                                       }
                                   } // 14 Shift from previos

                                    , new CellFormat
                                    {
                                        FontId = 0,
                                        FillId = 13,
                                        BorderId = 1,
                                        ApplyFill = true,
                                        Alignment = new Alignment()
                                        {
                                            Vertical = VerticalAlignmentValues.Center,
                                            Horizontal = HorizontalAlignmentValues.Center,
                                            WrapText = true
                                        }
                                    } // 15  Shift to next year






                );

            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);

            return styleSheet;
        }

        private Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType),
            };
        }

    }



    public class CustomStylesheet : Stylesheet
    {
        public CustomStylesheet()
        {
            var fonts = new Fonts();
            var font = new DocumentFormat.OpenXml.Spreadsheet.Font();
            var fontName = new FontName { Val = StringValue.FromString("Arial") };
            var fontSize = new FontSize { Val = DoubleValue.FromDouble(11) };
            font.FontName = fontName;
            font.FontSize = fontSize;
            fonts.Append(font);
            //Font Index 1
            font = new DocumentFormat.OpenXml.Spreadsheet.Font();
            fontName = new FontName { Val = StringValue.FromString("Arial") };
            fontSize = new FontSize { Val = DoubleValue.FromDouble(12) };
            font.FontName = fontName;
            font.FontSize = fontSize;
            font.Bold = new Bold();
            fonts.Append(font);
            fonts.Count = UInt32Value.FromUInt32((uint)fonts.ChildElements.Count);
            var fills = new Fills();
            var fill = new Fill();
            var patternFill = new PatternFill { PatternType = PatternValues.None };
            fill.PatternFill = patternFill;
            fills.Append(fill);
            fill = new Fill();
            patternFill = new PatternFill { PatternType = PatternValues.Gray125 };
            fill.PatternFill = patternFill;
            fills.Append(fill);
            //Fill index  2
            fill = new Fill();
            patternFill = new PatternFill
            {
                PatternType = PatternValues.Solid,
                ForegroundColor = new ForegroundColor()
            };
            patternFill.ForegroundColor =
               TranslateForeground(System.Drawing.Color.LightBlue);
            patternFill.BackgroundColor =
                new BackgroundColor { Rgb = patternFill.ForegroundColor.Rgb };
            fill.PatternFill = patternFill;
            fills.Append(fill);
            //Fill index  3
            fill = new Fill();
            patternFill = new PatternFill
            {
                PatternType = PatternValues.Solid,
                ForegroundColor = new ForegroundColor()
            };
            patternFill.ForegroundColor =
               TranslateForeground(System.Drawing.Color.DodgerBlue);
            patternFill.BackgroundColor =
               new BackgroundColor { Rgb = patternFill.ForegroundColor.Rgb };
            fill.PatternFill = patternFill;
            fills.Append(fill);
            fills.Count = UInt32Value.FromUInt32((uint)fills.ChildElements.Count);
            var borders = new Borders();
            var border = new Border
            {
                LeftBorder = new LeftBorder(),
                RightBorder = new RightBorder(),
                TopBorder = new TopBorder(),
                BottomBorder = new BottomBorder(),
                DiagonalBorder = new DiagonalBorder()
            };
            borders.Append(border);
            //All Boarder Index 1
            border = new Border
            {
                LeftBorder = new LeftBorder { Style = BorderStyleValues.Thin },
                RightBorder = new RightBorder { Style = BorderStyleValues.Thin },
                TopBorder = new TopBorder { Style = BorderStyleValues.Thin },
                BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin },
                DiagonalBorder = new DiagonalBorder()
            };
            borders.Append(border);
            //Top and Bottom Boarder Index 2
            border = new Border
            {
                LeftBorder = new LeftBorder(),
                RightBorder = new RightBorder(),
                TopBorder = new TopBorder { Style = BorderStyleValues.Thin },
                BottomBorder = new BottomBorder { Style = BorderStyleValues.Thin },
                DiagonalBorder = new DiagonalBorder()
            };
            borders.Append(border);
            borders.Count = UInt32Value.FromUInt32((uint)borders.ChildElements.Count);
            var cellStyleFormats = new CellStyleFormats();
            var cellFormat = new CellFormat
            {
                NumberFormatId = 0,
                FontId = 0,
                FillId = 0,
                BorderId = 0
            };
            cellStyleFormats.Append(cellFormat);
            cellStyleFormats.Count =
               UInt32Value.FromUInt32((uint)cellStyleFormats.ChildElements.Count);
            uint iExcelIndex = 164;
            var numberingFormats = new NumberingFormats();
            var cellFormats = new CellFormats();
            cellFormat = new CellFormat
            {
                NumberFormatId = 0,
                FontId = 0,
                FillId = 0,
                BorderId = 0,
                FormatId = 0
            };
            cellFormats.Append(cellFormat);
            var nformatDateTime = new DocumentFormat.OpenXml.Spreadsheet.NumberingFormat
            {
                NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++),
                FormatCode = StringValue.FromString("dd/mm/yyyy hh:mm:ss")
            };
            numberingFormats.Append(nformatDateTime);
            var nformat4Decimal = new DocumentFormat.OpenXml.Spreadsheet.NumberingFormat
            {
                NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++),
                FormatCode = StringValue.FromString("#,##0.0000")
            };
            numberingFormats.Append(nformat4Decimal);
            var nformat2Decimal = new DocumentFormat.OpenXml.Spreadsheet.NumberingFormat
            {
                NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++),
                FormatCode = StringValue.FromString("#,##0.00")
            };
            numberingFormats.Append(nformat2Decimal);
            var nformatForcedText = new DocumentFormat.OpenXml.Spreadsheet.NumberingFormat
            {
                NumberFormatId = UInt32Value.FromUInt32(iExcelIndex),
                FormatCode = StringValue.FromString("@")
            };
            numberingFormats.Append(nformatForcedText);
            // index 1
            // Cell Standard Date format 
            cellFormat = new CellFormat
            {
                NumberFormatId = 14,
                FontId = 0,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 2
            // Cell Standard Number format with 2 decimal placing
            cellFormat = new CellFormat
            {
                NumberFormatId = 4,
                FontId = 0,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 3
            // Cell Date time custom format
            cellFormat = new CellFormat
            {
                NumberFormatId = nformatDateTime.NumberFormatId,
                FontId = 0,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 4
            // Cell 4 decimal custom format
            cellFormat = new CellFormat
            {
                NumberFormatId = nformat4Decimal.NumberFormatId,
                FontId = 0,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 5
            // Cell 2 decimal custom format
            cellFormat = new CellFormat
            {
                NumberFormatId = nformat2Decimal.NumberFormatId,
                FontId = 0,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 6
            // Cell forced number text custom format
            cellFormat = new CellFormat
            {
                NumberFormatId = nformatForcedText.NumberFormatId,
                FontId = 0,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 7
            // Cell text with font 12 
            cellFormat = new CellFormat
            {
                NumberFormatId = nformatForcedText.NumberFormatId,
                FontId = 1,
                FillId = 0,
                BorderId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 8
            // Cell text
            cellFormat = new CellFormat
            {
                NumberFormatId = nformatForcedText.NumberFormatId,
                FontId = 0,
                FillId = 0,
                BorderId = 1,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 9
            // Coloured 2 decimal cell text
            cellFormat = new CellFormat
            {
                NumberFormatId = nformat2Decimal.NumberFormatId,
                FontId = 0,
                FillId = 2,
                BorderId = 2,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 10
            // Coloured cell text
            cellFormat = new CellFormat
            {
                NumberFormatId = nformatForcedText.NumberFormatId,
                FontId = 0,
                FillId = 2,
                BorderId = 2,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            // Index 11
            // Coloured cell text
            cellFormat = new CellFormat
            {
                NumberFormatId = nformatForcedText.NumberFormatId,
                FontId = 1,
                FillId = 3,
                BorderId = 2,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true)
            };
            cellFormats.Append(cellFormat);
            numberingFormats.Count =
              UInt32Value.FromUInt32((uint)numberingFormats.ChildElements.Count);
            cellFormats.Count = UInt32Value.FromUInt32((uint)cellFormats.ChildElements.Count);
            this.Append(numberingFormats);
            this.Append(fonts);
            this.Append(fills);
            this.Append(borders);
            this.Append(cellStyleFormats);
            this.Append(cellFormats);
            var css = new CellStyles();
            var cs = new CellStyle
            {
                Name = StringValue.FromString("Normal"),
                FormatId = 0,
                BuiltinId = 0
            };
            css.Append(cs);
            css.Count = UInt32Value.FromUInt32((uint)css.ChildElements.Count);
            this.Append(css);
            var dfs = new DifferentialFormats { Count = 0 };
            this.Append(dfs);
            var tss = new TableStyles
            {
                Count = 0,
                DefaultTableStyle = StringValue.FromString("TableStyleMedium9"),
                DefaultPivotStyle = StringValue.FromString("PivotStyleLight16")
            };
            this.Append(tss);
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
    }
}
