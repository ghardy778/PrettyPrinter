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
            //When is the function define
            //Treat like an if and lambda
            if(t.getCdr().getCar().isPair())
            {
                if (!p)
                {
                    Console.Write("(");

                }
                Console.Write("define ");

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
                        cdr.getCar().print(n, false);
                    }
                    Console.WriteLine("");
                    cdr = cdr.getCdr();
                }
                cdr.print(n, true);
            }
            //The list version of define
            //Treat like a regular
            else
            {
                if (!p)
                {
                    Console.Write("(");
                    Console.Write("define");
                    t.getCar().print(0, true);
                    t.getCdr().print(1, true);
                }
                else
                {
                    Console.Write("define");
                    t.getCar().print(1, true);
                    t.getCdr().print(1, true);
                }
            }
            
        }
    }
}


