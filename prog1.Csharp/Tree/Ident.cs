// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public override void print(int n)
        {
            // There got to be a more efficient way to print n spaces.
            //for (int i = 0; i < n; i++)
            //        Console.Write(" ");
            // || !name.Equals("cond") || !name.Equals("let")
            String spaces = new String(' ', n);
            Console.Write(spaces);
            if (!(name.Equals("begin") || name.Equals("cond") || name.Equals("let")))
            {
                Console.Write(name);
            }
            


        }

        public override String getName()
        {
            return name;
        }

        public override bool isSymbol()
        {
            return true;
        }
    }
}

