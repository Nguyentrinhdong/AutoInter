using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataInterfaces.Interfaces
{
    public class ILocation
    {
       

         public String LocationID = ""; // Id
         public String LocationName = "";// Name to display in the state
         public Boolean LocationStatus = true; //May be used to mark a state 
         public ITimedDesigned timedDesign = new ITimedDesigned();

        public ILocation(String TimedStr)
        { 
            String [] separate = {":"};
            String [] element = TimedStr.Split(separate,StringSplitOptions.RemoveEmptyEntries);
            LocationID = element[0];
            LocationName = element[0];
            ITimedDesigned lD = new ITimedDesigned(element[1],LocationName);
            timedDesign = lD;
        }

        public ILocation()
        {
            // TODO: Complete member initialization
        }
    }
}
