﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public class Section : IRenderable, IComponentParent
    {
        public Section(string sectionName)
        {
            Title = sectionName;
        }

        private List<IComponent> sectionList = new List<IComponent>();
        public ComponentType ComponentType { get { return ComponentType.Section; } }

        public string Title { get; private set; }

        public void Add(IComponent item)
        {
            sectionList.Add(item);
        }

        public void Add(IRenderable item)
        {
            Add((IComponent)item);
        }

        string IRenderable.render(int indent)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{1}<section title=\"{0}\">\r\n", Title, new String('\t', indent));
            foreach (var item in sectionList)
            {
                sb.AppendLine(item.render(indent + 1));
            }
            sb.AppendFormat("{0}</section>", new String('\t', indent));
            return sb.ToString();
        }
    }
}
