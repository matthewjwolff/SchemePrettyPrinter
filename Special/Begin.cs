// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {

	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" ");

            if(!p)
            {
                Console.Write("(");
            }
            t.getCar().print(n);
            Console.WriteLine();
            t.getCdr().print(n + 4, true);
        }
    }
}

