using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Numpad
{
    public partial class Form1 : Form
    {
        string numpad_value_string;
        public int shared_value { get; set; }
        public Thread thread1;
        public Thread thread2;
        Form1 form1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            button1.FlatAppearance.BorderSize = 0;
            if (numericUpDown1.Value >= 10000)
            {
                return;
            }
            else { numericUpDown1.Value += 1; button2.Text = "-1"; }
        }

        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= 10000)
            {

                return;
            }

            if (numericUpDown1.Value <= 0)
            {

                return;

            }
        }
        private void threadtest(int numric)
        {
            if (numric == 1)
            {
                if (numericUpDown1.Value != 0)
                {
                    numpad_value_string = numericUpDown1.Value.ToString();
                }
                else
                {
                    numpad_value_string = "";
                }

                Form1 form1 = new Form1();
                var numpadForm = new numpad(form1, numpad_value_string);
                numpadForm.ShowDialog();
                //numericUpDown1.Value = numpadForm.numpad_value;
                UpdateNumeric1(numpadForm.numpad_value);
            }
            else if (numric == 2)
            {
                if (numericUpDown2.Value != 0)
                {
                    numpad_value_string = numericUpDown2.Value.ToString();
                }
                else
                {
                    numpad_value_string = "";
                }
                Form1 form1 = new Form1();
                var numpadForm = new numpad(form1, numpad_value_string);
                numpadForm.ShowDialog();
                UpdateNumeric2(numpadForm.numpad_value);
            }
        }

        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(() => threadtest(1)));

            bool thread1_started = false;
            if (!thread1_started)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                thread1.Start();
                thread1_started = true;

            }
            else
            {

                thread1_started = false;
                thread1.Abort();
                return;
            }
        }

        private void UpdateNumeric1(int value)
        {
            if (numericUpDown1.InvokeRequired)
            {
                numericUpDown1.Invoke(new Action(() => numericUpDown1.Value = value));
                numericUpDown1.Invoke(new Action(() => numericUpDown1.Enabled = true));
                numericUpDown1.Invoke(new Action(() => numericUpDown2.Enabled = true));
                numericUpDown1.Invoke(new Action(() => button1.Enabled = true));
                numericUpDown1.Invoke(new Action(() => button2.Enabled = true));
                numericUpDown1.Invoke(new Action(() => button3.Enabled = true));
                numericUpDown1.Invoke(new Action(() => button4.Enabled = true));
            }
            else
            {
                numericUpDown1.Value = value;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "NUMBER PAD TEST";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (numericUpDown1.Value == 0)
            {
                return;
            }
            else
            {
                numericUpDown1.Value -= 1;
            }
            button1.Text = "+1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 10000)
            {
                button4.BackColor = Color.LightCoral;
                return;
            }
            else
            {
                button4.BackColor = Color.Gainsboro;
                button3.BackColor = Color.Gainsboro;
                numericUpDown2.Value += 1;
                button3.Text = "-1";
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 10000)
            {

                button4.BackColor = Color.LightCoral;

                return;
            }
            if (numericUpDown2.Value == 0)
            {

                button3.BackColor = Color.LightCoral;
                return;
            }


        }

        private void numericUpDown2_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(() => threadtest(2));

            bool thread2_started = false;
            if (!thread2_started)
            {
                numericUpDown2.Enabled = false;
                numericUpDown1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                thread2.Start();
                thread2_started = true;

            }
            else
            {
                thread2_started = false;
                thread2.Abort();
                return;
            }
        }
        private void UpdateNumeric2(int value)
        {
            if (numericUpDown2.InvokeRequired)
            {
                numericUpDown2.Invoke(new Action(() => numericUpDown2.Value = value));
                numericUpDown2.Invoke(new Action(() => numericUpDown1.Enabled = true));
                numericUpDown2.Invoke(new Action(() => numericUpDown2.Enabled = true));
                numericUpDown2.Invoke(new Action(() => button3.Enabled = true));
                numericUpDown2.Invoke(new Action(() => button4.Enabled = true));
                numericUpDown2.Invoke(new Action(() => button1.Enabled = true));
                numericUpDown2.Invoke(new Action(() => button2.Enabled = true));

            }
            else
            {
                numericUpDown2.Value = value;
                button3.Enabled = true;
                button4.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OnActivated(e);

            if (numericUpDown2.Value == 0)
            {
                button3.BackColor = Color.LightCoral;
                return;
            }
            else
            {
                button3.BackColor = Color.Gainsboro;
                button4.BackColor = Color.Gainsboro;
                numericUpDown2.Value -= 1;
                button4.Text = "+1";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.BackColor != Color.Green)
            {
                label1.BackColor = Color.Green;
            }
            else
            {
                label1.BackColor = Color.Red;
            }
        }
        private void working_tester()
        {

            while (true)
            {

                label1.BackColor = Color.Red;
                Thread.Sleep(500);

                label1.BackColor = Color.Green;
                Thread.Sleep(500);
            }
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) // CLOSE FORM AND ALL THREADS
        {
            if (thread1 != null && thread2 == null)
            {
                thread1.Abort();
            }
            else if (thread1 == null && thread2 != null)
            {
                thread2.Abort();
            }
            else if (thread1 != null && thread2 != null)
            {
                thread2.Abort();
                thread1.Abort();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) //NEW BUTTON ON THE STRIPDOWN MENUE
        {
            Form2 newMDIChild = new Form2(form1);
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
