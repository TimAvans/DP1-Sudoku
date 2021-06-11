using System.Collections.Generic;

namespace SudokuDP1.Factory.Parser
{
    public interface IParser
    {
        List<Dictionary<string, int>> Parse(List<string> file);
        IParser Clone();
        string Type();
    }
}
