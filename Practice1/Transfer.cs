using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Transfer : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = Clamp(x + 30,0,sourceImage.Height);
            int l = y;
            if (k < sourceImage.Height)
            {

                Color sourceColor = sourceImage.GetPixel(k, l);

                Color resultColor = Color.FromArgb(Clamp(sourceColor.R, 0, 255),
                                                   Clamp(sourceColor.G, 0, 255),
                                                   Clamp(sourceColor.B, 0, 255));
                return resultColor;
            }

            else
            {

                Color sourceColor = sourceImage.GetPixel(x, y);

                Color resultColor = Color.FromArgb(Clamp(0, 0, 255),
                                                   Clamp(0, 0, 255),
                                                   Clamp(0, 0, 255));
                return resultColor;
            }

        }
    }
}
