// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        // TODO: Add any fields needed.
    
        // TODO: Add an appropriate constructor.
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
  
            // Done TODO: Implement this function.
   //         for (int i = 0; i < n; i++)
     //               Console.Write(" ");
            if (!p)
            {
                Console.Write("(");
                t.getCar().print(0, true);
                t.getCdr().print(1, true);
            }
            else
            {
                t.getCar().print(1, true);
                t.getCdr().print(1, true);
            }
           
        }
    }
}


