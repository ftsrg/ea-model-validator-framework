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
-- Relationships that should be displayed in diagrams, but for which there are no relationships in the model. (Invalid link geometry. ITEM: Missing Connector)
select 
  Instance_ID, 
  'Missing Connector' as Problem 
from 
  t_diagramlinks l 
  left join t_connector c on l.ConnectorID = c.Connector_ID 
where 
  c.Connector_ID is null 
UNION 
select 
  Instance_ID, 
  'Missing Diagram' as Problem 
from 
  t_diagramlinks l 
  left join t_diagram d on l.DiagramID = d.Diagram_ID 
where 
  d.Diagram_ID is null
