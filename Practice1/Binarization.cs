﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Binarization : Filtres
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)((0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B));
            int t = 120;
            if (intensity >= t)
            {
                Color resultColor = Color.FromArgb((255),
                                                   (255),
                                                   (255));
                return resultColor;
            }
            else
            {
                Color resultColor = Color.FromArgb((0),
                                                   (0),
                                                   (0));
                return resultColor;
            }
           
            
        }
    }
}
