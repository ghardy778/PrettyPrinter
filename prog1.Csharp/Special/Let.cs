// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
      
	public Let() { }

        //Treat same as begin
        public override void print(Node t, int n, bool p)
        {
  
            if (!p)
            {
                Console.Write("(");

            }
            Console.WriteLine("let");

            Node cdr = t.getCdr();

            while (cdr.isPair())
            {
                t.getCar().print(n + 4, true);
                cdr.getCar().print(n + 4, false);
                Console.WriteLine("");

                cdr = cdr.getCdr();
            }
            cdr.print(n, true);
        }
    }
}


