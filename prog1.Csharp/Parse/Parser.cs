// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
// Changed rest grammar to remove left cursion and common left factors
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         | exp X
//    X -> rest
//         | . exp
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

        //Every where I used the scanner I used the variable name scanner,
        // would the code be affected if I used s instead?
        public Parser(Scanner s) { scanner = s; }

        private Node t = new BoolLit(true);  // Create true node with t pointer
        private Node f = new BoolLit(false); // Create f node with f pointer
        private Node nil = new Nil();
  
        public Node parseExp()
        {
            Token curToken = scanner.getNextToken();
            // TODO: write code for parsing an exp
            // Began the tree stucture and I believe most of it should be work fine

            //#t grammar
            if (curToken == new Token(TokenType.TRUE))
            {

                return t;
            }
            //#f grammar
            else if (curToken == new Token(TokenType.FALSE))
            {
                return f;
            }

            // ( rest grammar
            // Not 100% on this one.  The first node should be rest as it is in the grammar
            // But the second node, I'm guessing it will be parse rest as well
            else if (curToken == new Token(TokenType.LPAREN))
            {
                return new Cons(parseRest(), parseRest());
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
             else if (curToken == new Token(TokenType.QUOTE))
            {
                 return new Cons(parseExp(), parseRest());
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
                return nil;
            }
            // exp . exp grammar
            else if (curToken.getName().Equals('.'))
            {
                curToken = scanner.getNextToken();
                return new Cons(parseExp(), parseExp());
            }
            // exp rest grammar
            else
            {
                return new Cons(parseExp(), parseRest());
            }

            return null;
        }

        // TODO: Add any additional methods you might need.
    }
}

