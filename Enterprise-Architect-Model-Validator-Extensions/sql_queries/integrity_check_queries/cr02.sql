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
-- Orphan stereotypes that are not used by elements, attributes, methods, method parameters or connetors. (Orphaned element stereotypes)
select 
  XrefID 
from 
  t_xref 
  left outer join t_object on t_xref.Client = t_object.ea_guid 
where 
  t_xref.`Type` = 'element property' 
  and t_xref.Name = 'Stereotypes' 
  and t_object.ea_guid is null 
UNION 
select 
  XrefID 
from 
  t_xref 
  left outer join t_attribute on t_xref.Client = t_attribute.ea_guid 
where 
  t_xref.`Type` = 'attribute property' 
  and t_xref.Name = 'Stereotypes' 
  and t_attribute.ea_guid is null 
UNION 
select 
  XrefID 
from 
  t_xref 
  left outer join t_operation on t_xref.Client = t_operation.ea_guid 
where 
  t_xref.`Type` = 'operation property' 
  and t_xref.Name = 'Stereotypes' 
  and t_operation.ea_guid is null 
UNION 
select 
  XrefID 
from 
  t_xref 
  left outer join t_operationparams on t_xref.Client = t_operationparams.ea_guid 
where 
  t_xref.`Type` = 'parameter property' 
  and t_xref.Name = 'Stereotypes' 
  and t_operationparams.ea_guid is null 
UNION 
select 
  XrefID 
from 
  t_xref 
  left outer join t_connector on t_xref.Client = t_connector.ea_guid 
where 
  t_xref.`Type` = 'connector property' 
  and t_xref.Name = 'Stereotypes' 
  and t_connector.ea_guid is null 
UNION 
select 
  XrefID 
from 
  t_xref 
  left outer join t_connector on t_xref.Client = t_connector.ea_guid 
where 
  t_xref.`Type` = 'connectorSrcEnd property' 
  and t_xref.Name = 'Stereotypes' 
  and t_connector.ea_guid is null 
UNION 
select 
  XrefID 
from 
  t_xref 
  left outer join t_connector on t_xref.Client = t_connector.ea_guid 
where 
  t_xref.`Type` = 'connectorDestEnd property' 
  and t_xref.Name = 'Stereotypes' 
  and t_connector.ea_guid is null
