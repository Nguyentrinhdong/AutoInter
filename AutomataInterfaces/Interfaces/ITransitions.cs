using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataInterfaces.Interfaces
{
    public class ITransitions
    {
        public String ID="";
        public ILocation StateFrom = new ILocation();
        public ILocation StateTo = new ILocation();
       
        public String Fxy;
        public Boolean Mark = false;

        public ITransitions(String Trans) 
        {
            
        
        }
        public ITransitions(ILocation s1, ILocation s2, String guardStr)
        {
            StateFrom = s1;
            StateTo = s2;
            Fxy = guardStr;
        }

    }
}
