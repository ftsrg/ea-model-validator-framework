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
-- Elements that are related by themselves. (Invalid package object OR Orphaned package)
Select 
  child.ea_guid, 
  child.name 
FROM 
  t_object child 
  left join t_object parent on child.ParentID = parent.Object_ID 
  and parent.ParentID = child.Object_ID 
where 
  parent.Object_ID is not null 
  and child.Object_ID <> child.ParentID
