using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickLoader;

namespace Quick
{
    public partial class MainForm : Form
    {
        public List<ItemData> ActionsList = new List<ItemData>();
        public List<ItemData> CommandsList = new List<ItemData>();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            AltShift=5,
            WinKey = 8
        }
        int id = 0;
        public MainForm()
        {
            InitializeComponent();
            string path = AppDomain.CurrentDomain.BaseDirectory+@"Plugins\";

            //var d=Core.LoadPlugin(@"C:\QuickFileSystemTools.dll");
            ActionsList.AddRange(Core.LoadActions(path));
            CommandsList.AddRange(Core.LoadCommands(path));
            
            Visible=false;          
            RegisterHotKey(this.Handle, id, (int)(KeyModifier.Alt|KeyModifier.WinKey), Keys.Q.GetHashCode());           
        }

        public void LoadActions(List<ItemData> list)
        {
            SearchResult.Controls.Clear();
            foreach (var item in list)
            {
                var ctrl = new ResultItem();
                ctrl.pTitle = item.Name;
                ctrl.pDescription = item.Description;
                ctrl.Click += delegate (object o, EventArgs ev)
                {
                    ((ActionData)item).Action?.BeginInvoke(null, null);
                    Hide();
                };
                SearchResult.Controls.Add(ctrl);
            }
        }
        public void LoadCommands(List<ItemData> list)
        {
            SearchResult.Controls.Clear();
            foreach (var item in list)
            {
                var ctrl = new ResultItem();
                ctrl.FontFamily = new FontFamily("Consolas");
                ctrl.BorderColor = Color.Red;
                ctrl.pTitle = ";"+item.Name;
                ctrl.pDescription = item.Description;               
                SearchResult.Controls.Add(ctrl);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadActions(ActionsList);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /*Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                 
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);      
                int id = m.WParam.ToInt32();*/
                SearchBox.Text = "";
                Show();               
                SearchBox.Focus();
            }
        }

        bool canclose = false;      

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (canclose)
            {
                e.Cancel = false;
                return;
            }
            base.OnFormClosing(e);            
            Hide();
            SearchBox.Text = "";
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Hide();            
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            UnregisterHotKey(Handle, id);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchLabel.Visible = SearchBox.Text == "";
            if (SearchBox.Text != "" && SearchBox.Text[0] == ';')
            {
                SearchBox.Font = new Font(new FontFamily("Consolas"), SearchBox.Font.SizeInPoints);
                var str = SearchBox.Text.Substring(1);
                LoadCommands(Search.ParseList(CommandsList,str,true,false));
            }
            else
            {
                SearchBox.Font = new Font(new FontFamily("Microsoft Yi Baiti"), SearchBox.Font.SizeInPoints);                
                LoadActions(Search.ParseList(ActionsList, SearchBox.Text));
            }

            //if(SearchBox.Text="")
        }

        private void SearchResult_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black,0,0,Width,0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canclose = true;
            Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if(SearchBox.Text!="" && SearchBox.Text[0]==';')
                    ExecuteCommand();
                else
                {
                    if(SearchResult.Controls.Count>0)
                    {
                        ((ResultItem)SearchResult.Controls[SearchResult.Controls.Count-1]).PerformClick();
                    }
                }
            }
        }

        private void ExecuteCommand()
        {          
            var cmd = SearchBox.Text.Substring(1);
            var args ="";
            if (SearchBox.Text.IndexOf(' ') != -1)
            {
                cmd = SearchBox.Text.Substring(1, SearchBox.Text.IndexOf(' ') - 1);
                args = SearchBox.Text.Remove(0, SearchBox.Text.IndexOf(' ') + 1);
            }
            ((CommandData)CommandsList.Where(x => x.Name == cmd).First()).Action?.Invoke(CommandData.ToParams(args));
            Hide();
        }
    }
}
