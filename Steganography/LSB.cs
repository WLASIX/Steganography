using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Steganography
{
    internal class LSB
    {

        public LSB()
        {

        }

        // Метод для скрытия сообщения в изображении
        public Bitmap HideMessage(Image originalImage, string message)
        {
            // Создаём стеганографическое изображение, копируем полностью ширину, высоту и глубину цвета
            var inputBitmap = (Bitmap)originalImage;
            var stegoBitmap = new Bitmap(originalImage.Width, originalImage.Height, originalImage.PixelFormat);
            var graphics = Graphics.FromImage(stegoBitmap);
            graphics.DrawImage(inputBitmap, 
                new Rectangle(0, 0, inputBitmap.Width, inputBitmap.Height), 
                new Rectangle(0, 0, inputBitmap.Width, inputBitmap.Height), 
                GraphicsUnit.Pixel);

            // Создаем байтовый массив для сообщения
            // результат BitArray почему-то получается инвертированным (11110100 вместо 00101111), поэтому инвертируем его перед созданием BitArray чтобы символы были определены правильно
            byte[] messageBytes = InvertBytes(Encoding.GetEncoding(1251).GetBytes($"/|/{message}/|/"));
            // Конвертируем байты сообщения в битовый массив
            BitArray messageBits = new BitArray(messageBytes);

            int messageBitsIndex = 0;

            // Встраиваем биты сообщения в младшие биты каждого цветового канала каждого пикселя
            for (int i = 0; i < stegoBitmap.Height; ++i)
            {
                for (int j = 0; j < stegoBitmap.Width; ++j)
                {
                    Color pixel = stegoBitmap.GetPixel(j, i);
                    byte newRed = (byte)((pixel.R & 0xFE) | (messageBitsIndex < messageBits.Length && messageBits[messageBitsIndex] ? 1 : 0));
                    byte newGreen = (byte)((pixel.G & 0xFE) | (messageBitsIndex + 1 < messageBits.Length && messageBits[messageBitsIndex + 1] ? 1 : 0));
                    byte newBlue = (byte)((pixel.B & 0xFE) | (messageBitsIndex + 2 < messageBits.Length && messageBits[messageBitsIndex + 2] ? 1 : 0));
                    Color newPixel = Color.FromArgb(pixel.A, newRed, newGreen, newBlue);
                    stegoBitmap.SetPixel(j, i, newPixel);

                    messageBitsIndex += 3;
                    if (messageBitsIndex >= messageBits.Length) break;
                }
                if (messageBitsIndex >= messageBits.Length) break;
            }

            // Возвращаем изображение с сообщением
            return stegoBitmap;
        }

        // Метод для извлечения сообщения из изображения
        public string ExtractMessage(Image stegoImage)
        {
            Bitmap stegoBitmap = (Bitmap)stegoImage;
            var messageBits = new List<bool>();
            
            // Извлекаем из младших бит каждого цветового канала каждого пикселя
            for (int i = 0; i < stegoBitmap.Height; ++i)
            {
                for (int j = 0; j < stegoBitmap.Width; ++j)
                {
                    Color pixel = stegoBitmap.GetPixel(j, i);

                    // Извлекаем бит из красного канала
                    byte redBit = (byte)(pixel.R & 1);
                    messageBits.Add(redBit == 1);

                    // Извлекаем бит из зелёного канала
                    byte greenBit = (byte)(pixel.G & 1);
                    messageBits.Add(greenBit == 1);

                    // Извлекаем бит из синего канала
                    byte blueBit = (byte)(pixel.B & 1);
                    messageBits.Add(blueBit == 1); 
                    
                    // Если последние значащие биты пикселя были признаком конца сообщения, то фильтруем сообщение от мусора и выходим из функции
                    if (messageBits.Count % 8 == 0)
                    {
                        // Преобразуем биты в байты и декодируем строку
                        String message = new String(Encoding.GetEncoding(1251).GetString(ToByte(messageBits)).ToCharArray());

                        int firstIndex = message.IndexOf("/|/");
                        int secondIndex = message.IndexOf("/|/", firstIndex + 3); // начинаем поиск со следующего индекса за первым вхождением и добавляем 3, чтобы пропустить найденное первое вхождение
                        
                        if (secondIndex != -1)
                        {
                            string substr = message.Substring(0, secondIndex); // получаем подстроку, содержащую только символы перед вторым вхождением
                            message = substr.Replace("/|/", ""); // удаляем все вхождения подстроки '/|/' из подстроки substr
                            
                            return message;
                        }
                    }
                }
            }
            return "";
        }

        private byte[] InvertBytes(byte[] messageBytes)
        {
            byte[] invertedMessageBytes = new byte[messageBytes.Length];
            for (int i = 0; i < messageBytes.Length; i++)
            {
                byte b = messageBytes[i];
                byte invertedB = 0;
                for (int j = 0; j < 8; j++)
                {
                    invertedB <<= 1; // сдвигаем биты влево на 1 позицию
                    invertedB |= (byte)(b & 1); // добавляем младший бит из b в младший бит invertedB
                    b >>= 1; // сдвигаем биты вправо на 1 позицию
                }
                invertedMessageBytes[i] = invertedB;
            }

            return invertedMessageBytes;
        }

        private byte[] ToByte(List<bool> messageBits)
        {
            byte[] messageBytes = new byte[messageBits.Count / 8];
            for (int i = 0; i < messageBits.Count; i += 8)
            {
                byte b = 0;
                for (int j = 0; j < 8; j++)
                {
                    b <<= 1;
                    if (messageBits[i + j])
                        b |= 1;
                }
                messageBytes[i / 8] = b;
            }

            return messageBytes;
        }

        // Проверка на то, зашифрована ли уже картинка
        public bool IsEncrypted(Image stegoImage)
        {
            Bitmap stegoBitmap = (Bitmap)stegoImage;
            var messageBits = new List<bool>(24);
            byte[] messageBytes;

            // Извлекаем из младших бит каждого цветового канала каждого пикселя
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Color pixel = stegoBitmap.GetPixel(j, i);

                    // Извлекаем бит из красного канала
                    byte redBit = (byte)(pixel.R & 1);
                    messageBits.Add(redBit == 1);

                    // Извлекаем бит из зелёного канала
                    byte greenBit = (byte)(pixel.G & 1);
                    messageBits.Add(greenBit == 1);

                    // Извлекаем бит из синего канала
                    byte blueBit = (byte)(pixel.B & 1);
                    messageBits.Add(blueBit == 1);
                    // Если последние значащие биты пикселя были признаком конца сообщения, останавливаем цикл
                }
            }
            // Преобразуем биты в байты
            messageBytes = ToByte(messageBits);
            // Декодируем строку
            char[] charArrayMessage = Encoding.GetEncoding(1251).GetString(messageBytes).ToCharArray();
            String message = new String(charArrayMessage);

            if (message == "/|/") 
                return true;
            else 
                return false;
        }
    }
}