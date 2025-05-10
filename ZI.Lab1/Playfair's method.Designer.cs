using System.Windows.Forms;

namespace ZI.Lab1
{
    partial class Playfair_s_method
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Output_richTextBox = new System.Windows.Forms.RichTextBox();
            this.Input_richTextBox = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Key_label = new System.Windows.Forms.Label();
            this.Key_textBox = new System.Windows.Forms.TextBox();
            this.Decrypt_radioButton = new System.Windows.Forms.RadioButton();
            this.Encypt_radioButton = new System.Windows.Forms.RadioButton();
            this.Result_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SetMatrix_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Output_richTextBox
            // 
            this.Output_richTextBox.Location = new System.Drawing.Point(14, 207);
            this.Output_richTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Output_richTextBox.Name = "Output_richTextBox";
            this.Output_richTextBox.Size = new System.Drawing.Size(490, 127);
            this.Output_richTextBox.TabIndex = 0;
            this.Output_richTextBox.Text = "";
            // 
            // Input_richTextBox
            // 
            this.Input_richTextBox.Location = new System.Drawing.Point(14, 52);
            this.Input_richTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Input_richTextBox.Name = "Input_richTextBox";
            this.Input_richTextBox.Size = new System.Drawing.Size(490, 127);
            this.Input_richTextBox.TabIndex = 1;
            this.Input_richTextBox.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(14, 352);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(231, 232);
            this.dataGridView1.TabIndex = 2;
            // 
            // Key_label
            // 
            this.Key_label.AutoSize = true;
            this.Key_label.Location = new System.Drawing.Point(270, 351);
            this.Key_label.Name = "Key_label";
            this.Key_label.Size = new System.Drawing.Size(46, 20);
            this.Key_label.TabIndex = 3;
            this.Key_label.Text = "Ключ";
            // 
            // Key_textBox
            // 
            this.Key_textBox.Location = new System.Drawing.Point(270, 375);
            this.Key_textBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Key_textBox.Name = "Key_textBox";
            this.Key_textBox.Size = new System.Drawing.Size(234, 27);
            this.Key_textBox.TabIndex = 4;
            // 
            // Decrypt_radioButton
            // 
            this.Decrypt_radioButton.AutoSize = true;
            this.Decrypt_radioButton.Location = new System.Drawing.Point(370, 480);
            this.Decrypt_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Decrypt_radioButton.Name = "Decrypt_radioButton";
            this.Decrypt_radioButton.Size = new System.Drawing.Size(82, 24);
            this.Decrypt_radioButton.TabIndex = 5;
            this.Decrypt_radioButton.Text = "Decrypt";
            this.Decrypt_radioButton.UseVisualStyleBackColor = true;
            // 
            // Encypt_radioButton
            // 
            this.Encypt_radioButton.AutoSize = true;
            this.Encypt_radioButton.Checked = true;
            this.Encypt_radioButton.Location = new System.Drawing.Point(270, 480);
            this.Encypt_radioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Encypt_radioButton.Name = "Encypt_radioButton";
            this.Encypt_radioButton.Size = new System.Drawing.Size(79, 24);
            this.Encypt_radioButton.TabIndex = 6;
            this.Encypt_radioButton.TabStop = true;
            this.Encypt_radioButton.Text = "Encrypt";
            this.Encypt_radioButton.UseVisualStyleBackColor = true;
            // 
            // Result_button
            // 
            this.Result_button.Location = new System.Drawing.Point(270, 512);
            this.Result_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Result_button.Name = "Result_button";
            this.Result_button.Size = new System.Drawing.Size(232, 72);
            this.Result_button.TabIndex = 7;
            this.Result_button.Text = "button1";
            this.Result_button.UseVisualStyleBackColor = true;
            this.Result_button.Click += new System.EventHandler(this.Result_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Исходный текст";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Результат";
            // 
            // SetMatrix_button
            // 
            this.SetMatrix_button.Location = new System.Drawing.Point(270, 413);
            this.SetMatrix_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SetMatrix_button.Name = "SetMatrix_button";
            this.SetMatrix_button.Size = new System.Drawing.Size(232, 40);
            this.SetMatrix_button.TabIndex = 10;
            this.SetMatrix_button.Text = "Заполнить таблицу";
            this.SetMatrix_button.UseVisualStyleBackColor = true;
            this.SetMatrix_button.Click += new System.EventHandler(this.SetMatrix_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 600);
            this.Controls.Add(this.SetMatrix_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Result_button);
            this.Controls.Add(this.Encypt_radioButton);
            this.Controls.Add(this.Decrypt_radioButton);
            this.Controls.Add(this.Key_textBox);
            this.Controls.Add(this.Key_label);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Input_richTextBox);
            this.Controls.Add(this.Output_richTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox Output_richTextBox;
        private RichTextBox Input_richTextBox;
        private DataGridView dataGridView1;
        private Label Key_label;
        private TextBox Key_textBox;
        private RadioButton Decrypt_radioButton;
        private RadioButton Encypt_radioButton;
        private Button Result_button;
        private Label label1;
        private Label label2;
        private Button SetMatrix_button;
    }
}