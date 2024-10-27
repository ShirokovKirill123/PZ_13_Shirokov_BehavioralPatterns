using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_ChainOfResponsibility_Resources
{
    // Абстрактный класс обработчика

    public abstract class AccessHandler
    {
        public AccessHandler Successor { get; set; }
        public abstract void Handle(FileAccessRequest request);
    }
}
