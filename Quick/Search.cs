using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickLoader;
using System.Windows.Forms;

namespace Quick
{
    public class Search
    {
        public static int Parse(ItemData item,string str,bool sname=true,bool sdesc=true)
        {
            int result = 0;
            string[] words = str.ToUpper().Split(' ');
            foreach(var word in words)
            {                
                result += ((sname?item.Name.ToUpper().Contains(word):false) || 
                    (sdesc?item.Description.ToUpper().Contains(word):false))?1:0;
            }
            return result;
        }

        public static List<ItemData> ParseList(List<ItemData> items,string str, bool sname = true, bool sdesc = true)
        {            
            if (str == "") return items;
            if (str[0] == '?') return new List<ItemData>();
            List<___data> data = new List<___data>();
            foreach (var item in items)
                data.Add(new ___data(item,str,sname,sdesc));
            var arritems = data.ToArray();            
            Array.Sort(arritems,(x,y)=>(x.k>y.k || (x.k<y.k && x.data.Name.CompareTo(y.data.Name)<0))?-1:1);
            Array.Reverse(arritems);                       
            List<ItemData> result=new List<ItemData>();
            for(int i=0;i<arritems.Length;i++)
            {
                if(arritems[i].k!=0) result.Add(arritems[i].data);
            }
            return result;
        }

        class ___data
        {
            public int k;
            public ItemData data;
            public ___data(ItemData data, string str, bool sname = true, bool sdesc = true)
            {
                this.data = data;
                k = Parse(data,str,sname,sdesc);
            }
        }
    }
}
