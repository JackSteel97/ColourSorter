namespace ColourSorter {
    partial class ParentForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.startBtn = new System.Windows.Forms.Button();
            this.heightNum = new System.Windows.Forms.NumericUpDown();
            this.widthNum = new System.Windows.Forms.NumericUpDown();
            this.heightLbl = new System.Windows.Forms.Label();
            this.widthLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.heightNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNum)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(158, 87);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // heightNum
            // 
            this.heightNum.Location = new System.Drawing.Point(248, 192);
            this.heightNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.heightNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNum.Name = "heightNum";
            this.heightNum.Size = new System.Drawing.Size(65, 20);
            this.heightNum.TabIndex = 1;
            this.heightNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // widthNum
            // 
            this.widthNum.Location = new System.Drawing.Point(248, 238);
            this.widthNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.widthNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNum.Name = "widthNum";
            this.widthNum.Size = new System.Drawing.Size(65, 20);
            this.widthNum.TabIndex = 2;
            this.widthNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // heightLbl
            // 
            this.heightLbl.AutoSize = true;
            this.heightLbl.Location = new System.Drawing.Point(201, 194);
            this.heightLbl.Name = "heightLbl";
            this.heightLbl.Size = new System.Drawing.Size(41, 13);
            this.heightLbl.TabIndex = 3;
            this.heightLbl.Text = "Height:";
            // 
            // widthLbl
            // 
            this.widthLbl.AutoSize = true;
            this.widthLbl.Location = new System.Drawing.Point(204, 240);
            this.widthLbl.Name = "widthLbl";
            this.widthLbl.Size = new System.Drawing.Size(38, 13);
            this.widthLbl.TabIndex = 4;
            this.widthLbl.Text = "Width:";
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 436);
            this.Controls.Add(this.widthLbl);
            this.Controls.Add(this.heightLbl);
            this.Controls.Add(this.widthNum);
            this.Controls.Add(this.heightNum);
            this.Controls.Add(this.startBtn);
            this.Name = "ParentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colour Sorter";
            ((System.ComponentModel.ISupportInitialize)(this.heightNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.NumericUpDown heightNum;
        private System.Windows.Forms.NumericUpDown widthNum;
        private System.Windows.Forms.Label heightLbl;
        private System.Windows.Forms.Label widthLbl;
    }
}

