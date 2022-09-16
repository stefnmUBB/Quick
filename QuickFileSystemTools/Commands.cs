using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuickLoader;

namespace QuickTools
{
    public class Commands
    {
        public static CommandData Path = new CommandData("path",";path C:\\\\Folder\n;path \"C:\\\\My Folder\"", 
        delegate (List<string> args)
        {
            if(args.Count==1)
            {
                try
                {
                    string str = System.IO.Path.GetFullPath(args[0]);                  
                    System.Diagnostics.Process.Start(str);
                }
                catch(Exception)
                {
                    MessageBox.Show("An error occured.");
                }
                //System.Diagnostics.Process.Start();
               //MessageBox.Show(args[0]);
            }
        });
    }
}
