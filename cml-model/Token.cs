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
        private ComponentType ComponentType {
            get {
                switch (tagText)
                {
                    case "area":
                        return ComponentType.Area;
                    case "section":
                        return ComponentType.Section;
                    case "integer":
                        return ComponentType.Integer;
                    case "boolean":
                        return ComponentType.Boolean;
                    case "string":
                        return ComponentType.String;
                    default:
                        throw new MalformedCMLException();
                }
            }
        }
        public override string ToString()
        {
            return tagText;
        }
    }
}
