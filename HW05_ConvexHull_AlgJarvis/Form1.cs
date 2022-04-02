using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW05_ConvexHull_AlgJarvis
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

        private void buttonDraw_Click_1(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(SystemColors.GradientInactiveCaption);
            Brush brush = new SolidBrush(Color.Black);
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
                g.FillEllipse(brush, p.X - 2, p.Y - 2, 5, 5); // deseneaza cercurile

            }
        }

        private void buttonCompute_Click_1(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen convex = new Pen(Color.DarkMagenta, 3);

            List<int> hull = new List<int>(); //lista indicilor pct invelitorii convexe
            bool goOn;
            int iMin = 0;
            for (int i = 0; i < n; i++)
            {
                if (points[i].Y < points[iMin].Y)
                {
                    iMin = i;
                }
            }
            hull.Add(iMin);//punctul cel mai de jos si din stanga este primul punct din hull
            do
            {
                goOn = true;
                int pArbitrar = (hull[hull.Count - 1] + 1) % n;//un punct aleator care sa fie difeit de ultimul pct de pe invelitoare( %n ca sa nu treaca de n, ci sa apartina listei)
                for (int i = 0; i < n; i++)
                {
                    //sensul trig intre ultimul punct dun hull, fiecare punct din lista si un punct aleator
                    if (DetSensTrigonometric(points[hull[hull.Count - 1]].X, points[hull[hull.Count - 1]].Y, points[i].X, points[i].Y, points[pArbitrar].X, points[pArbitrar].Y) > 0)
                    {
                        pArbitrar = i;
                    }
                }
                hull.Add(pArbitrar); //se adauga urmatorul pct de pe invelitoare
                if (pArbitrar == iMin)
                {
                    goOn = false;//daca ajunge la primul punct se opreste
                }
            } while (goOn);

            for (int i = 0; i < hull.Count - 1; i++)
            {
                //desenarea invelitorii convexe
                g.DrawLine(convex, points[hull[i]].X, points[hull[i]].Y, points[hull[i+1]].X, points[hull[i+1]].Y);
            }
        }

        private double DetSensTrigonometric(double pX, double pY, double qX, double qY, double rX, double rY)
        {
            return pX * qY + qX * rY + pY * rX - rX * qY - pX * rY - qX * pY;
            // det = 0 => coliniare
            // det > 0 => sensul invers trig, sensul acelor de ceasornic, 'spre dreapta'
            // det < 0 => sensul trigonometric, 'spre stanga'
        }
    }
}
