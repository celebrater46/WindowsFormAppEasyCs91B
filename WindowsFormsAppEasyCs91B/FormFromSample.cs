using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs91B
{
    public partial class FormFromSample : Form
    {
        private int t;
        // public FormFromSample()
        // {
        //     InitializeComponent();
        // }
        public FormFromSample()
        {
            InitializeComponent();
            this.Text = "サンプル";
            this.ClientSize = new Size(200, 200);
            this.DoubleBuffered = true;

            t = 0;

            Timer tm = new Timer();
            tm.Interval = 100;
            tm.Start();

            this.Paint += new PaintEventHandler(fm_Paint);
            tm.Tick += new EventHandler(tm_Tick);
        }
        public void fm_Paint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            g.FillEllipse(new SolidBrush(Color.DeepPink), 0, 0, w, h);
            g.FillPie(new SolidBrush(Color.DarkOrchid), 0, 0, w, h, -90, (float)0.6*t);　

            g.FillEllipse(new SolidBrush(Color.Bisque) , (int)w/4, (int)h/4, (int)w/2, (int)h/2);

            string time = t / 10 + ":" + "0" + t % 10; 

            Font f = new Font("Courier", 20);
            SizeF ts = g.MeasureString(time, f);

            float tx = (w - ts.Width) / 2;
            float ty = (h - ts.Height) / 2;

            g.DrawString(time, f, new SolidBrush(Color.Black), tx, ty);
        }
        public void tm_Tick(Object sender, EventArgs e)
        {
            t = t + 1;
            if (t > 600)
                t = 0;

            this.Invalidate();
        }
    }
}