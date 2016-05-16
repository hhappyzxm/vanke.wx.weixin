using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZ.Framework
{
    public interface ICurrentLogin
    {
        object ID { get; set; }

        string UserName { get; set; }
    }
}
