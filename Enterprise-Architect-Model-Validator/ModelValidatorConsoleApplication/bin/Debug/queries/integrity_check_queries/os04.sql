-- Orphan diagrams that are not attached to any package or element. (Orphaned diagram)
select t_diagram.Diagram_ID, t_diagram.Name, t_diagram.Diagram_Type
from t_diagram
	left join t_package on t_package.Package_ID = t_diagram.Package_ID
where
	t_package.Package_ID is null
	or t_package.Parent_ID = 0