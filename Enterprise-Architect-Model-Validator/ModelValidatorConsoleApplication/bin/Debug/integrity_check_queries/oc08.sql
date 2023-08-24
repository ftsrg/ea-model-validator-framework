-- Attributes of a'Risk' element that are not assigned to any element.
select f.Object_ID, f.Risk from t_objectrisks f left join t_object o on f.Object_ID = o.Object_ID where o.Object_ID is null