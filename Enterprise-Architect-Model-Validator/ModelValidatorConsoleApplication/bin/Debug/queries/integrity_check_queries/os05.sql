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
-- Packages whose name differs from the package equivalent in table t_object. (Invalid package object)
SELECT 
  t_package.Package_ID, 
  t_package.Name AS PackageName, 
  t_object.Name AS ObjectName 
FROM 
  t_package 
  LEFT OUTER JOIN t_object ON (
    Object_Type = 'Package' 
    AND t_package.Package_ID LIKE t_object.PDATA1
  ) 
WHERE 
  t_package.Name <> t_object.Name
