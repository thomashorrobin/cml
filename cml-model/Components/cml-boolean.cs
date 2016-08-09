using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model.Components
{
    public class cml_boolean : ComponentBase<bool>
    {
        public cml_boolean(string optionName, bool optionValue) : base(optionName, optionValue) { }
        public override string render(int indent)
        {
            return string.Format("{2}<boolean name=\"{0}\" value={1} />", Name, Value, new string('\t', indent));
        }
    }
}
