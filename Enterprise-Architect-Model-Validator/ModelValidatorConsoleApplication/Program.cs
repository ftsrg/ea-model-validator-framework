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
using CommandLine;
using EA;
using ModelValidatorLibrary;

namespace ModelValidatorConsoleApplication
{
    public class Options
    {
        [Option("connectionstring", Required = true, HelpText = "Connection string for the Enterprise Architect database.")]
        public string ConnectionString { get; set; }

        [Option("packageguid", Required = true, HelpText = "GUID of the Enterprise Architect package to validate.")]
        public string PackageGUID { get; set; }

        [Option("querycollection", Required = true, HelpText = "Name of the query collection to check.")]
        public string QueryCollectionName { get; set; }

        [Option("exporter", HelpText = "Name of the exporter to use.")]
        public string ExporterName { get; set; }

        [Option("corrector", HelpText = "Name of the corrector to use.")]
        public string CorrectorName { get; set; }
    }

    public class ModelValidatorConsoleApplication
    {
        private static Repository repository;
        private static ModelValidator modelValidator;

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
            {
                DatabaseConnector databaseConnector = new DatabaseConnector();
                repository = databaseConnector.OpenConnection(options.ConnectionString, "win10", "");
                if (repository == null) { return; }

                modelValidator = new ModelValidator(repository);
                Package package = repository.GetPackageByGuid(options.PackageGUID);
                var queryResultsWithName = modelValidator.RunQueries(options.QueryCollectionName, package);

                if (options.ExporterName != null)
                    modelValidator.ExportQueryResults(options.ExporterName, queryResultsWithName);

                if (options.CorrectorName != null)
                    modelValidator.CorrectQueryResults(options.CorrectorName, queryResultsWithName);
            });
        }
    }
}