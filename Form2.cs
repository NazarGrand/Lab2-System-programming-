using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class FormRemake : Form
    {
        public FormText formText = null;
        int flag = 0;
        int position;
        List<string> words;
        Maska mask;
        string maska;
        public FormRemake()
        {
            InitializeComponent();
            radioButtonStart.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");
        }

        private void TakingText()
        {
            List<string> text = new List<string>();

            //MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");

            string row = "";

            string line = formText.richTextBox.Lines[CursorForm.Line];

            int firstIndexNextRow = formText.richTextBox.GetFirstCharIndexFromLine(CursorForm.Line + 1);
            for (int i = CursorForm.Column; i < line.Length; i++)
                row += line[i];

            text.Add(row);

            for (int i = CursorForm.Line + 1; i < formText.richTextBox.Lines.Length; i++)
            {
                text.Add(formText.richTextBox.Lines[i].ToString());
            }

            List<string[]> Words = new List<string[]>();
            foreach (string s in text)
                Words.Add(s.Split(' '));

            words = new List<string>();

            foreach (string[] word in Words)
            {
                for (int i = 0; i < word.Length; i++)
                    if (word[i] != "")
                        words.Add(word[i]);
            }

            //foreach (string word in words)
            //    richTextBox1.Text += word + " ";

            mask = new Maska();
            maska = textBoxMask.Text;

            mask.DecipheringMetacharacters(maska);

            position = 0;
            string[] lines = formText.richTextBox.Lines;

            if (CursorForm.Line >= 0 && CursorForm.Line < lines.Length && CursorForm.Column >= 0
                && CursorForm.Column < lines[CursorForm.Line].Length)
            {
                int firstCharIndex = formText.richTextBox.GetFirstCharIndexFromLine(CursorForm.Line);
                position = firstCharIndex + CursorForm.Column;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                int selectionStart = formText.richTextBox.SelectionStart + formText.richTextBox.SelectionLength;
                formText.column = selectionStart - formText.richTextBox.GetFirstCharIndexOfCurrentLine();
                formText.line = formText.richTextBox.GetLineFromCharIndex(selectionStart);

                CursorForm.Line = formText.line;
                CursorForm.Column = formText.column;

                //MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");
            }

            TakingText();

            foreach (string word in words)
                if (mask.MaskCheck(word, maska) == true)
                {
                    textBoxRemake.Text = mask.resultStr;
                    textBoxRemake.Visible = true;
                    label2.Visible = true;

                    int start = formText.richTextBox.Find(word, position, RichTextBoxFinds.None);
                   
                    if (start >= position)
                    {
                        formText.richTextBox.SelectionStart = start;
                        formText.richTextBox.SelectionLength = word.Length;


                        formText.line = formText.richTextBox.GetLineFromCharIndex(start);
                        formText.column = start - formText.richTextBox.GetFirstCharIndexFromLine(formText.line);
                        CursorForm.Line = formText.line;
                        CursorForm.Column = formText.column;

                        //MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");

                        formText.Activate();
                        flag = 1;
                        return;
                    }
                }
        }

        private void radioButtonStart_CheckedChanged(object sender, EventArgs e)
        {
            if (formText != null)
            {
                formText.line = 0;
                formText.column = 0;
            }
        }

        private void textBoxMask_TextChanged(object sender, EventArgs e)
        {
            textBoxRemake.Text = "";
            textBoxRemake.Enabled = true;
            textBoxRemake.Visible = false;
            label2.Visible = false;
        }

        private void FormRemake_Load(object sender, EventArgs e)
        {
            formText = new FormText();
           
            formText.Show();
            formText.Activate();
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            if ((CursorForm.Line == 0) && (CursorForm.Column == 0))
                radioButtonStart.Checked = true;
            else
                radioButtonCursor.Checked = true;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (formText.richTextBox.SelectionLength != 0)
            {
                formText.richTextBox.SelectedText = textBoxRemake.Text;

                int selectionStart = formText.richTextBox.SelectionStart;
                formText.column = selectionStart - formText.richTextBox.GetFirstCharIndexOfCurrentLine();
                formText.line = formText.richTextBox.GetLineFromCharIndex(selectionStart);

                CursorForm.Line = formText.line;
                CursorForm.Column = formText.column;

                //MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");
                formText.Activate();
            }

            flag = 0;
            textBoxRemake.Visible = false;
            label2.Visible = false;
        }

        private void textBoxRemake_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            TakingText();

            foreach (string word in words)
                if (mask.MaskCheck(word, maska) == true)
                {
                    textBoxRemake.Text = mask.resultStr;
                    textBoxRemake.Visible = true;
                    label2.Visible = true;

                    int start = formText.richTextBox.Find(word, position, RichTextBoxFinds.None);
                    //MessageBox.Show("start" + Convert.ToString(start));
                    if (start >= position)
                    {
                        formText.richTextBox.Select(start, word.Length);
                        formText.Activate();
                        Thread.Sleep(1000);

                        formText.Activate();

                        formText.line = formText.richTextBox.GetLineFromCharIndex(start);
                        formText.column = start - formText.richTextBox.GetFirstCharIndexFromLine(formText.line);
                        CursorForm.Line = formText.line;
                        CursorForm.Column = formText.column;

                        //MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");

                        if (formText.richTextBox.SelectionLength != 0)
                        {
                            int selectionStart = formText.richTextBox.SelectionStart;
                            formText.column = selectionStart - formText.richTextBox.GetFirstCharIndexOfCurrentLine();
                            formText.line = formText.richTextBox.GetLineFromCharIndex(selectionStart);

                            CursorForm.Line = formText.line;
                            CursorForm.Column = formText.column;

                            //MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");
                            formText.Activate();
                        }
                    }
                }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            TakingText();

            foreach (string word in words)
                if (mask.MaskCheck(word, maska) == true)
                {
                    textBoxRemake.Text = mask.resultStr;
                    textBoxRemake.Visible = true;
                    label2.Visible = true;

                    int start = formText.richTextBox.Find(word, position, RichTextBoxFinds.None);
                    //MessageBox.Show("start" + Convert.ToString(start));
                    if (start >= position)
                    {          
                        formText.richTextBox.Select(start, word.Length);
                        formText.Activate();        

                        formText.Activate();

                        formText.line = formText.richTextBox.GetLineFromCharIndex(start);
                        formText.column = start - formText.richTextBox.GetFirstCharIndexFromLine(formText.line);
                        CursorForm.Line = formText.line;
                        CursorForm.Column = formText.column;

                        //MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");
                        if (formText.richTextBox.SelectionLength != 0)
                        {
                            formText.richTextBox.SelectedText = textBoxRemake.Text;

                            int selectionStart = formText.richTextBox.SelectionStart + formText.richTextBox.SelectionLength;
                            formText.column = selectionStart - formText.richTextBox.GetFirstCharIndexOfCurrentLine();
                            formText.line = formText.richTextBox.GetLineFromCharIndex(selectionStart);

                            CursorForm.Line = formText.line;
                            CursorForm.Column = formText.column;

                            //MessageBox.Show($"line = {CursorForm.Line}, column = {CursorForm.Column}");
                            formText.Activate();
                        }
                    }
                }
        }
    }
}
