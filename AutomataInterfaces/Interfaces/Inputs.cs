using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomataInterfaces.Interfaces
{
    public class Inputs
    {
        
       public  struct PortElement
        {
           public String ID;
           public String Name;
           public String Domain;
           public IVar Var;
           public IType Type;


        }
        
        public List<PortElement> InputElements = new List<PortElement>();
   }
}
