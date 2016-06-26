using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    public class HammingNN : Network
    {
        double[] outputs, tmpoutputs;

        double[,] weightMatrix;
        int M, K;
        double[][] feedbackSynapse;  // eps c (0, 1/K]
        double emax = 0.001;

        Color baseColor;

        // создание сети по названию папки с эталонными изображениями, обучение сети
        public HammingNN(String dirname, Color baseColor)
        {
            List<List<double>> input = AlgsWithFiles.processingFilesInDirectory(dirname, AlgsWithFiles.binarImage, baseColor);

            K = input.Count;
            M = input[0].Count;

            this.baseColor = baseColor;

            outputs = new double[K];
            tmpoutputs = new double[K];

            weightMatrix = new double[K, M];
            feedbackSynapse = new double[K][];


            double eps = 1 / (1.2 * K);

            // инициализация матриц весовой и синапсов обр связи
            for (int i = 0; i < K; ++i)
            {
                for (int j = 0; j < M; ++j)
                    weightMatrix[i, j] = input[i][j] / 2.0;

                ////
                feedbackSynapse[i] = new double[K];
                for (int k = 0; k < K; ++k)
                {
                    if (i == k)
                        feedbackSynapse[i][ k] = 1;
                    else
                        feedbackSynapse[i][ k] = -eps;
                }
            }
        }

        double TresholdFun(double s)
        {
            double T = M / 2.0;
            if (s <= 0)
                return 0;
            if (s >= T)
                return T;
            else
                return s;
        }



        public override int Recognize(string filename)
        {
            List<double> x = AlgsWithFiles.binarImage(filename, baseColor);

            for (int i = 0; i < K; ++i)
            {
                double s = 0;

                for (int j = 0; j < M; ++j)
                    s += weightMatrix[i, j] * x[j];

                s += M / 2.0;

                // здесь s - состояние нейрона первого слоя

                outputs[i] = s;
            }

            Array.Copy(outputs, tmpoutputs, outputs.Length);

            double hammingDist;
            int indx = -1;

            while (true)
            {
                outputs = Matrix.MultiplyOnVector(feedbackSynapse, tmpoutputs);

                hammingDist = 0;

                for (int i = 0; i < K; ++i)
                {
                    outputs[i] = TresholdFun(outputs[i]);

                    hammingDist += Math.Abs(outputs[i] - tmpoutputs[i]);
                }


                if (hammingDist <= emax)
                {
                    double max = outputs[0];
                    indx = 0;

                    for (int i = 1; i < K; ++i)
                    {
                        if (outputs[i] > max)
                        {
                            max = outputs[i];
                            indx = i;
                        }
                    }
                    break;
                }

                Array.Copy(outputs, tmpoutputs, outputs.Length);
            }
            return indx;
        }


    }
}
