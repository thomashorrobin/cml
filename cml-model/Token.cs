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
                switch (tagText)
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
        public static IComponent getComponent(Token token)
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
    }
}
