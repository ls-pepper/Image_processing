using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Practice1
{
    class Roberts:MatrixFilter
    {
        protected float[,] kernel1 = null;

        public Roberts()
        {
            
            kernel = new float[2, 2] { { 1, 0 }, {0, -1} };
            kernel1 = new float[2, 2] { { 0, 1 }, { -1, 0} };
        }



        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0);
            int radiusY = kernel.GetLength(1);

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            float resultR1 = 0;
            float resultG1 = 0;
            float resultB1 = 0;
            for (int l = 0; l != radiusY; l++)
                for (int k = 0; k != radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k, l];
                    resultG += neighborColor.G * kernel[k, l];
                    resultB += neighborColor.B * kernel[k, l];
                }
            for (int l = 0; l != radiusY; l++)
                for (int k = 0; k != radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR1 += neighborColor.R * kernel1[k, l];
                    resultG1 += neighborColor.G * kernel1[k, l];
                    resultB1 += neighborColor.B * kernel1[k, l];
                }
            resultR = (float)Math.Sqrt(resultR * resultR + resultR1 * resultR1);
            resultG = (float)Math.Sqrt(resultG * resultG + resultG1 * resultG1);
            resultB = (float)Math.Sqrt(resultB * resultB + resultB1 * resultB1);

            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );




        }

    }
}

