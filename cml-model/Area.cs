using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public class Area : IRenderable
    {
        private List<IRenderable> areaList = new List<IRenderable>();

        public Area(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }

        public void Add(IRenderable item)
        {
            areaList.Add(item);
        }

        public string render(int indent)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{1}<area title=\"{0}\">\r\n", Title, new String('\t', indent));
            foreach (IRenderable item in areaList)
            {
                sb.AppendLine(item.render(indent + 1));
            }
            sb.AppendFormat("{0}</area>", new String('\t', indent));
            return sb.ToString();
        }
    }
}
