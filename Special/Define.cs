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
            //Get rest of list
            Node rest = t.getCdr();
            //If this is a function definition, line break
            if(rest.getCar().isPair())
            {
                //Print the defined term
                Console.Write(" ");
                rest.getCar().print(n,false);
                Console.WriteLine();
                //Print the rest
                //Print an open paren if we need one

                //Now print every term with a new line after
                while((rest = rest.getCdr())!=Nil.getNil())
                {
                    rest.getCar().print(n + 4, true);
                    Console.WriteLine();
                }
                Console.Write(")");
            } else //Just print normally
            {
                t.getCdr().print(n, true);
            }
        }
    }
}


