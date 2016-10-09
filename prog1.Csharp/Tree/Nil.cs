// Nil -- Parse tree node class for representing the empty list

using System;

namespace Tree
{
    public class Nil : Node
    {
        public Nil() { }

        public override void print(int n)
        {
            print(n, false);
        }

        //This prints the right PAREN in our printer
        public override void print(int n, bool p) {

            //Never do we only want one space behind paren
            //If greater than 1, then we indent accordingly.
            if (n <= 1)
                n = 0;
            String spaces = new string(' ', n);
            Console.Write(spaces);
            if (p)
                Console.Write(")");
            else
                Console.Write("()");
        }



      

        public override bool isNull()
        {
            return true;
        }
    }
}
