using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    interface IFerrari
    {
        string UseBrakes();
        string PushTheGas();
        string DriverName { get; set; }
    }
}
