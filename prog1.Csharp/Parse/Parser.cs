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
            if(curToken == null)
            {
                return null;
            }
            else if (curToken.getType() == new Token(TokenType.TRUE).getType())
            {

                return t;
            }
            //#f grammar
            else if (curToken.getType() == new Token(TokenType.FALSE).getType())
            {
                return f;
            }

            // ( rest grammar

            else if (curToken.getType() == new Token(TokenType.LPAREN).getType())
            {
                //return new Cons(parseRest(), parseRest());
                return parseRest();
            }

            // Identifier grammar
            else if (curToken.getType() == new Token(TokenType.IDENT).getType())
            {
                return new Ident(curToken.getName());
            }

            // Int_constant grammar
            else if (curToken.getType() == new Token(TokenType.INT).getType())
            {
                return new IntLit(curToken.getIntVal());
            }

            // String_constant grammar
            else if (curToken.getType() == new Token(TokenType.STRING).getType())
            {
                return new StringLit(curToken.getStringVal());
            }

            // ' exp grammar
             else if (curToken.getType() == new Token(TokenType.QUOTE).getType())
            {
                    return new Cons(new Ident("quote"), new Cons(parseExp(), nil));
            }

            return null;
        }

        //Adding in another ParseExp with a curToken param
        //The only difference between the two ParseExp is
        //the original one reads a token from the file
        //while this parseExp allows you to pass a token to read
        //in order to not advance to the next token of the file if we are
        //still interpreting that token.
        private Node parseExp(Token curToken)
        {


            if (curToken == null)
            {
                return null;
            }
            //#t grammar
            else if (curToken.getType() == new Token(TokenType.TRUE).getType())
            {

                return t;
            }
            //#f grammar
            else if (curToken.getType() == new Token(TokenType.FALSE).getType())
            {
                return f;
            }

            // ( rest grammar

            else if (curToken.getType() == new Token(TokenType.LPAREN).getType())
            {
                //return new Cons(parseRest(), parseRest());
                return parseRest();
            }

            // Identifier grammar
            else if (curToken.getType() == new Token(TokenType.IDENT).getType())
            {
                return new Ident(curToken.getName());
            }

            // Int_constant grammar
            else if (curToken.getType() == new Token(TokenType.INT).getType())
            {
                return new IntLit(curToken.getIntVal());
            }

            // String_constant grammar
            else if (curToken.getType() == new Token(TokenType.STRING).getType())
            {
                return new StringLit(curToken.getStringVal());
            }

            // ' exp grammar
            else if (curToken.getType() == new Token(TokenType.QUOTE).getType())
            {
                return new Cons(new Ident("quote"), new Cons(parseExp(), nil));
            }

            return null;
        }

        protected Node parseRest()
        {
          
            Token curToken = scanner.getNextToken();

            //error check to see if they forgot RPAREN
            //if they did, then it corrects it for them
            if(curToken == null)
            {
                return nil;
            }

            // ) grammar
            if (curToken.getType() == new Token(TokenType.RPAREN).getType())
            {
                return nil;
            }
            // exp . exp grammar
            else if (curToken.getName().Equals('.'))
            {
                curToken = scanner.getNextToken();
                if (curToken != null)
                    return new Cons(parseExp(curToken), parseRest());
                else
                    return null;
            }
            // exp rest grammar
            else
            {
                return new Cons(parseExp(curToken), parseRest());
            }

          
        }

        // TODO: Add any additional methods you might need.
    }
}

