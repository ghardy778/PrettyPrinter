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

        public override void print(int n, bool p) {
            // There got to be a more efficient way to print n spaces.
            //for (int i = 0; i < n; i++)
            //        Console.Write(" ");
            // Never a space before an RPAREN
            //   String spaces = new String(' ', n);
            //   Console.Write(spaces);

            if (p)
                Console.Write(")");
            else
                Console.Write("()");
        }

        public override void printNewLine(int n, bool p)
        {
            Console.WriteLine();
            String spaces = new string(' ', n);
            Console.Write(spaces);
            Console.Write(")");
        }

      

        public override bool isNull()
        {
            return true;
        }
    }
}
