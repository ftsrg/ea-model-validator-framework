# EAModelValidator

## About
Extensible Model Validator Framework for Enterprise Architect is designed to validate models besides seamless integration with the Enterprise Architect tool.
The key strength of the framework lies in its _extensibility_, which empowers users to create custom validation rules and facilitating comprehensive model validation tailored to their specific needs e.g. custom UML profiles.
This distinctive capability enables users to ensure rigorous validation and to amplify the value of model validation within the Enterprise Architect ecosystem.
Additionally, the framework offers _result exportation_ and _auto-correction_ functionalities, enhancing efficiency and streamlining the validation process.

## Installation
To use as an Enterprise Architect Add-In:
1. Build the whole whole solution in the [`Enterprise-Architect-Model-Validator`](/Enterprise-Architect-Model-Validator) folder (tested in Visual Studio 2022)
2. Copy the DLLs of the core projects (`ModelValidatorLibrary`, `ModelValidatorEAAddin`) into the folder of Enterprise Architect tool (e.g. `c:\Program Files (x86)\Sparx Systems\EA`) 
3. Create `modelValidatorExtensions` folder in the folder of Enterprise Architect
4. Create new extensions or use the provided ones (see `Enterprise-Architect-Model-Validator` folder, `EnterpriseArchitectExtension`, `GenericExtension`, `GenericQueryExtension`, `SpaceshipExtension`) and copy these into the previously created `modelValidatorExtensions` folder
5. Create `queries` folder in the folder of Enterprise Architect
6. Create new queries (validation rules in SQL syntax) of use the provided ones (see the [`sql_queries`](/Enterprise-Architect-Model-Validator-Extensions/sql_queries) folder, `generic_requirements_queries`, `integrity_check_queries`, `spaceship_requirement_queries`) and copy these into the previously created `queries` folder
7. Close all Enterprise Architect instances, if open
8. Execute the install scripts with _administrator_ rights (see the [`install`](/Enterprise-Architect-Model-Validator-Extensions/install) folder, `ModelValidatorEAAddin.bat`, `ModelValidatorEAAddin.reg`)
9. Open Enterprise Architect and show the Add-Ins window, the `ModelValidator` Add-In shall appear

To use as a console application:
1. Build the whole whole solution in the [`Enterprise-Architect-Model-Validator`](/Enterprise-Architect-Model-Validator) folder (tested in Visual Studio 2022)
2. Copy the DLLs of the core projects (`ModelValidatorLibrary`, `ModelValidatorEAAddin`) and the executable of the console application (`ModelValidatorConsoleApplication`) into the desired folder 
3. Create `modelValidatorExtensions` folder in the desired folder
4. Create new extensions or use the provided ones (see [`sql_queries`](/Enterprise-Architect-Model-Validator-Extensions/sql_queries) folder, `ConsoleExtension`, `GenericExtension`, `GenericQueryExtension`, `SpaceshipExtension`) and copy these into the previously created `modelValidatorExtensions` folder
5. Create `queries` folder in the desired folder
6. Create new queries (validation rules in SQL syntax) of use the provided ones (see [`install`](/Enterprise-Architect-Model-Validator-Extensions/install) folder, `generic_requirements_queries`, `integrity_check_queries`, `spaceship_requirement_queries`) and copy these into the previously created `queries` folder

## Using
To use as an Enterprise Architect Add-In:
1. Choose a _Query Collection_ from the drop-down menu
2. Choose an _Exporter_ from the drop-down menu
3. Trigger the validation with the _Validate_ button
4. You can use the _Find GUID_ button to search for a GUID from the clipboard

To use as a console application:
You shall provide some arguments for the executable:
1. `--connectionstring`: the connection string of the Enterprise Architect model (e.g. `c:\\ea_models\\example.eapx`)
2. `--packageguid`: the GUID string of the Enterprise Architect package to execute the validation on
3. `--querycollection`: the folder of the validation rules collection (e.g. `SpaceML Requirements`)
4. `--exporter`: the desired exporter to use (e.g. `Debug`)

## Contributors
- [Gergely Ulicska](https://github.com/ulicskagergo)

Note, that submodule [`Enterprise-Architect-Add-in-Framework`](https://github.com/GeertBellekens/Enterprise-Architect-Add-in-Framework/tree/a3d7466a26c8f6d8d38b20c92223508a5f8b603c) is forked from the repository of [Geert Bellekens](https://github.com/GeertBellekens): [Enterprise-Architect-Add-in-Framework](https://github.com/GeertBellekens/Enterprise-Architect-Add-in-Framework)
