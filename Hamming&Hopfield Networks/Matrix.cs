using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public static class Matrix
    {

        public static double[] MultiplyOnVector(double[][] m, double[] v)
        {
            if (m[0].Length != v.Length)
                throw new IndexOutOfRangeException("Bad indexes");

            double[] res = new double[m[0].Length];

            for (int i = 0; i < m.Length; i++)
                for (int j = 0; j < m[0].Length; j++)
                    res[i] += m[i][ j] * v[j];

            return res;

        }



        // for hopfield recognize
        public static double[] getDoubleArr(List<double> x)
        {
            double[] res = new double[x.Count];
            for(int i = 0; i < x.Count; ++i)
            {
                res[i] = x[i];
            }
            return res;
        }
    }
}
