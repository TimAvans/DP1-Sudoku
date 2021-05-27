using SudokuDP1.Model;
using System;
using System.Collections.Generic;


namespace SudokuDP1.Factory.Parser
{
    public class RegularParser : IParser
    {
        public const string Type = "regularparser";

        public RegularParser() { }

        public IParser Clone()
        {
            return (IParser)MemberwiseClone();
        }

        public void Parse(List<string> file)
        {
            //Grid array
            // -> subrosters -> cells
            double regionsize = Math.Sqrt(file[0].Length);
            double nrows = regionsize / (regionsize / Math.Floor(Math.Sqrt(regionsize)));
            double regionrowsize = regionsize / nrows;


            Dictionary<int, Region> grid = new Dictionary<int, Region>();

            foreach (char c in file[0])
            {


            }
        }
        string IParser.Type()
        {
            return Type;
        }
    }
}
