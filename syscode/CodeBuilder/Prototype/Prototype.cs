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

using System.Collections.Generic;
using System.IO;

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
        /// Relative namespace segements.The root namespcae is defined on CSharpBuilder.Namespace
        /// </summary>
        public IList<string> Subnamespace { get; set; } = new List<string>();

        /// <summary>
        /// Relative using directive
        /// </summary>
        internal IList<string> Subusings { get; } = new List<string>();

        public Prototype(string name)
            : base(name)
        {
        }

        /// <summary>
        /// File directory structure matches namespace.
        /// </summary>
        public string Subdirectory => string.Join(Path.DirectorySeparatorChar.ToString(), Subnamespace);

        /// <summary>
        /// Add using segments.e.g. AddUsing("System","IO")
        /// </summary>
        /// <param name="subnamespace"></param>
        public void AddSubusing(IEnumerable<string> subnamespace)
        {
            AddSubusing(string.Join(".", subnamespace));
        }

        public void AddSubusing(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && Subusings.IndexOf(name) == -1)
            {
                Subusings.Add(name);
            }
        }

        public CSharpBuilder Builder => this.Parent as CSharpBuilder;

    }
}
