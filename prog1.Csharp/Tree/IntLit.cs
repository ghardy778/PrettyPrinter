// IntLit -- Parse tree node class for representing integer literals

using System;

namespace Tree
{
    public class IntLit : Node
    {
        private int intVal;

        public IntLit(int i)
        {
            intVal = i;
        }

        public override void print(int n)
        {

            String spaces = new String(' ', n);
            Console.Write(spaces);

            Console.Write(intVal);
        }

        public override bool isNumber()
        {
            return true;
        }
    }
}
