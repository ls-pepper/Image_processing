using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Sepia:Filtres
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 30;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)((0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B));
            Color resultColor = Color.FromArgb(Clamp(intensity + 2 * k, 0, 255),
                                               Clamp((int)(intensity + 0.5 * k), 0, 255),
                                               Clamp(intensity - 1 * k, 0, 255));
            return resultColor;
        }
    }
}
