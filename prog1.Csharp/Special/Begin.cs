// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            if (!p)
            {
                Console.Write("(");
     
            }
            Console.WriteLine("begin");
            
            
            t.getCar().print(n+4, true);
            t.getCdr().getCar().print(n+4, false);
            t.getCdr().getCdr().printNewLine(n, false);
            
        }
    }
}

