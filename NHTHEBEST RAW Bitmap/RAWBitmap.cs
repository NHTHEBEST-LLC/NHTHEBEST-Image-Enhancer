using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHTHEBEST
{
    public class RAWBitmap
    {
        public Color[,] RAWColors { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }


        public Color ImageAvarage { 
            get
            {
                Color start = RAWColors[0, 0];
                int a = start.A;
                int r = start.R;
                int g = start.G;
                int b = start.B;

                foreach (var temp in RAWColors)
                {
                    a += Convert.ToInt32(temp.A);
                    r += Convert.ToInt32(temp.R);
                    g += Convert.ToInt32(temp.G);
                    b += Convert.ToInt32(temp.B);

                    a = a / 2;
                    r = r / 2;
                    g = g / 2;
                    b = b / 2;
                }

                return Color.FromArgb(a, r, g, b);
            } 
        }

        public RAWBitmap(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            Width = bitmap.Width;
            Height = bitmap.Height;
            RAWColors = new Color[Width, Height];
            for (int w = 0; w < Width-1; w++)
            {
                for (int h = 0; h < Height - 1; h++)
                {
                    RAWColors[w, h] = bitmap.GetPixel(w, h);
                }
            }
        }

        public RAWBitmap(Color[,] pixals,int width, int height)
        {
            RAWColors = pixals;
            Width = width;
            Height = height;
        }

        public RAWBitmap(int[,] argb, int width, int height)
        {
            Width = width;
            Height = height;
            for (int w = 0; w < Width - 1; w++)
            {
                for (int h = 0; h < Height - 1; h++)
                {
                    RAWColors[w, h] = Color.FromArgb(argb[w,h]);
                }
            }
        }

        public Color GetPixal(int x, int y)
        {
            return RAWColors[x, y];
        }
         
        public Image ToImage()
        {
            var img = new Bitmap(Width, Height);
            
            for (int w = 0; w < Width - 1; w++)
            {
                for (int h = 0; h < Height - 1; h++)
                {
                    img.SetPixel(w, h, RAWColors[w, h]);
                }
            }
            return img;
        }
    }

}
