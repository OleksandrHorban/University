using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Ferrari : IFerrari
    {
        public Ferrari(string x)
        {
            this.DriverName = x;
        }
        public string DriverName { get; set; }
        public string UseBrakes()
        {
            return "Brakes!";
        }
        public string PushTheGas()
        {
            return "PushTheGas!";
        }
        public override string ToString()
        {
            return $"488-Spider/{UseBrakes()}/{PushTheGas()}/{DriverName}";
        }

    }
}
