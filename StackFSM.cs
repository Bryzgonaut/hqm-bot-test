using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM_Bot
{
    public class StackFSM
    {
        private Stack<Action> stack = new Stack<Action>();

        public void update()
        {
            Action currentStateFunction = getCurrentState();

            if (currentStateFunction != null)
            {
                getCurrentState();
            }
        }

        public Action popState()
        {
            return stack.Pop();
        }

        public void pushState(Action state)
        {
            if (getCurrentState() != state)
            {
                stack.Push(state);
            }
        }

        public Action getCurrentState()
        {
            return stack.Count > 0 ? stack.Peek() : null;

        }
    }
}
