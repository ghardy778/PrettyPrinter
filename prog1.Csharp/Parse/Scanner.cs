// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
  

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

                //DONE TODO: skip white space and comments
                if (ch == 10)
                    return null;
                if (ch >= 9 && ch <= 13 || ch == 32)
                        {
                    return getNextToken();
                }
                if (ch == ';')
                {
                    In.ReadLine();
                    return getNextToken();
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
                else if (ch == '.' && In.Peek()!= '.')
                {
                         // We ignore the special identifier `...'.
                        //  We added an extra lookahead for ellipses
                        return new Token(TokenType.DOT);
                }

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
                    //DONE! TODO: scan a string into the buffer variable buf
                    ch = In.Read();
                    //int start = 0;
                    int length = 0;

                    while (ch != '"')
                    {
                        buf[length] = (char)ch;
                        ch = In.Read();
                        length++;
                    }
                    return new StringToken(new String(buf, 0, length));
                }


                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    int length = 0;
                    String number = "" +(char)ch;

                    while (In.Peek() >= '0' && In.Peek() <= '9')
                    {
                        ch = In.Read();
                        number += (char)ch;
                        length++;

                    }

                    i = Convert.ToInt32(number);
                    // DONE: scan the number and convert it to an integer

                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(i);
                }

                // Identifiers
                else if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch == '!' || ch >= '$' && ch <= '&' || ch == '*' || ch == '+' || ch == '-' || ch == '.' || ch == '/' || ch == ':' || ch >= '<' && ch <= '@' || ch == '^' || ch == '_' || ch == '~'
                         // or ch is some other valid first character
                         // for an identifier
                         )
                {

                    //int start = 0;
                    int length = 0;
                    buf[length] = (char)ch;
                    length++;
                    ch = In.Peek();

                    while (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch == '!' || ch >= '$' && ch <= '&' || ch == '*' || ch == '+' || ch == '-' || ch == '.' || ch == '/' || ch == ':' || ch >= '<' && ch <= '@' || ch == '^' || ch == '_' || ch == '~' || ch >= '0' && ch <= '9')
                    {
                        ch = In.Read();
                        buf[length] = (char)ch;
                        length++;
                        ch = In.Peek();
                    }

                    // DONE: scan an identifier into the buffer

                    // make sure that the character following the integer
                    // is not removed from the input stream
                    String ident = new string(buf, 0, length);
                    ident = ident.ToLower();
                    if(ident.Equals("quote"))
                        return new Token(TokenType.QUOTE);
                    else
                        return new IdentToken(ident);
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

