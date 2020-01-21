using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practice1
{
    class Glass : Filtres
    {
        Random rand;
        public Glass()
        {
            rand = new Random();
        }
        
       
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            
            int k = Clamp(x + (rand.Next(0, 10) - 5),0,sourceImage.Width-1);
            int l = Clamp(y + (rand.Next(0, 10) - 5), 0, sourceImage.Height-1);


                Color sourceColor = sourceImage.GetPixel(k, l);

                Color resultColor = Color.FromArgb(Clamp(sourceColor.R, 0, 255),
                                                   Clamp(sourceColor.G, 0, 255),
                                                   Clamp(sourceColor.B, 0, 255));
                return resultColor;
            

        }
    }
}
