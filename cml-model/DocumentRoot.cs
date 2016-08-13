using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public class DocumentRoot
    {
        private List<IRenderable> rootList = new List<IRenderable>();

        public void Add(IRenderable item)
        {
            rootList.Add(item);
        }

        public string render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<cml>");
            foreach (IRenderable item in rootList)
            {
                sb.AppendLine(item.render(1));
            }
            sb.AppendLine("</cml>");
            return sb.ToString();
        }
    }
}
