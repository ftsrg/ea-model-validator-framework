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
using ModelValidatorLibrary;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;

<<<<<<< HEAD
namespace GenericExtension
=======
namespace SpaceshipExtension
>>>>>>> f1257d9ae6c543270db1b2299889ef86e5cc5a10
{
    [Export(typeof(Corrector))]
    [ExportMetadata("Name", "SysML")]
    [ExportMetadata("Description", "Corrector for Model Validator Enterprise Architect Add-In.")]
    [ExportMetadata("HandledQueries", "gen01,gen02")]
    internal class GenericCorrector : Corrector
    {
        [ImportingConstructor]
        public GenericCorrector(Repository repository) : base(repository)
        {
            Repository = repository;
        }

        public override void CorrectAllQueryResults(List<QueryResult> queryResults)
        {
            foreach (var queryResult in queryResults)
            {
                CorrectOneQueryResult(queryResult);
            }
        }

        public override void CorrectOneQueryResult(QueryResult queryResult)
        {
            var name = queryResult.Name;
            var dt = queryResult.Result;
            switch (name)
            {
                case "gen01":
                case "gen02":
                    DeleteUnnecessaryConnections(dt, Repository);
                    break;
                default:
                    throw new System.Exception($"This type of query result cannot be handled (name: <{name}>).");
            }
            Repository.Models.Refresh();
        }

        private void DeleteUnnecessaryConnections(DataTable dt, Repository repository)
        {
            bool second = false;
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn c in dt.Columns)
                {
                    if (c.ColumnName.Equals("ConnectorGUID") && second)
                    {
                        var connectorGUID = dr[c.ColumnName].ToString();
                        Connector connector = repository.GetConnectorByGuid(connectorGUID);
                        Element client = repository.GetElementByID(connector.ClientID);
                        for (short i = 0; i < client.Connectors.Count; i++)
                        {
                            if (client.Connectors.GetAt(i).ConnectorGUID.Equals(connectorGUID))
                            {
                                client.Connectors.DeleteAt(i, true);
                                break;
                            }
                        }
                    }
                    second = !second;
                }
            }
        }
    }
}
