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
-- The Unit values of the parent-nested requirements do not correspond.
SELECT 
  DISTINCT o1.ea_guid AS [ParentGUID], 
  o1.name AS [ParentName], 
  op1.value AS [ParentUnitValue], 
  o2.ea_guid AS [NestedGUID], 
  o2.name AS [NestedName], 
  op2.value AS [NestedUnitValue] 
FROM 
  t_object o1, 
  t_objectproperties op1, 
  t_connector conn, 
  t_object o2, 
  t_objectproperties op2 
WHERE 
  conn.start_object_id = o1.object_id 
  AND conn.end_object_id = o2.object_id 
  AND conn.connector_type LIKE "Nesting" 
  AND op1.object_id = o1.object_id 
  AND op2.object_id = o2.object_id 
  AND op1.property LIKE "Unit" 
  AND op2.property LIKE "Unit" 
  AND op1.value NOT LIKE op2.value 
  AND (
    o1.package_id IN (
      #Branch#)
      OR o2.package_id IN (
        #Branch#))
