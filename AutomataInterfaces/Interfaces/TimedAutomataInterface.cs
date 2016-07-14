using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataInterfaces.Interfaces
{
    class TimedAutomataInterface
    {
        
        //String InterfaceID;
        // String InterfaceDescription;

        #region Declair Interface Properties
        public List<IState> Q = new List<IState>();
        Inputs X = new Inputs();
        Outputs Y = new Outputs();
        public IState q0 = new IState();
        public List<ITransitions> T = new List<ITransitions>();
       
      
        public TimedAutomataInterface()
        { 
        
        }

        public TimedAutomataInterface(String inputX, String inputY, String inputD, Automata automata)
        {
            TimedProvider timePro = new TimedProvider();
            X = timePro.XInputs(inputX, automata);
            Y = timePro.YInputs(inputY, automata);
        }

        #endregion
    }
}
