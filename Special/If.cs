// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" ");
            //Write IF from the start.  Once the expressions passes the else cause, Close with ")"
            Console.Write("(if");

            //Define the cond after if
            if (t.getCdr().getCar().isPair())
            {
                Node iff = t.getCdr().getCar();
                iff.print(0, p);
            }
            else Console.WriteLine();

            //Define the then statement
            Node thenn = t.getCdr().getCdr().getCar();
            if(!thenn.isNull())
            {
                thenn.print(n + 2, p);
            }
            else Console.WriteLine();

            //Goes down the scheme until gets to the else statement
            Node elsee = t.getCdr().getCdr().getCdr().getCar();
            while(!elsee.isNull())
            {
                elsee.print(n + 2, p);
            }
  
            Console.WriteLine(")");          
        }
    }
}

