using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    public interface IComponentParent : IRenderable
    {
        void Add(IRenderable item);
    }
}
