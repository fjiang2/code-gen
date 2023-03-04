# Tool of C# Code Generation (gencs)

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
SET GENCS_CLASS_NAME=Program

### PowerShell Examples

$env:GENCS_NAMESPACE='gencs.app.data'
$env:GENCS_OUTPUT='C:\code'
$env:GENCS_CLASS_NAME='Program'

## gencs commands

- View Model

    Create view model class:

./gencs.exe view-model UserViewModel -ns Mileage.ViewModels -p string+Name -p int?+Age --output "C:\devel\GitHub\mileage\Eux\Mileage\ViewModels"

- Json Node

    Create JsonNode feild and value:

./gencs.exe json-node UserJsonData -ns Project.Sample -f "sample.json" --output "C:\temp"



### lanuchSettings.json
- "commandLineArgs": "view-model UserViewModel -ns App.View.Model -p string+Name -p int?+Age"
- "commandLineArgs": "json-node JsonNodeData -ns UnitTestProject.Sample -f C:\\devel\\GitHub\\mug\\butterfly\\controller.metadata\\metadata\\85_1_65\\RealtimeBuffer_85_1_65.json --output C:\\devel\\GitHub\\code-gen\\UnitTestProject\\Sample"