// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {

	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" ");

            if(!p)
            {
                Console.Write("(");
            }
            t.getCar().print(n);
            t.getCdr().print(n, true);
        }
    }
}


