using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public abstract class ComponentBase<T> : IComponent
    {
        public ComponentBase(string optionName, T optionValue)
        {
            Name = optionName;
            Value = optionValue;
        }
        public string Name { get; private set; }
        public T Value { get; set; }
        public abstract string render(int indent);
    }

    public interface IComponent : IRenderable { }
}
