using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        List<Image> imageBox = new List<Image>();
        public Form1()
        {
            InitializeComponent();
            button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            progressBar1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
           

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image file |*.png;*.jpg;*.bmp |All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                imageBox.Add(image);

            }
            
            
            pictureBox1.Image = image;
            pictureBox1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            pictureBox1.Refresh();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap img = (Bitmap)pictureBox1.Image;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "png";
            saveFileDialog.Filter = "Image file |*.png;*.jpg;*.bmp |All files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)

                img.Save(saveFileDialog.FileName, ImageFormat.Png);
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageBox.Remove(imageBox.Last());
            pictureBox1.Image = imageBox.Last();
            pictureBox1.Refresh();


        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            //InvertFilter filter = new InvertFilter();
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filtres)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
                imageBox.Add(image);
            }
                
            

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void гауссToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void градацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new GradationGray();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void полутонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void бинаризацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Binarization();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void брэдлиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Bradley();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new GrayWorld();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void линейноеРастяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Histogram();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Transfer();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void эффектСтеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Glass();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void робертсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Roberts();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new Median();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void максимумToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new MaxFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void светящиесяКраяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtres filter = new LightEdge();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Dilation();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Erosion();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void открытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Opening();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new Closing();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtres filter = new TopHat();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
