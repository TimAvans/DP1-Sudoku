using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class Cell : IValidatable
    {
        private int? _value;
        public int? Value { get { return _value; }
            set
            {
                if (value > 0)
                {
                    _value = value;
                }
                else
                {
                    _value = null;
                }
            } 
        }

        public bool isValidated { get; set; }

        public int Region { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Cell(int value, int reg, int x, int y) 
        {
            this.Value = value;

            this.Region = reg;
            this.X = x;
            this.Y = y;
        }

        public bool Validate()
        {
            return Value != null;
        }
    }
}
