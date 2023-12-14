using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace pizzaDelivery {
    public class Pizza {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Images { get; set; }

        public BitmapImage Image {
            get {
                if (Images != null && Images.Length > 0) {
                    BitmapImage image = new BitmapImage();
                    using (MemoryStream stream = new MemoryStream(Images)) {
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = stream;
                        image.EndInit();
                    }
                    return image;
                }
                return null;
            }
        }
    }
}
