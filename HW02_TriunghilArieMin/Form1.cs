using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW02_TriunghilArieMin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        int n;
        List<Point> points;
        Graphics g;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            //deseneaza un nr n introdus de la tastatura de cercuri
            Graphics g = panel1.CreateGraphics();
            g.Clear(SystemColors.ControlDark);
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
                g.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);
            }
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen tri = new Pen(Color.Red, 2);
            double arieMin = Double.MaxValue;
            int indexVf1 = 0, indexVf2 = 0, indexVf3 = 0;
            //cauta aria minima intre 3 puncte
            //salveaza indecsii punctelor
            for (int i = 0; i < points.Count - 2; i++)
            {
                for (int j = i + 1; j < points.Count - 1; j++)
                {
                    for (int k = j + 1; k < points.Count; k++)
                    {
                        double arie = ArieTriunghi(points[i].X, points[i].Y, points[j].X, points[j].Y, points[k].X, points[k].Y);
                        if (arie != 0 && arie < arieMin) // arie != 0 -> conditie daca avem 3 pcte coliniare
                        {
                            arieMin = arie;
                            indexVf1 = i;
                            indexVf2 = j;
                            indexVf3 = k;
                        }
                    }
                }
            }
            labelResult.Text = arieMin.ToString();
            Point[] varfuri = { points[indexVf1], points[indexVf2], points[indexVf3] };
            //deseneaza triunghi
            g.DrawPolygon(tri, varfuri);
        }

        private double ArieTriunghi(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            double arie = 0.5 * Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x3 * y2 - x1 * y3 - x2 * y1);
            return arie;
        }
    }
}
