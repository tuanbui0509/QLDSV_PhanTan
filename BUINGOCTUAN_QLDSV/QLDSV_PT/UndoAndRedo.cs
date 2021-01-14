using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV_PT
{
    class UndoAndRedo
    {
        public Stack<string> stack;
        public void pushStack(string statement)
        {
            stack.Push(statement);
        }
        public string popStack()
        {
            return stack.Pop();
        }

        public UndoAndRedo()
        {
            stack = new Stack<string>(15);
        }
    }
}
