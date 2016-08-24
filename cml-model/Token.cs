using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public class Token
    {
        internal Token(string text, TokenType type)
        {
            tagText = text;
            TagType = type;
        }
        string tagText;
        public TokenType TagType { get; private set; }
        public ComponentType ComponentType {
            get {
                switch (tagText.Split(' ')[0])
                {
                    case "cml":
                        return ComponentType.Root;
                    case "section":
                        return ComponentType.Section;
                    case "integer":
                        return ComponentType.Integer;
                    case "boolean":
                        return ComponentType.Boolean;
                    case "string":
                        return ComponentType.String;
                    case "date":
                        return ComponentType.Date;
                    default:
                        throw new MalformedCMLException();
                }
            }
        }
        public override string ToString()
        {
            return tagText;
        }
        public bool IsComponent {
            get {
                return TagType == TokenType.Component;
            }
        }
        internal static IComponent getComponent(Token token)
        {
            switch (token.ComponentType)
            {
                case ComponentType.Section:
                    throw new MalformedCMLException();
                case ComponentType.Root:
                    throw new MalformedCMLException();
                case ComponentType.Integer:
                    return new Components.cml_integer("test", 1);
                case ComponentType.String:
                    return new Components.cml_string("test", "1");
                case ComponentType.Boolean:
                    return new Components.cml_boolean("test", true);
                case ComponentType.Date:
                    return new Components.cml_date("test", new DateTime(2015,2,12));
                default:
                    throw new MalformedCMLException();
            }
        }
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

        private static bool tagsClosedCorrectly(string file)
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
    public enum TokenType
    {
        Open,
        Close,
        Component
    }
}
