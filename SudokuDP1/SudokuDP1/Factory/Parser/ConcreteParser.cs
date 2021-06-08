using SudokuDP1.FileReader;
using System.Collections.Generic;
using System.IO;

namespace SudokuDP1.Factory.Parser
{
    public class ConcreteParser
    {
        private IFactory<IParser> factory;
        
        public Filereader FileReader { get; set; }

        public ConcreteParser() 
        {
            factory = new ParserFactory();
            FileReader = new Filereader();
        }

        public List<int[]> Parse(string location) 
        {
            System.Console.WriteLine(FileReader.GetSudokuType(Path.GetFileName(location)));
            var x = FileReader.ReadFile(location);
            System.Console.WriteLine(x[0]);
            return factory.Create(FileReader.GetSudokuType(Path.GetFileName(location))).Parse(FileReader.ReadFile(location));          
        }
    }
}
