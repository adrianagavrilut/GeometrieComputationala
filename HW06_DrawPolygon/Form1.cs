using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW06_DrawPolygon
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
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //List<List<Point>> polygons = new List<List<Point>>();
        //int contorPoligoane = -1;
        //bool drawingMode = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen pen = new Pen(Color.Black, 3);
            Point aux = new Point(e.X, e.Y);
            g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
            contor++;
            g.DrawEllipse(pen, aux.X - 2, aux.Y - 2, 4, 4);
            Pen linie = new Pen(Color.DarkViolet, 2);
            if (points.Count != 0)
            {
                g.DrawLine(linie, aux, points[points.Count - 1]);
            }
            points.Add(aux);
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //if (drawingMode)
            //{
            //    Pen pen = new Pen(Color.Black, 3);
            //    Point aux = new Point(e.X, e.Y);
            //    Pen linie = new Pen(Color.DarkViolet, 2);
            //    if (polygons[contorPoligoane].Count != 0)
            //    {
            //        if ((aux.X >= polygons[contorPoligoane][0].X - 2 && aux.X <= (polygons[contorPoligoane][0].X + 2)) && (aux.Y >= polygons[contorPoligoane][0].Y - 2 && aux.Y <= (polygons[contorPoligoane][0].Y + 2)))
            //        {
            //            drawingMode = false;
            //            buttonDrawingMode.BackColor = Color.Red;
            //        }
            //        if (drawingMode)
            //        {
            //            g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
            //            contor++;
            //            g.DrawEllipse(pen, aux.X - 2, aux.Y - 2, 4, 4);
            //            g.DrawLine(linie, aux, polygons[contorPoligoane][polygons[contorPoligoane].Count - 1]);
            //            polygons[contorPoligoane].Add(aux);
            //        }
            //        else
            //        {
            //            g.DrawLine(linie, polygons[contorPoligoane][0], polygons[contorPoligoane][polygons[contorPoligoane].Count - 1]);
            //        }
            //    }
            //    else
            //    {
            //        g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
            //        contor++;
            //        label1.Text = (contorPoligoane + 1).ToString();
            //        g.DrawEllipse(pen, aux.X - 2, aux.Y - 2, 4, 4);
            //        polygons[contorPoligoane].Add(aux);

            //    }
            //}
        }

        private void buttonDrawingMode_Click(object sender, EventArgs e)
        {
        //    if (!drawingMode)
        //    {
        //        List<Point> points = new List<Point>();
        //        polygons.Add(points);
        //        contor = 1;
        //        contorPoligoane++;
        //        drawingMode = true;
        //        buttonDrawingMode.BackColor = Color.LightCyan;
        //    }
        //    else
        //    {
        //        Graphics g = panel1.CreateGraphics();
        //        Pen linie = new Pen(Color.DarkViolet, 2);
        //        if (polygons[contorPoligoane].Count != 0)
        //        {
        //            g.DrawLine(linie, polygons[contorPoligoane][0], polygons[contorPoligoane][polygons[contorPoligoane].Count - 1]);
        //            Brush brush = Brushes.LightGoldenrodYellow;
        //            g.FillPolygon(brush, polygons[contorPoligoane].ToArray());
        //        }
        //        else
        //        {
        //            polygons.RemoveAt(contorPoligoane);
        //            contorPoligoane--;
        //        }
        //        drawingMode = false;
        //        buttonDrawingMode.BackColor = Color.LightSkyBlue;
        //    }

        }
    }
}
