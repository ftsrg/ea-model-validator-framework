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
using System.ComponentModel.Composition.Primitives;
using System.Data;
using System.Windows.Forms;

namespace EnterpriseArchitectExtension
{
    [Export(typeof(IExporter))]
    [ExportMetadata("Name", "PopupTable")]
    [ExportMetadata("Description", "Exporter for Model Validator Add-In, outputs data into the DataGridView of the Add-In.")]
    public class DataGridExporter : IExporter
    {
        private readonly string correct = "Correct";
        IEnumerable<Lazy<Corrector, ICorrectorData>> correctors;

        public void Export(List<QueryResult> queryResults, IEnumerable<Lazy<Corrector, ICorrectorData>> correctors)
        {
            this.correctors = correctors;
            ExportWindow exportWindow = new ExportWindow();

            DataTable dataTable = CreateMainDataTable();
            exportWindow.LoadDataIntoTab(dataTable, "Main");

            foreach (var queryResult in queryResults)
            {
                var name = queryResult.Name;
                dataTable = queryResult.Result;
                foreach (var corrector in correctors)
                {
                    if (corrector.Metadata.HandledQueries.Contains(name))
                    {
                        dataTable.Columns.Add(correct);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row[correct] = correct;
                        }
                        break;
                    }
                }
                exportWindow.LoadDataIntoTab(dataTable, name, DataGridViewCellClick);
            }
            exportWindow.Show();
        }

        private void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.CurrentCell == null
                || dataGridView.CurrentCell.Value == null
                || !dataGridView.CurrentCell.Value.Equals(correct))
            {
                return;
            }
            var tabPageName = dataGridView.Parent.Text;
            foreach (var corrector in correctors)
            {
                if (corrector.Metadata.HandledQueries.Contains(tabPageName))
                {
                    DataTable dataTable = new DataTable();

                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            dataTable.Columns.Add(column.HeaderText, column.ValueType);
                        }
                    }
                    DataRow dr = dataTable.NewRow();
                    foreach (DataGridViewCell cell in dataGridView.CurrentRow.Cells)
                    {
                        if (cell.Visible)
                        {
                            dr[cell.ColumnIndex] = cell.Value;
                        }
                    }
                    dataTable.Rows.Add(dr);
                    QueryResult queryResult = new QueryResult(tabPageName, dataTable);
                    corrector.Value.CorrectOneQueryResult(queryResult);
                }
            }
        }

        private DataTable CreateMainDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Clear();

            dataTable.Columns.Add("Property");
            dataTable.Columns.Add("Value");

            DataRow dataRow = dataTable.NewRow();
            dataRow["Property"] = "Export date";
            dataRow["Value"] = DateTime.Now;
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["Property"] = "Exporter name";
            dataRow["Value"] = "PopupTable";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["Property"] = "Exporter description";
            dataRow["Value"] = "Exporter for Model Validator Add-In, outputs data into the DataGridView of the Add-In.";
            dataTable.Rows.Add(dataRow);

            return dataTable;
        }
    }
}
