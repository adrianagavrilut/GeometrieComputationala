using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01_DreptunghiArieMin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        Graphics g;
        int n, xMax = 0, yMax = 0, xMin = 900, yMin = 500;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

            Pen p = new Pen(Color.Black, 3);
            n = rnd.Next(500);
            for (int i = 0; i < n; i++)
            {
                int x = rnd.Next(80, 800);
                int y = rnd.Next(80, 400);
                g.DrawEllipse(p, x, y, 3, 3);
                if (xMax < x)
                {
                    xMax = x;
                }
                if (yMax < y)
                {
                    yMax = y;
                }
                if (xMin > x)
                {
                    xMin = x;
                }
                if (yMin > y)
                {
                    yMin = y;
                }
            }
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen dr = new Pen(Color.Red, 3);
            g.DrawLine(dr, xMin, yMin, xMax, yMin); //lungime sus
            g.DrawLine(dr, xMin, yMax, xMax, yMax); //lungime jos
            g.DrawLine(dr, xMin, yMin, xMin, yMax); //latime stanga
            g.DrawLine(dr, xMax, yMin, xMax, yMax); //latime dreapta
        }
    }
}
