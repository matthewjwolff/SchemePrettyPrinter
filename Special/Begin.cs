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

            Console.WriteLine("(begin");

            //Check after begin to see if its a Cons. if a Cons, indent 4 times
            if (t.getCdr().isPair())
            {
                t.getCdr().print(n + 4, p);
            }
                for (int i = 0; i < n; i++)
                   Console.Write(" ");

            Console.Write(")");

        }
    }
}

