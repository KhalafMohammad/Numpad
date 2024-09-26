using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numpad
{
    public partial class numpad : Form
    {
        public int numpad_value;
        public int numpad_preval;
        const int MAX_LNGTH = 4;

        public Form1 form1 { get; set; }
        public numpad(Form1 form1Instance, string data)
        {
            InitializeComponent();
            form1 = form1Instance;
            textBox1.MaxLength = 5;
            textBox1.Text = data;
            int.TryParse(data, out numpad_preval);

            if (data == "0")
            {
                label2.BackColor = SystemColors.Control;
            }
            else { label2.BackColor = SystemColors.ActiveCaption; }
            label2.Text = $"Previous Value: {data}";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                return;
            }
            else
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }

            if (textBox1.Text.Length == 0)
            {
                button11.BackColor = Color.LightCoral;
                return;
            }

        }
        #region numpad buttons click handels //click me to show the handlers
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "1";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "6";
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                textBox1.Text += "8";
                button11.BackColor = Color.Red;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "9";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= MAX_LNGTH)
            {
                return;
            }
            else
            {
                button11.BackColor = Color.Red;
                textBox1.Text += "0";
                //if (textBox1.Text == "0")
                //{
                //    MessageBox.Show("cant enter 0 at first!!");
                //}
            }
        }

        #endregion //click me

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

            button11.BackColor = Color.LightCoral;
            textBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out numpad_value);
            if (numpad_value > 10000)
            {
                MessageBox.Show("MAX 10000!");
                numpad_value = numpad_preval;
                return;
            }
            else
            {
                form1.numericUpDown1.Value = numpad_value;
                form1.numericUpDown1.Enabled = true;
                Close();
            }

        }

        private void numpad_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Maximum amount that can be inserted is 10k or 10000! 💖");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This the previous amount that was inserted " + numpad_preval);
        }

        private void numpad_FormClosed(object sender, FormClosedEventArgs e)
        {
            int.TryParse(textBox1.Text, out numpad_value);
            if (numpad_value > 10000)
            {
                MessageBox.Show("MAX 10000!");
                numpad_value = numpad_preval;
            }
        }
    }
}
