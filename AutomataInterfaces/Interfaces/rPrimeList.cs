using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataInterfaces.Interfaces
{
    class rPrimeList
    {
        public ILocation rPrime = new ILocation();
        public String F_rPrime = "";
        public rPrimeList(ILocation rPrime1, string F)
        {
            // TODO: Complete member initialization
            this.rPrime = rPrime1;
            this.F_rPrime = F;
        }

    }
}
