using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Builder
{
    public class SamuraiSudokuBuilder : BaseSudokuBuilder
    {
        public const string TYPE = "samurai";

        public SamuraiSudokuBuilder() : base()
        {
            CompoundTypes.Add('S');
        }

        public override void BuildCompounds()
        {
            List<Dictionary<int, List<IValidatable>>> dictionaries = new List<Dictionary<int, List<IValidatable>>>();
            foreach (char c in CompoundTypes)
            {
                dictionaries.Add(new Dictionary<int, List<IValidatable>>());
            }

            for (int i = 0; i < CompoundTypes.Count; i++)
            {
                foreach (Cell cell in sudoku.Cells)
                    switch (CompoundTypes[i])
                    {
                        case 'R':
                            dictionaries[i] = BuildRegion(dictionaries[i], cell);
                            break;
                        case 'Y':
                            dictionaries[i] = BuildRow(dictionaries[i], cell);
                            break;
                        case 'X':
                            dictionaries[i] = BuildColumn(dictionaries[i], cell);
                            break;
                        case 'S':
                            dictionaries[i] = BuildSuperRegion();
                            break;
                    }
            }

            foreach (var entry in dictionaries)
            {
                foreach (var data in entry.Values)
                    sudoku.Regions.Add(new CompoundValidatable(data));
            }
        }

        public Dictionary<int, List<IValidatable>> BuildSuperRegion()
        {
            throw new NotImplementedException();
        }

        public override IBuilder<ISudoku> Clone()
        {
            return (SamuraiSudokuBuilder)MemberwiseClone();
        }

        public override string Type()
        {
            return TYPE;
        }
    }
}
