// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {

	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {

            if (!p)
            {
                Console.Write("(");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("lambda");

            for (int i = 0; i < n; i++)
                Console.Write(" ");

            Node second = t.getCdr().getCar();
            if (second.isPair())
            {
                second.print(n, true);
            }
            else Console.WriteLine();

            Node third = t.getCdr().getCdr().getCar();
            if (second.isPair())
            {
                second.print(n+2, true);
            }
            else Console.Write(" ");
        }
    }
}

