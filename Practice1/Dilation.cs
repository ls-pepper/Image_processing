using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Dilation : Filtres
    {
        private int width;
        private int height;
        private int elemWidth;
        private int elemHeight;

        int[,] elem = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            width = sourceImage.Width;
            height = sourceImage.Height;
            elemWidth = elem.GetLength(0);
            elemHeight = elem.GetLength(1);
            
            for (int y = elemHeight/2; y < height - elemHeight/2; y++)
            {
                for (int x = elemWidth / 2; x < width - elemWidth / 2; x++)
                {

                    resultImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
                }
            }
                
            return resultImage;

        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor;
            Color max = Color.FromArgb(0, 0, 0);
            for (int j = -elemHeight / 2; j <= elemHeight / 2; j++)
            {
                for (int i = -elemWidth / 2; i <= elemWidth / 2; i++)
                {
                    sourceColor = sourceImage.GetPixel(x + i, y + j);
                    if ((elem[i + elemWidth / 2, j + elemHeight / 2] == 1) & (sourceColor.GetBrightness() > max.GetBrightness()))
                    {
                        max = sourceColor;
                    }
                }
            }
            return max;
        }
    }
}
