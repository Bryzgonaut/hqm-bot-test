using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HockeyEditor;

namespace FSM_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryEditor.Init();


            StackFSM AI = new StackFSM();
            AI.pushState("testState");
            AI.pushState("testState1");
            AI.pushState("testState2");
            AI.popState();
            Console.Write(AI.getCurrentState());
            Console.Read();




        }
    }

    public class StackFSM
    {
        private Stack<string> stack = new Stack<string>();

        public void update()
        {
            string currentStateFunction = getCurrentState();

            if (currentStateFunction != null)
            {
                getCurrentState();
            }
        }

        public string popState()
        {
            return stack.Pop();
        }

        public void pushState(string state)
        {
            if (getCurrentState() != state)
            {
                stack.Push(state);
            }
        }

        public string getCurrentState()
        {
            return stack.Count > 0 ? stack.Peek() : null;
            //return stack.Count > 0 ? stack.ElementAt(stack.Count - 1) : null;
            //test stack.peek()
        }
    }

    

    public class Bot
    {
        Player m_player = PlayerManager.Players[1];

        public void returnToSpawn()
        {
            HQMVector mySpawn = m_player.Position;
            SkateTowards(mySpawn);
        }



    }
}
