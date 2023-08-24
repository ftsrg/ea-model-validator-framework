-- Elements that are related by themselves. (Invalid package object OR Orphaned package)
Select child.ea_guid, child.name
FROM t_object child
	left join t_object parent on child.ParentID = parent.Object_ID
where
	child.ParentID is not null
	and child.ParentID <> 0
	and parent.Object_ID is null