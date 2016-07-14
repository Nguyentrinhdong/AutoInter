using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomataInterfaces.Interfaces
{
    public class IVar
    {
        public String VarTypeID="";
        public String Values="";
        public IVar(String id, String val)
        {
            VarTypeID = id;
            Values = val;
        }
    }
}
