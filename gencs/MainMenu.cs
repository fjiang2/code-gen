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


        public MainMenu(IConfiguration configuration)
        {
            this.setting = new Setting(configuration);
            this.shell = new Shell();


            usingsOption = new Option<IEnumerable<string>>(new[] { "-u", "--using" }, () => setting.Usings, $"C# reference.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            nameSpaceOption = new Option<string>(new[] { "-ns", "--namespace" }, () => setting.NameSpace, $"Namespace of view model.");
            classNameOption = new Argument<string>("class", () => setting.ClassName, $"Class name of view model.");
            basesOption = new Option<IEnumerable<string>>(new[] { "-b", "--base" }, () => setting.Bases, $"Base class or interface.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            outputOption = new Option<string>(new[] { "-o", "--output" }, () => setting.Output, $"Directory of class file generated.");
        }


        public int Run(string[] args, string title)
        {
            RootCommand rootCommand = new RootCommand(title)
            {
                ViewModelCommand(),
                //SendBatchCommand(),
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
                new ClassInfoBinder(usingsOption, nameSpaceOption, classNameOption, basesOption),
                propertiesOption, outputOption
                );

            return cmd;
        }

    }
}
