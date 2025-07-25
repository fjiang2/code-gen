﻿//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        syscode(C# Code Builder)                                                                  //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.IO;

namespace Sys.CodeBuilder
{
    public class CSharpBuilder : Buildable
    {
        public string Namespace { get; set; } = "Sys.Unknown";

        private readonly Lazy<Usings> lazyUsings;
        private readonly List<Prototype> classes = new List<Prototype>();

        public CSharpBuilder()
        {
            lazyUsings = new Lazy<Usings>(() => new Usings(Option));
        }

        public Option Option
        {
            get => TheOption;
            set => TheOption = value;
        }

        internal static Option TheOption = new Option();

        private Usings Usings => lazyUsings.Value;

        public CSharpBuilder AddUsing(string name)
        {
            Usings.AddUsing(name);
            return this;
        }

        public CSharpBuilder AddUsingRange(IEnumerable<string> names)
        {
            foreach (var name in names)
                AddUsing(name);

            return this;
        }

        public CSharpBuilder AddClass(Class clss)
        {
            classes.Add(clss);
            clss.Parent = this;
            return this;
        }

        public CSharpBuilder AddEnum(EnumType _enum)
        {
            classes.Add(_enum);
            _enum.Parent = this;
            return this;
        }

        protected override void BuildBlock(CodeBlock block)
        {
            block.Add(Usings.GetBlock());

            block.AppendLine();

            block.AppendFormat("namespace {0}", this.Namespace);

            var c = new CodeBlock();

            classes.ForEach(
                    clss => c.Add(clss.GetBlock()),
                    clss => c.AppendLine()
                );

            block.AddWithBeginEnd(c);
        }

        public void Output(TextWriter writer)
        {
            writer.Write(this.ToString());
        }

        /// <summary>
        /// Create a file for all classes.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string Output(string directory, string fileName)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string code = this.ToString();
            string file = Path.ChangeExtension(Path.Combine(directory, fileName), "cs");
            File.WriteAllText(file, code);
            return file;
        }


        /// <summary>
        /// Create class files in the directory. Each class has its own file.
        /// </summary>
        /// <param name="directory"></param>
        public void Output(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            foreach (Prototype clss in classes)
            {
                CodeBlock block = new CodeBlock();
                block.Add(Usings.GetBlock());

                if (clss.Subusings.Count > 0)
                {
                    foreach (var name in clss.Subusings)
                    {
                        block.AppendLine($"using {this.Namespace}.{name};");
                    }
                }

                string ns = this.Namespace;
                if (clss.Subnamespace.Count > 0)
                {
                    string subns = string.Join(".", clss.Subnamespace);
                    ns = $"{ns}.{subns}";
                }

                block.AppendLine();
                block.Append($"namespace {ns}");

                var c = new CodeBlock();
                c.Add(clss.GetBlock());
                block.AddWithBeginEnd(c);

                string code = block.ToString();

                string folder = directory;
                if (!string.IsNullOrEmpty(clss.Subdirectory))
                {
                    folder = Path.Combine(directory, clss.Subdirectory);
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);
                }

                string file = Path.ChangeExtension(Path.Combine(folder, clss.Name), "cs");
                File.WriteAllText(file, code);
            }
        }
    }
}
