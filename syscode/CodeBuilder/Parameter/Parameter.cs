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
    public class Parameter
    {
        public TypeInfo Type { get; set; }

        public string Name { get; }

        public object Value { get; set; }

        public Parameter(TypeInfo type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public override string ToString()
        {
            if (Value == null)
                return string.Format("{0} {1}", Type, Name);
            else
                return string.Format("{0} {1} = {2}", Type, Name, Value);
        }
    }
}
