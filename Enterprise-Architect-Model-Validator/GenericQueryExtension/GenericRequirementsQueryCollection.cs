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
using System.ComponentModel.Composition;

<<<<<<< HEAD
namespace GenericExtension
=======
namespace SpaceshipExtension
>>>>>>> f1257d9ae6c543270db1b2299889ef86e5cc5a10
{
    [Export(typeof(IQueryCollection))]
    [ExportMetadata("Name", "SysML Requirements")]
    [ExportMetadata("Description", "Collection of generic requirements SQL queries.")]
    internal class GenericRequirementsQueryCollection : IQueryCollection
    {
        public string Path
        {
            get
            {
                return System.IO.Path.GetFullPath(System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "queries",
                    "generic_requirements_queries"
                ));
            }
        }
    }
}
