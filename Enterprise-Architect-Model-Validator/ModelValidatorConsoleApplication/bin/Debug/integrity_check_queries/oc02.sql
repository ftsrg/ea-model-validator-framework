-- Attributes of a'File' element that are not associated with any element.
select f.Object_ID, f.FileName
from t_objectfiles f
	left join t_object o on f.Object_ID = o.Object_ID
where
	o.Object_ID is null