// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            // DONE TODO: Implement this function.
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

