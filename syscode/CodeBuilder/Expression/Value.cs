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
using System.Linq;

namespace Sys.CodeBuilder
{

    public class Value : Buildable
    {
        public TypeInfo Type { get; set; } = TypeInfo.Anonymous;
        public ValueOutputFormat Format { get; set; } = ValueOutputFormat.MultipleLine;
        public int ArrayColumnNumber { get; set; } = 1;

        private readonly object value;

        public Value(object value)
        {
            this.value = value;
        }

        public Value(New value)
        {
            this.value = value;
        }

        public Value(string value)
        {
            this.value = value;
        }

        public Value(Array value)
        {
            this.value = value;
        }

        public Value(Dictionary<object, object> value)
        {
            this.value = value;
        }

        private Value NewValue(object value)
        {
            if (value is Value)
                return (Value)value;

            return new Value(value)
            {
                Format = Format
            };
        }

        private Dictionary<string, Value> objectValue => value as Dictionary<string, Value>;

        public void AddProperty(string propertyName, Value value)
        {
            if (objectValue == null)
                throw new Exception("object property is initialized, use new Value()");

            if (objectValue.ContainsKey(propertyName))
                throw new Exception($"duplicated property name:{propertyName}");

            objectValue.Add(propertyName, value);
        }

        protected override void BuildBlock(CodeBlock block)
        {
            base.BuildBlock(block);

            switch (value)
            {
                case Value x:
                    x.BuildBlock(block);
                    break;

                case New instance:
                    block.Add(instance);
                    break;

                case Array A:
                    if (Type == TypeInfo.Anonymous)
                        Type = new TypeInfo { Type = A.GetType() };
                    block.Append($"new {Type}");
                    WriteArrayValue(block, A, ArrayColumnNumber);
                    break;

                case Dictionary<object, object> dict:
                    block.Append($"new {Type}");
                    WriteDictionary(block, dict);
                    break;

                case Dictionary<string, Value> properties:
                    block.Append($"new {Type}");
                    WriteList(block, properties);
                    break;

                default:
                    block.Append(Primitive.ToPrimitive(value));
                    break;
            }
        }

        private void WriteArrayValue(CodeBlock block, Array A, int columnNumber)
        {
            Type ty = Type.GetElementType();

            if (ty != null && ty.IsPrimitive)
            {
                if (A.Length < 30)
                {
                    Format = ValueOutputFormat.SingleLine;
                }
                else if (A.Length < 100)
                {
                    Format = ValueOutputFormat.Wrap;
                    columnNumber = 10;
                }
                else
                {
                    Format = ValueOutputFormat.Wrap;
                    columnNumber = 20;
                }
            }

            switch (Format)
            {

                case ValueOutputFormat.SingleLine:
                    block.Append("{");
                    A.OfType<object>().ForEach(
                         x =>
                         {
                             NewValue(x).BuildBlock(block);
                         },
                         _ => block.Append(",")
                         );

                    block.Append("}");
                    break;



                case ValueOutputFormat.Wrap:
                    block.Begin();
                    for (int i = 0; i < A.Length; i++)
                    {
                        if (i % columnNumber == 0)
                            block.AppendLine();

                        if (i != 0 && i % (columnNumber * 10) == 0)     //add empty line every 10 lines
                            block.AppendLine();

                        Value item = NewValue(A.GetValue(i));
                        item.BuildBlock(block);

                        if (i != A.Length - 1)
                            block.Append(",");
                    }

                    block.End();
                    break;

                default: //MultipleLine
                    block.Begin();
                    block.AppendLine();
                    for (int i = 0; i < A.Length; i++)
                    {
                        if (i != 0 && i % columnNumber == 0)
                        {
                            block.AppendLine();
                        }

                        //block.AppendLine();
                        Value item = NewValue(A.GetValue(i));
                        item.BuildBlock(block);

                        if (i != A.Length - 1)
                            block.Append(",");

                    }

                    block.End();
                    break;
            }
        }

        private void WriteList(CodeBlock block, IDictionary<string, Value> properties)
        {

            switch (Format)
            {
                case ValueOutputFormat.SingleLine:
                    block.Append("{");
                    properties.ForEach(
                         kvp =>
                         {
                             string key = Primitive.ToPrimitive(kvp.Key);
                             block.Append($"{key} = ");
                             kvp.Value.BuildBlock(block);
                         },
                         _ => block.Append(",")
                         );

                    block.Append("}");
                    break;

                default:
                    block.Begin();

                    properties.ForEach(
                        kvp =>
                        {
                            block.AppendLine();
                            string key = kvp.Key;
                            block.Append($"{key} = ");
                            kvp.Value.BuildBlock(block);
                        },
                        _ => block.Append(",")
                        );

                    block.End();
                    break;
            }
        }

        private void WriteDictionary(CodeBlock block, Dictionary<object, object> dict)
        {

            switch (Format)
            {
                case ValueOutputFormat.SingleLine:
                    block.Append("{");
                    dict.ForEach(
                         kvp =>
                         {
                             string key = Primitive.ToPrimitive(kvp.Key);
                             block.Append($"[{key}] = ");
                             NewValue(kvp.Value).BuildBlock(block);
                         },
                         _ => block.Append(",")
                         );

                    block.Append("}");
                    break;

                default:
                    block.Begin();

                    dict.ForEach(
                        kvp =>
                            {
                                block.AppendLine();
                                string key = Primitive.ToPrimitive(kvp.Key);
                                block.Append($"[{key}] = ");
                                NewValue(kvp.Value).BuildBlock(block);
                            },
                        _ => block.Append(",")
                        );

                    block.End();
                    break;
            }
        }


        public static implicit operator Value(New value)
        {
            return new Value(value);
        }
    }

}
