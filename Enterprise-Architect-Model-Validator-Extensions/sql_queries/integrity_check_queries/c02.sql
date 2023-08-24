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
-- Relationships for which the source or target element is missing. (Invalid connector)
Select 
  t_connector.Connector_ID, 
  t_connector.Connector_Type 
from 
  t_connector 
  left join t_object on t_connector.End_Object_ID = t_object.Object_ID 
where 
  t_object.Object_ID is null 
  or (
    t_object.Name = 'EA_IMPORT_STUB' 
    and t_object.Package_ID = 1 
    and t_object.Object_Type = 'Class'
  ) 
UNION 
Select 
  t_connector.Connector_ID, 
  t_connector.Connector_Type 
from 
  t_connector 
  left join t_object on t_connector.Start_Object_ID = t_object.Object_ID 
where 
  t_object.Object_ID is null 
  or (
    t_object.Name = 'EA_IMPORT_STUB' 
    and t_object.Package_ID = 1 
    and t_object.Object_Type = 'Class'
  )
