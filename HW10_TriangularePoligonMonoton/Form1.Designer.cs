
namespace HW10_TriangularePoligonMonoton
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFinishUp = new System.Windows.Forms.Button();
            this.buttonPartiton = new System.Windows.Forms.Button();
            this.buttonTriangulate = new System.Windows.Forms.Button();
            this.buttonSavePolygons = new System.Windows.Forms.Button();
            this.listBoxPoligoane = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 343);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "DrawMode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFinishUp
            // 
            this.buttonFinishUp.Enabled = false;
            this.buttonFinishUp.Location = new System.Drawing.Point(639, 43);
            this.buttonFinishUp.Name = "buttonFinishUp";
            this.buttonFinishUp.Size = new System.Drawing.Size(75, 23);
            this.buttonFinishUp.TabIndex = 2;
            this.buttonFinishUp.Text = "FinishUp";
            this.buttonFinishUp.UseVisualStyleBackColor = true;
            this.buttonFinishUp.Click += new System.EventHandler(this.buttonFinishUp_Click);
            // 
            // buttonPartiton
            // 
            this.buttonPartiton.Enabled = false;
            this.buttonPartiton.Location = new System.Drawing.Point(638, 72);
            this.buttonPartiton.Name = "buttonPartiton";
            this.buttonPartiton.Size = new System.Drawing.Size(75, 23);
            this.buttonPartiton.TabIndex = 3;
            this.buttonPartiton.Text = "Partition";
            this.buttonPartiton.UseVisualStyleBackColor = true;
            this.buttonPartiton.Click += new System.EventHandler(this.buttonPartiton_Click);
            // 
            // buttonTriangulate
            // 
            this.buttonTriangulate.Enabled = false;
            this.buttonTriangulate.Location = new System.Drawing.Point(638, 130);
            this.buttonTriangulate.Name = "buttonTriangulate";
            this.buttonTriangulate.Size = new System.Drawing.Size(75, 23);
            this.buttonTriangulate.TabIndex = 4;
            this.buttonTriangulate.Text = "Triangulate";
            this.buttonTriangulate.UseVisualStyleBackColor = true;
            this.buttonTriangulate.Click += new System.EventHandler(this.buttonTriangulate_Click);
            // 
            // buttonSavePolygons
            // 
            this.buttonSavePolygons.Enabled = false;
            this.buttonSavePolygons.Location = new System.Drawing.Point(638, 101);
            this.buttonSavePolygons.Name = "buttonSavePolygons";
            this.buttonSavePolygons.Size = new System.Drawing.Size(75, 23);
            this.buttonSavePolygons.TabIndex = 5;
            this.buttonSavePolygons.Text = "SavePolygons";
            this.buttonSavePolygons.UseVisualStyleBackColor = true;
            this.buttonSavePolygons.Click += new System.EventHandler(this.buttonSavePolygons_Click);
            // 
            // listBoxPoligoane
            // 
            this.listBoxPoligoane.FormattingEnabled = true;
            this.listBoxPoligoane.Location = new System.Drawing.Point(638, 171);
            this.listBoxPoligoane.Name = "listBoxPoligoane";
            this.listBoxPoligoane.Size = new System.Drawing.Size(76, 147);
            this.listBoxPoligoane.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 374);
            this.Controls.Add(this.listBoxPoligoane);
            this.Controls.Add(this.buttonSavePolygons);
            this.Controls.Add(this.buttonTriangulate);
            this.Controls.Add(this.buttonPartiton);
            this.Controls.Add(this.buttonFinishUp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "FormPartPoligMontone";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonFinishUp;
        private System.Windows.Forms.Button buttonPartiton;
        private System.Windows.Forms.Button buttonTriangulate;
        private System.Windows.Forms.Button buttonSavePolygons;
        private System.Windows.Forms.ListBox listBoxPoligoane;
    }
}

