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
        }

        public override void BuildCompounds()
        {
            List<CompoundValidatable> SuperRegions = new List<CompoundValidatable>();

            List<Dictionary<int, List<IValidatable>>> dictionaries = new List<Dictionary<int, List<IValidatable>>>();
            foreach (char c in CompoundTypes)
            {
                dictionaries.Add(new Dictionary<int, List<IValidatable>>());
            }

            for (int r = 0; r < 5; r++)
            {

                for (int i = 0 + (r * sudoku.Cells.Count / 5); i < sudoku.Cells.Count / 5; i++)
                {
                    int counter = 0;
                    foreach(char c in CompoundTypes)
                    {
                        switch (c)
                        {
                            case 'R':
                                dictionaries[counter] = BuildRegion(dictionaries[counter], sudoku.Cells[i]);
                                break;
                            case 'Y':
                                dictionaries[counter] = BuildRow(dictionaries[counter], sudoku.Cells[i]);
                                break;
                            case 'X':
                                dictionaries[counter] = BuildColumn(dictionaries[counter], sudoku.Cells[i]);
                                break;
                        }
                        counter++;
                    }
                }

                List<IValidatable> RowsRegionsColumns = new List<IValidatable>();
                foreach (var entry in dictionaries)
                {
                    foreach (var data in entry.Values)
                    {
                        RowsRegionsColumns.Add(new CompoundValidatable(data));
                    }
                }

                SuperRegions.Add(new CompoundValidatable(RowsRegionsColumns));
            }

            foreach (CompoundValidatable compound in SuperRegions)
            {
                sudoku.Regions.Add(compound);
            }
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
