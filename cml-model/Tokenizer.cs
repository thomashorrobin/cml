using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cml_model
{
    public static class Tokenizer
    {
        public static List<Token> getTokens(string file)
        {
            if (!tagsClosedCorrectly(file))
            {
                throw new MalformedCMLException();
            }
            var tokenList = new List<Token>();
            while (file.Contains('<'))
            {
                int openTag = file.IndexOf('<');
                int closeTag = file.IndexOf('>');
                string tokenString = file.Substring(openTag + 1, closeTag - openTag - 1).Trim();
                tokenList.Add(new Token(tokenString, getTokenType(tokenString)));
                file = file.Substring(closeTag + 1);
            }
            return tokenList;
        }

        private static TokenType getTokenType(string tokenText)
        {
            if (tokenText.EndsWith("/"))
            {
                return TokenType.Component;
            }
            else if (tokenText.StartsWith("/"))
            {
                return TokenType.Close;
            }
            else
            {
                return TokenType.Open;
            }
        }

        public static bool tagsClosedCorrectly(string file)
        {
            bool expectingOpen = true;
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] == '<')
                {
                    if (!expectingOpen)
                    {
                        return false;
                    }
                    expectingOpen = !expectingOpen;
                }
                else if (file[i] == '>')
                {
                    if (expectingOpen)
                    {
                        return false;
                    }
                    expectingOpen = !expectingOpen;
                }
                else
                {
                    if (expectingOpen && !char.IsWhiteSpace(file[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
