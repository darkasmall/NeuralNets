using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Lab1
{
    delegate List<double> BiAction(string filename, Color baseColor);

    static class AlgsWithFiles
    {


        public static List<double> bipolImage(string filename, Color baseColor)
        {
            List<double> res = new List<double>();

            int difParam = 30;

            Image tmpIm = Image.FromFile(filename);
            Bitmap b = new Bitmap(tmpIm);

            for (int j = 0; j < b.Height; ++j)
                for (int i = 0; i < b.Width; ++i)
                {
                    int bp = b.GetPixel(i, j).ToArgb();
                    int cp = baseColor.ToArgb();
                    if (Math.Abs(bp - cp) < difParam)
                        res.Add(-1);
                    else
                        res.Add(1);
                }

            return res;
        }


        public static List<double> binarImage(string filename, Color baseColor)
        {
            List<double> res = new List<double>();

            int difParam = 30;

            Image tmpIm = Image.FromFile(filename);
            Bitmap b = new Bitmap(tmpIm);

            for (int j = 0; j < b.Height; ++j)
                for (int i = 0; i < b.Width; ++i)
                {
                    int bp = b.GetPixel(i, j).ToArgb();
                    int cp = baseColor.ToArgb();
                    if (Math.Abs(bp - cp) < difParam)
                        res.Add(0);
                    else
                        res.Add(1);
                }
            WriteArrInFile("ot.txt", res);
            return res;
        }

        public static List<List<double>> processingFilesInDirectory(String dirName, BiAction action, Color baseColor)
        {
            List<List<double>> res = new List<List<double>>();
            String[] fileNames = Directory.GetFiles(dirName);

            foreach (String fnm in fileNames)
                res.Add(action(fnm, baseColor));

            return res;
        }

        public static void WriteArrInFile(string fname, List<double> x)
        {
            StreamWriter sw = new StreamWriter(fname);
            for (int i = 0; i < x.Count; ++i)
                sw.Write(x[i]);

            sw.Close();
        }

        public static void WriteMtrxInFile(string fname, double[,] x)
        {
            StreamWriter sw = new StreamWriter(fname);
            for (int i = 0; i < x.GetLength(0); ++i)
            {
                for (int j = 0; j < x.GetLength(1); ++j)
                    sw.Write(x[i, j]);
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
