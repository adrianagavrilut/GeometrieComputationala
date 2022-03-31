using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03HW_CercArieMin
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
            g.Clear(SystemColors.GradientInactiveCaption);
            Brush brush = new SolidBrush(Color.Navy);
            if (!int.TryParse(this.textBoxN.Text, out n))
            {
                n = 0;
                MessageBox.Show("Va rugam sa introduceti un numar");
            }
            points = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                Point p = new Point(rnd.Next(200, this.panel1.Width - 200), rnd.Next(100, this.panel1.Height - 100));
                points.Add(p);
                g.FillEllipse(brush, p.X - 2, p.Y - 2, 4, 4);
                // deseneaza cercurile
            }
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen cerc = new Pen(Color.Red, 2);
            double distMAx = Double.MinValue;
            double distMAx1 = Double.MinValue;
            float x1 = 0, x2 = 0, y1 = 0, y2 = 0, xA = 0, yA = 0;
            //distanta cea mai mare dintre doua puncte
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count - 1; j++)
                {
                    double diametru = Distanta2Pct(points[i].X, points[i].Y, points[j].X, points[j].Y);
                    if (distMAx < diametru)
                    {
                        distMAx = diametru;
                        //coordonatele celor mai deparate doua puncte
                        x1 = points[i].X;
                        x2 = points[j].X;
                        y1 = points[i].Y;
                        y2 = points[j].Y;
                    }
                }
            }
            //coordonate centru
            float xCentru = (float)(x1 + x2) / 2;
            float yCentru = (float)(y1 + y2) / 2;
            for (int i = 0; i < points.Count; i++)
            {
                float dist1 = Distanta2Pct(points[i].X, points[i].Y, xCentru, yCentru);
                if (distMAx1 < dist1)
                {
                    distMAx1 = dist1;
                    //punctul A cel mai departat de centru
                    xA = points[i].X;
                    yA = points[i].Y;
                }
            }
            //raza cercului e distanta dintre punctul A si centru
            float raza = Distanta2Pct(xCentru, yCentru, xA, yA);
            //deseneaza cercul
            g.DrawEllipse(cerc, xCentru - raza, yCentru - raza, raza + raza, raza + raza);
        }

        private float Distanta2Pct(float x1, float y1, float x2, float y2)
        {
            float dist = (float)Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            return dist;
        }
    }
}
