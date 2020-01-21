using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Opening : Filtres
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Filtres erosion = new Erosion();
            Filtres dilation = new Dilation();
            Bitmap resultImage = erosion.processImage(sourceImage, worker);
            resultImage = dilation.processImage(resultImage, worker);
            return resultImage;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }
    }
}
