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
        // Print n spaces for indentation
        //Write name of ident as long as it's not one of these special idents listed.
        //These idents are printed in their respective specail print classes.
        public override void print(int n)
        {
            
            String spaces = new String(' ', n);
            Console.Write(spaces);
            if (!(name.Equals("begin") || name.Equals("cond") || name.Equals("let") || name.Equals("if") || name.Equals("lambda") || name.Equals("define")))
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

