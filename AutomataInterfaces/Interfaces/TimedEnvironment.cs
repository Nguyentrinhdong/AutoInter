using System;

namespace AutomataInterfaces.Interfaces
{
    internal class TimedEnvironment
    {
        // String InterfaceID;
        // String InterfaceDescription;

        #region Khai bao cac thuoc tinh Interface

        private static String _X = "", _Y = "";
        public String XString { get { return _X; } set { _X = value; } }
        public String YString { get { return _Y; } set { _Y = value; } }

        private Inputs X = new Inputs();
        private Outputs Y = new Outputs();
        private ITimedDesigned D = new ITimedDesigned();

        public TimedEnvironment()
        {

        }

        public TimedEnvironment(String inputX, String inputY, String inputD, Automata automata)
        {
            TimedProvider timePro = new TimedProvider();
            X = timePro.XInputs(inputX, automata);
            Y = timePro.YInputs(inputY, automata);
            D = timePro.TimedDesign(inputD);
        }

        #endregion Khai bao cac thuoc tinh Interface
    }
}