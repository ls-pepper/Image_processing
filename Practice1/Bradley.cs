using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Practice1
{
    class Bradley : Filtres
    {
        private int width;
        private int height;
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            width = (int)(sourceImage.Width * 0.125);
            height = (int)(sourceImage.Height * 0.125);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Filtres filter = new GrayScaleFilter();
            resultImage = filter.processImage(sourceImage, worker);

            for (int i = 0; i < resultImage.Width; i+=width)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < resultImage.Height; j+=height)
                {
                    getNewSetPixel(resultImage, i, j);

                }
            }
            return resultImage;
        }
        private void getNewSetPixel(Bitmap sourceImage, int x, int y)
        {
           
            int threshold = getThreshold(sourceImage, x, y);
            for (int i = 0; i != width; i++)
            {
                for (int j = 0; j != height; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    if (neighborColor.R > threshold)
                    {
                        sourceImage.SetPixel(idX, idY, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        sourceImage.SetPixel(idX, idY, Color.FromArgb(0, 0, 0));
                    }
                }
            }
        }
        private int getThreshold(Bitmap sourceImage, int x, int y)
        {
            double threshold = 0;
            for (int i = 0; i != width; i++)
            {
                for (int j = 0; j != height; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    threshold += neighborColor.R;
                }
            }
            threshold = (threshold / (width * height))*0.87;

            return (int)threshold;
        }


        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }
    }
}

