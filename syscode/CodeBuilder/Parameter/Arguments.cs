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
using System.Collections.Generic;

namespace Sys.CodeBuilder
{
    public class Arguments
    {
        private List<Argument> arguments { get; } = new List<Argument>();

        public Arguments(params Argument[] arguments)
        {
            this.arguments.AddRange(arguments);
        }

        public void Add(Argument argument)
        {
            this.arguments.Add(argument);
        }

        public override string ToString()
        {
            return string.Join(", ", arguments);
        }
    }
}
