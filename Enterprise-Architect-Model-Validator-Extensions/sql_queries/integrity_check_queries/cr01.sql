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
-- More than one time in x_ref table.
Select 
  Client, 
  `Type`, 
  Name, 
  Behavior 
from 
  t_xref 
where 
  Name in (
    'Stereotypes', 'CustomProperties'
  ) 
Group by 
  Client, 
  `Type`, 
  Name, 
  Behavior 
having 
  count(XRefID) > 1
