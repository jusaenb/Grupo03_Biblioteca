using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Tabla<T, u> : KeyedCollection<T, u> where u : Entity<T>
    {
        protected override T GetKeyForItem(u item)
        {
            return item.Id;
        }
    }

}
