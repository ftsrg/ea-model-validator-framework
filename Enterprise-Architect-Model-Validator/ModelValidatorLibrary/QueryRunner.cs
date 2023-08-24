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
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace ModelValidatorLibrary
{
    public class QueryRunner
    {
        private Repository Repository { get; set; }

        public QueryRunner(Repository repository)
        {
            Repository = repository;
        }

        public List<XmlDocument> RunQueries(List<string> queries)
        {
            List<XmlDocument> xmlDocuments = new List<XmlDocument>();
            foreach (string query in queries)
                xmlDocuments.Add(RunQuery(query));
            return xmlDocuments;
        }

        public XmlDocument RunQuery(string query, string packageID = null)
        {
            if (packageID != null)
            {
                query = ReplaceBranchWithPackageTreeIDString(query, packageID);
            }
            query = RemoveComments(query);

            XmlDocument result = new XmlDocument();
            string xml = Repository.SQLQuery(query);
            if (xml.Contains("Dataset"))
                result.LoadXml(xml);
            else
                result = null;
            return result;
        }


        private string ReplaceBranchWithPackageTreeIDString(string sql, string packageID)
        {
            string branch = "#Branch#";
            if (sql.Contains(branch))
            {
                string packageTreeIDString = GetPackageTreeIDString(packageID);
                sql = sql.Replace(branch, packageTreeIDString);
            }
            return sql;
        }

        private string GetPackageTreeIDString(string packageID)
        {
            List<string> allPackageTreeIDs = new List<string>();
            List<string> parentpackageIDs = new List<string>
            {
                packageID
            };
            allPackageTreeIDs = GetPackageTreeIDs(allPackageTreeIDs, parentpackageIDs);
            return string.Join(",", allPackageTreeIDs.ToArray());
        }

        private List<string> GetPackageTreeIDs(List<string> allPackageTreeIDs, List<string> parentPackageIDs)
        {
            if (parentPackageIDs.Count == 0 && allPackageTreeIDs.Count == 0)
            {
                allPackageTreeIDs.Add("0");
                return allPackageTreeIDs;
            }
            allPackageTreeIDs.AddRange(parentPackageIDs);

            string sql = $"SELECT p.package_id FROM t_package p WHERE p.Parent_ID in ({string.Join(",", parentPackageIDs.ToArray())})";
            XmlDocument xmlDocument = new XmlDocument();
            string xmlResult = Repository.SQLQuery(sql);
            xmlDocument.LoadXml(xmlResult);
            XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("package_id");

            List<string> result = new List<string>();
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                result.Add(Convert.ToString(xmlNode.InnerText));
            }
            if (result.Count > 0)
            {
                List<string> childPackageIDs = new List<string>
                {
                    string.Join(",", result.ToArray())
                };
                GetPackageTreeIDs(allPackageTreeIDs, childPackageIDs);
            }
            return allPackageTreeIDs;
        }

        private string RemoveComments(string query)
        {
            if (query.Contains("--"))
            {
                query = Regex.Replace(query, @"--.*(\r\n|\r|\n)", "");
            }
            if (query.Contains("/*") && query.Contains("*/"))
            {
                query = Regex.Replace(query, @"/\*[\s\S]*\*/", "");
            }
            if (query.Contains("#DB=#"))
            {
                query = Regex.Replace(query, @"#DB=#.*#DB=#", "");
            }
            return query;
        }
    }
}
