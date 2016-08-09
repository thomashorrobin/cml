using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public class MultiAreaDocumentRoot : IRoot<Area>
    {
        private List<Area> rootList = new List<Area>();

        public void Add(Area item)
        {
            rootList.Add(item);
        }

        public string render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<cml>");
            foreach (Area item in rootList)
            {
                sb.AppendLine(item.render(1));
            }
            sb.AppendLine("</cml>");
            return sb.ToString();
        }
    }
}
