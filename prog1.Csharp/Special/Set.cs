// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set() { }
	 
        //Treat the same as regular
        public override void print(Node t, int n, bool p)
        {
            
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

