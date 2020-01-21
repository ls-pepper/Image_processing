using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class LightEdge : Filtres
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Filtres medianFilter = new Median();
            Filtres sobel = new Sobel();
            Filtres maxFilter = new MaxFilter();
            Bitmap resultImage = medianFilter.processImage(sourceImage, worker);
            resultImage = sobel.processImage(resultImage, worker);
            resultImage = maxFilter.processImage(resultImage, worker);
            return resultImage;
        }
        
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }
    }
}
