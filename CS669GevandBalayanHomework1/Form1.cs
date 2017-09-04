using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS669GevandBalayanHomework1
{
    public partial class frmMain : Form
    {
        private bool imageLoaded = false;
        public frmMain()
        {
            InitializeComponent();
            InitButtons();
            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images\test.jpg");
            if (System.IO.File.Exists(fileName))
                pictInput.Image = new Bitmap(fileName);
        }

        private enum ColorCode
        {
            R, G, B, Yluma, I, Q, Cr, Cb, U, V, C, M, Y, K
        }
        private void InitButtons()
        {
            btnRed.Enabled = imageLoaded;
            btnBlue.Enabled = imageLoaded;
            btnGreen.Enabled = imageLoaded;


            btnCyan.Enabled = imageLoaded;
            btnYellow.Enabled = imageLoaded;
            btnMagenta.Enabled = imageLoaded;
            btnBlack.Enabled = imageLoaded;

            btnYColorSpace.Enabled = imageLoaded;
            btnU.Enabled = imageLoaded;
            btnV.Enabled = imageLoaded;

            btnI.Enabled = imageLoaded;
            btnQ.Enabled = imageLoaded;
        }
        private Bitmap GenerateBitmap(ColorCode input)
        {
            Bitmap returnedBitmap = new Bitmap(pictInput.Image);
            switch (input)
            {
                case ColorCode.R:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            var newPixel = Color.FromArgb(pixel.R, pixel.R, pixel.R);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.G:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            var newPixel = Color.FromArgb(pixel.G, pixel.G, pixel.G);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.B:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            var newPixel = Color.FromArgb(pixel.B, pixel.B, pixel.B);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.C:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int black = Math.Min(Math.Min(255 - pixel.R, 255 - pixel.B), 255 - pixel.G);
                            int cyan = (255 - pixel.R - black) % (255 - black);
                            var newPixel = Color.FromArgb(cyan, cyan, cyan);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.M:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int black = Math.Min(Math.Min(255 - pixel.R, 255 - pixel.B), 255 - pixel.G);
                            int magenta = (255 - pixel.G - black) % (255 - black);
                            var newPixel = Color.FromArgb(magenta, magenta, magenta);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.Y:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int black = Math.Min(Math.Min(255 - pixel.R, 255 - pixel.B), 255 - pixel.G);
                            int yellow = (255 - pixel.B - black) % (255 - black);
                            var newPixel = Color.FromArgb(yellow, yellow, yellow);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.K:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int black = Math.Min(Math.Min(255 - pixel.R, 255 - pixel.B), 255 - pixel.G);
                            var newPixel = Color.FromArgb(black, black, black);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.Yluma:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int yLuma = (int)(pixel.R * .299000 + pixel.G * .587000 + pixel.B * .114000);
                            var newPixel = Color.FromArgb(yLuma, yLuma, yLuma);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.U:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int u = (int)(pixel.R * -.168736 + pixel.G * -.331264 + pixel.B * .500000) + 128;
                            var newPixel = Color.FromArgb(u, u, u);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.V:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int v = (int)(pixel.R * .500000 + pixel.G * -.418688 + pixel.B * -.081312) + 128;
                            var newPixel = Color.FromArgb(v, v, v);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.I:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int ipix = (int)(pixel.R * .596000 + pixel.G * -.274000 + pixel.B * -.322000) + 128;
                            var newPixel = Color.FromArgb(ipix, ipix, ipix);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.Q:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int ipix = (int)(pixel.R * .211000 + pixel.G * -.523000 + pixel.B * .312000) + 128;
                            var newPixel = Color.FromArgb(ipix, ipix, ipix);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.Cb:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int ipix = (int)(pixel.R * .168736 + pixel.G * -.331264 + pixel.B * .5) + 128;
                            var newPixel = Color.FromArgb(ipix, ipix, ipix);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;
                case ColorCode.Cr:
                    for (int i = 0; i < returnedBitmap.Width; i++)
                        for (int j = 0; j < returnedBitmap.Height; j++)
                        {
                            var pixel = returnedBitmap.GetPixel(i, j);
                            int ipix = (int)(pixel.R * .5 + pixel.G * -.418688 - pixel.B * .081312) + 128;
                            var newPixel = Color.FromArgb(ipix, ipix, ipix);
                            returnedBitmap.SetPixel(i, j, newPixel);
                        }
                    break;



            }
            return returnedBitmap;
        }
        private void GenerateNewForm(Bitmap bmp, string title)
        {

            Form tempForm = new Form();
            tempForm.Height = this.Height;
            tempForm.Width = this.Width;
            tempForm.Text = title;
            PictureBox tempBox = new PictureBox();
            tempBox.Image = bmp;
            tempBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            tempForm.Controls.Add(tempBox);
            tempForm.Show();

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        pictInput.Image = new Bitmap(dlg.FileName);
                        imageLoaded = true;
                        InitButtons();
                    }
                }
            }
            catch
            {
                imageLoaded = false;
                InitButtons();
                MessageBox.Show("Error! Couldn't load image.");
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.R);
            }).ContinueWith(t => GenerateNewForm(bmp, "Red"), TaskScheduler.FromCurrentSynchronizationContext());


        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.G);
            }).ContinueWith(t => GenerateNewForm(bmp, "Green"), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.B);
            }).ContinueWith(t => GenerateNewForm(bmp, "Blue"), TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void btnCyan_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.C);
            }).ContinueWith(t => GenerateNewForm(bmp, "Cyan"), TaskScheduler.FromCurrentSynchronizationContext());


        }

        private void btnMagenta_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.M);
            }).ContinueWith(t => GenerateNewForm(bmp, "Magenta"), TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.Y);
            }).ContinueWith(t => GenerateNewForm(bmp, "Yellow"), TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.K);
            }).ContinueWith(t => GenerateNewForm(bmp, "K - Black"), TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void btnYColorSpace_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.Yluma);
            }).ContinueWith(t => GenerateNewForm(bmp, "Y"), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.U);
            }).ContinueWith(t => GenerateNewForm(bmp, "U"), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.V);
            }).ContinueWith(t => GenerateNewForm(bmp, "V"), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.I);
            }).ContinueWith(t => GenerateNewForm(bmp, "I"), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.Q);
            }).ContinueWith(t => GenerateNewForm(bmp, "Q"), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnCr_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.Cr);
            }).ContinueWith(t => GenerateNewForm(bmp, "Cr"), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void btnCb_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Task.Factory.StartNew(() =>
            {
                bmp = GenerateBitmap(ColorCode.Cb);
            }).ContinueWith(t => GenerateNewForm(bmp, "Cb"), TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
