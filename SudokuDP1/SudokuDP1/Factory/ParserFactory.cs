﻿using SudokuDP1.Factory.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Factory
{
    public class ParserFactory : IFactory
    {
        public Dictionary<string, IParser> types = new Dictionary<string, IParser>();

        public ParserFactory() { LoadTypes(); }

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(IParser)))
                {
                    FieldInfo field = type.GetField("Type");
                    if (field == null)
                        Console.WriteLine("There are no types");
                    else
                        Register(field.GetValue(null).ToString(),
                            (IParser)Activator.CreateInstance(type));
                }
            }
        }

        public void Register(string type, IParser parser) 
        {
            types[type] = parser;
        }

        public IParser Create(string type)
        {
            IParser tmp = types[type];
            return tmp.Clone();
        }
    }
}
