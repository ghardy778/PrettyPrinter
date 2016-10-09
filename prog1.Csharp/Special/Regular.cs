// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
      
        public Regular() { }

        //if !p
        //   Print LParen and make sure no indent after LParen
        //   Print Cdr with 1 indent for space inbetween elements
        //else
        //   Print car with no indent bc it follows a Lparen
        //   Print cdr with 1 indent to seperate elements of a list
        public override void print(Node t, int n, bool p)
        {

   

            if (!p)
            {
                Console.Write("(");
                n = 0;
                t.getCar().print(n, true);
                n++;
                t.getCdr().print(n, true);
            }
            else
            {
                t.getCar().print(n, true);
                if (n == 0)
                    n++;
                t.getCdr().print(n, true);
            }
           
        }
    }
}


