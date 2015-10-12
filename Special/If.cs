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
            
            if(!p)
            {
                Console.Write("(");
            }
            // print "if"
            t.getCar().print(n);
            Console.Write(" ");

            Node blocks = t.getCdr().getCdr();
            if (t.getCdr().isPair() & blocks.isPair() & blocks.getCdr().isPair())
            { 
                t.getCdr().getCar().print(n+1, false);
                Console.WriteLine();
         //       for (int i = 0; i < n; i++)
          //          Console.Write(" ");
                blocks.getCar().print(n + 4, false);
                if (blocks.getCdr().isPair())
                {
                    Console.WriteLine();
                    blocks.getCdr().getCar().print(n+4, false);
                }
                Console.WriteLine();
            }
            else t.getCdr().print(n, true);
            for (int i = 0; i < n; i++)
                Console.Write(" ");
            Console.Write(")");
        }
    }
}

