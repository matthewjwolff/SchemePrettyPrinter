// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;
using System.Collections.Generic;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }

        public Node parseExp()
        {
            return parseExp(scanner.getNextToken());
        }

        private Node parseExp(Token tok)
        {
            if (tok.getType() == TokenType.INT)
                return new IntLit(tok.getIntVal());
            else if (tok.getType() == TokenType.STRING)
                return new StringLit(tok.getStringVal());
            else if (tok.getType() == TokenType.TRUE)
                return BoolLit.getTrue();
            else if (tok.getType() == TokenType.FALSE)
                return BoolLit.getFalse();
            else if (tok.getType() == TokenType.QUOTE)
                return new Cons(new Ident("'"), parseExp());
            else if (tok.getType() == TokenType.IDENT)
                return new Ident(tok.getName());
            else if (tok.getType() == TokenType.LPAREN)
                return parseRest();
            return null;
        }
  
        protected Node parseRest()
        {
            Stack<Node> st = new Stack<Node>();
            Token next = scanner.getNextToken();
            while((next.getType() != TokenType.RPAREN) && (next.getType() != TokenType.DOT))
            {
                st.Push(parseExp(next));
                next = scanner.getNextToken();
            }
            if (next.getType() == TokenType.DOT)
            {
                st.Push(parseExp());
            }
            else
            {
                if (st.Count == 0)
                    return Nil.getNil();
                st.Push(Nil.getNil());
            }
            while(true)
            {
                Node cdr = st.Pop();
                Node car = st.Pop();
                st.Push(new Cons(car, cdr));
                if (st.Count == 1)
                {
                    return st.Pop();
            }
            }
        }

        // TODO: Add any additional methods you might need.
    }
}

