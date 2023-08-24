-- Elements that are related by themselves. (Invalid package object OR Orphaned package)
Select t_object.ea_guid, t_object.name
FROM t_object
where ParentID = Object_ID