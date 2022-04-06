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

        List<Point> points = new List<Point>();

        private void panel1_Click(object sender, EventArgs e)
        {
            Point p = panel1.PointToClient(Cursor.Position);
            points.Add(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
