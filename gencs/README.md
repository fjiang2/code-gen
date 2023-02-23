# Generate C# class

## Environment Variable

- GENCS_NAMESPACE

    Default namespace

- GENCS_CLASS_NAME

    Default class name

- GENCS_OUTPUT

    Default output directory

## Commands

- View Model

    Create view model class:

./gencs.exe view-model UserViewModel -ns Mileage.ViewModels -p string+Name -p int?+Age --output "C:\devel\GitHub\mileage\Eux\Mileage\ViewModels"

- Json Node

    Create JsonNode feild and value:

./gencs.exe json-node JsonNodeData -ns UnitTestProject.Sample -f "RealtimeBuffer_85_1_65.json" --output "C:\temp"
