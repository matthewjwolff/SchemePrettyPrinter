// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using System.Text;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];
        private char[] idents = { '!', '$', '%', '&', '*', '+', '-', '.', '/', ':', '<', '=', '>', '?', '@', '^', '_', '~' };

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need

        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();
   
                //Skip whitespace characters
                while (ch==' ' | ch=='\t' | ch=='\n' | ch=='\r' | ch=='\f')
                {
                    ch = In.Read();
                }
                    
                //If a comment, discard line and consume next character
                while (ch==';')
                {
                    In.ReadLine();
                    ch = In.Read();
                }

                if (ch == -1)
                    return null;
        
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '"')
                {
                    //Known issue: passing a string formatted like "string"with a quote inside". Is that ok?
                    StringBuilder builder = new StringBuilder();
                    ch = In.Read();
                    do
                    {
                        builder.Append((char)ch);
                        ch = In.Read();
                    } while (ch != '"');
                    return new StringToken(builder.ToString());
                }

    
                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    // Should we use the buffer array of the class?
                    int i = ch - '0';
                    char next = (char)In.Peek();
                    while (next >= '0' && next <= '9')
                    {
                        i *= 10;
                        i += next - '0';
                        In.Read();
                        next = (char)In.Peek();
                    }
                    return new IntToken(i);
                }
        
                // Identifiers
                else if ((ch >= 'A' && ch <= 'Z') ||
                    (ch>='a' && ch<= 'z') || 
                    Array.IndexOf(idents, (char)ch)>-1
                         ) {
                    StringBuilder builder = new StringBuilder();
                    builder.Append((char)ch);
                    char next = (char)In.Peek();
                    while(next != ' ')
                    {
                        builder.Append(next);
                        In.Read();
                        next = (char)In.Peek();
                    }

                    return new IdentToken(builder.ToString());
                }
    
                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}

