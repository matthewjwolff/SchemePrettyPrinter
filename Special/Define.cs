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
            //Print "define"
            t.getCar().print(n);
            Console.Write(" ");
            //Get rest of list
            Node rest = t.getCdr();
            //If this is a function definition, line break
            if(rest.getCar().isPair())
            {
                rest.getCar().print(n,false);
                Console.WriteLine();
                rest.getCdr().print(n+4, false);
            } else //Just print normally
            {
                t.getCdr().print(n, true);
            }
        }
    }
}


