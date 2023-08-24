-- Start and end object of the connection is the same
SELECT o.ea_guid AS [GUID],
	o.name AS [Name],
	conn.ea_guid AS [ConnectorGUID],
	conn.connector_type AS [ConnectorType]
FROM t_object o, t_connector conn
WHERE conn.start_object_id = conn.end_object_id
	AND conn.start_object_id = o.object_id
	AND o.package_id IN (#Branch#)