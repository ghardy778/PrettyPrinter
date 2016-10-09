// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Cond() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Console.Write("(");

            }
            Console.WriteLine("cond");

            Node cdr = t.getCdr();

            //While cdr is a cons,
            //we indent the required spaces
            //print the car of the cdr
            //Write new line
            //Then move the cdr to the next cdr.
            while (cdr.isPair())
            {
                t.getCar().print(n + 4, true);  //This indents our printer by calling the same identifier call that just prints n spaces
                cdr.getCar().print(n + 4, false);
                Console.WriteLine("");
                cdr = cdr.getCdr();
            }
            cdr.print(n, true);  //Prints the next node after cons are finished

        }
    }
}



