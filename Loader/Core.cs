using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;

namespace QuickLoader
{
    public class Core
    {
        internal static List<ActionData> LoadAsmActions(string path)
        {
            List<ActionData> result=new List<ActionData>();
            var asm = Assembly.LoadFile(path);
            var type = asm.GetType("QuickTools.Items");
            if (type != null)
            {
                var items = type.GetFields(BindingFlags.Public | BindingFlags.Static).Where(f => f.FieldType == typeof(ActionData))
                    .ToDictionary(f => f.Name, f => (ActionData)f.GetValue(null));
                foreach (var item in items)
                    result.Add(item.Value);
            }
            return result;
        }      

        public static List<ItemData> LoadActions(string path)
        {
            List<ItemData> result = new List<ItemData>();

            string[] files = Directory.GetFiles(path,"*.dll");
            for(int i=0;i<files.Length;i++)
            {
                result.AddRange(LoadAsmActions(files[i]));
            }

            files = Directory.GetFiles(path, "*.dll.lnk");
            for(int i=0;i<files.Length;i++)
            {
                WshShell shell = new WshShell(); 
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(files[i]);
                result.AddRange(LoadAsmActions(link.TargetPath));                
            }

            return result;
        }        

        internal static List<ItemData> LoadAsmCommands(string path)
        {
            List<ItemData> result = new List<ItemData>();
            var asm = Assembly.LoadFile(path);
            var type = asm.GetType("QuickTools.Commands");
            if (type != null)
            {
                var items = type.GetFields(BindingFlags.Public | BindingFlags.Static).Where(f => f.FieldType == typeof(CommandData))
                    .ToDictionary(f => f.Name, f => (CommandData)f.GetValue(null));
                foreach (var item in items)
                    result.Add(item.Value);
            }
            return result;
        }

        public static List<ItemData> LoadCommands(string path)
        {
            List<ItemData> result = new List<ItemData>();

            string[] files = Directory.GetFiles(path, "*.dll");
            for (int i = 0; i < files.Length; i++)
            {
                result.AddRange(LoadAsmCommands(files[i]));
            }

            files = Directory.GetFiles(path, "*.dll.lnk");
            for (int i = 0; i < files.Length; i++)
            {
                WshShell shell = new WshShell();
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(files[i]);
                result.AddRange(LoadAsmCommands(link.TargetPath));
            }

            return result;
        }
    }
}
