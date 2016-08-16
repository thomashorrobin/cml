using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model.Components
{
    public class cml_string : ComponentBase<string>
    {
        public cml_string(string optionName, string optionValue) : base(optionName, optionValue) { }
        public override string render(int indent)
        {
            return string.Format("{2}<string name=\"{0}\" value=\"{1}\" />", Name, Value, new String('\t', indent));
        }
        public override ComponentType ComponentType { get { return ComponentType.String; } }
    }
}
