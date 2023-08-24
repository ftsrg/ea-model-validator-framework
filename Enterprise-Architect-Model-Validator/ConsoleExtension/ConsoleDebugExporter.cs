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

namespace ConsoleExtension
{
    [Export(typeof(IExporter))]
    [ExportMetadata("Name", "Debug")]
    [ExportMetadata("Description", "Debug exporter for Model Validator Console Application.")]
    public class ConsoleDebugExporter : IExporter
    {
        public void Export(List<QueryResult> queryResults, IEnumerable<Lazy<Corrector, ICorrectorData>> correctors)
        {
            foreach (var queryResult in queryResults)
            {
                Console.WriteLine(queryResult.Name);
                DataTable dt = queryResult.Result;

                Console.WriteLine("---");
                printDataTable(dt);

                foreach (DataColumn c in dt.Columns)
                {
                    if (!c.ColumnName.Equals("Data_Id"))
                    {
                        Console.WriteLine($"{c.ColumnName}");
                    }
                }

                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn c in dt.Columns)
                    {
                        if (!c.ColumnName.Equals("Data_Id"))
                        {
                            Console.WriteLine(dr[c.ColumnName].ToString());
                        }
                    }
                }
            }
        }

        private void printDataTable(DataTable tbl)
        {
            string line = "";
            foreach (DataColumn item in tbl.Columns)
            {
                line += $"{item.ColumnName}\t";
            }
            line += "\n";
            foreach (DataRow row in tbl.Rows)
            {
                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    line += $"{row[i]}\t";
                }
                line += "\n";
            }
            Console.WriteLine(line);
        }
    }
}
