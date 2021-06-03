using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Factory.Parser
{
    class SamuraiParser : IParser
    {
        public const string Type = "samuraiparser";

        public IParser Clone()
        {
            return (SamuraiParser)MemberwiseClone();
        }

        public List<int[]> Parse(List<string> file)
        {
            throw new NotImplementedException();
        }
        string IParser.Type()
        {
            return Type;
        }
    }
}
