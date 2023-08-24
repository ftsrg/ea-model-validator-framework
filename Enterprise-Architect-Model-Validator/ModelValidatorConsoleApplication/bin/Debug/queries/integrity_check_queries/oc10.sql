-- Attributes of a'Test' element that are not assigned to any element.
select f.Object_ID, f.Test from t_objecttests f left join t_object o on f.Object_ID = o.Object_ID where o.Object_ID is null