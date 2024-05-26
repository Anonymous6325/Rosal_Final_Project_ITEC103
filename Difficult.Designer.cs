namespace ITEC_103_ROSAL___MAKASAYAN
{
    partial class Difficult
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.ForeColor = System.Drawing.Color.White;
            this.lblQuestion.Location = new System.Drawing.Point(695, 134);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(204, 90);
            this.lblQuestion.TabIndex = 13;
            this.lblQuestion.Text = "Answer the Math Equation\r\n";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(711, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 12;
            this.label2.Tag = "correctAnswer";
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(849, 16);
            this.btn3.Margin = new System.Windows.Forms.Padding(2);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(45, 27);
            this.btn3.TabIndex = 11;
            this.btn3.Text = "Back";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(701, 345);
            this.btn2.Margin = new System.Windows.Forms.Padding(2);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(190, 50);
            this.btn2.TabIndex = 10;
            this.btn2.Tag = "2";
            this.btn2.Text = "button2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.ClickAnswerEvent);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(701, 273);
            this.btn1.Margin = new System.Windows.Forms.Padding(2);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(190, 50);
            this.btn1.TabIndex = 9;
            this.btn1.Tag = "1";
            this.btn1.Text = "button1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.ClickAnswerEvent);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ITEC_103_ROSAL___MAKASAYAN.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(13, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(668, 439);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Difficult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ITEC_103_ROSAL___MAKASAYAN.Properties.Resources.f030f38a_a20a_408f_a35d_5726f34e7d18;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 493);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Difficult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Difficult";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}