// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {

	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            
            if (!p)
            { 
                Console.Write("(");
            }

            t.getCar().print(n);

            Console.WriteLine();
            if (t.getCdr().isPair())
            {
                t.getCdr().print(n, true);
            }
        }
    }
}

