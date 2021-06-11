﻿using SudokuDP1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Visitor
{
    public interface IVisitor
    {
        void VisitCompoundValidatable(CompoundValidatable compound);
    }
}
