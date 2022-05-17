using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW09_PartitionarePoligoaneMonotone
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

        int contor = 1;
        bool drawingMode = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //points.Add(new Point(269, 25));
            //points.Add(new Point(316, 104));
            //points.Add(new Point(378, 50));
            //points.Add(new Point(384, 140));
            //points.Add(new Point(438, 121));
            //points.Add(new Point(507, 195));
            //points.Add(new Point(383, 207));
            //points.Add(new Point(387, 258));
            //points.Add(new Point(284, 331));
            //points.Add(new Point(227, 209));
            //points.Add(new Point(78, 277));
            //points.Add(new Point(142, 102));
            //points.Add(new Point(268, 175));
            //points.Add(new Point(218, 65));
            //points.Add(new Point(68, 70));
            //Pen pen = new Pen(Color.Black, 2);
            //if (points.Count > 1)
            //{
            //    e.Graphics.DrawLines(pen, points.ToArray());
            //    for(int i=0;i<points.Count;i++)
            //    {
            //        g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), points[i].X - 20, points[i].Y - 20);
            //        contor++;
            //    }
            //}

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            if (drawingMode)
            {
                Pen pen = new Pen(Color.Black, 3);
                Point aux = new Point(e.X, e.Y);
                Pen linie = new Pen(Color.Black, 2);
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
                Pen linie = new Pen(Color.Black, 2);
                g.DrawLine(linie, points[0], points[points.Count - 1]);
                buttonFinishUp.Enabled = false;
                drawingMode = false;
                buttonPartiton.Enabled = true;
            }
        }
        #endregion

        #region Partition
        private void buttonPartiton_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen penPart = new Pen(Color.DarkViolet, 2);
            float[] dashValues = { 3, 2, 3, 2 };
            penPart.DashPattern = dashValues;
            //fara sortare vf dupa ordonata
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (este_varf_reflex(points, i))
                {
                    //cazul cand i == 0 (i - 1 <=> points.Count - 1)
                    if (i == 0)
                    {
                        if (este_sub(i, (points.Count - 1)) && este_sub(i, (i + 1)))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, points[i], points[index]);
                        }
                        if (este_deasupra(i, (points.Count - 1)) && este_deasupra(i, (i + 1)))
                        {
                            int index = UnVarfSubVarful(i);
                            g.DrawLine(penPart, points[i], points[index]);
                        }
                    }
                    // cazul cand i == n - 1 (i + 1 <=> 0)
                    else if (i == points.Count - 1)
                    {
                        if (este_sub(i, (i - 1)) && este_sub(i, 0))
                        {
                            int index = UnVarfDeasupraVarfului(i);
                            g.DrawLine(penPart, points[i], points[index]);
                        }
                        if (este_deasupra(i, (i - 1)) && este_deasupra(i, 0))
                        {
                            int index = UnVarfSubVarful(i); 
                            g.DrawLine(penPart, points[i], points[index]);
                        }
                    }
                    else
                    {
                        if (este_sub(i, (i - 1)) && este_sub(i, (i + 1)))//p(i-1) si p(i+1) se afla sub p(i)
                        {
                            //unim p(i) cu un vf aflat deasupra lui
                            int index = UnVarfDeasupraVarfului(i); //cel mai de jos  care e deasupra
                                                                   //p[i] vf de separare
                            g.DrawLine(penPart, points[i], points[index]);
                        }
                        if (este_deasupra(i, (i - 1)) && este_deasupra(i, (i + 1)))//p(i-1) si p(i+1) se afla deasupra p(i)
                        {
                            //unim cu un vf sub el
                            int index = UnVarfSubVarful(i); //cel mai de sus care e sub
                                                            //p[i] vf de unire
                            g.DrawLine(penPart, points[i], points[index]);
                        }
                    }
                }
            }
        }

        private int UnVarfDeasupraVarfului(int i)
        {
            int minIndex = -1;
            for (int index = 0; index < points.Count; index++)
            {
                if (este_deasupra(i, index)  && IsDiagonal(points, i, index))
                {
                    if (minIndex == -1)
                    {
                        minIndex = index;
                    }
                    else
                    {
                        if (points[index].Y > points[minIndex].Y)
                        {
                            minIndex = index;
                        }
                    }
                }
            }
            return minIndex;
        }

        private int UnVarfSubVarful(int i)
        {
            int maxIndex = -1;
            for (int index = 0; index < points.Count; index++)
            {
                if (este_sub(i, index) && IsDiagonal(points, i, index))
                {
                    if(maxIndex == -1)
                    {
                        maxIndex = index;
                    }
                    else
                    {
                        if (points[index].Y < points[maxIndex].Y)
                        {
                            maxIndex = index;
                        }
                    }
                }
            }
            return maxIndex;
        }

        private bool este_sub(int i, int j)
        {
            if (points[j].Y > points[i].Y || (points[j].Y == points[i].Y && points[j].X < points[i].X))
            {
                return true;
            }
            return false;
        }

        private bool este_deasupra(int i, int j)
        {
            if (points[j].Y < points[i].Y || (points[j].Y == points[i].Y && points[j].X < points[i].X))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region FunctiiDiagonala

        private bool IsDiagonal(List<Point> puncte, int i, int j)
        {
            bool intersectie = false;
            //nu intersecteaza laturi neinciente
            for (int k = 0; k < puncte.Count - 1; k++)
            {
                if (i != k && i != (k + 1) && j != k && j != (k + 1) && se_intersecteaza(puncte[i], puncte[j], puncte[k], puncte[k + 1]))
                {
                    intersectie = true;
                    break;
                }
            }
            //vf pt ultima latura
            if (i != puncte.Count - 1 && i != 0 && j != puncte.Count - 1 && j != 0 && se_intersecteaza(puncte[i], puncte[j], puncte[puncte.Count - 1], puncte[0]))
            {
                intersectie = true;
            }
            //se afla in interiorul P
            if (!intersectie && se_afla_in_interiorul_poligonului(puncte, i, j))
            {
                return true;
            }
            return false;
        }

        private int ValoareDeterminant(Point a, Point b, Point c)
        {
            return a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - a.X * c.Y - b.X * a.Y;
        }

        private bool se_afla_in_interiorul_poligonului(List<Point> puncte, int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : puncte.Count - 1;
            int pi_urm = (pi < puncte.Count - 1) ? pi + 1 : 0;
            if ((este_varf_convex(puncte, pi) && intoarcere_spre_stanga(puncte, pi, pj, pi_urm) && intoarcere_spre_stanga(puncte, pi, pi_ant, pj)) || (este_varf_reflex(puncte, pi) && !(intoarcere_spre_dreapta(puncte, pi, pj, pi_urm) && intoarcere_spre_dreapta(puncte, pi, pi_ant, pj))))
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_dreapta(List<Point> puncte, int p1, int p2, int p3)
        {
            if (ValoareDeterminant(puncte[p1], puncte[p2], puncte[p3]) > 0)
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_stanga(List<Point> puncte, int p1, int p2, int p3)
        {
            if (ValoareDeterminant(puncte[p1], puncte[p2], puncte[p3]) < 0)
            {
                return true;
            }
            return false;
        }

        private bool este_varf_reflex(List<Point> puncte, int p)
        {
            int p_ant = (p > 0) ? p - 1 : puncte.Count - 1;
            int p_urm = (p < puncte.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_stanga(puncte, p_ant, p, p_urm);
        }

        private bool este_varf_convex(List<Point> puncte, int p)
        {
            int p_ant = (p > 0) ? p - 1 : puncte.Count - 1;
            int p_urm = (p < puncte.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_dreapta(puncte, p_ant, p, p_urm);
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
