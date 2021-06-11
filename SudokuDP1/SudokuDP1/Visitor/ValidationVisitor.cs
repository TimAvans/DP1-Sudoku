using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Visitor
{
    public class ValidationVisitor : IVisitor
    {
        public void VisitCompoundValidatable(CompoundValidatable compound)
        {
            int amountCellsInRegion = 0;

            foreach(Cell cell in compound.Children)
            {
                cell.isValidated = true;
            }

            foreach (Cell celli in compound.Children)
            {
                foreach (Cell cellt in compound.Children)
                {
                    //don't compare it to itself
                    if (celli != cellt)
                    {
                        if (celli.X == cellt.X ||
                            celli.Y == cellt.Y ||
                            celli.Region == cellt.Region)
                        {
                            celli.isValidated = celli.Validate();
                            if (celli.Value == cellt.Value)
                            {
                                celli.isValidated = false;
                                cellt.isValidated = false;
                            }
                        }
                    }
                }
                amountCellsInRegion++;
            }
        }
    }
}