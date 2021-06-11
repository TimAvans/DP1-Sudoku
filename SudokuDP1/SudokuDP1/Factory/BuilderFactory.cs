using SudokuDP1.Builder;
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
    public class BuilderFactory : IFactory<IBuilder<ISudoku>>
    {
        private Dictionary<string, IBuilder<ISudoku>> Types = new Dictionary<string, IBuilder<ISudoku>>();

        public BuilderFactory() { LoadTypes(); }

        public void LoadTypes()
        {
            Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterfaces().Contains(typeof(IBuilder<ISudoku>)))
                {
                    FieldInfo field = type.GetField("TYPE");
                    if (field == null)
                        Console.WriteLine("There are no types");
                    else
                        Register(field.GetValue(null).ToString(),
                            (IBuilder<ISudoku>)Activator.CreateInstance(type));
                }
            }
        }

        public void Register(string type, IBuilder<ISudoku> parser)
        {
            Types[type] = parser;
        }

        public IBuilder<ISudoku> Create(string type)
        {
            IBuilder<ISudoku> tmp = Types[type];
            return tmp.Clone();
        }
    }
}
