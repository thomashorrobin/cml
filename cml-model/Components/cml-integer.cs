using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model.Components
{
    public class cml_integer : ComponentBase<int>
    {
        public cml_integer(string optionName, int optionValue) : base(optionName, optionValue) { }
        public override string render(int indent)
        {
            return string.Format("{2}<integer name=\"{0}\" value=\"{1}\" />", Name, Value, new string('\t', indent));
        }
    }
}
