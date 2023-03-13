using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;

// Можно потом добавить ползунок, чтобы захватывать более 1 младшего бита (говорят 2-3 бита ещё норм)

namespace Steganography
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StegoMethod.SelectedItem = StegoMethod.Items[0];
        }

        private string FilePath { get; set; }
        private Image image { get; set; }

        private void HideText_Click(object sender, EventArgs e)
        {
            // Если пользователь не загрузил картинку, то мы ничего не делаем
            if (image == null)
                return;

            switch (StegoMethod.SelectedItem)
            {
                case "Least Significant Bits (LSB)":
                    {
                        if (textBox1.Text.Length > 0)
                        {
                            var lsb = new LSB();
                            var image = Image.FromFile(FilePath);
                            pictureBox1.Image = lsb.HideMessage(image, textBox1.Text);
                            MessageBox.Show(
                                "The message was successfully embedded in the image. Don't forget to save the file!",
                                "Success", MessageBoxButtons.OK);
                        }
                        else MessageBox.Show("Enter text!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                case "EXIF modification":
                    {
                        if (textBox1.Text.Length > 0)
                        {
                            var exif = new EXIF();
                            pictureBox1.Image = exif.SetExifData(FilePath, textBox1.Text);
                            MessageBox.Show(
                                "The message was successfully saved and embedded in the metadata. Don't forget to save the file!",
                                "Success", MessageBoxButtons.OK);
                        }
                        else MessageBox.Show("Enter text!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void ExtractText_Click(object sender, EventArgs e)
        {
            // Если пользователь не загрузил картинку, то мы ничего не делаем
            if (image == null)
                return;

            switch (StegoMethod.SelectedItem)
            {
                case "Least Significant Bits (LSB)":
                    {
                        var lsb = new LSB();
                        
                        // Проверка на то, зашифровано ли изображение
                        bool isEncrypted = lsb.IsEncrypted(image);

                        if (isEncrypted)
                            textBox1.Text = lsb.ExtractMessage(image);
                        if (!isEncrypted)
                            MessageBox.Show("The picture is not encrypted, or encrypted by another program!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                case "EXIF modification":
                    {
                        var exif = new EXIF();
                        FileInfo.Text = exif.GetExifData(FilePath);
                        break;
                    }
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            // Если пользователь не загрузил картинку, то мы ничего не делаем
            if (image == null)
                return;

            // Сохраняем изображение с сообщением в отдельный файл
            var sfd = new SaveFileDialog
            {
                Filter = "Image Files (*.bmp) |*.bmp|" +
                         "Image Files (*.jpg) |*.jpg|" +
                         "All files (*.*)|*.*"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.bmp) |*.jpg;*.bmp|" +
                         "All files (*.*) | *.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofd.FileName;
                image = Image.FromFile(ofd.FileName);
                pictureBox1.Image = image;

                var exif = new EXIF();
                FileInfo.Text = exif.GetExifData(FilePath);
            }
        }

        private void StegoMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Least Significant Bits (LSB)
            if (StegoMethod.SelectedIndex == 0)
            {
                //ExtractText.Enabled = true;
                //FileInfo.ReadOnly = true;

            }

            // EXIF modification
            if (StegoMethod.SelectedIndex == 1)
            {
                //ExtractText.Enabled = false;
                //FileInfo.ReadOnly = false;

            }
        }
    }
}

