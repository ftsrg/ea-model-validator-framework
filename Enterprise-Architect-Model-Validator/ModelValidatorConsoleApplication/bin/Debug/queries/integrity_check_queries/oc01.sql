-- Items that do not have a specific type. (Invalid Object Types)
SELECT * FROM t_object
where
	Object_Type is null
	or Object_Type = ''
	or ( Name='EA_IMPORT_STUB'
		and Package_ID=1 and Object_Type='Class')