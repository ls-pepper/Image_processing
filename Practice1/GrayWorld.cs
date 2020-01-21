using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class GrayWorld : Filtres
    {
        int averageR = 0;
        int averageG = 0;
        int averageB = 0;
        int avg = 0;
        Color avgColor;
        double coefR = 0;
        double coefG = 0;
        double coefB = 0;


        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x == 0 & y == 0)
            {
                avgColor = getScaled(sourceImage);
                avg = (avgColor.R + avgColor.G + avgColor.B) / 3;
            }

            Color sourceColor = sourceImage.GetPixel(x, y);
            coefR = (double)avg / avgColor.R;
            coefG = (double)avg / avgColor.G;
            coefB = (double)avg / avgColor.B;

            Color resultColor = Color.FromArgb(Clamp((int)(sourceColor.R * coefR) , 0, 255),
                                   Clamp((int)(sourceColor.G * coefG), 0, 255),
                                   Clamp((int)(sourceColor.B * coefB), 0, 255));
            return resultColor;

        }


        private Color getScaled(Bitmap sourceImage)
        {

            for (int i = 0; i < sourceImage.Width; ++i)
            {
                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    averageR += sourceColor.R;
                    averageG += sourceColor.G;
                    averageB += sourceColor.B;

                }
            }
            int N = sourceImage.Width * sourceImage.Height;
            averageR = averageR / N;
            averageG = averageG / N;
            averageB = averageB / N;
            Color resultScaled = Color.FromArgb(Clamp(averageR, 0, 255),
                                              Clamp(averageG, 0, 255),
                                              Clamp(averageB, 0, 255));
            return resultScaled;




        }
    }
}
