using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.FileReader
{
    public class Filereader
    {
        public string GetSudokuType(string location) 
        {
            return location.Split('.')[1].Any(char.IsDigit) ? "regularparser" : location.Split('.')[1] + "parser";
        }

        public List<string> ReadFile(string location) 
        {
            List<string> lines = File.ReadAllLines(location).ToList();
            return lines;
        }

    }
}
