using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HW04_ConvexHull_AlgSimplu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int n;
        Graphics g;
        List<Point> points;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(SystemColors.ControlLight);
            Brush brush = new SolidBrush(Color.Navy);
            if (!int.TryParse(this.textBoxN.Text, out n))
            {
                n = 0;
                MessageBox.Show("Va rugam sa introduceti un numar");
            }
            points = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                Point p = new Point(rnd.Next(50, this.panel1.Width - 50), rnd.Next(50, this.panel1.Height - 50));
                points.Add(p);
                g.FillEllipse(brush, p.X - 4, p.Y - 4, 6, 6); // deseneaza cercurile

            }
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen convex = new Pen(Color.Plum, 3);
            int p, q, r;
            bool valid;
            for (p = 0; p < n; p++)
            {
                for (q = 0; q < n; q++)
                {
                    if (p != q)
                    {
                        valid = true;
                        for (r = 0; r < n; r++)
                        {
                            if (r != p && r != q)
                            {
                                if (DetSensTrigonometric(points[p].X, points[p].Y, points[q].X, points[q].Y, points[r].X, points[r].Y) > 0)//daca se afla la dreapta
                                {
                                    valid = false;
                                }
                            }
                        }
                        if (valid)
                        {
                            g.DrawLine(convex, points[p].X, points[p].Y, points[q].X, points[q].Y);
                        }
                    }

                }
            }
        }

        private double DetSensTrigonometric(double pX, double pY, double qX, double qY, double rX, double rY)
        {
            return pX * qY + qX * rY + pY * rX - rX * qY - pX * rY - qX * pY;
        }
    }
}
