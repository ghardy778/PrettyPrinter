// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
  
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            //If no LParen print one
            if (!p)
            {
                Console.Write("(");
     
            }

            Console.WriteLine("begin"); //Write our begin identifier

            Node cdr = t.getCdr(); //Get cdr of the starting Node t

            //While cdr is a cons,
            //we indent the required spaces
            //print the car of the cdr
            //Write new line
            //Then move the cdr to the next cdr.
            while(cdr.isPair())
            {
                t.getCar().print(n + 4, true);  //This indents our printer by calling the same identifier call that just prints n spaces
                cdr.getCar().print(n + 4, false);
                Console.WriteLine("");
                cdr = cdr.getCdr();
            }
            cdr.print(n, true); //This prints the next node after the cons are finished 
            
        }
    }
}

