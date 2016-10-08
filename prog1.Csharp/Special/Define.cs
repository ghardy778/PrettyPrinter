// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            //Done with the variable define, the function define still needs to be implemented
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


