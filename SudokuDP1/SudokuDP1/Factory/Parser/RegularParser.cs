using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Factory.Parser
{
    public class RegularParser : IParser
    {
        public const string Type = "RegularParser";

        public IParser Clone()
        {
            return (IParser)MemberwiseClone();
        }

        public void Parse()
        {
            throw new NotImplementedException();
        }
        string IParser.Type()
        {
            return Type;
        }
    }
}
