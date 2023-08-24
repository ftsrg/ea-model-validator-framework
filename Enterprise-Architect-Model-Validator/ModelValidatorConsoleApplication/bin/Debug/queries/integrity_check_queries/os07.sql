-- Packages for which there is no equivalent in table t_object. (Invalid package object)
Select t_object.ea_guid, t_object.name
from t_object
	left join t_package on t_package.Package_ID = t_object.Package_ID
where
	t_package.Package_ID is null
	and (t_object.ParentID is null
		or t_object.ParentID=0)