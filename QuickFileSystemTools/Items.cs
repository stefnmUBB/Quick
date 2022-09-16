using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickLoader;

namespace QuickTools
{
    public static class Items
    {        
        public static ActionData AppData = new ActionData("AppData",_("Opens AppData directory."),delegate() 
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));         
        });

        public static ActionData Desktop = new ActionData("Desktop", _("Opens Desktop directory."), delegate ()
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        });

        public static ActionData StartUp = new ActionData("Startup", _("Opens Startup directory."), delegate ()
        {
            System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        });

        public static string _(string s)
        {
            return s + $"\n\n[Assembly:{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}]";
        }
    }
}
