using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Perceptrone
{
    public class Perceptrone
    {
        private double[] weights = new double[21]; // Синаптичні ваги
        //private double teta; // Поріг активації
        private int[][] inputData = new int[26][];
        static double learningRate = 1;
        private int[] target;
        public Perceptrone()
        {
            Random random = new Random();

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = random.NextDouble() * 2 - 1;
            }
        }

        private double Train(int[] input)
        {
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * weights[i];
            }

            return 1.0 / (1.0 + Math.Exp(-sum));
        }
        public void Info()
        {
            Console.WriteLine();
            for (int i = 0; i < weights.Length; i++)
            {
                Console.WriteLine(i + 1 + " Weight: " + weights[i]);
            }
            Console.WriteLine("\n");
        }
        public double Recognize(int[] input)
        {
            double recognized = -1;

            recognized = Train(input);

            return recognized;
        }

        public void Start(int[] target, int[][] inputData)
        {
            this.target = target;


            for (int i = 0; i < this.inputData.Length; i++)
            {
                this.inputData[i] = inputData[i].Concat(new int[] { 1 }).ToArray();
            }
            bool correct = false;
            int c;
            double error;
            while (!correct)
            {
                for (int i = 0; i < target.Length; i++)
                {
                    double y = Train(this.inputData[i]);
                    error = y * (1 - y) * (target[i] - y);
                        

                    for (int j = 0; j < weights.Length; j++)
                    {
                        //weights[j] += learningRate * (target[i] - y) * this.inputData[i][j];
                        weights[j] += learningRate * error * this.inputData[i][j];
                    }
                }

                c = 0;

                for (int i = 0; i < 26; i++)
                {
                    if ((target[i] == 1) && (Train(this.inputData[i]) > 0.90d)) { c++; }
                    //if ((target[i] == 0) && (Train(this.inputData[i]) < 0.9d)) { c++; }
                }
                if (c == 1) { correct = true; }
            }
        }
    }
}
