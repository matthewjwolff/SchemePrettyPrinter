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
            for (int i = 0; i < n; i++)
                Console.Write(" ");
            if(!p)
            {
                Console.Write("(");
            }
            t.getCar().print(n);
            t.getCdr().print(n, true);
        }
    }
}

