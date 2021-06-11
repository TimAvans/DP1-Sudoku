using SudokuDP1.Factory;
using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Builder
{
    class SudokuBuilder : IBuilder<ISudoku>
    {
        private ISudoku sudoku;
        private IFactory<ISudoku> factory;

        public SudokuBuilder()
        {
            this.factory = new SudokuFactory();
        }
       
        public void BuildSudoku(string type)
        {
            sudoku = factory.Create(type.ToLower());
            functions[type]();
        }
        
        public void BuildCells(List<int[]> cell_data)
        {
            List<Cell> cells = new List<Cell>();
            foreach (int[] data in cell_data)
            {
                cells.Add(new Cell(data[0], data[1], data[2], data[3]));
            }
            this.sudoku.Cells = cells;
        }

        public void BuildRows()
        {
            Dictionary<int, List<Cell>> cells = new Dictionary<int, List<Cell>>();

            foreach(Cell cell in sudoku.Cells)
            {
                if (!cells.ContainsKey(cell.Y))
                {
                    List<Cell> temp = new List<Cell>();
                    temp.Add(cell);
                    cells.Add(cell.Y, temp);
                } else
                {
                    cells[cell.Y].Add(cell);
                }
            }

            foreach(KeyValuePair<int, List<Cell>> entry in cells)
            {
                sudoku.Children.Add(new Row(entry.Value));
            }
        }

        public void BuildRegions()
        {
            Dictionary<int, List<Cell>> cells = new Dictionary<int, List<Cell>>();

            foreach (Cell cell in sudoku.Cells)
            {
                if (!cells.ContainsKey(cell.Region))
                {
                    List<Cell> temp = new List<Cell>();
                    temp.Add(cell);
                    cells.Add(cell.Region, temp);
                }
                else
                {
                    cells[cell.Region].Add(cell);
                }
            }

            foreach (KeyValuePair<int, List<Cell>> entry in cells)
            {
                sudoku.Children.Add(new Region(entry.Value));
            }
        }

        public void BuildColumns()
        {
            Dictionary<int, List<Cell>> cells = new Dictionary<int, List<Cell>>();

            foreach (Cell cell in sudoku.Cells)
            {
                if (!cells.ContainsKey(cell.X))
                {
                    List<Cell> temp = new List<Cell>();
                    temp.Add(cell);
                    cells.Add(cell.X, temp);
                }
                else
                {
                    cells[cell.X].Add(cell);
                }
            }

            foreach (KeyValuePair<int, List<Cell>> entry in cells)
            {
                sudoku.Children.Add(new Column(entry.Value));
            }
        }

        public ISudoku GetResult()
        {
            return this.sudoku;
        }
    }
}
