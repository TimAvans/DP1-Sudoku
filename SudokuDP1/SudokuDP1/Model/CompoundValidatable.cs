using SudokuDP1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuDP1.Model
{
    public class CompoundValidatable : IVisitable, IValidatable
    {
        public List<IValidatable> Children { get; set; }

        public string type { get; set; }

        public CompoundValidatable(List<IValidatable> children)
        {
            Children = children;
            this.type = type;
        }

        public void AcceptVisitor(IVisitor visitor)
        {
            visitor.VisitCompoundValidatable(this);
        }

        public bool Validate()
        {
            foreach(IValidatable child in Children)
            {
                if (!child.Validate())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
