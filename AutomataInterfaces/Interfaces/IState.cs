using System;

namespace AutomataInterfaces.Interfaces
{
    public class IState
    {
        public String StateID = ""; // Id
        public String StateDescription = "";// Name to display in the state
        public Boolean StateStatus = true; //May be used to mark a state
        public long TimedEvent = 0;
        //public ITimedDesigned timedDesign = new ITimedDesigned();

        // s1:(true => (display = idle))|[0,1];

        public IState(String TimedStr)
        {
            String[] separate = {":"};
            String[] element = TimedStr.Split(separate, StringSplitOptions.RemoveEmptyEntries);
            StateID = element[0];
            StateDescription = element[0];
            ITimedDesigned tD = new ITimedDesigned(element[1], StateDescription);
            TimedEvent = tD.timedIntv.TimeEvent;
            //timedDesign = tD;
        }

        public IState()
        {
            // TODO: Complete member initialization
        }
    }
}