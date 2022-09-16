using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLoader
{
    public class ItemData
    {
        public string Name = "", Description = "";
        public ItemData(string Name,string Description)
        {
            this.Name = Name;
            this.Description = Description;

        }
    }
}
