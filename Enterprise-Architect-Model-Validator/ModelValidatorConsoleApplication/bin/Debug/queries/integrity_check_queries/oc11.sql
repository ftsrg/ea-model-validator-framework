-- Attributes of a'Constraint' element that do not have a specific type.
select Object_ID, ConstraintType from t_objectconstraint where ConstraintType is null or ConstraintType=''