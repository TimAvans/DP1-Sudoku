using SudokuDP1.FileReader;
using System.IO;

namespace SudokuDP1.Factory.Parser
{
    public class ConcreteParser
    {
        private ParserFactory factory;
        private Filereader fr;

        public ConcreteParser() 
        {
            factory = new ParserFactory();
            fr = new Filereader();
        }

        public void Parse(string location) 
        {
            System.Console.WriteLine(fr.GetSudokuType(Path.GetFileName(location)));
            var x = fr.ReadFile(location);
            System.Console.WriteLine(x[0]);
            factory.Create(fr.GetSudokuType(Path.GetFileName(location))).Parse(fr.ReadFile(location));          
        }
    }
}
