using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System;
using System.Linq;


namespace ZI.Lab1
{
    public partial class Playfair_s_method : Form
    {
        private const string ALPHABET_ARRAY = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; // Русский алфавит
        private const string PACIFIER_SYMBOL = "Х"; // Символ-заполнитель для дубликатов
        private char[,] keyMatrix; // Матрица ключа
        private readonly int SquareCells; // Размерность матрицы

        public Playfair_s_method()
        {
            InitializeComponent();
            this.SquareCells = 6; // Для русского алфавита используется матрица 6x6
            this.keyMatrix = new char[SquareCells, SquareCells];
            this.dataGridView1.ColumnCount = this.dataGridView1.RowCount = this.SquareCells;
        }

        private void Result_button_Click(object sender, EventArgs e)
        {
            string inputString = this.Input_richTextBox.Text.Replace(" ", "").ToLower();
            string digramString = this.GetDigram(inputString);
            this.Output_richTextBox.Text = this.Cipher(digramString, this.Decrypt_radioButton.Checked);
        }

        private void SetMatrix_button_Click(object sender, EventArgs e)
        {
            string keyString = this.Key_textBox.Text.Replace(" ", "").ToLower();
            this.SetMatrix(keyString);
        }

        private string RemoveAllDuplicates(string inputStr)
        {
            HashSet<char> uniqueChars = new HashSet<char>(inputStr);
            return new string(uniqueChars.ToArray());
        }

        private void SetMatrix(string key)
        {
            // Убедимся, что ключ содержит уникальные символы и дополнить его, если нужно
            key += ALPHABET_ARRAY; // Добавляем весь алфавит, чтобы заполнить матрицу
            key = RemoveAllDuplicates(key); // Убираем дубликаты

            if (key.Length < SquareCells * SquareCells)
            {
                // Дополняем ключ, чтобы он имел достаточно символов для заполнения матрицы
                key += new string(PACIFIER_SYMBOL[0], SquareCells * SquareCells - key.Length);
            }

            for (int i = 0; i < SquareCells * SquareCells; i++)
            {
                int row = i / SquareCells;
                int col = i % SquareCells;
                this.keyMatrix[row, col] = key[i];
                this.dataGridView1[col, row].Value = key[i]; // Заполняем DataGridView
            }
        }


        private int[] GetPosition(char[,] matrix, char symbol)
        {
            for (int index = 0; index < SquareCells * SquareCells; index++)
            {
                int i = index % SquareCells;
                int j = index / SquareCells;

                if (matrix[i, j] == symbol)
                {
                    return new int[] { i, j };
                }
            }
            throw new ArgumentException($"Символ '{symbol}' не найден в матрице.");
        }

        private string GetDigram(string inputStr)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < inputStr.Length; i += 2)
            {
                char first = inputStr[i];
                char second = (i + 1 < inputStr.Length) ? inputStr[i + 1] : PACIFIER_SYMBOL[0];

                if (first == second)
                {
                    second = PACIFIER_SYMBOL[0];
                    i--; // Повторная обработка текущего символа
                }

                result.Append(first);
                result.Append(second);
            }

            return result.ToString();
        }

        private string Cipher(string inputStr, bool decode)
        {
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < inputStr.Length - 1; index += 2)
            {
                char firstSymbol = inputStr[index];
                char secondSymbol = inputStr[index + 1];

                int[] firstPos = GetPosition(keyMatrix, firstSymbol);
                int[] secondPos = GetPosition(keyMatrix, secondSymbol);

                if (!decode)
                {
                    result.Append(new string(EncodeSymbols(firstPos, secondPos)));
                }
                else
                {
                    result.Append(new string(DecodeSymbols(firstPos, secondPos)));
                }
            }

            return decode ? RemovePacifier(result.ToString()) : result.ToString();
        }

        private string RemovePacifier(string inputStr)
        {
            return inputStr.Replace(PACIFIER_SYMBOL, "");
        }

        private char[] EncodeSymbols(int[] pos1, int[] pos2)
        {
            if (pos1[0] == pos2[0]) // Одна строка
            {
                return new char[]
                {
                    keyMatrix[pos1[0], Mod(pos1[1] + 1, SquareCells)],
                    keyMatrix[pos2[0], Mod(pos2[1] + 1, SquareCells)]
                };
            }
            else if (pos1[1] == pos2[1]) // Одна колонка
            {
                return new char[]
                {
                    keyMatrix[Mod(pos1[0] + 1, SquareCells), pos1[1]],
                    keyMatrix[Mod(pos2[0] + 1, SquareCells), pos2[1]]
                };
            }
            else // Разные строки и колонки
            {
                return new char[]
                {
                    keyMatrix[pos1[0], pos2[1]],
                    keyMatrix[pos2[0], pos1[1]]
                };
            }
        }

        private char[] DecodeSymbols(int[] pos1, int[] pos2)
        {
            if (pos1[0] == pos2[0]) // Одна строка
            {
                return new char[]
                {
                    keyMatrix[pos1[0], Mod(pos1[1] - 1, SquareCells)],
                    keyMatrix[pos2[0], Mod(pos2[1] - 1, SquareCells)]
                };
            }
            else if (pos1[1] == pos2[1]) // Одна колонка
            {
                return new char[]
                {
                    keyMatrix[Mod(pos1[0] - 1, SquareCells), pos1[1]],
                    keyMatrix[Mod(pos2[0] - 1, SquareCells), pos2[1]]
                };
            }
            else // Разные строки и колонки
            {
                return new char[]
                {
                    keyMatrix[pos1[0], pos2[1]],
                    keyMatrix[pos2[0], pos1[1]]
                };
            }
        }

        private int Mod(int x, int mod)
        {
            return (x % mod + mod) % mod;
        }
    }
}