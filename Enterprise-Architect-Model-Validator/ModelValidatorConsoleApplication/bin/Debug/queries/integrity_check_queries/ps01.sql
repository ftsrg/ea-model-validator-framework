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
-- Orphaned packages that do not have a parent or slave package. (Orphaned package)
SELECT 
  parent.ea_guid, 
  parent.name 
FROM 
  t_package child 
  LEFT JOIN t_package parent on parent.Package_ID = child.Parent_ID 
where 
  parent.Package_ID Is NULL 
  and child.Parent_ID <> 0
