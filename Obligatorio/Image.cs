using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicfilLib;

namespace Obligatorio
{
    class Image : IPicture
    {
        private Bitmap image;
        public Image(Bitmap img)
        {
            image = img;
        }

        public int Height
        {
            get
            {
                return image.Height;
            }
        }

        public int Width
        {
            get
            {
                return image.Width;
            }
        }

        public IPicture Clone()
        {
            Image imageClone = new Image(image);
            return imageClone;
        }

        public Color GetColor(int x, int y)
        {
            Color color = image.GetPixel(x,y);
            return color;
        }

        public void Resize(int width, int height)
        {
            image = new Bitmap(image, width, height); 
        }

        public void SetColor(int x, int y, Color color)
        {
            image.SetPixel(x, y, Color.FromArgb(color.A, color.R, color.G, color.B));
        }
    }
}
