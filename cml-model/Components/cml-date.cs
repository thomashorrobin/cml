using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model.Components
{
    public class cml_date : ComponentBase<DateTime>
    {
        public cml_date(string optionName, DateTime optionValue) : base(optionName, optionValue)
        {
        }

        public override string render(int indent)
        {
            return string.Format("{2}<date name=\"{0}\" value=\"{1}\" />", Name, Value.ToString("yyyy-MM-dd"), new string('\t', indent));
        }
    }
}
