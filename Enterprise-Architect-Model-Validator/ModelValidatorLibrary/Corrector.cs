﻿/*
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
using System.ComponentModel.Composition;

namespace ModelValidatorLibrary
{
    public abstract class Corrector
    {
        public Repository Repository { get; set; }
        [ImportingConstructor]
        public Corrector(Repository repository)
        {
            Repository = repository;
        }
        public abstract void CorrectAllQueryResults(List<QueryResult> queryResults);
        public abstract void CorrectOneQueryResult(QueryResult queryResult);
    }

    public interface ICorrectorData
    {
        string Name { get; }
        string Description { get; }
        string HandledQueries { get; }
    }
}
