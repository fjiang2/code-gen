# C# Code Generation (gencs)

## Environment Variable

### Variable List

- GENCS_NAMESPACE

    Default namespace

- GENCS_CLASS_NAME

    Default class name

- GENCS_OUTPUT

    Default output directory

### Command Prompt Examples

- SET GENCS_NAMESPACE=gencs.app.data
- SET GENCS_OUTPUT=C:\code
- SET GENCS_CLASS_NAME=Program

### PowerShell Examples

- $env:GENCS_NAMESPACE='gencs.app.data'
- $env:GENCS_OUTPUT='C:\code'
- $env:GENCS_CLASS_NAME='Program'

## gencs Commands

### View Model

    Create view model class:

    ./gencs.exe view-model UserViewModel -ns Project.ViewModels -p string+Name -p int?+Age --output "C:\temp"

### Json Node

    Create JsonNode feild and value:
    ./gencs.exe json-node UserJsonData -ns Project.Sample -f "sample.json" --output "C:\temp"
