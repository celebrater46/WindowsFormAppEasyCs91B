using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs91B
{
    public partial class Form1 : Form
    {
        private int elapsed;
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Graphic Timer";
            this.ClientSize = new Size(200, 200);
            this.DoubleBuffered = true;

            elapsed = 0;

            Timer tm = new Timer();
            tm.Interval = 100;
            tm.Start();

            this.Paint += new PaintEventHandler(FmPaint);
            tm.Tick += new EventHandler(TmTick);
        }

        public void FmPaint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            
            g.FillEllipse(new SolidBrush(Color.DeepPink), 0, 0, w, h);
            g.FillPie(new SolidBrush(Color.DarkOrchid), 0, 0, w, h, -90, (float)0.6 * t);
            g.FillEllipse(new SolidBrush(Color.Bisque), (int)w/4, (int)h/4, (int)w/2, (int)h/2);

            // string time = elapsed / 10 + ":" + "0" + elapsed % 10;
            int hour = elapsed / 10;
            int minute = elapsed % 10;
            string time = string.Format("{0} : 0{1}", hour, minute);

            Font f = new Font("Courier", 20);
            SizeF ts = g.MeasureString(time, f);

            // Find Center Location
            float tx = (w - ts.Width) / 2;
            float ty = (h - ts.Height) / 2;
            
            g.DrawString(time, f, new SolidBrush(Color.Black), tx, ty);
        }

        public void TmTick(Object sender, EventArgs e)
        {
            elapsed++;
            if (elapsed > 600) // After 1 minute
            {
                elapsed = 0;
                this.Invalidate();
            }
        }
    }
}