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
-- Orphan diagrams that are not attached to any package or element. (Orphaned diagram)
SELECT 
  t_diagram.Diagram_ID, 
  t_diagram.Name, 
  t_diagram.ParentID, 
  t_object.Object_ID 
FROM 
  t_diagram 
  LEFT OUTER JOIN t_object ON t_diagram.Package_ID = t_object.Package_ID 
  AND t_diagram.ParentID = t_object.Object_ID 
WHERE 
  t_object.Object_ID IS NULL 
  AND t_diagram.ParentID <> 0
