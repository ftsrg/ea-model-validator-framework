-- Relationships for which the type is missing. (Invalid connector)
select t_connector.ea_guid from t_connector where Connector_Type is null
