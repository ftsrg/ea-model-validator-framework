-- Tagged values that are not assigned to any element.
select p.* from t_objectproperties p left join t_object o on p.Object_ID = o.Object_ID where o.Object_ID is null