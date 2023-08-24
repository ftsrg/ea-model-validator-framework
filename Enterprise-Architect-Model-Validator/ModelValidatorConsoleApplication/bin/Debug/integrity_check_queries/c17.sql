-- Method parameters for which the method was not found.
select c.* from t_operationparams c left join t_operation o on c.OperationID = o.OperationID where o.OperationID is null