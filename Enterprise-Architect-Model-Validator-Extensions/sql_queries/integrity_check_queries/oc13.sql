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
-- Missing objects to be displayed in missing diagrams and diagrams for which there are objects to be displayed. (Invalid object geometry. ITEM: Missing Diagram AND/OR Invalid object geometry. ITEM: Missing Object)
select 
  Instance_ID, 
  'Missing Object' as Problem 
from 
  t_diagramobjects l 
  left join t_object c on l.Object_ID = c.Object_ID 
where 
  c.Object_ID is null 
UNION 
select 
  Instance_ID, 
  'Missing Diagram' as Problem 
from 
  t_diagramobjects l 
  left join t_diagram d on l.Diagram_ID = d.Diagram_ID 
where 
  d.Diagram_ID is null
