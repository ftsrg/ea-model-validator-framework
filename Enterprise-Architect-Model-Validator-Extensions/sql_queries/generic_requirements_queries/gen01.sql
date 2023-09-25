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
-- The start and the end object of the connection are the same
SELECT
  o.ea_guid AS [GUID],
  o.name AS [Name],
  conn.ea_guid AS [ConnectorGUID],
  conn.connector_type AS [ConnectorType]
FROM
  t_object o,
  t_connector conn
WHERE
  conn.start_object_id = conn.end_object_id
  AND conn.start_object_id = o.object_id
  AND o.package_id IN (
    #Branch#)
