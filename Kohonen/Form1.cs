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
    public partial class MainForm : Form
    {
        private FormShow formSh;

        public MainForm()
        {
            InitializeComponent();
            AddOwnedForm(formSh);
        }

        int iterCount = 400;

        Network kohonen = null;
        List<List<double>> inputData = new List<List<double>>();

        int w, h, dataDim;

        private void button_Create_Click(object sender, EventArgs e)
        {
            w = Int32.Parse(textBox_Width.Text);
            h = Int32.Parse(textBox_Height.Text);
            kohonen = new Network(w, h, 3);
            label1.Text = "Создана сеть размера [" + w.ToString() + ";" + h.ToString() + "]";
        }

        

        private void createRandomInputData()
        {
            inputData.Clear();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < dataDim; ++i)
            {
                List<double> newVal = new List<double>();
                newVal.Add(r.Next(30, 256));
                newVal.Add(r.Next(30, 256));
                newVal.Add(r.Next(30, 256));
                inputData.Add(newVal);
            }
        }


        private void button_Training_Click(object sender, EventArgs e)
        {
            if (kohonen == null)
            {
                MessageBox.Show("Сперва создайте сеть!");
                return;
            }

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.MarqueeAnimationSpeed = 1;
            progressBar.Maximum = iterCount;

            dataDim = Int32.Parse(textBox_DataDim.Text);
            createRandomInputData();
            kohonen.Training(inputData, iterCount, ref progressBar);

            progressBar.Value = progressBar.Maximum;

            label1.Text += "\nСеть обучена. Количество цветов = " + dataDim.ToString();
        }

        private void button_Show_Click(object sender, EventArgs e)
        {
            if (kohonen == null)
            {
                MessageBox.Show("Сперва создайте сеть!");
                return;
            }
            formSh = new FormShow();
            var colors = kohonen.PictureMap();
            formSh.drawPicture(colors);
            formSh.Show();
        }


        private void button_SaveFile_Click(object sender, EventArgs e)
        {
            if (kohonen == null)
            {
                MessageBox.Show("Сперва создайте сеть!");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files|*.txt";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                kohonen.SaveToFile(saveFileDialog.FileName);
            }
            
        }
    }
}
