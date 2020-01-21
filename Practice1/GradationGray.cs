using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class GradationGray : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)((sourceColor.R + sourceColor.G + sourceColor.B) / 3);
            Color resultColor = Color.FromArgb(Clamp(intensity, 0, 255),
                                               Clamp(intensity, 0, 255),
                                               Clamp(intensity, 0, 255));
            return resultColor;

        }
    }
}
