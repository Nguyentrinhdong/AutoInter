using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomataInterfaces.Interfaces
{

    public class ITimedIntervals
    {
        /// <summary>
        /// Discription of timed constraint.
        /// </summary>

        int _lowerBound;
        int _timeEvent;
        int _upperBound;

        public int LowerBound { get { return _lowerBound; } set { _lowerBound = value; } }
        public int TimeEvent { get { return _timeEvent; } set { _timeEvent = TimedEventRandom(); } }
        public int UpperBound { get { return _upperBound; } set { _upperBound = value; } }

        public ITimedIntervals()
        {
            LowerBound = 0;
            TimeEvent = 0;
            UpperBound = 0;
        }

        public ITimedIntervals(int lowerB, int upperB)
        {
            LowerBound = lowerB;
            TimeEvent = TimedEventRandom();
            UpperBound = upperB;
        }

        public int TimedEventRandom()
        {
            Random Rdm = new Random();
            return Rdm.Next(_lowerBound, _upperBound);
        }

        public int Length(int t, int t1)
        {
            return t1 - t;
        }
    }

    public class ITimedDesigned
    {
        /// <summary>
        /// Timed Designs Store precondition and postcondition for an interface.
        /// Precondition: The condition that an assignment over input ports of an interface
        /// Postcondition: The condition that an assignment V over {X,Y} 
        /// ItimedIntervals: Timed Contraints of an interface.
        /// </summary>
        public struct TypeAI
        {
            public String TypeName;
            public String TypeValues;
            public String Variables;
        }

        String _ID;
        String _Rho_f;
        String _Rho_t;
        String _Precondition;
        String _PostCondition;
        public String ID { get { return _ID; } set { _ID = value; } }
        public ITimedIntervals timedIntv = new ITimedIntervals();
        public String Precondition { get { return _Precondition; } set { _Precondition = value; } }
        public String PostCondition { get { return _PostCondition; } set { _PostCondition = value; } }
        public String Rho_f { get { return _Rho_f; } set { _Rho_f = value; } }
        public String Rho_t { get { return _Rho_t; } set { _Rho_t = value; } }
        List<TypeAI> Type = new List<TypeAI>();
        public ITimedDesigned() { }
        //s1:(true => (display = idle))|[0,1];
        public ITimedDesigned(String timedStr, String str1)
        {
            ID = "D" + str1;
            String[] Implyseparate = { "=>" };

            String[] element = timedStr.Split(Implyseparate,StringSplitOptions.RemoveEmptyEntries);
            Precondition = element[0].Substring(1).Trim(); //.Substring(1)
           
            String[] preRho = element[1].Split('|');
            PostCondition = preRho[0].Remove(preRho[0].Length-1).Trim();
            Rho_f = PostCondition;
            Rho_t = preRho[1];//.Remove(preRho[1].Length - 1);
            try
            {
                String[] interval = Rho_t.Split(',');
                if (interval[0].Length != 0)
                {
                    timedIntv.LowerBound = int.Parse(interval[0].Substring(1));
                }
                else
                    timedIntv.LowerBound = 0;

                if (interval[1].Length != 0)
                {
                    interval[1] = interval[1].Remove(interval[1].Length - 1);

                }
                else
                    interval[1] = "0";


                if (interval[1].Trim() == "+")
                {
                    timedIntv.UpperBound = int.MaxValue;
                }
                else
                    timedIntv.UpperBound = int.Parse(interval[1]);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("There are errors in source code. Please check the timed duration.");
                
            }
           

            timedIntv.TimeEvent = timedIntv.TimedEventRandom();
        }
    }
}
