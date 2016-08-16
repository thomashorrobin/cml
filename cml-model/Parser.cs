using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public static class Parser
    {
        public static DocumentRoot ParserCML(string file)
        {
            var tokens = Token.getTokens(file);
            return (DocumentRoot)Parse(tokens);
        }
        private static IRenderable Parse(List<Token> tokens)
        {
            Token token = tokens[0];
            tokens.RemoveAt(0);
            if (token.IsComponent)
            {
                return Token.getComponent(token);
            }
            else if(token.TagType == TokenType.Close)
            {
                throw new MalformedCMLException();
            }
            else
            {
                IComponentParent container;
                if (token.ComponentType == ComponentType.Root)
                {
                    container = new DocumentRoot();
                }
                else if (token.ComponentType == ComponentType.Section)
                {
                    container = new Section("test name");
                }
                else
                {
                    throw new MalformedCMLException();
                }
                while (tokens[0].IsComponent)
                {
                    container.Add(Parse(tokens));
                }
                return container;
            }
        }
    }
}
