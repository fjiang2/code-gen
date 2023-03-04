# Generate C# class

## Environment Variable

- GENCS_NAMESPACE

    Default namespace

- GENCS_CLASS_NAME

    Default class name

- GENCS_OUTPUT

    Default output directory

### Command Prompt Examples

SET GENCS_NAMESPACE=gencs.app.data
SET GENCS_OUTPUT=C:\code

### PowerShell Examples

$env:GENCS_NAMESPACE='gencs.app.data'
$env:GENCS_OUTPUT='C:\code'


## gencs commands

- View Model

    Create view model class:

./gencs.exe view-model UserViewModel -ns Mileage.ViewModels -p string+Name -p int?+Age --output "C:\devel\GitHub\mileage\Eux\Mileage\ViewModels"

- Json Node

    Create JsonNode feild and value:

./gencs.exe json-node UserJsonData -ns Project.Sample -f "sample.json" --output "C:\temp"
