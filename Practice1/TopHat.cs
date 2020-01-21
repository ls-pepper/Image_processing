using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class TopHat : Filtres
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Filtres erosion = new Erosion();
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            resultImage = erosion.processImage(sourceImage, worker);
            
            for (int i = 0; i < resultImage.Width; ++i)
            {
                for (int j = 0; j < resultImage.Height; ++j)
                {
                   
                    Color erosionColor = resultImage.GetPixel(i, j);
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    Color resultColor = Color.FromArgb(Clamp(sourceColor.R - erosionColor.R, 0, 255),
                                               Clamp(sourceColor.G - erosionColor.G, 0, 255),
                                               Clamp(sourceColor.B - erosionColor.B, 0, 255));
                    resultImage.SetPixel(i, j, resultColor);

                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }
    }
}
