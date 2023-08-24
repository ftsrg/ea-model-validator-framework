-- Orphan diagrams that are not linked to an element via its parent. (Orphaned diagram)
SELECT t_diagram.Diagram_ID, t_diagram.Name, t_diagram.ParentID
FROM t_diagram
WHERE
	t_diagram.ParentID IS NULL