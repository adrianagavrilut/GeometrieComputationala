using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HW07_Triangulare_DiagonaleV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region DrawPolygon

        Graphics g;
        List<Point> points = new List<Point>();
        int contor = 0;
        bool drawingMode = false;
        bool poligonInchis = false;

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
                poligonInchis = true;
            }
        }
        #endregion

        #region TriangulareDiag
        private void buttonTriang_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (points.Count <= 3)
            {
                return;
            }
            if (!poligonInchis)
            {
                buttonFinishUp_Click(sender, e);
            }
            Tuple<int, int>[] diagonale = new Tuple<int, int>[points.Count - 3];
            int contorDiag = 0;
            Pen penTR = new Pen(Color.Black, 2);
            for (int i = 0; i < points.Count - 2; i++)
            {
                for (int j = i + 2; j < points.Count; j++)
                {
                    if (i == 0 && j == points.Count - 1)
                    {
                        break;
                    }
                    bool intersectie = false;
                    //nu intersecteaza laturi neinciente
                    for (int k = 0; k < points.Count - 1; k++)
                    {
                        if (i != k && i != (k + 1) && j != k && j != (k + 1) && se_intersecteaza(points[i], points[j], points[k], points[k + 1]))
                        {
                            intersectie = true;
                            break;
                        }
                    }
                    //vf pt ultima latura
                    if (i != points.Count - 1 && i != 0 && j != points.Count - 1 && j != 0 && se_intersecteaza(points[i], points[j], points[points.Count - 1], points[0]))
                    {
                        intersectie = true;
                    }
                    //nu interseceata diagonale
                    if (!intersectie)
                    {
                        for (int k = 0; k < contorDiag; k++)
                        {
                            if (i != diagonale[k].Item1 && i != diagonale[k].Item2 && j != diagonale[k].Item1 && j != diagonale[k].Item2 && se_intersecteaza(points[i], points[j], points[diagonale[k].Item1], points[diagonale[k].Item2]))
                            {
                                intersectie = true;
                                break;
                            }
                        }
                        //se afla in interiorul P
                        if (!intersectie)
                        {
                            if (se_afla_in_interiorul_poligonului(i, j))
                            {
                                Thread.Sleep(100);
                                g.DrawLine(penTR, points[i], points[j]);
                                diagonale[contorDiag] = new Tuple<int, int>(i, j);
                                contorDiag++;
                            }
                        }
                    }
                    if (contorDiag == points.Count - 3)
                    {
                        return;
                    }
                }
            }
        }

        private int ValoareDeterminant(Point a, Point b, Point c)
        {
            return a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - a.X * c.Y - b.X * a.Y;
        }

        private bool se_afla_in_interiorul_poligonului(int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : points.Count - 1;
            int pi_urm = (pi < points.Count - 1) ? pi + 1 : 0;
            if ((este_varf_convex(pi) && intoarcere_spre_stanga(pi, pj, pi_urm) && intoarcere_spre_stanga(pi, pi_ant, pj)) || (este_varf_reflex(pi) && !(intoarcere_spre_dreapta(pi, pj, pi_urm) && intoarcere_spre_dreapta(pi, pi_ant, pj))))
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_dreapta(int p1, int p2, int p3)
        {
            if (ValoareDeterminant(points[p1], points[p2], points[p3]) > 0)
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_stanga(int p1, int p2, int p3)
        {
            if (ValoareDeterminant(points[p1], points[p2], points[p3]) < 0)
            {
                return true;
            }
            return false;
        }

        private bool este_varf_reflex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : points.Count - 1;
            int p_urm = (p < points.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_stanga(p_ant, p, p_urm);
        }

        private bool este_varf_convex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : points.Count - 1;
            int p_urm = (p < points.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_dreapta(p_ant, p, p_urm);
        }

        private bool se_intersecteaza(Point s1, Point s2, Point p1, Point p2)
        {
            if (ValoareDeterminant(p2, p1, s1) * ValoareDeterminant(p2, p1, s2) <= 0 && ValoareDeterminant(s2, s1, p1) * ValoareDeterminant(s2, s1, p2) <= 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
