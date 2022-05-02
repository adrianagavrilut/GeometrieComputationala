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
        int contor = 0;
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

        private void buttonDrawMode_Click(object sender, EventArgs e)
        {
            if (!drawingMode)
            {
                drawingMode = true;
                buttonDrawMode.Enabled = false;
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
            for (int i = 0; i < points.Count - 2; i++)
            {
                for (int j = i + 2; j < points.Count; j++)
                {
                    if (i == 0 && j == points.Count - 1)
                    {
                        break;
                    }
                    if (!IntersecteazaLaturi(points[i], points[j], i, j) &&
                        !IntersecteazaDiagonale(points[i], points[j]) &&
                        ApartinePoligon(points[i], points[j], i, j))
                    {
                        diagonale.Add(i);
                        diagonale.Add(j);
                        g.DrawLine(penTR, points[i], points[j]);
                        contorDiag++;
                    }
                }
            }
        }

        private bool IntersecteazaLaturi(Point a, Point b, int pozA, int pozB)
        {
            bool toReturn = false;
            for (int i = 0; i < points.Count; i++)
            {
                float xIntersectie, yIntersectie;
                if (DeterminaIntersectiaG(a, b, points[i], points[(i + 1) % points.Count], out xIntersectie, out yIntersectie))
                {
                    if (!((Math.Round(xIntersectie) == a.X && Math.Round(yIntersectie) == a.Y) || (Math.Round(xIntersectie) == b.X && Math.Round(yIntersectie) == b.Y)))
                    {
                        toReturn = true;
                    }
                }
            }
            return toReturn;
        }

        //private int ProdusDeterminant(Point b2, Point b1, Point a1, Point a2)
        //{
        //    return ValoareDeterminant(b2, b1, a1) * ValoareDeterminant(b2, b1, a2);
        //}

        private int ValoareDeterminant(Point a, Point b , Point c)
        {
            return a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - a.X * c.Y - b.X * a.Y;
        }

        private bool IntersecteazaDiagonale(Point a, Point b)
        {
            bool toReturn = false;
            for (int i = 0; i < diagonale.Count - 1; i++)
            {
                float xIntersectie, yIntersectie;
                if (DeterminaIntersectiaG(a, b, points[diagonale[i]], points[diagonale[i + 1]], out xIntersectie, out yIntersectie))
                {
                    if (!((Math.Round(xIntersectie) == a.X && Math.Round(yIntersectie) == a.Y) || (Math.Round(xIntersectie) == b.X && Math.Round(yIntersectie) == b.Y)))
                    {
                        toReturn = true;
                    }
                }
            }
            return toReturn;
        }

        private bool ApartinePoligon(Point a, Point b, int pozA, int pozB)
        {
            //segmentul  ab apartine poligonului daca cel putin 1 punct apartine poligonului
            Point v1 = points[(pozA + 1) % points.Count];
            Point v2 = points[(pozA - 1) < 0 ? points.Count - 1 : pozA - 1];
            if (ValoareDeterminant(v2, a, v1) < 0)
            {
                if(ValoareDeterminant(a, b, v1) > 0 && ValoareDeterminant(a, v2, b) > 0)
                {
                    return true;
                }
            }
            else
            {
                if (ValoareDeterminant(a, b, v1) < 0 && ValoareDeterminant(a, v2, b) < 0)
                {
                    return true;
                }
            }
            return false;
        }

        static public float DeterminantG(float a1, float b1, float a2, float b2)
        {
            return a1 * b2 - a2 * b1;
        }

        static public bool RezolvaSistemulG(float a1, float b1, float c1, float a2, float b2, float c2, ref float x, ref float y)
        {
            x = 0;
            y = 0;
            float d = DeterminantG(a1, b1, a2, b2);
            if (d == 0)
                return false;
            else
            {
                x = DeterminantG(c1, b1, c2, b2) / d;
                y = DeterminantG(a1, c1, a2, c2) / d;

                return true;
            }
        }

        public bool DeterminaIntersectiaG(Point p11, Point p12, Point p21, Point p22, out float x, out float y)
        {
            x = 0;
            y = 0;
            bool exista = false;
            bool orizontal1 = false, orizontal2 = false, vertical1 = false, vertical2 = false;
            int ok = 0;
            if (p11.X == p12.X)
                vertical1 = true;
            if (p11.Y == p12.Y)
                orizontal1 = true;
            if (p21.X == p22.X)
                vertical2 = true;
            if (p21.Y == p22.Y)
                orizontal2 = true;
            if (vertical1 && orizontal2)
                if (RezolvaSistemulG(1, 0, p11.X, 0, 1, p21.Y, ref x, ref y) == true)
                    exista = true;
            if (orizontal1 && vertical2)
                if (RezolvaSistemulG(0, 1, p11.Y, 1, 0, p21.X, ref x, ref y) == true)
                    exista = true;
            if (orizontal1 == true && (vertical2 == false && orizontal2 == false))
                if (RezolvaSistemulG(0, 1, p11.Y, ((float)(p22.Y - p21.Y)) / (p22.X - p21.X), -1, ((float)(p21.X * p22.Y - p22.X * p21.Y)) / (p22.X - p21.X), ref x, ref y) == true)
                    exista = true;
            if (vertical1 == true && (vertical2 == false && orizontal2 == false))
                if (RezolvaSistemulG(1, 0, p11.X, ((float)(p22.Y - p21.Y)) / (p22.X - p21.X), -1, ((float)(p21.X * p22.Y - p22.X * p21.Y)) / (p22.X - p21.X), ref x, ref y) == true)
                    exista = true;
            if (orizontal2 == true && (vertical1 == false && orizontal1 == false))
                if (RezolvaSistemulG(((float)(p12.Y - p11.Y)) / (p12.X - p11.X), -1, ((float)(p11.X * p12.Y - p12.X * p11.Y)) / (p12.X - p11.X), 0, 1, p21.Y, ref x, ref y) == true)
                    exista = true;
            if (vertical2 == true && (vertical1 == false && orizontal1 == false))
                if (RezolvaSistemulG(((float)(p12.Y - p11.Y)) / (p12.X - p11.X), -1, ((float)(p11.X * p12.Y - p12.X * p11.Y)) / (p12.X - p11.X), 1, 0, p21.X, ref x, ref y) == true)
                    exista = true;
            if ((orizontal1 == false && vertical1 == false) && (orizontal2 == false && vertical2 == false))
                if (RezolvaSistemulG(((float)(p12.Y - p11.Y)) / (p12.X - p11.X), -1,
                    ((float)(p11.X * p12.Y - p12.X * p11.Y)) / (p12.X - p11.X),
                    ((float)(p22.Y - p21.Y)) / (p22.X - p21.X), -1,
                    ((float)(p21.X * p22.Y - p22.X * p21.Y)) / (p22.X - p21.X), ref x, ref y) == true)
                    exista = true;
            if (exista == true)
            {
                if ((p11.X <= x && x <= p12.X) || (p12.X <= x && x <= p11.X))
                    ok++;
                if ((p21.X <= x && x <= p22.X) || (p22.X <= x && x <= p21.X))
                    ok++;
                if ((p11.Y <= y && y <= p12.Y) || (p12.Y <= y && y <= p11.Y))
                    ok++;
                if ((p21.Y <= y && y <= p22.Y) || (p22.Y <= y && y <= p21.Y))
                    ok++;
                if (ok == 4)
                    return true;
                else
                    return false;


            }
            else
                return false;
        }
    }
}
