using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Steganography
{
    internal class EXIF
    {
        public EXIF()
        {

        }
        public string GetExifData(string imagePath)
        {
            var image = Image.FromFile(imagePath);
            var propertyItems = image.PropertyItems;

            // Находим объект метаданных с нужным идентификатором
            var propertyItem = propertyItems.FirstOrDefault(p => p.Id == GetPropertyItemId(imagePath));

            if (propertyItem != null)
            {
                // Если объект метаданных найден, то читаем его значение
                var message = Encoding.ASCII.GetString(propertyItem.Value);
                return message;
            }

            return "Value not set";
        }

        public Image SetExifData(string imagePath, string message)
        {
            var image = Image.FromFile(imagePath);
            var propertyItem = (PropertyItem)FormatterServices.GetUninitializedObject(typeof(PropertyItem));

            // Устанавливаем нужный идентификатор метаданных
            propertyItem.Id = GetPropertyItemId(imagePath);
            
            // Устанавливаем тип данных (здесь выбран тип ASCII-строка)
            propertyItem.Type = 2;

            propertyItem.Value = Encoding.ASCII.GetBytes(message);

            image.SetPropertyItem(propertyItem);

            return image;
        }

        private int GetPropertyItemId(string imagePath)
        {
            string imageExtension = Path.GetExtension(imagePath);

            switch (imageExtension)
            {
                case ".bmp":
                    return 0x9286;
                case ".jpg":
                    return 0x9001;
            }

            return 0;
        }
    }
}
