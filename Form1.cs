using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormText : Form
    {
        public int line = 0, column = 0;
        public FormText()
        {
            InitializeComponent();
            richTextBox.Size = this.Size;
            richTextBox.Height = this.Height - 100;
            richTextBox.Select(0,0);
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            //label1.Text = Convert.ToString(richTextBox.Cursor);

            int position = richTextBox.GetCharIndexFromPosition(richTextBox.PointToClient(Cursor.Position));
            line = richTextBox.GetLineFromCharIndex(position);
            column = position - richTextBox.GetFirstCharIndexFromLine(line);
            CursorForm.Line = line;
            CursorForm.Column = column;
            //label1.Text = "Line: " + (line + 1) + " Column: " + (column + 1);
            //richTextBox.Height = this.Height;

        }

        private void bOpenFile_Click(object sender, EventArgs e)
        {
          
        }

        private void FormText_Load(object sender, EventArgs e)
        {
            string path = @"InputFile.txt";
            string[] readText = File.ReadAllLines(path);

            foreach (string read in readText)
                richTextBox.Text += read + '\n';

            //label1.Text = Convert.ToString(richTextBox.SelectionStart);
        }
    }
}
