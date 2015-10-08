// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" ");

            Console.WriteLine("(define");
            if (t.getCdr() != null)
            {
                t.getCdr().getCar().print(n, false);
            }
            else
                Console.Write(")");
        }
    }
}


