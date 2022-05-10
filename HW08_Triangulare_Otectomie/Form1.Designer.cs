
namespace HW08_Triangulare_Otectomie
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonThreeColor = new System.Windows.Forms.Button();
            this.buttonArie = new System.Windows.Forms.Button();
            this.labelArie = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 363);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // buttonDrawMode
            // 
            this.buttonDrawMode.Location = new System.Drawing.Point(762, 12);
            this.buttonDrawMode.Name = "buttonDrawMode";
            this.buttonDrawMode.Size = new System.Drawing.Size(75, 25);
            this.buttonDrawMode.TabIndex = 1;
            this.buttonDrawMode.Text = "DrawMode";
            this.buttonDrawMode.UseVisualStyleBackColor = true;
            this.buttonDrawMode.Click += new System.EventHandler(this.buttonDrawMode_Click);
            // 
            // buttonFinishUp
            // 
            this.buttonFinishUp.Enabled = false;
            this.buttonFinishUp.Location = new System.Drawing.Point(762, 43);
            this.buttonFinishUp.Name = "buttonFinishUp";
            this.buttonFinishUp.Size = new System.Drawing.Size(75, 25);
            this.buttonFinishUp.TabIndex = 2;
            this.buttonFinishUp.Text = "FinishUp";
            this.buttonFinishUp.UseVisualStyleBackColor = true;
            this.buttonFinishUp.Click += new System.EventHandler(this.buttonFinishUp_Click);
            // 
            // buttonTriang
            // 
            this.buttonTriang.Enabled = false;
            this.buttonTriang.Location = new System.Drawing.Point(762, 74);
            this.buttonTriang.Name = "buttonTriang";
            this.buttonTriang.Size = new System.Drawing.Size(75, 25);
            this.buttonTriang.TabIndex = 3;
            this.buttonTriang.Text = "Triangulate";
            this.buttonTriang.UseVisualStyleBackColor = true;
            this.buttonTriang.Click += new System.EventHandler(this.buttonTriang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(673, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Triangles";
            // 
            // buttonThreeColor
            // 
            this.buttonThreeColor.Enabled = false;
            this.buttonThreeColor.Location = new System.Drawing.Point(762, 105);
            this.buttonThreeColor.Name = "buttonThreeColor";
            this.buttonThreeColor.Size = new System.Drawing.Size(75, 25);
            this.buttonThreeColor.TabIndex = 6;
            this.buttonThreeColor.Text = "3-color";
            this.buttonThreeColor.UseVisualStyleBackColor = true;
            this.buttonThreeColor.Click += new System.EventHandler(this.buttonThreeColor_Click);
            // 
            // buttonArie
            // 
            this.buttonArie.Enabled = false;
            this.buttonArie.Location = new System.Drawing.Point(762, 136);
            this.buttonArie.Name = "buttonArie";
            this.buttonArie.Size = new System.Drawing.Size(75, 25);
            this.buttonArie.TabIndex = 7;
            this.buttonArie.Text = "Get Area";
            this.buttonArie.UseVisualStyleBackColor = true;
            this.buttonArie.Click += new System.EventHandler(this.buttonArie_Click);
            // 
            // labelArie
            // 
            this.labelArie.AutoSize = true;
            this.labelArie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelArie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArie.Location = new System.Drawing.Point(762, 172);
            this.labelArie.Name = "labelArie";
            this.labelArie.Size = new System.Drawing.Size(2, 18);
            this.labelArie.TabIndex = 8;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(9, 390);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(251, 13);
            this.labelInfo.TabIndex = 9;
            this.labelInfo.Text = "Punctele se deseneaza in sens invers trigonometric!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 424);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelArie);
            this.Controls.Add(this.buttonArie);
            this.Controls.Add(this.buttonThreeColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTriang);
            this.Controls.Add(this.buttonFinishUp);
            this.Controls.Add(this.buttonDrawMode);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1TriangOtectomie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDrawMode;
        private System.Windows.Forms.Button buttonFinishUp;
        private System.Windows.Forms.Button buttonTriang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonThreeColor;
        private System.Windows.Forms.Button buttonArie;
        private System.Windows.Forms.Label labelArie;
        private System.Windows.Forms.Label labelInfo;
    }
}


