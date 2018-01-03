using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Чапыгин_Фильтры
{
    public partial class Form1 : Form
    {

        Bitmap image;
        bool[,] m = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void оТКРЫТЬToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void иНВЕРСИЯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            /*Bitmap resultImage = filter.processImage(image, backgroundWorker1);
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();*/
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true) image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void рАЗМЫТИЕToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void гАУССToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void гРЕЙСКЕЙЛЬToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сЕПИЯToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepiah();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яРКОСТЬToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Yarkost();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сОБЕЛЬToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void рЕЗКОСТЬToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Rezkost();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сТЕКЛОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Steklo();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вОЛНЫToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Volny();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void щАРРToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Scharr();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void мОУШЕНБЛУРToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Motion();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void мЕДИАННЫЙФИЛЬТРToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filters filter = new Median();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сЕРЫЙМИРToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filters filter = new Semir();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сУЖЕНИЕToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter;// = new Ero();
            if (m == null) filter = new Ero();
            else filter = new Ero(m);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void рАСШИРЕНИЕToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter;// = new Dil();
            if (m == null) filter = new Dil();
            else filter = new Dil(m);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void оТКРЫТИЕToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter;// = new Otkr();
            if (m == null) filter = new Otkr();
            else filter = new Otkr(m);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void зАКРЫТИЕToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter;// = new Zakr();
            if (m == null) filter = new Zakr();
            else filter = new Zakr(m);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тОПХЕТToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter; //= new Th();
            if (m == null) filter = new Th();
            else filter = new Th(m);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void лИНЕЙНОЕРАСТЯЖЕНИЕToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Lin();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m = new bool[5, 5];
            m[0, 0] = Convert.ToBoolean(maskedTextBox1.Text);
            m[0, 1] = Convert.ToBoolean(maskedTextBox2.Text);
            m[0, 2] = Convert.ToBoolean(maskedTextBox3.Text);
            m[0, 3] = Convert.ToBoolean(maskedTextBox4.Text);
            m[0, 4] = Convert.ToBoolean(maskedTextBox5.Text);
            m[1, 0] = Convert.ToBoolean(maskedTextBox6.Text);
            m[1, 1] = Convert.ToBoolean(maskedTextBox7.Text);
            m[1, 2] = Convert.ToBoolean(maskedTextBox8.Text);
            m[1, 3] = Convert.ToBoolean(maskedTextBox9.Text);
            m[1, 4] = Convert.ToBoolean(maskedTextBox10.Text);
            m[2, 0] = Convert.ToBoolean(maskedTextBox11.Text);
            m[2, 1] = Convert.ToBoolean(maskedTextBox12.Text);
            m[2, 2] = Convert.ToBoolean(maskedTextBox13.Text);
            m[2, 3] = Convert.ToBoolean(maskedTextBox14.Text);
            m[2, 4] = Convert.ToBoolean(maskedTextBox15.Text);
            m[3, 0] = Convert.ToBoolean(maskedTextBox16.Text);
            m[3, 1] = Convert.ToBoolean(maskedTextBox17.Text);
            m[3, 2] = Convert.ToBoolean(maskedTextBox18.Text);
            m[3, 3] = Convert.ToBoolean(maskedTextBox19.Text);
            m[3, 4] = Convert.ToBoolean(maskedTextBox20.Text);
            m[4, 0] = Convert.ToBoolean(maskedTextBox21.Text);
            m[4, 1] = Convert.ToBoolean(maskedTextBox22.Text);
            m[4, 2] = Convert.ToBoolean(maskedTextBox23.Text);
            m[4, 3] = Convert.ToBoolean(maskedTextBox24.Text);
            m[4, 4] = Convert.ToBoolean(maskedTextBox25.Text);
        }
    }
}
