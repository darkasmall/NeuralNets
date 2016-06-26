using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Kohonen
{
    public class Network
    {
        List<List<Neuron>> neurons = new List<List<Neuron>>();
        private bool isTraining = false;
        private int dataDim = -1;

        public Network(int width, int height, int weightDimension)
        {
            for (int i = 0; i < width; ++i)
            {
                neurons.Add(new List<Neuron>());
                for (int j = 0; j < height; ++j)
                {
                    neurons[i].Add(new Neuron(j, i, weightDimension));
                }
            }
        }

        private Neuron BMU(List<double> inputVals)
        {
            double minDist = double.MaxValue;
            int iBMU = 0;
            int jBMU = 0;

            for (int i = 0; i < neurons.Count; ++i)
                for (int j = 0; j < neurons[i].Count; ++j)
                {
                    double curDist = neurons[i][j].CalcDistanse(inputVals);
                    if (curDist < minDist)
                    {
                        minDist = curDist;
                        iBMU = i;
                        jBMU = j;
                    }
                } 
            return neurons[iBMU][jBMU];
        }

        

        public void Training(List<List<double>> inputData, int iterCount, ref ProgressBar prBar)
        {
            double mapRadius = neurons.Count;
            double timeConstant = iterCount / Math.Log(mapRadius);
            double startRate = 0.6;

            int curIter = 1;
            double rate = startRate;
            int curDataInd = -1;
            double neighbourSpacing = mapRadius;
            double err = 1.0;

            while (curIter < iterCount && err >= 0.0001)
            {
                curDataInd = (1 + curDataInd) % inputData.Count;
                Neuron bmu = BMU(inputData[curDataInd]);
                err = bmu.CalcError(inputData[curDataInd]);

                for (int i = 0; i < neurons.Count; ++i)
                    for (int j = 0; j < neurons[i].Count; ++j)
                    {
                        double spacing = Math.Sqrt(Math.Pow(bmu.x - neurons[i][j].x, 2) + Math.Pow(bmu.y - neurons[i][j].y, 2));

                        if (spacing < neighbourSpacing)
                        {
                            neurons[i][j].UpdateWeights(inputData[curDataInd], rate);
                        }
                    }

                curIter++;
                rate = startRate * Math.Exp(-curIter / iterCount);
                neighbourSpacing = mapRadius * Math.Exp(-(double)curIter / timeConstant);
                prBar.Increment(1);
            }

            isTraining = true;
            dataDim = inputData.Count;
        }

        public List<List<Color>> PictureMap()
        {
            List<List<Color>> res = new List<List<Color>>();

            for (int i = 0; i < neurons.Count; ++i)
            {
                res.Add(new List<Color>());
                for (int j = 0; j < neurons[i].Count; ++j)
                {
                    res[i].Add(neurons[i][j].ToColor());
                }
            }
            return res;
        }

        public void SaveToFile(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);

            String netText = "trained " + isTraining.ToString();
            if (isTraining)
                netText += " " + dataDim.ToString();
            netText += "\n";

            netText += neurons.Count.ToString() + " " + neurons[0].Count.ToString();
            for (int i = 0; i < neurons.Count; ++i)
            {
                for (int j = 0; j < neurons[0].Count; ++j)
                {
                    netText += neurons[i][j].ToString() + "|";
                }
                netText += "\n";
            }
            sw.Write(netText);
            sw.Close();
        }
    }
}
