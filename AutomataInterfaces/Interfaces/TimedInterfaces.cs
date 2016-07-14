using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AutomataInterfaces.Interfaces
{
    public class TimedInterfaces
    {
        // String InterfaceID;
        // String InterfaceDescription;

        #region Khai bao cac thuoc tinh Interface
        public String XString { get { return _X; } set { _X = value; } }
        public String YString { get { return _Y; } set { _Y = value; } }
 
        static String _X = "";
        static String _Y = "";
        ITimedDesigned _Xi = new ITimedDesigned();
        Inputs X = new Inputs();
        Outputs Y = new Outputs();
        public ITimedDesigned Xi { get { return _Xi; } set { _Xi = value; } }
        
        public TimedInterfaces()
        { 
        
        }
        public TimedInterfaces(String inputX, String inputY, String inputD, Automata automata)
        {
            TimedProvider tPro = new TimedProvider();
            X = tPro.XInputs(inputX, automata);
            Y = tPro.YInputs(inputY, automata);
            Xi = tPro.TimedDesign(inputD);
        }
        #endregion
      
   }

}
