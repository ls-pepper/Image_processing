using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Practice1
{
    class Median : Filtres
    {



        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            List<Color> sumColor = new List<Color>();

            int radiusX = 1;
            int radiusY = 1;



            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    sumColor.Add(neighborColor);

                }

            sumColor.Sort((a, b) => a.GetBrightness().CompareTo(b.GetBrightness()));
            int n = sumColor.Count / 2;


            return sumColor[n];
        }
    }
}
