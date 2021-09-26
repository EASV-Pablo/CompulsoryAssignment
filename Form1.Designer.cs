
using System.Drawing;

namespace CompulsoryAssigment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitle = new System.Windows.Forms.Label();
            this.tBoxInitNum = new System.Windows.Forms.TextBox();
            this.tBoxFinalNum = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.listResult = new System.Windows.Forms.ListBox();
            this.tBoxConsole = new System.Windows.Forms.TextBox();
            this.rbtnAsc = new System.Windows.Forms.RadioButton();
            this.rbtnDes = new System.Windows.Forms.RadioButton();
            this.lblSort = new System.Windows.Forms.Label();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.lblResultTime = new System.Windows.Forms.Label();
            this.lblTimeUsed = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.marioDraw = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.marioDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(408, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Insert the range to generate prime numbers:";
            // 
            // tBoxInitNum
            // 
            this.tBoxInitNum.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tBoxInitNum.Location = new System.Drawing.Point(401, 289);
            this.tBoxInitNum.Name = "tBoxInitNum";
            this.tBoxInitNum.Size = new System.Drawing.Size(100, 23);
            this.tBoxInitNum.TabIndex = 2;
            this.tBoxInitNum.Text = "Initial number";
            this.tBoxInitNum.Enter += new System.EventHandler(this.tBoxInitNum_Enter);
            this.tBoxInitNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxInitNum_KeyPress);
            this.tBoxInitNum.Leave += new System.EventHandler(this.tBoxInitNum_Leave);
            // 
            // tBoxFinalNum
            // 
            this.tBoxFinalNum.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tBoxFinalNum.Location = new System.Drawing.Point(401, 318);
            this.tBoxFinalNum.Name = "tBoxFinalNum";
            this.tBoxFinalNum.Size = new System.Drawing.Size(100, 23);
            this.tBoxFinalNum.TabIndex = 3;
            this.tBoxFinalNum.Text = "Final number";
            this.tBoxFinalNum.Enter += new System.EventHandler(this.tBoxFinalNum_Enter);
            this.tBoxFinalNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBoxFinalNum_KeyPress);
            this.tBoxFinalNum.Leave += new System.EventHandler(this.tBoxFinalNum_Leave);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(401, 428);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 25);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // listResult
            // 
            this.listResult.ColumnWidth = 50;
            this.listResult.FormattingEnabled = true;
            this.listResult.ItemHeight = 15;
            this.listResult.Location = new System.Drawing.Point(12, 51);
            this.listResult.MultiColumn = true;
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(609, 214);
            this.listResult.TabIndex = 1;
            // 
            // tBoxConsole
            // 
            this.tBoxConsole.Location = new System.Drawing.Point(12, 289);
            this.tBoxConsole.Multiline = true;
            this.tBoxConsole.Name = "tBoxConsole";
            this.tBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxConsole.Size = new System.Drawing.Size(383, 164);
            this.tBoxConsole.TabIndex = 5;
            // 
            // rbtnAsc
            // 
            this.rbtnAsc.AutoSize = true;
            this.rbtnAsc.Checked = true;
            this.rbtnAsc.Location = new System.Drawing.Point(414, 368);
            this.rbtnAsc.Name = "rbtnAsc";
            this.rbtnAsc.Size = new System.Drawing.Size(81, 19);
            this.rbtnAsc.TabIndex = 6;
            this.rbtnAsc.TabStop = true;
            this.rbtnAsc.Text = "Ascending";
            this.rbtnAsc.UseVisualStyleBackColor = true;
            // 
            // rbtnDes
            // 
            this.rbtnDes.AutoSize = true;
            this.rbtnDes.Location = new System.Drawing.Point(414, 393);
            this.rbtnDes.Name = "rbtnDes";
            this.rbtnDes.Size = new System.Drawing.Size(87, 19);
            this.rbtnDes.TabIndex = 7;
            this.rbtnDes.Text = "Descending";
            this.rbtnDes.UseVisualStyleBackColor = true;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(401, 350);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(47, 15);
            this.lblSort.TabIndex = 8;
            this.lblSort.Text = "Sort by:";
            // 
            // btnClearResult
            // 
            this.btnClearResult.Location = new System.Drawing.Point(521, 289);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(100, 52);
            this.btnClearResult.TabIndex = 9;
            this.btnClearResult.Text = "Clear Results";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // lblResultTime
            // 
            this.lblResultTime.AutoSize = true;
            this.lblResultTime.Location = new System.Drawing.Point(12, 268);
            this.lblResultTime.Name = "lblResultTime";
            this.lblResultTime.Size = new System.Drawing.Size(64, 15);
            this.lblResultTime.TabIndex = 10;
            this.lblResultTime.Text = "Time used:";
            // 
            // lblTimeUsed
            // 
            this.lblTimeUsed.AutoSize = true;
            this.lblTimeUsed.Location = new System.Drawing.Point(82, 268);
            this.lblTimeUsed.Name = "lblTimeUsed";
            this.lblTimeUsed.Size = new System.Drawing.Size(0, 15);
            this.lblTimeUsed.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(521, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 52);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Stop";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // marioDraw
            // 
            this.marioDraw.Image = ((System.Drawing.Image)(resources.GetObject("marioDraw.Image")));
            this.marioDraw.Location = new System.Drawing.Point(544, 409);
            this.marioDraw.Name = "marioDraw";
            this.marioDraw.Size = new System.Drawing.Size(50, 50);
            this.marioDraw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.marioDraw.TabIndex = 13;
            this.marioDraw.TabStop = false;
            this.marioDraw.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 465);
            this.Controls.Add(this.marioDraw);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTimeUsed);
            this.Controls.Add(this.lblResultTime);
            this.Controls.Add(this.btnClearResult);
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.rbtnDes);
            this.Controls.Add(this.rbtnAsc);
            this.Controls.Add(this.tBoxConsole);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tBoxFinalNum);
            this.Controls.Add(this.tBoxInitNum);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Prime Generator";
            ((System.ComponentModel.ISupportInitialize)(this.marioDraw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tBoxInitNum;
        private System.Windows.Forms.TextBox tBoxFinalNum;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.TextBox tBoxConsole;
        private System.Windows.Forms.RadioButton rbtnAsc;
        private System.Windows.Forms.RadioButton rbtnDes;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.Label lblResultTime;
        private System.Windows.Forms.Label lblTimeUsed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox marioDraw;
    }
}

