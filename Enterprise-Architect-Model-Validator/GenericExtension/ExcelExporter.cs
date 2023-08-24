/*
 *  Copyright 2023 Gergely Ulicska
 *  
 *  See the README file(s) distributed with this work for additional
 *  information regarding copyright ownership and contributors.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */
using ModelValidatorLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace GenericExtension
{

    [Export(typeof(IExporter))]
    [ExportMetadata("Name", "Excel")]
    [ExportMetadata("Description", "Excel exporter for the Spaceship (TM) Extension for Enterprise Architect.")]
    internal class ExcelExporter : IExporter
    {
        private Excel.Application application;

        public void Export(List<QueryResult> queryResults, IEnumerable<Lazy<Corrector, ICorrectorData>> correctors)
        {
            application = new Excel.Application();
            if (application == null)
            {
                throw new Exception("Excel is not properly installed");
            }
            Excel.Workbook workbook = application.Workbooks.Add();
            CreateMainSheet(application);

            foreach (var queryResult in queryResults)
            {
                ExportSheet(queryResult.Name, queryResult.Result, queryResult.Description);
            }

            application.Visible = true;
        }

        private void CreateMainSheet(Excel.Application application)
        {
            Excel.Worksheet sheet = application.Worksheets[1];
            sheet.Name = "Main";
            sheet.Cells[1, 1] = "Export date";
            sheet.Cells[1, 2] = DateTime.Now;
            sheet.Cells[2, 1] = "Exporter name";
            sheet.Cells[2, 2] = "Excel";
            sheet.Cells[3, 1] = "Exporter description";
            sheet.Cells[3, 2] = "Excel exporter for the Spaceship (TM) Extension for Enterprise Architect.";
            sheet.Columns.AutoFit();
        }

        private void ExportSheet(string tableName, DataTable dt, string description)
        {
            Excel.Worksheet sheet = application.Worksheets.Add(Type.Missing, application.Worksheets[application.Worksheets.Count], 1, Excel.XlSheetType.xlWorksheet);
            sheet.Name = tableName;
            sheet.Cells[1, 1] = description;
            DataTableToExcel(dt, sheet);
            sheet.Columns.AutoFit();
            sheet.Columns[1].ColumnWidth = 40;
        }

        private void DataTableToExcel(DataTable dt, Excel.Worksheet sheet)
        {
            int iColumn = 0;
            var header_row = sheet.UsedRange.Rows.Count + 1;
            foreach (DataColumn c in dt.Columns)
            {
                if (!c.ColumnName.Equals("Data_Id"))
                {
                    iColumn++;
                    sheet.Rows[header_row].Font.Bold = true;
                    sheet.Cells[header_row, iColumn] = c.ColumnName;
                }
            }

            int iRow = sheet.UsedRange.Rows.Count - 1;
            foreach (DataRow dr in dt.Rows)
            {
                iRow++;
                iColumn = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    if (!c.ColumnName.Equals("Data_Id"))
                    {
                        iColumn++;
                        sheet.Cells[iRow + 1, iColumn] = dr[c.ColumnName];
                    }
                }
            }
        }
    }
}

