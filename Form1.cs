using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string currentFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                if (MessageBox.Show("Erase file?", "New", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    currentFile = "";
                    textBox1.Text = string.Empty;
                }  
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFile == "")
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    currentFile = openFileDialog1.FileName;
                    using var file = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                    textBox1.Text = file.ReadToEnd();
                }
            }
            else
            {
                using var file = new StreamReader(currentFile, Encoding.Default);
                textBox1.Text = file.ReadToEnd();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFile == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using var file = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                    file.Write(textBox1.Text);
                }
            }
            else
            {
                using var file = new StreamWriter(currentFile, false, Encoding.Default);
                file.Write(textBox1.Text);
            }
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void BackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }

        private void FindTextToolStripMenuItem_Click(object sender, EventArgs e) => new FindText(this).Show();

        private void ReplaceTextToolStripMenuItem_Click(object sender, EventArgs e) => new ReplaceText(this).ShowDialog();

        private void InsertDateTimeToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Text += $" {DateTime.Now}";

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Copy();

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) => textBox1.Paste();

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.CanUndo)
                textBox1.Undo();
        }

        private void Form1_Load(object sender, EventArgs e) => currentFile = "";

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using var file = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                file.Write(textBox1.Text);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => Close();
    }
}