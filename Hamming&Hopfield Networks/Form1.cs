using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab1
{
    public partial class Form1 : Form
    {
        Color baseColor;
        Image sourceImage;


        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            baseColor = Color.FromArgb(255, 199, 191, 230);
         //   baseColor = Color.FromArgb(255, 255, 255, 255);
            panel1.BackColor = baseColor;

            initializeBoxes();
            
        }

        private void initializeBoxes()
        {
            String[] fileNames1 = Directory.GetFiles("samples");
            String[] fileNames2 = Directory.GetFiles("noisy");

            foreach (String fnm in fileNames1)
            {
                sampImsListBox.Items.Add(fnm);
            }

            foreach (String fnm in fileNames2)
            {
                recImsBox.Items.Add(fnm);
            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((sender as PictureBox).Cursor == Cursors.Hand)
            {
                baseColor = ((Bitmap)(sender as PictureBox).Image).GetPixel(e.X, e.Y);
                panel1.BackColor = baseColor;
                pictureBox1.Cursor = Cursors.Default;
                pictureBox2.Cursor = Cursors.Default;
            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox2.Cursor = Cursors.Hand;
        }



        private void recImsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceImage = Image.FromFile(recImsBox.SelectedItem.ToString());
            pictureBox2.Image = new Bitmap(sourceImage, pictureBox1.Width, pictureBox1.Height);
        }

        private void sampImsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceImage = Image.FromFile(sampImsListBox.SelectedItem.ToString());
            pictureBox1.Image = new Bitmap(sourceImage, pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (recImsBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите изображение!");
            }
            else
            {
                string type = "(Hamming)";
                Network net = new HammingNN("samples", baseColor);

                //string type = "(Hopfield)";
                //Network net = new HopfieldNN("samples", baseColor);

                int n = net.Recognize(recImsBox.SelectedItem.ToString()) + 1; // индексация с 1

                string mssg = "Изображение отнесено к классу " + n;

                mssg += " " + type;
                MessageBox.Show(mssg);
            }
            
        }

    }
}
