﻿
namespace HW07_Triangulare_DiagonaleV2
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
            this.buttonDrawMode = new System.Windows.Forms.Button();
            this.buttonFinishUp = new System.Windows.Forms.Button();
            this.buttonTriang = new System.Windows.Forms.Button();
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
            // buttonDrawMode
            // 
            this.buttonDrawMode.Location = new System.Drawing.Point(639, 13);
            this.buttonDrawMode.Name = "buttonDrawMode";
            this.buttonDrawMode.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawMode.TabIndex = 1;
            this.buttonDrawMode.Text = "DrawMode";
            this.buttonDrawMode.UseVisualStyleBackColor = true;
            this.buttonDrawMode.Click += new System.EventHandler(this.buttonDrawMode_Click);
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
            // buttonTriang
            // 
            this.buttonTriang.Enabled = false;
            this.buttonTriang.Location = new System.Drawing.Point(639, 73);
            this.buttonTriang.Name = "buttonTriang";
            this.buttonTriang.Size = new System.Drawing.Size(75, 23);
            this.buttonTriang.TabIndex = 3;
            this.buttonTriang.Text = "Triangulate";
            this.buttonTriang.UseVisualStyleBackColor = true;
            this.buttonTriang.Click += new System.EventHandler(this.buttonTriang_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 367);
            this.Controls.Add(this.buttonTriang);
            this.Controls.Add(this.buttonFinishUp);
            this.Controls.Add(this.buttonDrawMode);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1TriangulareDiag";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDrawMode;
        private System.Windows.Forms.Button buttonFinishUp;
        private System.Windows.Forms.Button buttonTriang;
    }
}
