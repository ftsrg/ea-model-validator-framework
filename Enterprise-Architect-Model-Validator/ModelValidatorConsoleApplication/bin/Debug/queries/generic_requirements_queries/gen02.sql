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
-- Parallel (unnecessary) connections
SELECT 
  DISTINCT o.ea_guid AS [GUID], 
  o.name AS [Name], 
  conn1.ea_guid AS [ConnectorGUID], 
  conn1.connector_type AS [ConnectorType] 
FROM 
  t_object o, 
  t_connector conn1, 
  t_connector conn2 
WHERE 
  conn1.start_object_id = conn2.start_object_id 
  AND conn1.end_object_id = conn2.end_object_id 
  AND conn1.connector_type = conn2.connector_type 
  AND NOT conn1.connector_id = conn2.connector_id 
  AND conn1.start_object_id = o.object_id 
  AND o.package_id IN (
    #Branch#)
