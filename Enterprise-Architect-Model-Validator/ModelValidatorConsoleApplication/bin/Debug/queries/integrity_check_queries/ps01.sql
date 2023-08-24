-- Orphaned packages that do not have a parent or slave package. (Orphaned package)
SELECT parent.ea_guid, parent.name
FROM t_package child
	LEFT JOIN t_package parent on parent.Package_ID = child.Parent_ID
where
	parent.Package_ID Is NULL
	and child.Parent_ID <> 0