// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {

	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
            //for (int i = 0; i < n; i++)
               // Console.Write(" ");

            if (!p)
                Console.Write("(");
            //Print "lambda"
            t.getCar().print(n);
            Console.Write(" ");

            Node second = t.getCdr().getCar();
            if (second.isPair())
            {
                second.print(n, false);
            }
            Console.WriteLine();
            Node term = t.getCdr().getCdr();
            while(!term.isNull())
            {
                for (int i = 0; i < n + 4; i++)
                    Console.Write(" ");
                term.getCar().print(0);
                term = term.getCdr();
                Console.WriteLine();
            }
            for (int i = 0; i < n; i++)
                Console.Write(" ");
            Nil.getNil().print(n,true);
        }
    }
}

