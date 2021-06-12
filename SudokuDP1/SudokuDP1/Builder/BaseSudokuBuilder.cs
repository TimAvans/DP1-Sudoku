using SudokuDP1.Factory;
using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Builder
{
    public abstract class BaseSudokuBuilder : IBuilder<ISudoku>
    {
        protected ISudoku sudoku;
        private IFactory<ISudoku> factory;

        public List<char> CompoundTypes { get; set; }
        public BaseSudokuBuilder()
        {
            this.factory = new SudokuFactory();

            CompoundTypes = new List<char>() { 'R', 'Y', 'X' };
        }

        public void BuildSudoku(string type)
        {
            sudoku = factory.Create(type.ToLower());
        }

        public void BuildCells(List<Dictionary<string, int>> cell_data)
        {
            List<Cell> cells = new List<Cell>();
            foreach (var data in cell_data)
            {
                cells.Add(new Cell(data["value"], data["region"], data["superregion"], data["x"], data["y"]));
            }
            this.sudoku.Cells = cells;

            BuildCompounds();
        }

        public virtual void BuildCompounds()
        {
            List<Dictionary<int, List<IValidatable>>> dictionaries = new List<Dictionary<int, List<IValidatable>>>();

            foreach(char c in CompoundTypes)
            {
                dictionaries.Add(new Dictionary<int, List<IValidatable>>());
            }

            dictionaries = FillDictionaries(dictionaries);

            AddRegions(dictionaries);
        }

        public virtual List<Dictionary<int, List<IValidatable>>> FillDictionaries(List<Dictionary<int, List<IValidatable>>> dictionaries) 
        {
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
                    }
            }
            return dictionaries;
        }

        public virtual void AddRegions(List<Dictionary<int, List<IValidatable>>> dictionaries) 
        {
            foreach (var entry in dictionaries)
            {
                foreach (var data in entry.Values)
                    sudoku.Regions.Add(new CompoundValidatable(data));
            }
        }

        public Dictionary<int, List<IValidatable>> BuildRegion(Dictionary<int, List<IValidatable>> list, Cell cell)
        {
            if (!list.ContainsKey(cell.Region))
            {
                List<IValidatable> temp = new List<IValidatable>();
                temp.Add(cell);
                list.Add(cell.Region, temp);
            }
            else
            {
                list[cell.Region].Add(cell);
            }

            return list;
        }

        public Dictionary<int, List<IValidatable>> BuildColumn(Dictionary<int, List<IValidatable>> list, Cell cell)
        {
            if (!list.ContainsKey(cell.X))
            {
                List<IValidatable> temp = new List<IValidatable>();
                temp.Add(cell);
                list.Add(cell.X, temp);
            }
            else
            {
                list[cell.X].Add(cell);
            }

            return list;
        }

        public Dictionary<int, List<IValidatable>> BuildRow(Dictionary<int, List<IValidatable>> list, Cell cell)
        {
            if (!list.ContainsKey(cell.Y))
            {
                List<IValidatable> temp = new List<IValidatable>();
                temp.Add(cell);
                list.Add(cell.Y, temp);
            }
            else
            {
                list[cell.Y].Add(cell);
            }

            return list;
        }

        public ISudoku GetResult()
        {
            return this.sudoku;
        }

        public void BuildRows()
        {
            BuildCompounds();
        }

        public virtual IBuilder<ISudoku> Clone()
        {
            throw new NotImplementedException();
        }

        public virtual string Type()
        {
            return "Base";
        }
    }
}
