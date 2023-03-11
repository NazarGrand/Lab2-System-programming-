using System;

namespace WindowsFormsApp1
{
    partial class FormRemake
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMask = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRemake = new System.Windows.Forms.TextBox();
            this.radioButtonStart = new System.Windows.Forms.RadioButton();
            this.radioButtonCursor = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnFindAll = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текст пошуку";
            // 
            // textBoxMask
            // 
            this.textBoxMask.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMask.Location = new System.Drawing.Point(219, 34);
            this.textBoxMask.Name = "textBoxMask";
            this.textBoxMask.Size = new System.Drawing.Size(282, 30);
            this.textBoxMask.TabIndex = 1;
            this.textBoxMask.Click += new System.EventHandler(this.textBoxMask_TextChanged);
            this.textBoxMask.TextChanged += new System.EventHandler(this.textBoxMask_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Текст заміни";
            this.label2.Visible = false;
            // 
            // textBoxRemake
            // 
            this.textBoxRemake.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRemake.Location = new System.Drawing.Point(219, 83);
            this.textBoxRemake.Name = "textBoxRemake";
            this.textBoxRemake.Size = new System.Drawing.Size(282, 30);
            this.textBoxRemake.TabIndex = 3;
            this.textBoxRemake.Visible = false;
            this.textBoxRemake.TextChanged += new System.EventHandler(this.textBoxRemake_TextChanged);
            // 
            // radioButtonStart
            // 
            this.radioButtonStart.AutoSize = true;
            this.radioButtonStart.Location = new System.Drawing.Point(297, 128);
            this.radioButtonStart.Name = "radioButtonStart";
            this.radioButtonStart.Size = new System.Drawing.Size(91, 21);
            this.radioButtonStart.TabIndex = 4;
            this.radioButtonStart.Text = "Спочатку";
            this.radioButtonStart.UseVisualStyleBackColor = true;
            this.radioButtonStart.CheckedChanged += new System.EventHandler(this.radioButtonStart_CheckedChanged);
            this.radioButtonStart.Click += new System.EventHandler(this.radioButtonStart_CheckedChanged);
            // 
            // radioButtonCursor
            // 
            this.radioButtonCursor.AutoSize = true;
            this.radioButtonCursor.Location = new System.Drawing.Point(297, 170);
            this.radioButtonCursor.Name = "radioButtonCursor";
            this.radioButtonCursor.Size = new System.Drawing.Size(106, 21);
            this.radioButtonCursor.TabIndex = 5;
            this.radioButtonCursor.Text = "Від курсора";
            this.radioButtonCursor.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(63, 226);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 42);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(164, 226);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(85, 42);
            this.btnReplace.TabIndex = 11;
            this.btnReplace.Text = "Замінити";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnFindAll
            // 
            this.btnFindAll.Location = new System.Drawing.Point(279, 226);
            this.btnFindAll.Name = "btnFindAll";
            this.btnFindAll.Size = new System.Drawing.Size(91, 42);
            this.btnFindAll.TabIndex = 13;
            this.btnFindAll.Text = "Знайти всі слова";
            this.btnFindAll.UseVisualStyleBackColor = true;
            this.btnFindAll.Click += new System.EventHandler(this.btnFindAll_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(388, 226);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(91, 42);
            this.btnReplaceAll.TabIndex = 14;
            this.btnReplaceAll.Text = "Замінити всі слова";
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // FormRemake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 294);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnFindAll);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.radioButtonCursor);
            this.Controls.Add(this.radioButtonStart);
            this.Controls.Add(this.textBoxRemake);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMask);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(800, 270);
            this.Name = "FormRemake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Remake";
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.Load += new System.EventHandler(this.FormRemake_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRemake;
        private System.Windows.Forms.RadioButton radioButtonStart;
        private System.Windows.Forms.RadioButton radioButtonCursor;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnFindAll;
        private System.Windows.Forms.Button btnReplaceAll;
    }
}