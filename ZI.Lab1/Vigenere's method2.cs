using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZI.Lab1
{
    public partial class Vigenere_s_method2 : Form
    {
        char empty = ' ';
        string[,] table = new string[,]
       {
           {"абвгдеёжзийклмнопрстуфхцчшщъыьэюя"},
           {"бвгдеёжзийклмнопрстуфхцчшщъыьэюяа"},
           {"вгдеёжзийклмнопрстуфхцчшщъыьэюяаб"},
           {"гдеёжзийклмнопрстуфхцчшщъыьэюяабв"},
           {"деёжзийклмнопрстуфхцчшщъыьэюяабвг"},
           {"еёжзийклмнопрстуфхцчшщъыьэюяабвгд"},
           {"ёжзийклмнопрстуфхцчшщъыьэюяабвгде"},
           {"жзийклмнопрстуфхцчшщъыьэюяабвгдеё"},
           {"зийклмнопрстуфхцчшщъыьэюяабвгдеёж"},
           {"ийклмнопрстуфхцчшщъыьэюяабвгдеёжз"},
           {"йклмнопрстуфхцчшщъыьэюяабвгдеёжзи"},
           {"клмнопрстуфхцчшщъыьэюяабвгдеёжзик"},
           {"лмнопрстуфхцчшщъыьэюяабвгдеёжзикл"},
           {"мнопрстуфхцчшщъыьэюяабвгдеёжзийкл"},
           {"нопрстуфхцчшщъыьэюяабвгдеёжзийклм"},
           {"опрстуфхцчшщъыьэюяабвгдеёжзийклмн"},
           {"прстуфхцчшщъыьэюяабвгдеёжзийклмно"},
           {"рстуфхцчшщъыьэюяабвгдеёжзийклмноп"},
           {"стуфхцчшщъыьэюяабвгдеёжзийклмнопр"},
           {"туфхцчшщъыьэюяабвгдеёжзийклмнопрс"},
           {"уфхцчшщъыьэюяабвгдеёжзийклмнопрст"},
           {"фхцчшщъыьэюяабвгдеёжзийклмнопрсту"},
           {"хцчшщъыьэюяабвгдеёжзийклмнопрстуф"},
           {"цчшщъыьэюяабвгдеёжзийклмнопрстуфх"},
           {"чшщъыьэюяабвгдеёжзийклмнопрстуфхц"},
           {"шщъыьэюяабвгдеёжзийклмнопрстуфхцч"},
           {"щъыьэюяабвгдеёжзийклмнопрстуфхцчш"},
           {"ъыьэюяабвгдеёжзийклмнопрстуфхцчшщ"},
           {"ыьэюяабвгдеёжзийклмнопрстуфхцчшщъ"},
           {"ьэюяабвгдеёжзийклмнопрстуфхцчшщъы"},
           {"эюяабвгдеёжзийклмнопрстуфхцчшщъыь"},
           {"юяабвгдеёжзийклмнопрстуфхцчшщъыьэ"},
           {"яабвгдеёжзийклмнопрстуфхцчшщъыьэю"},
       };
        string alpabet = ("абвгдеёжзийклмнопрстуфхцчшщъыьэюя");
        string done;
        int stroka, stolbec;
        public Vigenere_s_method2()
        {
            InitializeComponent();
        }

        private void шифровкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vigenere_s_method form5 = new Vigenere_s_method();
            this.Close();
            form5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = Convert.ToString(richTextBox1.Text);
            string shifr = Convert.ToString(textBox1.Text);
            List<char> list = new List<char>();
            int length = text.Length;
            while (list.Count != text.Length)
            {
                foreach (char i in shifr)
                {
                    list.Add(i);
                    if (list.Count == text.Length)
                        break;
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != empty)
                {
                    stolbec = alpabet.IndexOf(list[i]);
                    stroka = table[stolbec, 0].IndexOf(text[i]);
                    done += alpabet[stroka];
                }
                else
                    done += ' ';
            }
            richTextBox2.Text = Convert.ToString(done);
        }
    }
}
