// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree
{
    public class StringLit : Node
    {
        private string stringVal;

        public StringLit(string s)
        {
            stringVal = s;
        }

        public override void print(int n)
        {
            String spaces = new String(' ', n);
            Console.Write(spaces);

            Console.Write("\"" + stringVal + "\"");
        }

        public override bool isString()
        {
            return true;
        }
    }
}

