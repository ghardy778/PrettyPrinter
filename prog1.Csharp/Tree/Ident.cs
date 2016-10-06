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
            String spaces = new String(' ', n);
            Console.Write(spaces);

            Console.WriteLine(name);
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

