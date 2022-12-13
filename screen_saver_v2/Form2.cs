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

namespace screen_saver_v2
{
    public partial class Form2 : Form
    {
        Random angleR;
        int angle;

        public Form2()
        {
            angleR = new Random();
            angle = angleR.Next(360);
            InitializeComponent();
            GraphicsPath shape = new GraphicsPath();
            shape.AddEllipse(10, 30, 50, 50);
            this.Region = new Region(shape);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            double radian = (angle * Math.PI) / 180;
            Top -= (int)(10 * Math.Sin(radian));
            Left += (int)(10 * Math.Cos(radian));

            //bounce 
            if (this.DesktopLocation.Y <= 0)
            {
                angle = 360 - angle;
                radian = (angle * Math.PI) / 180;
            }
            if (this.DesktopLocation.X <= 0)
            {
                angle = 180 - angle;
                radian = (angle * Math.PI) / 180;
            }
            if (this.DesktopLocation.X >= Screen.PrimaryScreen.Bounds.Width - 50)
            {
                angle = 180 - angle;
                radian = (angle * Math.PI) / 180;
            }

            if (this.DesktopLocation.Y >= Screen.PrimaryScreen.Bounds.Height - 50)
            {
                angle = 360 - angle;
                radian = (angle * Math.PI) / 180;

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control)
                Application.Exit();
        }
    }
}
