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
                n = 0;
                t.getCar().print(n, true);
                n++;
                t.getCdr().print(n, true);
            }
            else
            {
                t.getCar().print(n, true);
                if (n == 0)
                    n++;
                t.getCdr().print(n, true);
            }
           
        }
    }
}


