using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuickLoader
{
    public class CommandData : ItemData
    {      
        public Action<List<string>> Action=null;
        public CommandData(string Name,string Description,Action<List<string>> Action) : base(Name,Description)
        {            
            this.Action = Action;
        }
        
        public static List<string> ToParams(string args)
        {
            return args.Split('"')
                     .Select((element, index) => index % 2 == 0  
                                           ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           : new string[] { element }) 
                     .SelectMany(element => element).ToList();
        }

    }
}
