// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        private Cons list;

        public Quote(Cons list)
        {
            this.list = list;
        }

        public override void print(Node t, int n, bool p)
        {
            Console.Write("'");
            ((Cons)list.getCar()).print(n, false);
        }

        public Cons getQuote()
        {
            return list;
        }
    }
}

