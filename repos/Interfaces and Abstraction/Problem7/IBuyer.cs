using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7
{
    public interface IBuyer
    {
        string Name { get; }

        int Food { get; }

        void BuyFood();
    }
}
