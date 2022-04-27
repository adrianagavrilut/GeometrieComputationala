using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW07_Triangulare_Diagonale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        List<Point> points = new List<Point>();
        int contor = 1;
        bool drawingMode = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (drawingMode)
            {
                Pen pen = new Pen(Color.Black, 3);
                Point aux = new Point(e.X, e.Y);
                Pen linie = new Pen(Color.DarkViolet, 2);
                g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
                contor++;
                g.DrawEllipse(pen, aux.X - 2, aux.Y - 2, 4, 4);
                if (points.Count != 0)
                {
                    g.DrawLine(linie, aux, points[points.Count - 1]);
                }
                points.Add(aux);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!drawingMode)
            {
                drawingMode = true;
                button1.Enabled = false;
                buttonFinishUp.Enabled = true;
            }
        }

        private void buttonFinishUp_Click(object sender, EventArgs e)
        {
            if (drawingMode)
            {
                Graphics g = panel1.CreateGraphics();
                Pen linie = new Pen(Color.DarkViolet, 2);
                g.DrawLine(linie, points[0], points[points.Count - 1]);
                buttonFinishUp.Enabled = false;
                drawingMode = false;
                buttonTriang.Enabled = true;
            }
        }

        List<int> diagonale = new List<int>();

        private void buttonTriang_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen penTR = new Pen(Color.Purple, 2);
            int contorDiag = 0;
            for (int i = 0; i < points.Count - 3; i++)
            {
                for (int j = i + 2; j < points.Count - 1; j++)
                {
                    //g.DrawLine(penTR, points[i], points[j]);

                    if (i == 0 && j == points.Count - 1)
                    {
                        break;
                    }
                    if (!IntersectieLaturi(points[i], points[j], points[i + 1], points[j + 1]) && !IntersectieLaturi(points[i], points[j], points[i - 1], points[j - 1]) &&
                        !IntersectieDiagonale(points[i], points[j]) &&
                        InteriorPoligon(points[i], points[j]))
                    {
                        diagonale.Add(i);
                        diagonale.Add(j);
                        g.DrawLine(penTR, points[i], points[j]);
                        contorDiag++;
                    }
                    if (contorDiag == points.Count - 3)
                    {
                        return;
                    }
                }
            }
        }

        private bool IntersectieLaturi(Point a1, Point b1, Point a2, Point b2)
        {
            if (ProdusDeterminant(b2, b1, a1, a2) <= 0 && ProdusDeterminant(a2, a1, b1, b2) <= 0)
            {
                return true;
            }
            return false;
        }

        private int ProdusDeterminant(Point b2, Point b1, Point a1, Point a2)
        {
            return ValoareDeterminant(b2, b1, a1) * ValoareDeterminant(b2, b1, a2);
        }

        private int ValoareDeterminant(Point a, Point b , Point c)
        {
            return a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - a.X * c.Y - b.X * a.Y;
        }

        private bool IntersectieDiagonale(Point a, Point b)
        {
            for (int i = 0; i < diagonale.Count - 1; i++)
            {
                if (ProdusDeterminant(b, a, points[diagonale[i]], points[diagonale[i + 1]]) <= 0 && ProdusDeterminant(points[diagonale[i + 1]], points[diagonale[i]], a, b) <= 0)
                {
                    return true;
                }
            }
            return false;
        }
        private bool InteriorPoligon(Point a, Point b)
        {
            int iSus = -1, iJos = -1, iSt = -1, iDr = -1;
            //cel mai de sus pct
            //cel mai de jos
            //cel mai din stanga
            //cel mai din drapta
            for (int i = 0; i < points.Count; i++)
            {
                if (iSus < points[i].Y)
                {
                    iSus = i;
                }
                if (iJos > points[i].Y)
                {
                    iJos = i;
                }
                if (iSt < points[i].X)
                {
                    iSt = i;
                }
                if (iDr > points[i].X)
                {
                    iDr = i;
                }
            }
            //a, b in interior
            for (int i = 0; i < points.Count; i++)
            {
                if (a.Y > points[iSus].Y && a.Y < points[iJos].Y && a.X > points[iSt].X && a.X < points[iDr].Y && b.Y > points[iSus].Y && b.Y < points[iJos].Y && b.X > points[iSt].X && b.X < points[iDr].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
