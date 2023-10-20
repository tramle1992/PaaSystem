using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace Common.Infrastructure.Office
{
    public class WordMLService
    {
        //public WordMLService()
        //{
        //}

        public static string GetStringRowPerPage(string strStringCount, int RowLength, int PageRow, int PageRowSecond, int PageIndex)
        {
            string currString = "";
            int countRow = 0;
            string[] newLineArray = { Environment.NewLine, "\n" };
            string[] textArray = strStringCount.Split(newLineArray, StringSplitOptions.None);
            int startIndex=0;
            int endIndex=0;
            int PageNumber = 1;

            foreach (string line in textArray)
            {
                if (line.Length <= RowLength)
                {
                    countRow += 1;
                    if (currString == "")
                        currString = line;
                    else currString += "\n" + line;
                    if (countRow == PageRow)
                    {
                        if (PageIndex == PageNumber) return currString;
                        else currString = "";
                        PageNumber += 1;
                        PageRow = PageRowSecond;
                        countRow = 0;
                    }
                }
                else
                {
                    startIndex=0;
                    endIndex=0;
                    //countRow += (line.Length / RowLenght) + 1;
                    for (int j = 1; j <= (line.Length / RowLength) + 1; j++)
                    {
                        countRow += 1;
                        if ((line.Length - startIndex) <= (RowLength)) endIndex = line.Length - startIndex;
                        else endIndex = RowLength;//line.Length - (line.Length - (RowLength * j));
                        if(startIndex == 0)
                        {
                            currString += "\n";
                        }
                        currString += line.Substring(startIndex, endIndex);
                        startIndex += endIndex;

                        if (countRow == PageRow)
                        {
                            if (startIndex < line.Length)
                            {
                                string[] strString = currString.Split(' ');

                                startIndex -= strString.Last().Length;

                                strString = strString.Take(strString.Count() - 1).ToArray();

                                currString = string.Join(" ", strString);
                            }
                            if (PageIndex == PageNumber) return currString;
                            else currString = "";
                            PageNumber += 1;
                            PageRow = PageRowSecond;
                            countRow = 0;
                        }
                    }
                }

                if ((countRow == PageRow) && (PageIndex == PageNumber))
                {
                    return currString;
                }
                //else if (PageIndex > PageNumber) currString = "";
            }                     

            return currString;
        }

        public static int PageCount(string strStringCount, int RowLength, int FirstPageRow, int SecondPageRow)
        {
            int PageNumber = 1;
            int countRow=0;
            string[] newLineArray = { Environment.NewLine, "\n" };
            string[] textArray = strStringCount.Split(newLineArray, StringSplitOptions.None);
            
            foreach (string line in textArray)
            {
                if (line.Length <= RowLength) countRow += 1;
                else countRow += (line.Length / RowLength) + 1;
            }
            if (countRow <= FirstPageRow) PageNumber = 1;
            else if ((countRow > FirstPageRow) && ((countRow - FirstPageRow) <= SecondPageRow)) PageNumber = 2;
            else PageNumber = ((countRow - FirstPageRow) / SecondPageRow) + 2;

            return PageNumber;
        }

        public static void RemoveAllSdtBlock(MainDocumentPart mainPart,bool bKeepParagraph)
        {
            //IEnumerable<SdtBlock> tagFields = mainPart.Document.Body.Descendants<SdtBlock>();
            List<SdtBlock> tagFields = mainPart.Document.Descendants<SdtBlock>().ToList();
            foreach (var field in tagFields)
            {
                if (bKeepParagraph)
                {
                    //grab the RunProperties from the SdtBlcok
                    RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();

                    //create a new paragraph containing a run and a text element
                    Paragraph newParagraph = new Paragraph();
                    Run newRun = new Run();
                    if (runProp != null)
                    {
                        //assign the RunProperties to our new run
                        newRun.Append(runProp.CloneNode(true));
                    }
                    Text newText = new Text("");
                    newRun.Append(newText);
                    newParagraph.Append(newRun);
                    //insert the new paragraph before the field we're going to remove
                    field.Parent.InsertBefore(newParagraph, field);
                }
                field.Remove();
            }
        }

        public static void SetTablePositionYSdtRunByName(MainDocumentPart mainPart, string Name, int Value)
        {
            IEnumerable<SdtRun> tagFields = mainPart.Document.Body.Descendants<SdtRun>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                //TablePositionProperties tblPos = (TablePositionProperties)field.Parent.Parent.Parent.Parent.FirstChild.Descendants<TablePositionProperties>();
                TablePositionProperties tblPos = new TablePositionProperties() { VerticalAnchor = VerticalAnchorValues.Text, TablePositionY = Value };
                if (tblPos != null)
                {
                    tblPos.TablePositionY = Value;
                    TableOverlap overlap2 = new TableOverlap() { Val = TableOverlapValues.Overlap };
                    //field.Parent.Parent.Parent.Parent.FirstChild.Remove();
                    field.Parent.Parent.Parent.Parent.FirstChild.Append(tblPos, overlap2);
                }
            }
        }

        public static void SetTablePositionYSdtContentCellByName(MainDocumentPart mainPart, string Name, int PosYValue, int HeightValue)
        {
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                TablePositionProperties tblPos = (TablePositionProperties)field.Parent.Parent.FirstChild.FirstChild;
                if (tblPos != null)
                {
                    TablePositionProperties newTblPos = (TablePositionProperties)tblPos.CloneNode(true);
                    newTblPos.TablePositionY = PosYValue;
                    TableOverlap overlap2 = new TableOverlap() { Val = TableOverlapValues.Overlap };
                    field.Parent.Parent.FirstChild.InsertAfter(overlap2.CloneNode(true), tblPos);
                    field.Parent.Parent.FirstChild.InsertAfter(newTblPos, tblPos);
                    field.Parent.Parent.FirstChild.FirstChild.Remove();
                    
                }
                TableRowHeight tblRowHeight = (TableRowHeight)field.Parent.FirstChild.FirstChild;
                if (tblRowHeight != null)
                {
                    tblRowHeight.Val =(UInt32)HeightValue;
                    field.Parent.FirstChild.FirstChild.Remove();
                    field.Parent.FirstChild.Append(tblRowHeight);
                }
            }
        }

        public static void RemoveAllSdtContentCell(MainDocumentPart mainPart)
        {           
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>();

            foreach (var field in tagFields)
            {
                IEnumerable<Paragraph> paragraphs = field.SdtContentCell.Descendants<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    //Paragraph newParagraph = paragraph;
                    RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                    //create a new paragraph containing a run and a text element
                    Paragraph newParagraph = new Paragraph();
                    Run newRun = new Run();
                    if (runProp != null)
                    {
                        //assign the RunProperties to our new run
                        newRun.Append(runProp.CloneNode(true));
                    }
                    Text newText = new Text("");
                    newRun.Append(newText);
                    newParagraph.Append(newRun);

                    IEnumerable<TableCell> tablecells = field.SdtContentCell.Descendants<TableCell>();
                    foreach (var tablecell in tablecells)
                    {
                        TableCell tableCell1 = new TableCell();
                        tableCell1.Append(tablecell.TableCellProperties.CloneNode(true));
                        tableCell1.Append(newParagraph);
                        field.Parent.InsertBefore(tableCell1, field);
                        field.Remove();
                    }

                }
            }
        }

        public static void RemoveSdtContentCellNumberByName(MainDocumentPart mainPart, string Name, string Value)
        {
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                IEnumerable<Paragraph> paragraphs = field.SdtContentCell.Descendants<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    //Paragraph newParagraph = paragraph;
                    RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                    //create a new paragraph containing a run and a text element
                    Paragraph newParagraph = new Paragraph();
                    ParagraphProperties paragraphProperties1 = new ParagraphProperties();
                    Justification justification1 = new Justification() { Val = JustificationValues.Center };
                    paragraphProperties1.Append(justification1);

                    Run newRun = new Run();
                    if (runProp != null)
                    {
                        //assign the RunProperties to our new run
                        newRun.Append(runProp.CloneNode(true));
                    }
                    Text newText = new Text(Value);
                    newRun.Append(newText);
                    newParagraph.Append(newRun);

                    IEnumerable<TableCell> tablecells = field.SdtContentCell.Descendants<TableCell>();
                    foreach (var tablecell in tablecells)
                    {
                        TableCell tableCell1 = new TableCell();
                        tableCell1.Append(tablecell.TableCellProperties.CloneNode(true));
                        tableCell1.Append(paragraphProperties1);
                        tableCell1.Append(newParagraph);
                        field.Parent.InsertBefore(tableCell1, field);
                        field.Remove();
                    }

                }
            }
        }

        public static void RemoveSdtContentCellYesNoByName(MainDocumentPart mainPart, string Name, string Value)
        {
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                IEnumerable<Paragraph> paragraphs = field.SdtContentCell.Descendants<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    //Paragraph newParagraph = paragraph;
                    RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                    //create a new paragraph containing a run and a text element
                    Paragraph newParagraph = new Paragraph();
                    ParagraphProperties paragraphProperties1 = new ParagraphProperties();
                    Justification justification1 = new Justification() { Val = JustificationValues.Center };
                    paragraphProperties1.Append(justification1);
                    SymbolChar symbolChar1 = new SymbolChar() { Font = "Wingdings", Char = "F0FC" };
                    TableCellProperties tablecellPro = new TableCellProperties();
                    tablecellPro.Append(justification1.CloneNode(true));

                    Run newRun = new Run();
                    if (runProp != null)
                    {
                        //assign the RunProperties to our new run                        
                        newRun.Append(runProp.CloneNode(true));
                    }

                    Text newText = new Text(Value);
                    if (Value == "true") newRun.Append(symbolChar1);

                    newParagraph.Append(paragraphProperties1.CloneNode(true));
                    newParagraph.Append(newRun);

                    IEnumerable<TableCell> tablecells = field.SdtContentCell.Descendants<TableCell>();
                    foreach (var tablecell in tablecells)
                    {
                        TableCell tableCell1 = new TableCell();
                        
                        tableCell1.Append(tablecell.TableCellProperties.CloneNode(true));
                        //newParagraph.Append(paragraphProperties1.CloneNode(true));
                        //if (Value == "true") tableCell1.Append(paragraphProperties1);
                        //tableCell1.Append(tablecellPro.CloneNode(true));
                        tableCell1.Append(newParagraph.CloneNode(true));

                        field.Parent.InsertBefore(tableCell1, field);
                        field.Remove();
                    }

                }
            }
        }

        public static void RemoveSdtContentCellByName(MainDocumentPart mainPart, string Name, string Value)
        {
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                IEnumerable<Paragraph> paragraphs = field.SdtContentCell.Descendants<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    //Paragraph newParagraph = paragraph;
                    RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                    //create a new paragraph containing a run and a text element
                    Paragraph newParagraph = new Paragraph();
                    Run newRun = new Run();
                    if (runProp != null)
                    {
                        //assign the RunProperties to our new run
                        newRun.Append(runProp.CloneNode(true));
                    }
                    Text newText = new Text(Value);
                    newRun.Append(newText);
                    if (paragraph.ParagraphProperties != null)
                        newParagraph.Append(paragraph.ParagraphProperties.CloneNode(true));
                    newParagraph.Append(newRun);

                    IEnumerable<TableCell> tablecells = field.SdtContentCell.Descendants<TableCell>();
                    foreach (var tablecell in tablecells)
                    {
                        TableCell tableCell1 = new TableCell();
                        tableCell1.Append(tablecell.TableCellProperties.CloneNode(true));
                        tableCell1.Append(newParagraph);
                        field.Parent.InsertBefore(tableCell1, field);
                        field.Remove();
                    }

                }
            }
        }

        public static void RemoveSdtContentCellByName(OpenXmlElement element, string Name, string Value)
        {
            IEnumerable<SdtCell> tagFields = element.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                IEnumerable<Paragraph> paragraphs = field.SdtContentCell.Descendants<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    //Paragraph newParagraph = paragraph;
                    RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                    //create a new paragraph containing a run and a text element
                    Paragraph newParagraph = new Paragraph();
                    Run newRun = new Run();
                    if (runProp != null)
                    {
                        //assign the RunProperties to our new run
                        newRun.Append(runProp.CloneNode(true));
                    }
                    Text newText = new Text(Value);
                    newRun.Append(newText);
                    if (paragraph.ParagraphProperties != null)
                        newParagraph.Append(paragraph.ParagraphProperties.CloneNode(true));
                    newParagraph.Append(newRun);

                    IEnumerable<TableCell> tablecells = field.SdtContentCell.Descendants<TableCell>();
                    foreach (var tablecell in tablecells)
                    {
                        TableCell tableCell1 = new TableCell();
                        tableCell1.Append(tablecell.TableCellProperties.CloneNode(true));
                        tableCell1.Append(newParagraph);
                        field.Parent.InsertBefore(tableCell1, field);
                        field.Remove();
                    }

                }
            }
        }

        public static void RemoveSdtContentCellMultiLineByName(MainDocumentPart mainPart, string Name, string Value, string alignment = null)
        {
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                IEnumerable<Paragraph> paragraphs = field.SdtContentCell.Descendants<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    //Paragraph newParagraph = paragraph;
                    RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                    //create a new paragraph containing a run and a text element
                    Paragraph newParagraph = new Paragraph();

                    //Set alignment for paragraph properties
                    if (alignment != null)
                    {
                        ParagraphProperties paragraphProperties1 = new ParagraphProperties();
                        JustificationValues? justification = GetJustificationFromString(alignment);
                        paragraphProperties1.AppendChild<Justification>(new Justification() { Val = justification });
                        newParagraph.AppendChild<ParagraphProperties>(paragraphProperties1);
                    }

                    Run newRun = new Run();
                    if (runProp != null)
                    {
                        //assign the RunProperties to our new run
                        newRun.Append(runProp.CloneNode(true));
                    }

                    string[] newLineArray = { Environment.NewLine, "\n" };
                    string[] textArray = Value.Split(newLineArray, StringSplitOptions.None);

                    bool first = true;

                    foreach (string line in textArray)
                    {
                        if (!first)
                        {
                            newRun.Append(new Break());
                        }

                        first = false;

                        Text txt = new Text();
                        txt.Text = line;
                        newRun.Append(txt);
                    }
                    
                    //Text newText = new Text(Value);
                    //newRun.Append(newText);
                    newParagraph.Append(newRun);

                    IEnumerable<TableCell> tablecells = field.SdtContentCell.Descendants<TableCell>();
                    foreach (var tablecell in tablecells)
                    {
                        TableCell tableCell1 = new TableCell();
                        tableCell1.Append(tablecell.TableCellProperties.CloneNode(true));
                        tableCell1.Append(newParagraph);
                        field.Parent.InsertBefore(tableCell1, field);
                        field.Remove();
                    }

                }
            }
        }

        public static void RemoveRowSdtContentCellByName(MainDocumentPart mainPart, string Name)
        {
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                field.Parent.Remove();
            }
        }

        public static void RemoveTableSdtContentCellByName(MainDocumentPart mainPart, string Name)
        {
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                field.Parent.Parent.Remove();
            }
        }

        public static void RemoveTableSdtRunByName(MainDocumentPart mainPart, string Name)
        {
            IEnumerable<SdtRun> tagFields = mainPart.Document.Body.Descendants<SdtRun>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                field.Parent.Parent.Parent.Parent.Remove();
            }
        }

        public static void RemoveSdtRunByName(MainDocumentPart mainPart, string Name)
        {
            IEnumerable<SdtRun> tagFields = mainPart.Document.Body.Descendants<SdtRun>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                field.Remove();
            }
        }

        public static void RemoveSdtRunByName(MainDocumentPart mainPart, string Name, string Value)
        {
            IEnumerable<SdtRun> tagFields = mainPart.Document.Body.Descendants<SdtRun>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                IEnumerable<Paragraph> paragraphs = field.SdtContentRun.Descendants<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    //Paragraph newParagraph = paragraph;
                    RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                    //create a new paragraph containing a run and a text element
                    Paragraph newParagraph = new Paragraph();
                    Run newRun = new Run();
                    if (runProp != null)
                    {
                        //assign the RunProperties to our new run
                        newRun.Append(runProp.CloneNode(true));
                    }
                    Text newText = new Text(Value);
                    newRun.Append(newText);
                    newParagraph.Append(newRun);

                    IEnumerable<TableCell> tablecells = field.SdtContentRun.Descendants<TableCell>();
                    foreach (var tablecell in tablecells)
                    {
                        TableCell tableCell1 = new TableCell();
                        tableCell1.Append(tablecell.TableCellProperties.CloneNode(true));
                        tableCell1.Append(newParagraph);
                        field.Parent.InsertBefore(tableCell1, field);
                        field.Remove();
                    }

                }
                //field.Remove();
            }
        }

        public static OpenXmlElement GetTableSdtContentCellByName(MainDocumentPart mainPart, string Name)
        {
            OpenXmlElement parent = null;
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                parent = field.Parent.Parent;
            }
            return parent;
        }

        public static OpenXmlElement GetRowSdtContentCellByName(MainDocumentPart mainPart, string Name)
        {
            OpenXmlElement parent = null;
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                parent = field.Parent;
            }
            return parent;
        }

        public static void RemoveTextStdElementByName(MainDocumentPart mainPart, string Name, string Value)
        {
            IEnumerable<SdtElement> tagFields = mainPart.Document.Body.Descendants<SdtElement>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                RunProperties runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                Run newRun = new Run();
                if (runProp != null)
                {
                    //assign the RunProperties to our new run
                    newRun.Append(runProp.CloneNode(true));
                }
                Text newText = new Text(Value);
                newRun.Append(newText);
                field.Parent.InsertBefore(newRun, field);
                field.Remove();
            }
        }

        public static string GetTextSdtContentCellByName(MainDocumentPart mainPart, string Name)
        {
            string sText = "";
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);
            
            foreach (var field in tagFields)
            {
                IEnumerable<Text> texts = field.SdtContentCell.Descendants<Text>();

                for (int i = 0; i < texts.Count(); i++)
                {
                    Text text = texts.ElementAt(i);

                    if (i == 0)
                    {
                        sText=text.Text;
                    }
                    else
                    {
                        text.Remove();
                    }
                }
            }
            return sText;
        }

        public static JustificationValues? GetJustificationFromString(string alignment)
        {
            switch (alignment)
            {
                case "center": return JustificationValues.Center;
                case "right": return JustificationValues.Right;
                case "left": return JustificationValues.Left;
                default: return null;
            }
        }

        public static RunProperties GetRunPropertiesSdtContentCellByName(MainDocumentPart mainPart, string Name)
        {
            RunProperties runProp = new RunProperties();
            IEnumerable<SdtCell> tagFields = mainPart.Document.Body.Descendants<SdtCell>().Where
        (r => r.SdtProperties.GetFirstChild<SdtAlias>().Val == Name);

            foreach (var field in tagFields)
            {
                IEnumerable<Paragraph> paragraphs = field.SdtContentCell.Descendants<Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    //Paragraph newParagraph = paragraph;
                    runProp = field.SdtProperties.GetFirstChild<RunProperties>();
                }
            }
            return runProp;
        }

        public static void AddRow4ColumnSdtContentCellByName
            (MainDocumentPart mainPart, string LabelName, string ControlName, string colValue1, string colValue2, bool bMerge, bool bMergeRow, bool bWithoutCol)
        {
            //Get text and properties label
            OpenXmlElement parent = GetTableSdtContentCellByName(mainPart, ControlName);

            RunProperties rp1 = new RunProperties();
            string LabelValue = "";
            if (LabelName != "")
            {
                LabelValue = GetTextSdtContentCellByName(mainPart, LabelName);
                rp1 = WordMLService.GetRunPropertiesSdtContentCellByName(mainPart, LabelName);
            }
            else rp1 = WordMLService.GetRunPropertiesSdtContentCellByName(mainPart, ControlName);
            
            RunProperties rp2 = WordMLService.GetRunPropertiesSdtContentCellByName(mainPart, ControlName);
                                             
            TableRow tableRow1 = new TableRow();
            BuildTableRow(tableRow1, rp1, rp2, LabelValue, colValue1, bMerge, false);
            if(!bWithoutCol)
                BuildTableRow(tableRow1, rp1, rp2, LabelValue, colValue2, bMerge, bMergeRow);
            else BuildTableRow(tableRow1, rp1, rp2, "", "", bMerge, bMergeRow);

            tableRow1.Append(rp1.CloneNode(true));
            
            parent.Append(tableRow1.CloneNode(true));
        }

        public static void BuildTableRow(OpenXmlElement parent, RunProperties rp1, RunProperties rp2, string colValue1, string colValue2, bool bMerge, bool bMergeRow)
        {
            TableCellProperties tableCellProperties1 = new TableCellProperties();
            HorizontalMerge verticalMerge1 = new HorizontalMerge()
            {
                Val = MergedCellValues.Restart
            };
            tableCellProperties1.Append(verticalMerge1);

            TableCellProperties tableCellProperties2 = new TableCellProperties();
            HorizontalMerge verticalMerge2 = new HorizontalMerge()
            {
                Val = MergedCellValues.Continue
            };
            tableCellProperties2.Append(verticalMerge2);

            Paragraph newParagraph1 = new Paragraph();
            Run newRun1 = new Run();
            if (rp1 != null)
            {
                //assign the RunProperties to our new run
                newRun1.Append(rp1.CloneNode(true));
            }
            Text newText1 = new Text(colValue1);
            if (colValue1 == "" && bMerge) newText1 = new Text(colValue2);
            newRun1.Append(newText1);
            newParagraph1.Append(newRun1);

            TableCell tableCell1 = new TableCell();
            tableCell1.Append(rp1.CloneNode(true));
            tableCell1.Append(newParagraph1);

            if(bMergeRow) tableCell1.Append(tableCellProperties2.CloneNode(true));
            else if (bMerge) tableCell1.Append(tableCellProperties1.CloneNode(true));
            
            Paragraph newParagraph2 = new Paragraph();
            Run newRun2 = new Run();
            if (rp2 != null)
            {
                //assign the RunProperties to our new run
                newRun2.Append(rp2.CloneNode(true));
            }
            Text newText2 = new Text(colValue2);
            newRun2.Append(newText2);
            newParagraph2.Append(newRun2);

            TableCell tableCell2 = new TableCell();
            tableCell2.Append(rp2.CloneNode(true));
            tableCell2.Append(newParagraph2.CloneNode(true));
            if (bMerge || bMergeRow)
                tableCell2.Append(tableCellProperties2.CloneNode(true));
                        
            parent.Append(rp1.CloneNode(true));
            parent.Append(tableCell1.CloneNode(true));
            parent.Append(tableCell2.CloneNode(true));
            
        }

        public static void AddRow3ColumnSdtContentCellByName(MainDocumentPart mainPart, string ControlName1, string ControlName2,string ControlName3, string colValue1, string colValue2, string colValue3)
        {
            //Get text and properties label
            OpenXmlElement parent = GetTableSdtContentCellByName(mainPart, ControlName1);

            RunProperties rp1 = WordMLService.GetRunPropertiesSdtContentCellByName(mainPart, ControlName1);
            RunProperties rp2 = WordMLService.GetRunPropertiesSdtContentCellByName(mainPart, ControlName2);
            RunProperties rp3 = WordMLService.GetRunPropertiesSdtContentCellByName(mainPart, ControlName3);

            TableRow tableRow1 = new TableRow();
            BuildTableCell(tableRow1, rp1, colValue1);
            BuildTableCell(tableRow1, rp2, colValue2);
            BuildTableCell(tableRow1, rp3, colValue3);

            parent.Append(tableRow1.CloneNode(true));
        }

        public static void BuildTableCell(OpenXmlElement parent, RunProperties rp1, string colValue1)
        {            
            Paragraph newParagraph1 = new Paragraph();
            Run newRun1 = new Run();
            if (rp1 != null)
            {
                //assign the RunProperties to our new run
                newRun1.Append(rp1.CloneNode(true));
            }
            Text newText1 = new Text(colValue1);           
            newRun1.Append(newText1);
            newParagraph1.Append(newRun1);

            TableCell tableCell1 = new TableCell();
            tableCell1.Append(rp1.CloneNode(true));
            tableCell1.Append(newParagraph1);
            
            parent.Append(rp1.CloneNode(true));
            parent.Append(tableCell1.CloneNode(true));            

        }

        public static void RemoveUnknownElement(MainDocumentPart mainPart)
        {
            IEnumerable<OpenXmlUnknownElement> tagFields = mainPart.Document.Body.Descendants<OpenXmlUnknownElement>();
            foreach (var field in tagFields)
            {
                field.Remove();
            }
        }


        public static void RemoveHeadersAndFooters(WordprocessingDocument wordDoc)
        {
            // Given a document name, remove all of the headers and footers
            // from the document.
            var docPart = wordDoc.MainDocumentPart;

            // Count the header and footer parts and continue if there 
            // are any.
            if (docPart.HeaderParts.Count() > 0 ||
                docPart.FooterParts.Count() > 0)
            {
                // Remove the header and footer parts.
                docPart.DeleteParts(docPart.HeaderParts);
                docPart.DeleteParts(docPart.FooterParts);

                // Get a reference to the root element of the main
                // document part.
                Document document = docPart.Document;

                // Remove all references to the headers and footers.

                // First, create a list of all descendants of type
                // HeaderReference. Then, navigate the list and call
                // Remove on each item to delete the reference.
                var headers =
                  document.Descendants<HeaderReference>().ToList();
                foreach (var header in headers)
                {
                    header.Remove();
                }

                // First, create a list of all descendants of type
                // FooterReference. Then, navigate the list and call
                // Remove on each item to delete the reference.
                var footers =
                  document.Descendants<FooterReference>().ToList();
                foreach (var footer in footers)
                {
                    footer.Remove();
                }

                // Save the changes.
                document.Save();
            }
        }
       
    }
}
