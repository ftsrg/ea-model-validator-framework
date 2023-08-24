-- Attributes of a constraint element that do not have a specific name.
select Object_ID, `Constraint` from t_objectconstraint where `Constraint` is null or `Constraint`=''