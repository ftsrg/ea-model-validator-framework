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
using System.Data;

namespace ModelValidatorLibrary
{
    public class QueryResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Query { get; set; }
        public DataTable Result { get; set; }
        public QueryResult() { }
        public QueryResult(string name, string description, string query, DataTable result)
        {
            Name = name;
            Description = description;
            Query = query;
            Result = result;
        }

        public QueryResult(string name, DataTable result)
        {
            Name = name;
            Result = result;
        }
    }
}
