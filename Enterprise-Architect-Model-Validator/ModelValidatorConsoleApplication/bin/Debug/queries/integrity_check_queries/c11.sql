-- Constraints of attributes for which no attributes have been found.
select c.* from t_attributeconstraints c left join t_attribute o on c.ID = o.ID where o.ID is null