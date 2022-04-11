
namespace HW06_DrawPolygon
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
            this.buttonDrawingMode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 341);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // buttonDrawingMode
            // 
            this.buttonDrawingMode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonDrawingMode.Location = new System.Drawing.Point(716, 13);
            this.buttonDrawingMode.Name = "buttonDrawingMode";
            this.buttonDrawingMode.Size = new System.Drawing.Size(53, 35);
            this.buttonDrawingMode.TabIndex = 1;
            this.buttonDrawingMode.Text = "Draw";
            this.buttonDrawingMode.UseVisualStyleBackColor = false;
            this.buttonDrawingMode.Click += new System.EventHandler(this.buttonDrawingMode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(716, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDrawingMode);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1DrawPolygon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDrawingMode;
        private System.Windows.Forms.Label label1;
    }
}

