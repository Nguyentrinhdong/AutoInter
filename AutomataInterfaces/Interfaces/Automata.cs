using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataInterfaces.Interfaces
{
    public class Automata
    {
        public String AutomataID;
        // String InterfaceDescription;
        #region Khai bao cac thuoc tinh Interface
        public List<IVar> Var = new List<IVar>();
        public List<IType> Type = new List<IType>();
        public List<ILocation> Q = new List<ILocation>();
        public Inputs X = new Inputs();
        public Outputs Y = new Outputs();
        public IState InitialState; //Start at location p0_th
        public ILocation q0;
        public List<ITransitions> T = new List<ITransitions>();
        public List<IState> S = new List<IState>();

        /// <summary>
        /// Thiet lap cac gia tri cho M
        /// </summary>

        public Automata()
        {

        }

        #endregion

    }
}
