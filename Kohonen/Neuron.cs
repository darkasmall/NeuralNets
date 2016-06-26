using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kohonen
{
    public class Neuron
    {
        List<double> weights;
        public double x, y;

        public Neuron(double x, double y, int weightDimension)
        {
            weights = new List<double>();

            this.x = x;
            this.y = y;

            SetRandomWeights(weightDimension, 255);
        }

        private void SetRandomWeights(int weightDimension, int maxVal)
        {
            Random r = new Random(unchecked((int)(DateTime.Now.Ticks)));

            for (int i = 0; i < weightDimension; ++i)
                weights.Add(r.Next(maxVal));
        }

        public double CalcDistanse(List<double> inputVals)
        {
            double res = 0;

            for (int i = 0; i < weights.Count; ++i)
            {
                res += Math.Pow(inputVals[i] - weights[i], 2);
            }
            res = Math.Sqrt(res);

            return res;
        }

        public void UpdateWeights(List<double> inputVals, double h)
        {
            for (int i = 0; i < weights.Count; ++i)
            {
                weights[i] += (inputVals[i] - weights[i]) * h;
            }
        }

        public double CalcError(List<double> inputVals)
        {
            double res = 0.0;
            for (int i = 0; i < weights.Count; i++)
            {
                res += (weights[i] - inputVals[i]) * (weights[i] - inputVals[i]);
            }
            res = Math.Sqrt(res);
            return res;
        }

        public Color ToColor()
        {
            return Color.FromArgb(255, Convert.ToInt32(weights[0]), 
                                       Convert.ToInt32(weights[1]), 
                                       Convert.ToInt32(weights[2]));
        }

        public String ToString()
        {
            String res = "";
            foreach (double w in weights)
                res += w.ToString() + " ";
            return res;
        }
    }
}
