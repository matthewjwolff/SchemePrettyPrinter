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
            //for (int i = 0; i < n; i++)
                //Console.Write(" ");
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
                for (int i = 0; i < n + 4; i++)
                    Console.Write(" ");
                rest.getCar().print(0, false);
                Console.WriteLine();
                while ((rest = rest.getCdr()) != Nil.getNil())
                {
                    for (int j = 0; j < n + 4; j++)
                        Console.Write(" ");
                    rest.getCar().print(0, false);
                    Console.WriteLine();
                }
                for (int k = 0; k < n; k++)
                    Console.Write(" ");
                Nil.getNil().print(n, true);
            }
            else t.getCdr().print(n, true);
        }
    }
}


