-- Packages that are self-relatives. (Invalid package object OR Orphaned package)
SELECT t_package.ea_guid, t_package.name
FROM t_package
WHERE Package_ID = Parent_ID