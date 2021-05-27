using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class Region
    {
        public Dictionary<int, Cell[]> region = new Dictionary<int, Cell[]>(); 
    }
}
