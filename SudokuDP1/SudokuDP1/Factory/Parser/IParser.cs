using System.Collections.Generic;

namespace SudokuDP1.Factory.Parser
{
    public interface IParser
    {
        void Parse(List<string> file);
        IParser Clone();
        string Type();
    }
}
