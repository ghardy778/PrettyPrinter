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

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }
  
        public Node parseExp()
        {
            Token curToken = scanner.getNextToken();
            // TODO: write code for parsing an exp
            //     I wrote the basic structure of taking a token
            //     and creating a node from it based on it's type.
            //    We will add how the tree comes into play later.

            //#t grammar
            if (curToken == new Token(TokenType.TRUE))
            {
                return new BoolLit(true);
            }
            //#f grammar
            else if (curToken == new Token(TokenType.FALSE))
            {
                return new BoolLit(false);
            }

            // ( rest grammar
            else if (curToken == new Token(TokenType.LPAREN))
            {
                return this.parseRest();
            }

            // Identifier grammar
            else if (curToken == new Token(TokenType.IDENT))
            {
                return new Ident(curToken.getName());
            }

            // Int_constant grammar
            else if (curToken == new Token(TokenType.INT))
            {
                return new IntLit(curToken.getIntVal());
            }

            // String_constant grammar
            else if (curToken == new Token(TokenType.STRING))
            {
                return new StringLit(curToken.getStringVal());
            }

            // ' exp grammar
            // GRANT
            else if (curToken == new Token(TokenType.QUOTE))
            {
                //Not quite sure what to do here, it needs to call parseExp() again 
                //while including the ' somehow
                return new StringLit("/'"+ parseExp().getStringVal()+ parseExp().getStringVal())    //wrong but use parseExp() to get exp inside quote
            }

            return null;
        }
  
        protected Node parseRest()
        {
            // TODO: write code for parsing a rest.. no
            Token curToken = scanner.getNextToken();

            // ) grammar
            // GRANT
            // Not sure if cons is the right thing
            if(curToken == new Token(TokenType.RPAREN))
            {
                return new Cons(null, null);
            }
            //exp+ [ . exp ] )'
            // GRANT:
            // this grammar stands for one or more expressions, 
            // optional .exp RPAREN.  Not sure if . exp is symbol for anything
            else
            {
                
            }

            return null;
        }

        // TODO: Add any additional methods you might need.
    }
}

