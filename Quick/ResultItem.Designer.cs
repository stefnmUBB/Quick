namespace Quick
{
    partial class ResultItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.Body = new System.Windows.Forms.Panel();
            this.Body.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(3, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(44, 23);
            this.Title.TabIndex = 0;
            this.Title.Text = "Title";
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Sitka Small", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Description.Location = new System.Drawing.Point(16, 23);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(85, 19);
            this.Description.TabIndex = 1;
            this.Description.Text = "Description";
            this.Description.Click += new System.EventHandler(this.Description_Click);
            // 
            // Body
            // 
            this.Body.Controls.Add(this.Title);
            this.Body.Controls.Add(this.Description);
            this.Body.Location = new System.Drawing.Point(3, 3);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(394, 75);
            this.Body.TabIndex = 2;
            this.Body.Click += new System.EventHandler(this.Body_Click);
            this.Body.Paint += new System.Windows.Forms.PaintEventHandler(this.Body_Paint);
            // 
            // ResultItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Body);
            this.Name = "ResultItem";
            this.Size = new System.Drawing.Size(400, 81);
            this.Body.ResumeLayout(false);
            this.Body.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Panel Body;
    }
}
