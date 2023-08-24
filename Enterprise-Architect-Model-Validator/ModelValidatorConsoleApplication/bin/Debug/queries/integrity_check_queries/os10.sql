-- Elements that are related by themselves. (Invalid package object OR Orphaned package)
Select child.ea_guid, child.name
FROM t_object child
	left join t_object parent on child.ParentID = parent.Object_ID and parent.ParentID = child.Object_ID
where
	parent.Object_ID is not null
	and child.Object_ID <> child.ParentID