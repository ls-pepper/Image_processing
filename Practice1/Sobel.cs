using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Practice1
{
    class Sobel : MatrixFilter
    {
        protected float[,] kernel1 = null;

        public Sobel()
        {

            kernel = new float[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            kernel1 = new float[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        }

            protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            float resultR1 = 0;
            float resultG1 = 0;
            float resultB1 = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR1 += neighborColor.R * kernel1[k + radiusX, l + radiusY];
                    resultG1 += neighborColor.G * kernel1[k + radiusX, l + radiusY];
                    resultB1 += neighborColor.B * kernel1[k + radiusX, l + radiusY];
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
