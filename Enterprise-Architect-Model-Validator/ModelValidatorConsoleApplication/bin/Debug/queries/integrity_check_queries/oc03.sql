-- Attributes of an'Effort' element that are not associated with any element.
select f.Object_ID, f.Effort
from t_objecteffort f
	left join t_object o on f.Object_ID = o.Object_ID
where
	o.Object_ID is null