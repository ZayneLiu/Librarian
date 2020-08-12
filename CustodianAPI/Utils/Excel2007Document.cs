using System;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CustodianAPI.Utils
{
    public class Excel2007Document : Document
    {
        public Excel2007Document()
        {
        }

        public Excel2007Document(string filePath) : base(filePath)
        {
            Index();
        }


        protected override void Index()
        {
            var startTime = DateTime.Now;
            Console.Write($"Indexing {Name}");

            #region Excel
            var xlsx = SpreadsheetDocument.Open(path: Location, isEditable: false);
            var workSheets = xlsx.WorkbookPart.WorksheetParts.GetEnumerator();

            # region Get sharedStringTable
            IQueryable<string> sharedStringTableList = null;
            using (var parts = xlsx.RootPart.Parts.GetEnumerator())
            {
                while (parts.MoveNext())
                {
                    var b = parts.Current.OpenXmlPart;
                    if (b.GetType() == typeof(SharedStringTablePart))
                    {
                        var part = (SharedStringTablePart)parts.Current.OpenXmlPart;
                        sharedStringTableList = from item in part.SharedStringTable.Elements().AsQueryable()
                                                select item.InnerText;
                    }
                }
            }
            #endregion

            while (workSheets.MoveNext())
            {
                var sheet = workSheets.Current;
                using var sheetData = sheet.Worksheet.Elements<SheetData>().GetEnumerator();
                while (sheetData.MoveNext())
                {
                    using var rows = sheetData.Current.Elements<Row>().GetEnumerator();
                    while (rows.MoveNext())
                    {
                        var row = rows.Current;
                        using var cells = row.Elements<Cell>().GetEnumerator();
                        while (cells.MoveNext())
                        {
                            var cell = cells.Current;
                            var text = "";
                            // TODO: Potential issue with the cell type
                            // FIXME: The value the cells with type `Date`
                            if (cell.DataType == null)
                                text = cell.CellValue.InnerText;
                            else if (cell.DataType == CellValues.SharedString)
                                text = sharedStringTableList.ElementAt(int.Parse(cell.CellValue.InnerText));
                            else
                                text = cell.CellValue.InnerText;

                            this.AddToIndex(text);
                        }
                    }
                }
            }
            #endregion

            Console.Write($" >==> {Thumbnail.Count} unique words. {(DateTime.Now - startTime).TotalMilliseconds}ms\n");
        }
    }
}