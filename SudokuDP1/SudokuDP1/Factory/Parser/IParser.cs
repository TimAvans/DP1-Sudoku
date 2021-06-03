using System.Collections.Generic;

namespace SudokuDP1.Factory.Parser
{
    public interface IParser
    {
        List<int[]> Parse(List<string> file);
        IParser Clone();
        string Type();
    }
}
