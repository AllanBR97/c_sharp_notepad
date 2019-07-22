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
    public partial class ReplaceText : Form
    {
        private readonly Form1 form;
        public ReplaceText(Form1 f)
        {
            form = f;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // a fazer...
            if(checkBox1.Checked)
            {
                if (ReplaceTextBox.Text != "" && WithTextBox.Text != "" && form.textBox1.Text != "")
                {
                    if (form.textBox1.Text.Contains(ReplaceTextBox.Text))
                    {
                        form.textBox1.Text = form.textBox1.Text.Replace(ReplaceTextBox.Text, WithTextBox.Text);
                    }
                }
            }
            else
            {
                if (ReplaceTextBox.Text.ToLower() != "" && WithTextBox.Text.ToLower() != "" && form.textBox1.Text.ToLower() != "")
                {
                    if (form.textBox1.Text.ToLower().Contains(ReplaceTextBox.Text.ToLower()))
                    {
                        form.textBox1.Text = form.textBox1.Text.ToLower().Replace(ReplaceTextBox.Text.ToLower(), WithTextBox.Text.ToLower());
                    }
                }
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // a fazer...
            if (ReplaceTextBox.Text != "" && WithTextBox.Text != "" && form.textBox1.Text != "")
            {
                if (form.textBox1.Text == ReplaceTextBox.Text)
                {
                    form.textBox1.Text = form.textBox1.Text.Replace(ReplaceTextBox.Text, WithTextBox.Text);
                }
                else
                    MessageBox.Show($"'{ReplaceTextBox.Text}' not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (ReplaceTextBox.Text != "" && WithTextBox.Text != "")
            {
                string temp;
                temp = ReplaceTextBox.Text;
                ReplaceTextBox.Text = WithTextBox.Text;
                WithTextBox.Text = temp;
            }
        }
    }
}
