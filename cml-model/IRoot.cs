using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cml_model
{
    interface IRoot<T>
    {
        string render();
        void Add(T item);
    }
}
