using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Closing:Filtres
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Filtres erosion = new Erosion();
            Filtres dilation = new Dilation();
            Bitmap resultImage = dilation.processImage(sourceImage, worker);
            resultImage = erosion.processImage(resultImage, worker);
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }
    }
}

