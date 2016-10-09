// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Lambda() { }
        
        //Treat the same as if, but with lambda ident instead
        public override void print(Node t, int n, bool p)
        {
            
            if (!p)
            {
                Console.Write("(");

            }
            Console.Write("Lambda ");

            Node cdr = t.getCdr();

            cdr.getCar().print(0, false);
            cdr = cdr.getCdr();
            Console.WriteLine();
            while (cdr.isPair())
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

