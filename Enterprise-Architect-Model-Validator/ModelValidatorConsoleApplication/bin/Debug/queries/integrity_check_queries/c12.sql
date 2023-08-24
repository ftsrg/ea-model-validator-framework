-- Attribute tags for which no attribute has been found. (Invalid attribute tag)
select * from t_attributetag c left join t_attribute o on c.ElementID = o.ID where o.ID is null