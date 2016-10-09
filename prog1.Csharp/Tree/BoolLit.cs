// BoolLit -- Parse tree node class for representing boolean literals

using System;

namespace Tree
{
    public class BoolLit : Node
    {
        private bool boolVal;
  
        public BoolLit(bool b)
        {
            boolVal = b;
        }
  
        public override void print(int n)
        {
            String spaces= new String(' ', n);
            Console.Write(spaces);
 

            if (boolVal)
                Console.Write("#t");
            else
                Console.Write("#f");
        }

        public override bool isBool()
        {
            return true;
        }
    }
}
