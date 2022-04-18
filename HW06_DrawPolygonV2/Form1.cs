using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW06_DrawPolygonV2
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Paint += Panel1_Paint;
            panel1.Refresh();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Pen linie = new Pen(Color.DarkViolet, 2);
            points.Add(points[0]);
            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(linie, points[i], points[i + 1]);
            }
        }
    }
}
