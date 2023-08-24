-- Packages whose name differs from the package equivalent in table t_object. (Invalid package object)
SELECT t_package.Package_ID, t_package.Name AS PackageName, t_object.Name AS ObjectName
FROM t_package
	LEFT OUTER JOIN t_object ON (Object_Type='Package' AND t_package.Package_ID LIKE t_object.PDATA1)
WHERE
	t_package.Name <> t_object.Name