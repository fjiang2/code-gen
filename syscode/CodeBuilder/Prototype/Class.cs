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

using Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sys.CodeBuilder
{
    public class Class : Prototype
    {
        private readonly List<Buildable> list = new List<Buildable>();

        public TypeInfo[] Inherits { get; set; }
        public bool Sorted { get; set; } = false;

        private readonly UniqueNameMaker uniqueNameMaker;

        public Class(string className)
            : this(className, new TypeInfo[] { })
        {
            //class name can be same as property/field name
            this.uniqueNameMaker = new UniqueNameMaker(className);
        }

        public Class(string className, params TypeInfo[] inherits)
            : base(className)
        {
            this.Inherits = inherits;
            base.Modifier = Modifier.Public;
        }

        public string ClassName => base.Name;

        public void Clear()
        {
            list.Clear();
        }

        public int Index => list.Count;

        public Class Add(Buildable code)
        {
            this.list.Add(code);
            code.Parent = this;
            return this;
        }

        public Class Insert(int index, Buildable code)
        {
            this.list.Insert(index, code);
            code.Parent = this;
            return this;
        }

        public Class AddRange(IEnumerable<Buildable> members)
        {
            foreach (var member in members)
                this.Add(member);

            return this;
        }

        public Constructor AddConstructor()
        {
            var constructor = new Constructor(ClassName);

            this.Add(constructor);
            return constructor;
        }

        public Field AddField<T>(Modifier modifier, string name, Value value = null)
        {
            var field = new Field(new TypeInfo { Type = typeof(T) }, name, value)
            {
                Modifier = modifier
            };

            this.Add(field);
            return field;
        }

        public Property AddProperty<T>(Modifier modifier, string name, object value = null)
        {
            var property = new Property(new TypeInfo { Type = typeof(T) }, name, value)
            {
                Modifier = modifier
            };

            this.Add(property);
            return property;
        }

        public Buildable AppendLine()
        {
            var builder = new Buildable();
            this.Add(builder);

            return builder;
        }

        public Directive AddMember(string text)
        {
            var member = new Directive(text);
            this.Add(member);
            return member;
        }

        private IEnumerable<Class> classes
        {
            get
            {
                return list
                    .Where(item => item is Class)
                    .Select(item => (Class)item);
            }
        }

        private IEnumerable<Constructor> constructors
        {
            get
            {
                return list
                    .Where(item => item is Constructor)
                    .Select(item => (Constructor)item);
            }
        }

        private IEnumerable<Field> fields
        {
            get
            {
                return list
                    .Where(item => item is Field)
                    .Select(item => (Field)item);
            }
        }

        private IEnumerable<Method> methods
        {
            get
            {
                return list
                    .Where(item => item is Method)
                    .Select(item => (Method)item);
            }
        }

        private IEnumerable<Property> properties
        {
            get
            {
                return list
                    .Where(item => item is Property)
                    .Select(item => (Property)item);
            }
        }



        protected override void BuildBlock(CodeBlock clss)
        {
            base.BuildBlock(clss);
            if (Comment != null)
            {
                Comment.Alignment = Alignment.Top;
                clss.AppendFormat($"{Comment}");
            }

            clss.AppendFormat("{0} class {1}", new ModifierString(Modifier), ClassName);
            if (Inherits.Length > 0)
                clss.AppendFormat("\t: {0}", string.Join(", ", Inherits.Select(inherit => inherit.ToString())));

            var body = new CodeBlock();

            if (Sorted)
            {
                var flds = fields.Where(fld => (fld.Modifier & Modifier.Const) != Modifier.Const);
                foreach (Field field in flds.OrderBy(fld => fld.Modifier))
                {
                    body.Add(field);
                }

                foreach (Constructor constructor in constructors)
                {
                    body.Add(constructor);
                    body.AppendLine();
                }

                foreach (Property property in properties)
                {
                    body.Add(property);

                    if (property.GetBlock().Count > 1)
                        body.AppendLine();
                }

                foreach (Method method in methods)
                {
                    body.Add(method);
                    body.AppendLine();
                }

                flds = fields.Where(fld => (fld.Modifier & Modifier.Const) == Modifier.Const);
                if (flds.Count() > 0)
                {
                    body.AppendLine();
                    foreach (Field field in flds)
                    {
                        body.Add(field);
                    }
                }

                foreach (Class _class in classes)
                {
                    body.Add(_class);
                    body.AppendLine();
                }
            }
            else
            {
                list.ForEach(
                    item => body.Add(item),
                    item =>
                        {
                            if (item.Count == 1 && (item is Field || item is Property))
                                return;

                            //if (item.Count == 1 && (item is Member))
                            //    return;

                            body.AppendLine();
                        }
                    );
            }

            clss.AddWithBeginEnd(body);
        }

        public void AddMethod(CommonMethodType type)
        {
            var rw = properties
                .Where(p => (p.Modifier & Modifier.Public) == Modifier.Public && p.CanRead && p.CanWrite)
                .Select(p => new PropertyInfo { PropertyName = p.Name });

            AddMethod(rw, type, isExtensionMethod: false);
        }

        public void AddMethod(IEnumerable<PropertyInfo> propertyNames, CommonMethodType methodType, bool isExtensionMethod)
        {
            var x = new CommonMethodGenerator(ClassName, propertyNames)
            {
                IsExtensionMethod = isExtensionMethod,
            };

            switch (methodType)
            {
                case CommonMethodType.Map:
                    Add(x.Map());
                    break;

                case CommonMethodType.Equals:
                    Add(x.Equals());
                    break;

                case CommonMethodType.Clone:
                    Add(x.Clone());
                    break;

                case CommonMethodType.Compare:
                    Add(x.Compare());
                    break;

                case CommonMethodType.Copy:
                    Add(x.Copy());
                    break;

                case CommonMethodType.GetHashCode:
                    Add(x._GetHashCode());
                    break;

                case CommonMethodType.ToDictionary:
                    Add(x.ToDictinary());
                    break;

                case CommonMethodType.FromDictionary:
                    Add(x.FromDictinary());
                    break;

                case CommonMethodType.ToString:
                    Add(x._ToString_v2());
                    break;



                case CommonMethodType.StaticCloneFrom:
                    Add(x.StaticCloneFrom());
                    break;

                case CommonMethodType.StaticCompareTo:
                    Add(x.StaticCompareTo());
                    break;

                case CommonMethodType.StaticCopyTo:
                    Add(x.StaticCopyTo());
                    break;

                case CommonMethodType.StaticToSimpleString:
                    Add(x.StaticToSimpleString());
                    break;
            }
        }



        /// <summary>
        /// make unique name in the class
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string MakeUniqueName(string name)
        {
            return uniqueNameMaker.ToUniqueName(name);
        }
    }
}
