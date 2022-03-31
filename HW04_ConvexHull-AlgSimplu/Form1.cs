using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW04_ConvexHull_AlgSimplu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Gold, 3);
            Pen pen2 = new Pen(Color.BlueViolet, 3);

            Random rand = new Random();
            int n = rand.Next(3, 20);

            PointF[] m1 = new PointF[n];

            for (int i = 0; i < n; i++)
            {
                m1[i].X = rand.Next(50, panel1.Width - 50);
                m1[i].Y = rand.Next(50, panel1.Height - 50);
                g.DrawEllipse(pen2, m1[i].X, m1[i].Y, 2, 2);
            }

            int p, q, r;
            bool valid;

            for (p = 0; p < n; p++)
            {
                for (q = 0; q < n; q++)
                {
                    valid = true;
                    for (r = 0; r < n; r++)
                    {
                        if (determinant(m1[p].X, m1[p].Y, m1[q].X, m1[q].Y, m1[r].X, m1[r].Y) > 0)
                            valid = false;
                    }
                    if (valid)
                    {
                        g.DrawLine(pen, m1[p].X, m1[p].Y, m1[q].X, m1[q].Y);
                        //Thread.Sleep(100);
                    }
                }
            }
        }

        private float determinant(float xp, float yp, float xq, float yq, float xr, float yr)
        {
            float d = xp * (yq - yr) + xq * (yr - yp) + xr * (yp - yq);
            return d;
        }
    }
}
