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

namespace Kohonen
{
    public partial class FormShow : Form
    {
        private Bitmap picture;
        
        public FormShow()
        {
            InitializeComponent();
            saveFileDialog1 = new SaveFileDialog();
        }

        public void drawPicture(List<List<Color>> colors)
        {
            picture = new Bitmap(colors.Count, colors[0].Count);
            for (int w = 0; w < picture.Width; ++w)
                for (int h = 0; h < picture.Height; ++h)
                    picture.SetPixel(w, h, colors[w][h]);
            pictureBox1.Image = new Bitmap(picture, pictureBox1.Width, pictureBox1.Height);
        }

        private void FormShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Сохранить изображение?", "",MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg";
                saveFileDialog1.ShowDialog();


                if (saveFileDialog1.FileName != "")
                {
                    FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                    picture.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fs.Close();
                }
            }
        }
    }
}
