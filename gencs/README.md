# Tool of C# Code Generation (gencs)

## gencs Commands

- View Model

    Create view model class:

./gencs.exe view-model UserViewModel -ns Mileage.ViewModels -p string+Name -p int?+Age --output "C:\devel\GitHub\mileage\Eux\Mileage\ViewModels"

- Mvvm Template

    Create Mvvm Model/ViewModel/View class:

./gencs.exe mvvm-template -ns Tmdd.WPF -m TmddOwnerCenter -v TmddOwnerCenterTree --output "C:\src\trafficware\atms\Tmdd.WPF"

- Json Node

    Create JsonNode field and value:

./gencs.exe json-node UserJsonData -ns Project.Sample -f "sample.json" --output "C:\temp"



### lanuchSettings.json
- "commandLineArgs": "view-model UserViewModel -ns App.View.Model -p string+Name -p int?+Age"
- "commandLineArgs": "json-node JsonNodeData -ns UnitTestProject.Sample -f C:\\devel\\GitHub\\mug\\butterfly\\controller.metadata\\metadata\\85_1_65\\RealtimeBuffer_85_1_65.json --output C:\\devel\\GitHub\\code-gen\\UnitTestProject\\Sample"
- "commandLineArgs": "json-node GeoIntersection2 -ns UnitTestProject.Sample -f C:\\spm\\data\\backup\\GEO_2.json --output C:\\spm\\data\\backup"
- "commandLineArgs": "mvvm-template -ns Tmdd.WPF -m TmddOwnerCenter -v TmddOwnerCenterTree --output \"C:\\src\\trafficware\\atms\\Tmdd.WPF\""