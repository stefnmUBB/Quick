using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick
{
    public partial class ResultItem : UserControl
    {
        public ResultItem()
        {
            InitializeComponent();
            Dock = DockStyle.Top;            
        }

        public Color BorderColor = Color.Aqua;

        int padding = 3;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Parent.BackColor),0,0,Width,Height);
            var pen = new Pen(BorderColor);            
            e.Graphics.DrawArc(pen, padding,padding,10,10,180,90);
            e.Graphics.DrawArc(pen, Width-11-padding, padding, 10, 10, 270, 90);
            e.Graphics.DrawArc(pen, Width-11-padding, Height-11-padding, 10, 10, 0, 90);
            e.Graphics.DrawArc(pen, padding, Height-11-padding, 10, 10, 90, 90);
            e.Graphics.DrawLine(pen,5+padding,padding,Width-5-padding,padding);
            e.Graphics.DrawLine(pen, 5+padding, Height-1-padding, Width - 5-padding, Height-1-padding);
            e.Graphics.DrawLine(pen,padding,5+padding,padding,Height-5-padding);
            e.Graphics.DrawLine(pen, Width-1-padding, 5+padding, Width-1-padding, Height - 5-padding);
        }

        public string pTitle { get => Title.Text; set => Title.Text = value; }
        public string pDescription { get => Description.Text; set => Description.Text = value; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Body.Height = Description.Top + Description.Height;
            Body.Width = Width - 4 * padding;
            Body.Top = Body.Left = 2*padding;
            Height = Body.Height + 4 * padding;
        }

        private void Title_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void Description_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void Body_Paint(object sender, PaintEventArgs e)
        {         
        }

        private void Body_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        public FontFamily FontFamily
        {
            set
            {
                Title.Font = new Font(value, Title.Font.SizeInPoints);
                Description.Font = new Font(value, Description.Font.SizeInPoints);               
            }
        }

        public void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }
    }
}
