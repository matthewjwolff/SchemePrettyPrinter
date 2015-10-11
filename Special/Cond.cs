// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Cond() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = Console.CursorLeft; i < n; i++)
                Console.Write(" ");
            if (!p)
            {
                Console.Write("(");
            }
            //print "cond"
            t.getCar().print(n);
            Console.WriteLine();
            Node rest = t.getCdr();
            if (rest.isPair())
            {
                rest.getCar().print(n + 4, false);
                while ((rest = rest.getCdr()) != Nil.getNil())
                {
                    rest.getCar().print(n + 4, false);
                }
                Console.WriteLine();
                Console.Write(")");
            }
            else t.getCdr().print(n, true);
        }
    }
}


