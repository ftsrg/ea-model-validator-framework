-- Package elements for which there is no equivalent in the t_package table. (Invalid package object)
select t_object.Name, t_object.Object_ID
from t_object
	left join t_package on t_object.PDATA1 LIKE t_package.Package_ID
where
	t_package.Package_ID is null
	and t_object.Object_Type = 'Package'