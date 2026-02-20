namespace FileExplorer
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
            this.leftPathBox = new System.Windows.Forms.TextBox();
            this.rightPathBox = new System.Windows.Forms.TextBox();
            this.goLeft = new System.Windows.Forms.Button();
            this.goRight = new System.Windows.Forms.Button();
            this.leftBox = new System.Windows.Forms.RichTextBox();
            this.rightBox = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.moveRight = new System.Windows.Forms.Button();
            this.moveLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leftPathBox
            // 
            this.leftPathBox.Location = new System.Drawing.Point(82, 60);
            this.leftPathBox.Name = "leftPathBox";
            this.leftPathBox.Size = new System.Drawing.Size(100, 20);
            this.leftPathBox.TabIndex = 0;
            // 
            // rightPathBox
            // 
            this.rightPathBox.Location = new System.Drawing.Point(706, 60);
            this.rightPathBox.Name = "rightPathBox";
            this.rightPathBox.Size = new System.Drawing.Size(100, 20);
            this.rightPathBox.TabIndex = 1;
            // 
            // goLeft
            // 
            this.goLeft.Location = new System.Drawing.Point(214, 60);
            this.goLeft.Name = "goLeft";
            this.goLeft.Size = new System.Drawing.Size(75, 23);
            this.goLeft.TabIndex = 2;
            this.goLeft.Text = "Go";
            this.goLeft.UseVisualStyleBackColor = true;
            this.goLeft.Click += new System.EventHandler(this.goLeft_Click_1);
            // 
            // goRight
            // 
            this.goRight.Location = new System.Drawing.Point(831, 57);
            this.goRight.Name = "goRight";
            this.goRight.Size = new System.Drawing.Size(75, 23);
            this.goRight.TabIndex = 3;
            this.goRight.Text = "Go";
            this.goRight.UseVisualStyleBackColor = true;
            this.goRight.Click += new System.EventHandler(this.goRight_Click_1);
            // 
            // leftBox
            // 
            this.leftBox.Location = new System.Drawing.Point(28, 98);
            this.leftBox.Name = "leftBox";
            this.leftBox.Size = new System.Drawing.Size(361, 384);
            this.leftBox.TabIndex = 4;
            this.leftBox.Text = "";
            //this.leftBox.TextChanged += new System.EventHandler(this.leftBox_TextChanged);
            this.rightBox.DoubleClick += new System.EventHandler(this.leftBox_DoubleClick);
            // 
            // rightBox
            // 
            this.rightBox.Location = new System.Drawing.Point(619, 98);
            this.rightBox.Name = "rightBox";
            this.rightBox.Size = new System.Drawing.Size(361, 384);
            this.rightBox.TabIndex = 5;
            this.rightBox.Text = "";
            //this.rightBox.TextChanged += new System.EventHandler(this.rightBox_TextChanged);
            this.rightBox.DoubleClick += new System.EventHandler(this.rightBox_DoubleClick);

            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(415, 621);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(155, 621);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(75, 23);
            this.copyBtn.TabIndex = 7;
            this.copyBtn.Text = "Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click_1);
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(731, 621);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(75, 23);
            this.newBtn.TabIndex = 8;
            this.newBtn.Text = "New";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click_1);
            // 
            // moveRight
            // 
            this.moveRight.Location = new System.Drawing.Point(460, 221);
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(75, 23);
            this.moveRight.TabIndex = 9;
            this.moveRight.Text = "Right";
            this.moveRight.UseVisualStyleBackColor = true;
            this.moveRight.Click += new System.EventHandler(this.moveRight_Click_1);
            // 
            // moveLeft
            // 
            this.moveLeft.Location = new System.Drawing.Point(460, 338);
            this.moveLeft.Name = "moveLeft";
            this.moveLeft.Size = new System.Drawing.Size(75, 23);
            this.moveLeft.TabIndex = 10;
            this.moveLeft.Text = "Left";
            this.moveLeft.UseVisualStyleBackColor = true;
            this.moveLeft.Click += new System.EventHandler(this.moveLeft_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 741);
            this.Controls.Add(this.moveLeft);
            this.Controls.Add(this.moveRight);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.rightBox);
            this.Controls.Add(this.leftBox);
            this.Controls.Add(this.goRight);
            this.Controls.Add(this.goLeft);
            this.Controls.Add(this.rightPathBox);
            this.Controls.Add(this.leftPathBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox leftPathBox;
        private System.Windows.Forms.TextBox rightPathBox;
        private System.Windows.Forms.Button goLeft;
        private System.Windows.Forms.Button goRight;
        private System.Windows.Forms.RichTextBox leftBox;
        private System.Windows.Forms.RichTextBox rightBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button newBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button moveRight;
        private System.Windows.Forms.Button moveLeft;
    }
}

