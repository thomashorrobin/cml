using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public interface IValueItem<T>: IValueItem
    {
        T value { get; set; }
        string name { get; }
    }

    public interface IValueItem : IRenderable { }
}
