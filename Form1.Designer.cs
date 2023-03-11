namespace WindowsFormsApp1
{
    partial class FormText
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox.Location = new System.Drawing.Point(0, 1);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(100, 96);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.richTextBox.Click += new System.EventHandler(this.richTextBox_TextChanged);
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // FormText
            // 
            this.ClientSize = new System.Drawing.Size(506, 412);
            this.Controls.Add(this.richTextBox);
            this.Location = new System.Drawing.Point(250, 200);
            this.Name = "FormText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Text";
            this.Load += new System.EventHandler(this.FormText_Load);
            this.ResumeLayout(false);

        }

        public System.Windows.Forms.RichTextBox richTextBox;

        #endregion

        //private System.Windows.Forms.RichTextBox richTextBox;
    }
}

