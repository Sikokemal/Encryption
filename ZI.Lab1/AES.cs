using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ZI.Lab1
{
    public partial class AES : Form
    {
        public AES()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Добавляем элементы в ComboBox для выбора формата
            comboBox1.Items.Add("Word Document");
            comboBox1.Items.Add("Image");
            comboBox1.Items.Add("Audio");
            comboBox1.Items.Add("Video");
            comboBox1.SelectedIndex = 0; // Устанавливаем Word Document по умолчанию
        }

        // Метод для шифрования текста с использованием AES
        private string Encrypt(string plainText, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // Метод для расшифровки текста с использованием AES
        private string Decrypt(string encryptedText, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        // Метод для чтения текста из .docx файла
        private string ReadTextFromDocx(string filePath)
        {
            StringBuilder text = new StringBuilder();

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;
                text.Append(body.InnerText);
            }

            return text.ToString();
        }

        // Метод для сохранения текста в новый .docx файл
        private void SaveTextToDocx(string filePath, string text)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();
                Paragraph paragraph = new Paragraph(new Run(new Text(text)));
                body.Append(paragraph);
                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }
        }

        // Метод для шифрования изображения
        private byte[] EncryptImage(byte[] imageBytes, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(imageBytes, 0, imageBytes.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        // Метод для расшифровки изображения
        private byte[] DecryptImage(byte[] encryptedBytes, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        // Метод для шифрования аудио или видео файла
        private byte[] EncryptMedia(byte[] mediaBytes, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(mediaBytes, 0, mediaBytes.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        // Метод для расшифровки аудио или видео файла
        private byte[] DecryptMedia(byte[] encryptedBytes, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    return ms.ToArray();
                }
            }
        }

        // Обработчик кнопки "Выбрать файл"
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (comboBox1.SelectedItem.ToString() == "Word Document")
            {
                openFileDialog.Filter = "Word Documents|*.docx|Text Files|*.txt";
            }
            else if (comboBox1.SelectedItem.ToString() == "Image")
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.encIma";
            }
            else if (comboBox1.SelectedItem.ToString() == "Audio")
            {
                openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.enc";
            }
            else if (comboBox1.SelectedItem.ToString() == "Video")
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.enc";
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog.FileName;
            }
        }

        // Обработчик кнопки "Зашифровать"
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = textBox3.Text;
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Выберите файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string key = textBox1.Text;
                string iv = textBox2.Text;
                if (key.Length != 16 || iv.Length != 16)
                {
                    MessageBox.Show("Ключ и IV должны быть длиной 16 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBox1.SelectedItem.ToString() == "Word Document")
                {
                    string plainText = Path.GetExtension(filePath) == ".docx"
                        ? ReadTextFromDocx(filePath)
                        : File.ReadAllText(filePath);

                    string encryptedText = Encrypt(plainText, key, iv);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Word Documents|*.docx|Text Files|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (Path.GetExtension(saveFileDialog.FileName) == ".docx")
                        {
                            SaveTextToDocx(saveFileDialog.FileName, encryptedText);
                        }
                        else
                        {
                            File.WriteAllText(saveFileDialog.FileName, encryptedText);
                        }

                        MessageBox.Show("Текст успешно зашифрован и сохранён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "Image")
                {
                    byte[] imageBytes = File.ReadAllBytes(filePath);
                    byte[] encryptedImage = EncryptImage(imageBytes, key, iv);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Encrypted Image|*.encIma";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, encryptedImage);
                        MessageBox.Show("Изображение успешно зашифровано и сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "Audio" || comboBox1.SelectedItem.ToString() == "Video")
                {
                    byte[] mediaBytes = File.ReadAllBytes(filePath);
                    byte[] encryptedMedia = EncryptMedia(mediaBytes, key, iv);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Encrypted Media|*.enc";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, encryptedMedia);
                        MessageBox.Show($"{comboBox1.SelectedItem.ToString()} успешно зашифровано и сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = textBox3.Text;
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Выберите файл для дешифровки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string key = textBox1.Text;
                string iv = textBox2.Text;
                if (key.Length != 16 || iv.Length != 16)
                {
                    MessageBox.Show("Ключ и IV должны быть длиной 16 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboBox1.SelectedItem.ToString() == "Word Document")
                {
                    string encryptedText;
                    if (Path.GetExtension(filePath) == ".docx")
                    {
                        encryptedText = ReadTextFromDocx(filePath); // Чтение зашифрованного текста из Word
                    }
                    else
                    {
                        encryptedText = File.ReadAllText(filePath); // Чтение зашифрованного текста из текстового файла
                    }

                    string decryptedText = Decrypt(encryptedText, key, iv);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Word Documents|*.docx|Text Files|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (Path.GetExtension(saveFileDialog.FileName) == ".docx")
                        {
                            SaveTextToDocx(saveFileDialog.FileName, decryptedText);
                        }
                        else
                        {
                            File.WriteAllText(saveFileDialog.FileName, decryptedText);
                        }

                        MessageBox.Show("Текст успешно расшифрован и сохранён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (comboBox1.SelectedItem.ToString() == "Image")
                {
                    byte[] encryptedImage = File.ReadAllBytes(filePath);
                    byte[] decryptedImage = DecryptImage(encryptedImage, key, iv);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, decryptedImage);
                        MessageBox.Show("Изображение успешно расшифровано и сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (comboBox1.SelectedItem.ToString() == "Audio" || comboBox1.SelectedItem.ToString() == "Video")
                {
                    byte[] encryptedMedia = File.ReadAllBytes(filePath);
                    byte[] decryptedMedia = DecryptMedia(encryptedMedia, key, iv);

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = comboBox1.SelectedItem.ToString() == "Audio" ? "Audio Files|*.mp3;*.wav;*.ogg" : "Video Files|*.mp4;*.avi;*.mkv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, decryptedMedia);
                        MessageBox.Show($"{comboBox1.SelectedItem.ToString()} успешно расшифровано и сохранено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для генерации случайного ключа или IV
        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder result = new StringBuilder(length);
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[length];
                rng.GetBytes(data);
                foreach (byte b in data)
                {
                    result.Append(chars[b % chars.Length]);
                }
            }
            return result.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            textBox1.Text = GenerateRandomString(16); // Генерация ключа
            textBox2.Text = GenerateRandomString(16); // Генерация IV
            MessageBox.Show("Ключ и IV успешно сгенерированы!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}