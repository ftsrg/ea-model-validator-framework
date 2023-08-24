-- Attributes that are not assigned to any element.
select att.* from t_attribute att left join t_object obj on att.Object_ID = obj.Object_ID where obj.Object_ID is null