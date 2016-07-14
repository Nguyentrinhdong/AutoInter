using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataInterfaces.Interfaces
{
    class PlugableEI
    {
        public ILocation q = new ILocation();
        public ILocation qPrime = new ILocation();
        public Boolean Marked = false;

        public PlugableEI(ILocation _qPrime, ILocation _q)
        {
            q = _q;
            qPrime = _qPrime;
        }
    }
}
