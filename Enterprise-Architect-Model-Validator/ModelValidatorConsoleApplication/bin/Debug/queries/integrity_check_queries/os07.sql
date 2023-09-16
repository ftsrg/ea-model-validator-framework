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
-- Packages for which there is no equivalent in table t_object. (Invalid package object)
Select 
  t_object.ea_guid, 
  t_object.name 
from 
  t_object 
  left join t_package on t_package.Package_ID = t_object.Package_ID 
where 
  t_package.Package_ID is null 
  and (
    t_object.ParentID is null 
    or t_object.ParentID = 0
  )
