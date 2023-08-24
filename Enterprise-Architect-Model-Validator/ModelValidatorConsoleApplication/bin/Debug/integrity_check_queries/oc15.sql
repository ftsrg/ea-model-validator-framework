-- Operations that are not assigned to any element.
select op.* from t_operation op left join t_object obj on op.Object_ID = obj.Object_ID where obj.Object_ID is null