using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FindText : Form
    {
        private readonly Form1 form;
        private int pos = 0;
        private short total = 0;
        public FindText(Form1 f)
        {
            form = f;
            InitializeComponent();
        }
        
        private void FindNext(string text)
        {
            try
            {
                pos = checkBox1.Checked ? form.textBox1.Text.IndexOf(text, pos) : form.textBox1.Text.ToLower().IndexOf(text, pos);  
                form.textBox1.Select(pos, text.Length);
                pos += text.Length;
                total++;
            }
            catch
            {
                MessageBox.Show($"No more occurrences found!\nTotal: {total}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pos = total = 0;
            }         
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (form.textBox1.Focus() == false)
                form.textBox1.Focus();
            FindNext(findTextBox.Text);
        }
    }
}
