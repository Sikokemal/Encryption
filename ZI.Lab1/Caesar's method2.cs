using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging; // Для работы с .docx
using DocumentFormat.OpenXml.Wordprocessing; // Для обработки текста в документе

namespace ZI.Lab1
{
    public partial class Form3 : Form
    {
        private string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private char empty = ' ';
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k;
            string message = richTextBox1.Text;
            k = Convert.ToInt32(textBox1.Text);
            string decoded = string.Empty;

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] == empty)
                {
                    decoded += " ";
                }
                else
                {
                    int index = alphabet.IndexOf(message[i]);
                    if (index != -1)
                    {
                        int newIndex = (index - k + alphabet.Length) % alphabet.Length;
                        decoded += alphabet[newIndex];
                    }
                    else
                    {
                        decoded += message[i]; // Оставляем символ без изменений, если его нет в алфавите
                    }
                }
            }

            richTextBox2.Text = decoded;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Открытие диалога для выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|Word Documents|*.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath = openFileDialog.FileName;
                string message = GetTextFromFile(sourceFilePath);

                // Проверка на ввод сдвига в textBox1
                if (!int.TryParse(textBox1.Text, out int k))
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение сдвига.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Дешифрование текста
                string decoded = string.Empty;
                for (int i = 0; i < message.Length; i++)
                {
                    if (message[i] == empty)
                    {
                        decoded += " ";
                    }
                    else
                    {
                        int index = alphabet.IndexOf(message[i]);
                        if (index != -1)
                        {
                            int newIndex = (index - k + alphabet.Length) % alphabet.Length;
                            decoded += alphabet[newIndex];
                        }
                        else
                        {
                            decoded += message[i]; // Оставляем символ без изменений, если его нет в алфавите
                        }
                    }
                }

                // Вывод дешифрованного текста в richTextBox2
                richTextBox2.Text = decoded;
            }
        }

        // Метод для получения текста из .docx файла
        private string GetTextFromFile(string filePath)
        {
            StringBuilder text = new StringBuilder();

            if (filePath.EndsWith(".docx"))
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
                {
                    var body = wordDoc.MainDocumentPart.Document.Body;
                    text.Append(body.InnerText);
                }
            }
            else if (filePath.EndsWith(".txt"))
            {
                text.Append(File.ReadAllText(filePath));
            }

            return text.ToString();
        }

        private void шифрованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Close();
            form2.Show();
        }
    }
}
