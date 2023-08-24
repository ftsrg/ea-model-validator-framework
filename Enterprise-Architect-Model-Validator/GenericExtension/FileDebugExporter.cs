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
using System.Globalization;
using System.IO;

namespace GenericExtension
{
    [Export(typeof(IExporter))]
    [ExportMetadata("Name", "FileDebug")]
    [ExportMetadata("Description", "Debug exporter for file debug for Model Validator Enterprise Architect Add-In.")]
    public class FileDebugExporter : IExporter
    {
        public void Export(List<QueryResult> queryResults, IEnumerable<Lazy<Corrector, ICorrectorData>> correctors)
        {
            string directoryName = Path.GetFullPath(Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "logs"
                ));
            Directory.CreateDirectory(directoryName);
            string fileName = Path.Combine(directoryName, $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture)}.log");
            StreamWriter streamWriter = new StreamWriter(fileName, append: true);
            streamWriter.AutoFlush = true;

            streamWriter.WriteLine("Export started.");
            foreach (var queryResult in queryResults)
            {
                streamWriter.WriteLine(queryResult.Name);
                DataTable dt = queryResult.Result;

                foreach (DataColumn c in dt.Columns)
                {
                    if (!c.ColumnName.Equals("Data_Id"))
                    {
                        streamWriter.Write($"{c.ColumnName};");
                    }
                }
                streamWriter.WriteLine();

                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn c in dt.Columns)
                    {
                        if (!c.ColumnName.Equals("Data_Id"))
                        {
                            streamWriter.Write($"{dr[c.ColumnName]};");
                        }
                    }
                    streamWriter.WriteLine();
                }
            }
            streamWriter.WriteLine("Export finished.");
            streamWriter.Close();
        }
    }
}
