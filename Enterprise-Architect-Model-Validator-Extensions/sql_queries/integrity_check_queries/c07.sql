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
-- Check the consistency between the relationships in the model and those presented in the diagrams. (Invalid link geometry. ITEM: Missing Connector)
SELECT 
  t_connector.Connector_ID, 
  t_connector.Connector_Type, 
  t_diagram.Diagram_ID, 
  t_connector.DiagramID 
FROM 
  t_connector 
  LEFT JOIN t_diagram ON t_connector.DiagramID = t_diagram.Diagram_ID 
WHERE 
  (
    (
      (t_diagram.Diagram_ID) Is Null
    ) 
    AND (
      (t_connector.DiagramID)<> 0
    )
  )
