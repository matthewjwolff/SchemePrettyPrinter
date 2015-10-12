// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {

	public If() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" ");
            //Write IF from the start.  Once the expressions passes the else cause, Close with ")"
            Console.Write("if ");

            t.getCdr().getCar().print(0, false);
            Console.WriteLine();

            Node blocks = t.getCdr().getCdr();
            while(!blocks.isNull())
            {
                blocks.getCar().print(n+4);
                Console.WriteLine();
                blocks = blocks.getCdr();
            }
            blocks.print(n,true);
            //Console.WriteLine();
        }
    }
}

