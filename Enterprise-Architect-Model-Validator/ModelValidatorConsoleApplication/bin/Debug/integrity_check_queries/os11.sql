-- Packages that are self-relatives. (Invalid package object OR Orphaned package)
Select child.ea_guid, child.name
FROM t_object child
	left join t_object parent on child.ParentID = parent.Object_ID
where parent.Object_Type = 'Package'