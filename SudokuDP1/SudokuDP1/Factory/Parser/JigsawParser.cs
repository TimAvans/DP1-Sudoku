using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Factory.Parser
{
    class JigsawParser : IParser
    {
        public const string Type = "jigsawparser";

        public IParser Clone()
        {
            return (JigsawParser)MemberwiseClone();
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
