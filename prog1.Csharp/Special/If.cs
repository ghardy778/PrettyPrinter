// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {

	public If() { }

        public override void print(Node t, int n, bool p)
        {

            if (!p)
            {
                Console.Write("(");

            }

            //Write the if identifier
            //Set cdr to t.cdr
            //print car of cdr
            //Update cdr to next cdr and write new line
            Console.Write("if ");
            Node cdr = t.getCdr();
            cdr.getCar().print(0, false);
            cdr = cdr.getCdr();
            Console.WriteLine();

            //While cdr is cons
            //indent n + 4 spaces
            //if cdr.car is a list
            //   then indent extra spaces
            //else
            //   don't indent
            //Print new line update cdr
            while(cdr.isPair())
            {
                t.getCar().print(n + 4, true);
                 if (cdr.getCar().isPair())
                {
                    cdr.getCar().print(n + 4, false);
                }
                else
                {
                    cdr.getCar().print(0, false);
                }
                Console.WriteLine("");
                cdr = cdr.getCdr();
            }
            cdr.print(n, true);
        }
    }
}

