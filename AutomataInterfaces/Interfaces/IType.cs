using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomataInterfaces.Interfaces
{
    public class IType
    {
        public String TypeID;
        public String TypeValues;
        public IType(String id, String val)
        {
            TypeID = id;
            TypeValues = val;
        }
    }
}
