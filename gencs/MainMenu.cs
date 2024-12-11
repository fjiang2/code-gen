using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gencs.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace gencs
{
    internal class MainMenu
    {
        private readonly Setting setting;
        private readonly Shell shell;

        private readonly Option<IEnumerable<string>> usingsOption;
        private readonly Option<string> nameSpaceOption;
        private readonly Argument<string> classNameOption;
        private readonly Option<IEnumerable<string>> basesOption;
        private readonly Option<string> outputOption;

        private ClassInfoBinder classInfoBinder;

        public MainMenu(IConfiguration configuration)
        {
            this.setting = new Setting(configuration);
            this.shell = new Shell();


            usingsOption = new Option<IEnumerable<string>>(new[] { "-u", "--using" }, () => setting.Usings, $"C# reference.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            nameSpaceOption = new Option<string>(new[] { "-ns", "--namespace" }, () => setting.NameSpace, $"Namespace.");
            classNameOption = new Argument<string>("class", () => setting.ClassName, $"Class name.");
            basesOption = new Option<IEnumerable<string>>(new[] { "-b", "--base" }, () => setting.Bases, $"Base class or interface.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            outputOption = new Option<string>(new[] { "-o", "--output" }, () => setting.Output, $"Directory of class file generated.");

            classInfoBinder = new ClassInfoBinder(usingsOption, nameSpaceOption, classNameOption, basesOption);
        }


        public int Run(string[] args, string title)
        {
            RootCommand rootCommand = new RootCommand(title)
            {
                ViewModelCommand(),
                JsonClassCommand(),
                JsonNodeCommand(),
                //ReceiveCommand(),
            };

            int exit = rootCommand.InvokeAsync(args).Result;
            return exit;
        }

        private Command ViewModelCommand()
        {

            var propertiesOption = new Option<IEnumerable<string>>(new[] { "-p", "--property" }, () => setting.Fields, $"Properties of view model, pattern:type+variable.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            var cmd = new Command("view-model", "Generate view model class.")
            {
                usingsOption, nameSpaceOption,
                classNameOption, basesOption,
                propertiesOption,
                outputOption,
            };

            cmd.SetHandler(shell.GenerateViewModel,
                classInfoBinder,
                propertiesOption, outputOption
                );

            return cmd;
        }

        private Command JsonNodeCommand()
        {

            var fileOption = new Option<string>(new[] { "-f", "--file" }, "Json file name.")
            {
                AllowMultipleArgumentsPerToken = false
            };

            var cmd = new Command("json-node", "Generate data class in JsonNode.")
            {
                usingsOption, nameSpaceOption,
                classNameOption, basesOption,
                fileOption,
                outputOption,
            };

            cmd.SetHandler(shell.GenerateJsonNode,
                classInfoBinder,
                fileOption, outputOption
                );

            return cmd;
        }

        private Command JsonClassCommand()
        {

            var propertiesOption = new Option<IEnumerable<string>>(new[] { "-p", "--property" }, () => setting.Fields, $"Properties of class, pattern:type+variable+name.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            var dtoTypeOption = new Option<string>(new[] { "-t", "--type" }, () => setting.DtoType, $"class type, dj:Data Contract Json, nj:NewtonSoft Json, mj:Microsoft Json.");

            var cmd = new Command("dto-class", "Generate data transfer object class.")
            {
                usingsOption, nameSpaceOption,
                classNameOption, basesOption,
                propertiesOption, dtoTypeOption,
                outputOption,
            };

            cmd.SetHandler(shell.GenerateDtoClass,
                classInfoBinder,
                propertiesOption, dtoTypeOption,
                outputOption
                );

            return cmd;
        }
    }
}
