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

namespace Sys.CodeBuilder
{

    class CodeLine
    {
        public static readonly CodeLine EmptyLine = new CodeLine();

        public CodeLine()
        {
        }

        internal static string Tab(int n) => CSharpBuilder.TheOption.Tab(n);

        public int tab { get; set; }
        public string Line { get; set; }


        public override string ToString()
        {
            var tabs = Tab(tab);
            return $"{tabs}{Line}";
        }
    }
}
