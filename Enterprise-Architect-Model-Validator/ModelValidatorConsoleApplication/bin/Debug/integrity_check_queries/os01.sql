-- Orphan diagrams that are not attached to any package or element. (Orphaned diagram)
SELECT t_diagram.Diagram_ID, t_diagram.Name, t_diagram.ParentID, t_object.Object_ID
FROM t_diagram
	LEFT OUTER JOIN t_object ON t_diagram.Package_ID = t_object.Package_ID AND t_diagram.ParentID = t_object.Object_ID
WHERE
	t_object.Object_ID IS NULL
	AND t_diagram.ParentID <> 0