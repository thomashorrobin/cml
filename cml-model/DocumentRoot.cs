using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public class DocumentRoot : IRenderable, IComponentParent
    {
        private List<IRenderable> rootList = new List<IRenderable>();

        public void Add(IRenderable item)
        {
            rootList.Add(item);
        }

        public ComponentType ComponentType { get { return ComponentType.Root; } }

        public List<IRenderable> Components { get { return new List<IRenderable>(rootList); } }

        public string render(int indent)
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
