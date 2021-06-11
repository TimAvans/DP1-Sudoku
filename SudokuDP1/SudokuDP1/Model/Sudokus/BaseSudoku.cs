using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model.Sudokus
{
    public abstract class BaseSudoku : ISudoku
    {
        public BaseSudoku()
        {
            Cells = new List<Cell>();
            Regions = new List<CompoundValidatable>();
        }
        public List<Cell> Cells { get; set; }
        public List<CompoundValidatable> Regions { get; set; }

        public void AcceptForRegions(IVisitor visitor)
        {
            foreach (CompoundValidatable cv in Regions)
            {
                cv.AcceptVisitor(visitor);
            }

            foreach(Cell c in Cells)
            {
                Console.WriteLine(c.isValidated);
            }
        }

        public virtual ISudoku Clone()
        {
            throw new NotImplementedException();
        }

        public virtual string Type()
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            foreach (IValidatable v in Regions)
            {
                if (!v.Validate())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
