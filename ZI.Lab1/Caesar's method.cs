using System;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging; // Для работы с .docx
using DocumentFormat.OpenXml.Wordprocessing; // Для обработки текста в документе
using System.Text;

namespace ZI.Lab1
{
    public partial class Form2 : Form
    {
        private readonly string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private char empty = ' ';

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем текст из richTextBox1
            string message = richTextBox1.Text;

            // Проверка на ввод сдвига в textBox1
            if (!int.TryParse(textBox1.Text, out int k))
            {
                MessageBox.Show("Пожалуйста, введите корректное значение сдвига.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Обрезка сдвига по длине алфавита
            k = k % alphabet.Length;
            string coded = string.Empty;

            // Шифрование текста
            foreach (char symbol in message)
            {
                if (symbol == empty)
                {
                    coded += empty;
                }
                else
                {
                    int index = alphabet.IndexOf(symbol);
                    if (index != -1)
                    {
                        int newIndex = (index + k) % alphabet.Length;
                        coded += alphabet[newIndex];
                    }
                    else
                    {
                        coded += symbol; // Оставляем символ без изменений, если его нет в алфавите
                    }
                }
            }

            // Вывод зашифрованного текста в richTextBox2
            richTextBox2.Text = coded;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Открытие диалога для выбора исходного файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.docx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Чтение текста из исходного Word-файла
                string sourceFilePath = openFileDialog.FileName;
                string message = GetTextFromDocx(sourceFilePath);

                // Проверка на ввод сдвига в textBox1
                if (!int.TryParse(textBox1.Text, out int k))
                {
                    MessageBox.Show("Пожалуйста, введите корректное значение сдвига.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Обрезка сдвига по длине алфавита
                k = k % alphabet.Length;
                string coded = string.Empty;

                // Шифрование текста
                foreach (char symbol in message)
                {
                    if (symbol == empty)
                    {
                        coded += empty;
                    }
                    else
                    {
                        int index = alphabet.IndexOf(symbol);
                        if (index != -1)
                        {
                            int newIndex = (index + k) % alphabet.Length;
                            coded += alphabet[newIndex];
                        }
                        else
                        {
                            coded += symbol; // Оставляем символ без изменений, если его нет в алфавите
                        }
                    }
                }

                // Вывод зашифрованного текста в richTextBox2
                richTextBox2.Text = coded;
            }
        }

        // Метод для получения текста из .docx файла
        private string GetTextFromDocx(string filePath)
        {
            StringBuilder text = new StringBuilder();

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;
                text.Append(body.InnerText);
            }

            return text.ToString();
        }

        private void дешифрованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Close();
            form3.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Инициализация, если требуется
        }
    }
}
