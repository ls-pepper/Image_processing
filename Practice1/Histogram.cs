using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Histogram : Filtres
    {
        Color minColor = new Color();
        Color maxColor = new Color();
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x == 0 & y == 0)
            {
                getMinMaxBright(sourceImage);
            }

            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp((sourceColor.R - minColor.R) * (255 / (maxColor.R - minColor.R)), 0, 255),
                                               Clamp((sourceColor.G - minColor.G) * (255 / (maxColor.G - minColor.G)), 0, 255),
                                               Clamp((sourceColor.B - minColor.B) * (255 / (maxColor.B - minColor.B)), 0, 255));
            return resultColor;
        }

        private void getMinMaxBright(Bitmap sourceImage)
        {

            float minBright = 0;
            float maxBright = 0;
            for (int i = 0; i < sourceImage.Width; ++i)
            {
                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    float bright = sourceColor.GetBrightness();

                    
                    if (i == 0 & j == 0)
                    {
                        minBright = bright;
                        maxBright = bright;
                    }
                        
                    if (minBright > bright)
                    {
                        minBright = bright;
                        minColor = sourceColor;

                    }
                        

                    if (maxBright < bright)
                    {
                        maxBright = bright;
                        maxColor = sourceColor;

                    }
                       
                    
                }
            }
            



        }
    }
}
