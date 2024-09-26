using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numpad
{
    public partial class Form2 : Form
    {
        public Form1 form1 { get; set; }
        public Form2(Form form1test)
        {
            InitializeComponent();
            form1 = form1test as Form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.numericUpDown1.Value += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
