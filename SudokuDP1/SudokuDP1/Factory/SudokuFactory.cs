using SudokuDP1.Factory.Parser;
using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Factory
{
    class SudokuFactory : IFactory<ISudoku>
    {
        private Dictionary<string, ISudoku> Types = new Dictionary<string, ISudoku>();

        public SudokuFactory() { LoadTypes(); }

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(ISudoku)))
                {
                    FieldInfo field = type.GetField("Type");
                    if (field == null)
                        Console.WriteLine("There are no types");
                    else
                        Register(field.GetValue(null).ToString(),
                        (ISudoku)Activator.CreateInstance(type));
                }
            }
        }

        public void Register(string type, ISudoku parser)
        {
            Types[type] = parser;
        }

        public ISudoku Create(string type)
        {
            ISudoku tmp = Types[type];
            return tmp.Clone();
        }
    }
}
