using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using File = System.IO.File;

namespace ShanxiAdultEducationBatchQueryScore
{
    internal class NPOIHelper
    {

        public class ExcelUtility
        {
            /// <summary>
            /// 将excel导入到dataTable
            /// </summary>
            /// <param name="filePath">excel路径</param>
            /// <param name="isColumnName">第一行是否是列名</param>
            /// <returns>返回dataTable</returns>
            public static DataTable ExcelToDataTable(string filePath, bool isColumnName)
            {
                FileStream fs = null;
                IWorkbook workbook = null;
                var startRow = 0;
                try
                {
                    DataTable dataTable = null;
                    using (fs = File.OpenRead(filePath))
                    {
                        // 版本后缀控制
                        if (filePath.IndexOf(".xlsx", StringComparison.Ordinal) > 0)
                            workbook = new XSSFWorkbook(fs);
                        // 版本后缀控制
                        else if (filePath.IndexOf(".xls", StringComparison.Ordinal) > 0)
                            workbook = new HSSFWorkbook(fs);

                        if (workbook == null) return null;
                        var sheet = workbook.GetSheetAt(0);
                        dataTable = new DataTable();
                        if (sheet == null) return dataTable;
                        var rowCount = sheet.LastRowNum;//总行数
                        if (rowCount <= 0) return dataTable;
                        var firstRow = sheet.GetRow(0);//第一行
                        int cellCount = firstRow.LastCellNum;//列数

                        //构建dataTable的列
                        DataColumn column = null;
                        ICell cell = null;
                        if (isColumnName)
                        {
                            startRow = 1;//如果第一行是列名，则从第二行开始读取
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                cell = firstRow.GetCell(i);
                                if (cell?.StringCellValue == null) continue;
                                column = new DataColumn(cell.StringCellValue);
                                dataTable.Columns.Add(column);
                            }
                        }
                        else
                        {
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                column = new DataColumn("column" + (i + 1));
                                dataTable.Columns.Add(column);
                            }
                        }

                        //填充行
                        for (var i = startRow; i <= rowCount; ++i)
                        {
                            var row = sheet.GetRow(i);
                            if (row == null) continue;

                            var dataRow = dataTable.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                cell = row.GetCell(j);
                                if (cell == null)
                                {
                                    dataRow[j] = "";
                                }
                                else
                                {
                                    //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)
                                    switch (cell.CellType)
                                    {
                                        case CellType.Blank:
                                            dataRow[j] = "";
                                            break;
                                        case CellType.Numeric:
                                            var format = cell.CellStyle.DataFormat;
                                            //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                            if (format == 14 || format == 31 || format == 57 || format == 58)
                                                dataRow[j] = cell.DateCellValue;
                                            else
                                                dataRow[j] = cell.NumericCellValue;
                                            break;
                                        case CellType.String:
                                            dataRow[j] = cell.StringCellValue;
                                            break;
                                        case CellType.Unknown:
                                            break;
                                        case CellType.Formula:
                                            break;
                                        case CellType.Boolean:
                                            break;
                                        case CellType.Error:
                                            break;
                                        default:
                                            throw new ArgumentOutOfRangeException();
                                    }
                                }
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                    }
                    return dataTable;
                }
                catch (Exception)
                {
                    fs?.Close();
                    return null;
                }
            }
        }
        public static bool DataTableToExcel(DataTable dt, string txtPath)
        {
            FileStream fs = null;
            try
            {
                if (dt == null || dt.Rows.Count <= 0) return false;
                IWorkbook workbook = new HSSFWorkbook();
                var sheet = workbook.CreateSheet("Sheet0");
                var rowCount = dt.Rows.Count;//行数
                var columnCount = dt.Columns.Count;//列数

                //设置列头
                var row = sheet.CreateRow(0);
                ICell cell = null;
                for (var c = 0; c < columnCount; c++)
                {
                    cell = row.CreateCell(c);
                    cell.SetCellValue(dt.Columns[c].ColumnName);
                }

                //设置每行每列的单元格,
                for (var i = 0; i < rowCount; i++)
                {
                    row = sheet.CreateRow(i + 1);
                    for (var j = 0; j < columnCount; j++)
                    {
                        cell = row.CreateCell(j);//excel第二行开始写入数据
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }
                using (fs = File.OpenWrite(txtPath))
                {
                    workbook.Write(fs);//向打开的这个xls文件中写入数据
                }
                return true;
            }
            catch (Exception)
            {
                fs?.Close();
                return false;
            }
        }
    }
}
