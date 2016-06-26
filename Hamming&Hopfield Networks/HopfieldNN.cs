using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    public class HopfieldNN : Network
    {
        List<List<double>> samples;

        double[][] weightMatrix;

        Color baseColor;

        public HopfieldNN(String dirname, Color baseColor)
        {
            samples = AlgsWithFiles.processingFilesInDirectory(dirname, AlgsWithFiles.bipolImage, baseColor);
            
            this.baseColor = baseColor;

            int n = samples[0].Count; 
            weightMatrix = new double[n][];

            for (int i = 0; i < n; ++i)
            {
                weightMatrix[i] = new double[n];
                for (int j = 0; j < n; ++j)
                {
                    double sum = 0;
                    for (int k = 0; k < samples.Count; ++k)
                    {
                        sum += samples[k][i] * samples[k][j];
                    }
                    weightMatrix[i][j] = sum / n;
                }
            }
        }


        int TresholdFunc(double x)
        {
            return x >= 0 ? 1 : -1;
        }


        public override int Recognize(string filename)
        {
            List<double> x = AlgsWithFiles.bipolImage(filename, baseColor);
            double[] fstSignals = Matrix.getDoubleArr(x);
            double[] sndSignals = fstSignals;

            double eps = 0.001;

            for (int i = 0; i < 10000; ++i)
            {
                double err = 0.0;
                sndSignals = Matrix.MultiplyOnVector(weightMatrix, fstSignals);

                for (int j = 0; j < sndSignals.Length; ++j)
                    sndSignals[j] = TresholdFunc(sndSignals[j]);

                for (int j = 0; j < sndSignals.Length; ++j)
                {
                    err += fstSignals[j] * sndSignals[j];
                }

                err = fstSignals.Length - err;
                fstSignals = sndSignals;

                if (err < eps)
                    break;
            }

            // find result
            double minDist = double.MaxValue;
            int index = 0;
            for (int k = 0; k < samples.Count; ++k)
            {
                double dist = 0.0;
                for (int j = 0; j < sndSignals.Length; ++j)
                {
                    dist += samples[k][j] * sndSignals[j];
                }
                dist = fstSignals.Length - dist;
                if (dist < minDist)
                {
                    minDist = dist;
                    index = k;
                }
            }

            return index;
        }
    }
}
