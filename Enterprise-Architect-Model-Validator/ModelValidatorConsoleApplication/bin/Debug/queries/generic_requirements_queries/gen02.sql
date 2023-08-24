-- Parallel (unnecessary) connections
SELECT DISTINCT o.ea_guid AS [GUID],
	o.name AS [Name],
	conn1.ea_guid AS [ConnectorGUID],
	conn1.connector_type AS [ConnectorType]
FROM t_object o, t_connector conn1, t_connector conn2
WHERE conn1.start_object_id = conn2.start_object_id
	AND conn1.end_object_id = conn2.end_object_id
	AND conn1.connector_type = conn2.connector_type
	AND NOT conn1.connector_id = conn2.connector_id
	AND conn1.start_object_id = o.object_id
	AND o.package_id IN (#Branch#)