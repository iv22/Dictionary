using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dictionary
{
    public abstract class AbstractOperationController
    {
        public Model model { get; protected set; }

        public abstract void ExecOperation();
    }
}
