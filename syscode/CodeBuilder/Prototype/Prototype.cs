//--------------------------------------------------------------------------------------------------//
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.CodeBuilder
{
    /// <summary>
    /// Prototype is minimum unit ot create a source code file
    /// such as class/struct/enum files
    /// </summary>
    public class Prototype : Declare
    {
        public string Prefix { get; set; }

        /// <summary>
        /// Relative namespace segements
        /// </summary>
        public List<string> Namespaces { get; set; } = new List<string>();
        public List<string> Usings { get; set; } = new List<string>();

        public Prototype(string name)
            : base(name)
        {
        }

        public string RelativeNamespace => string.Join(".", Namespaces);
        public string Subdirectory => string.Join("\\", Namespaces);

        public CSharpBuilder Builder => this.Parent as CSharpBuilder;

    }
}
