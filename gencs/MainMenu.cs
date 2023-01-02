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

        public MainMenu(IConfiguration configuration)
        {
            this.setting = new Setting(configuration);
            this.shell = new Shell();
        }
        public int Run(string[] args, string title)
        {
            RootCommand rootCommand = new RootCommand(title)
            {
                ViewModelCommand(),
                //SendBatchCommand(),
                //ReceiveCommand(),
                //TriggerCommand(),
                //ListSessionsCommand(),
                //AuthorizeCommand(),

            };

            int exit = rootCommand.InvokeAsync(args).Result;
            return exit;
        }

        private Command ViewModelCommand()
        {
            var usingsOption = new Option<IEnumerable<string>>(new[] { "-u", "--using" }, () => setting.Usings, $"C# reference.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            var nameSpaceOption = new Option<string>(new[] { "-ns", "--namespace" }, () => setting.NameSpace, $"Namespace of view model.");
            var classNameOption = new Argument<string>("class", () => setting.ClassName, $"Class name of view model.");
            var basesOption = new Option<IEnumerable<string>>(new[] { "-b", "--base" }, () => setting.Bases, $"Base class or interface.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            var fieldsOption = new Option<IEnumerable<string>>(new[] { "-f", "--field" }, () => setting.Fields, $"Private fields of view model, pattern:type+variable.")
            {
                AllowMultipleArgumentsPerToken = true
            };

            var outputOption = new Option<string>(new[] { "-o", "--output" }, () => setting.NameSpace, $"Out directory of class file.");


            var cmd = new Command("view-model", "Generate view model class.")
            {
                usingsOption, nameSpaceOption, 
                classNameOption, basesOption,
                fieldsOption,
                outputOption,
            };
            
            cmd.SetHandler(shell.GenerateViewModel,
                new ClassInfoBinder(usingsOption, nameSpaceOption, classNameOption, basesOption),
                fieldsOption, outputOption
                );

            return cmd;
        }

    }
}
