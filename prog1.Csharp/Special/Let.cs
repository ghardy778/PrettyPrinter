// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            if (!p)
            {
                Console.Write("(");

            }
            Console.WriteLine("let");


            t.getCar().print(n + 4, true);
            t.getCdr().getCar().print(n + 4, false);
            t.getCdr().getCdr().printNewLine(n, false);
        }
    }
}


