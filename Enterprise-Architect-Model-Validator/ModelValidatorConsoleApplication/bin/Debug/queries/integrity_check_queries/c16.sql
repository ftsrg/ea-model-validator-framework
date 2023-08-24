-- Method tags for which no method has been found.
select * from t_operationtag c left join t_operation o on c.ElementID = o.OperationID where o.OperationID is null