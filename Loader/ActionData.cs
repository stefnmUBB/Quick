using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLoader
{
    public class ActionData : ItemData
    {        
        public Action Action;
        public ActionData(string Name,string Description,Action action): base(Name,Description)
        {          
            Action = action;
        }

        //public 
    }
}
