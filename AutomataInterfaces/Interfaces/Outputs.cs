using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataInterfaces.Interfaces
{
    public class Outputs
    {
        public struct PortElement
        { 
            public String ID;
            public String Name;
            public String Domain;
            public IVar Var;
            public IType Type;
        }
        //Input InputString X to Interfaces
        public List<PortElement> OutputElements = new List<PortElement>();
      }
  }


