using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZI.Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Playfair_s_method form4 = new Playfair_s_method();
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vigenere_s_method form5 = new Vigenere_s_method();
            form5.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AES form4 = new AES();
            form4.Show();

        }
    }
}
