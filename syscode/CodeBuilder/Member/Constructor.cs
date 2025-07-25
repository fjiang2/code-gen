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

namespace Sys.CodeBuilder
{
    public class Constructor : Member, IBuildable
    {

        public Arguments BaseArgs { get; set; }

        public Constructor(string constructorName)
            : base(constructorName)
        {
            base.Modifier = Modifier.Public;
            base.Type = null;
        }


        protected override string signature
        {
            get
            {
                CodeBlock block = new CodeBlock();
                block.AppendLine($"{Signature}({Params})");
                if (BaseArgs != null)
                {
                    block.Indent().Append($": base({BaseArgs})").Unindent();
                }

                return block.ToString();
            }
        }

    }
}
