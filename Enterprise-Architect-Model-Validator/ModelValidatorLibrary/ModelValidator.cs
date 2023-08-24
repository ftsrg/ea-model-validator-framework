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
using EA;
using System.Collections.Generic;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Linq;
using System.Data;
using System.Text.RegularExpressions;

namespace ModelValidatorLibrary
{
    public sealed class ModelValidator 
    {
        private Repository Repository { get; set; }
        private CompositionContainer Container { get; set; }

#pragma warning disable 0649
        [ImportMany]
        private IEnumerable<Lazy<IQueryCollection, IQueryCollectionData>> queryCollections; 
        [ImportMany]
        private IEnumerable<Lazy<IExporter, IExporterData>> exporters;
        [ImportMany]
        private IEnumerable<Lazy<Corrector, ICorrectorData>> correctors;
#pragma warning restore 0649

        public IEnumerable<Lazy<IQueryCollection, IQueryCollectionData>> QueryCollections => queryCollections;
        public IEnumerable<Lazy<IExporter, IExporterData>> Exporters => exporters;
        public IEnumerable<Lazy<Corrector, ICorrectorData>> Correctors => correctors;

        public ModelValidator(Repository repository)
        {
            Repository = repository;
            try
            {
                var catalog = new AggregateCatalog();
                // load all assembly from the .dll folder \modelValidatorExtensions
                string absPath = "modelValidatorExtensions";
                try
                {
                    catalog.Catalogs.Add(new DirectoryCatalog(
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), absPath)));
                }
                catch (Exception)
                {
                    throw new Exception($"Extension folder '{absPath}' not found.");
                }

                Container = new CompositionContainer(catalog);
                Container.ComposeExportedValue(Repository);
                Container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                throw new Exception(compositionException.ToString());
            }
            catch (ReflectionTypeLoadException reflectionTypeLoadException)
            {
                foreach (var exception in reflectionTypeLoadException.LoaderExceptions)
                {
                    throw new Exception(exception.Message);
                }
            }
        }

        public List<QueryResult> RunQueries(string queryCollectionName, Package package)
        {
            var runner = new QueryRunner(Repository);
            var queryCollection = queryCollections.Where(q => q.Metadata.Name.Equals(queryCollectionName)).FirstOrDefault();

            var queryResults = new List<QueryResult>();

            DirectoryInfo directoryInfo = new DirectoryInfo(queryCollection.Value.Path);
            FileInfo[] files = directoryInfo.GetFiles("*.sql");
            foreach (FileInfo file in files)
            {
                string query = System.IO.File.ReadAllText(file.FullName);
                XmlDocument result = runner.RunQuery(query, package.PackageID.ToString());
                if (result != null)
                {
                    string fileNameWithoutExtension = file.Name.Replace(file.Extension, "");

                    System.Data.DataSet dataSet = new System.Data.DataSet();
                    using (XmlReader xmlNodeReader = new XmlNodeReader(result))
                        dataSet.ReadXml(xmlNodeReader);
                    DataTable dt = dataSet.Tables[dataSet.Tables.Count - 1];

                    var queryResult = new QueryResult
                    {
                        Name = fileNameWithoutExtension,
                        Description = GetDescription(query),
                        Query = query,
                        Result = dt
                    };
                    queryResults.Add(queryResult);
                }
            }

            return queryResults; 
        }

        private string GetDescription(string query)
        {
            if (query.Contains("--"))
            {
                return Regex.Match(query, @"--.*(\r\n|\r|\n)").Value.Replace("--", "").Trim();
            }
            if (query.Contains("/*") && query.Contains("*/"))
            {
                return Regex.Match(query, @"/\*[\s\S]*\*/").Value.Replace("/*", "").Replace("*/", "").Trim();
            }
            if (query.Contains("#DB=#"))
            {
                return Regex.Match(query, @"#DB=#.*#DB=#").Value.Replace("#DB=#", "").Trim();
            }
            return "";
        }

        public void ExportQueryResults(string exporterName, List<QueryResult> queryResults)
        {
            var exporter = exporters.Where(e => e.Metadata.Name.Equals(exporterName)).FirstOrDefault();
            exporter.Value.Export(queryResults, correctors);
        }

        public void CorrectQueryResults(string correctorName, List<QueryResult> queryResults)
        {
            var corrector = correctors.Where(c => c.Metadata.Name.Equals(correctorName)).FirstOrDefault();
            corrector.Value.CorrectAllQueryResults(queryResults);
        }
    }
}