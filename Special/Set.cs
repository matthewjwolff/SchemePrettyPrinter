// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            //CursorLeft gets the cursor's position in the console. Don't indent if you don't have to.
            for (int i = 0; i < n; i++)
                Console.Write(" ");
            

            if (!p)
            {
                Console.Write("(");
            }

            t.getCar().print(n);

            if (t.getCar().isPair())
            {
                t.getCar().print(n+4, true);
            }
            else t.getCdr().print(n, true);

            //Console.WriteLine();
        }
    }
}

