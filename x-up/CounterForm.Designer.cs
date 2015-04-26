namespace x_up
{
    partial class CounterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterForm));
            this.counterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // counterLabel
            // 
            this.counterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.counterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.counterLabel.Location = new System.Drawing.Point(0, 0);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(67, 31);
            this.counterLabel.TabIndex = 0;
            this.counterLabel.Text = "0";
            this.counterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.counterLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
            this.counterLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // CounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(67, 31);
            this.Controls.Add(this.counterLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CounterForm";
            this.Opacity = 0.6D;
            this.Text = "X-UP";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label counterLabel;

    }
}

