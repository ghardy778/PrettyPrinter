// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
 
	public Quote() { }

        //Print quote, then skip cdr.cdr which would be an extra nil node
        //This nil node, does not need an RPAREN because it correlates with
        //the quote symbol which does not begin with a LPAREN
        public override void print(Node t, int n, bool p)
        {
           
            Console.Write("'");
            t.getCdr().getCar().print(0, false);


        }
    }
}

