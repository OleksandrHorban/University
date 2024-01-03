using System;

class Program
{
    static void Main()
    {

        double[][] inputData = new double[10][]
            {
                new double[] {
                    1, 1, 1,
                    1, 0, 1,
                    1, 0, 1,
                    1, 0, 1,
                    1, 1, 1}, // Вхідні дані для цифри "0"
                new double[] {
                    0, 0, 1,
                    0, 0, 1,
                    0, 0, 1,
                    0, 0, 1,
                    0, 0, 1}, // Вхідні дані для цифри "1"
                new double[] {
                    1, 1, 1,
                    0, 0, 1,
                    1, 1, 1,
                    1, 0, 0,
                    1, 1, 1}, // Вхідні дані для цифри "2"
                new double[] {
                    1, 1, 1,
                    0, 0, 1,
                    1, 1, 1,
                    0, 0, 1,
                    1, 1, 1}, // Вхідні дані для цифри "3"
                new double[] {
                    1, 0, 1,
                    1, 0, 1,
                    1, 1, 1,
                    0, 0, 1,
                    0, 0, 1}, // Вхідні дані для цифри "4"
                new double[] {
                    1, 1, 1,
                    1, 0, 0,
                    1, 1, 1,
                    0, 0, 1,
                    1, 1, 1}, // Вхідні дані для цифри "5"
                new double[] {
                    1, 1, 1,
                    0, 0, 1,
                    1, 1, 1,
                    1, 0, 1,
                    1, 1, 1}, // Вхідні дані для цифри "6"
                new double[] {
                    1, 1, 1,
                    0, 0, 1,
                    0, 0, 1,
                    0, 0, 1,
                    0, 0, 1}, // Вхідні дані для цифри "7"
                new double[] {
                    1, 1, 1,
                    1, 0, 1,
                    1, 1, 1,
                    1, 0, 1,
                    1, 1, 1}, // Вхідні дані для цифри "8"
                new double[] {
                    1, 1, 1,
                    1, 0, 1,
                    1, 1, 1,
                    0, 0, 1,
                    1, 1, 1}  // Вхідні дані для цифри "9"
            };

        //double[] target = new double[]
        //   {
        //        0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        //   };

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int inputSize = 15;
        double[] weights = new double[inputSize];
        double teta = 0.5;

        Random random = new Random();
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = random.NextDouble() * 2 - 1;
        }

        double learningRate = 0.1;
        bool[] numbersLearned = new bool[10];

        int maxEpochs = 1000;
        int currentEpoch = 0;

        while (currentEpoch < maxEpochs)
        {
            Console.WriteLine("Нова епоха навчання");
            bool allNumbersLearned = true;

            for (int i = 0; i < 10; i++)
            {
                if (numbersLearned[i])
                {
                    continue;
                }

                double[] inputVector = inputData[i];
                double targetValue = (i % 2 == 0) ? 1 : 0;

                double inputSignal = 0;
                for (int j = 0; j < inputSize; j++)
                {
                    inputSignal += inputVector[j] * weights[j];
                }

                double outputSignal = (inputSignal >= teta) ? 1 : 0;
                Console.WriteLine($"Розпізнавання числа {i}: Вихід = {outputSignal}");

                if (outputSignal == targetValue)
                {
                    Console.WriteLine("Правильно розпізнано.");
                    numbersLearned[i] = true;
                }
                else
                {
                    allNumbersLearned = false;

                    for (int j = 0; j < inputSize; j++)
                    {
                        weights[j] += learningRate * (targetValue - outputSignal) * inputVector[j];
                    }
                }
            }

            currentEpoch++;
            Console.WriteLine($"Епоха: {currentEpoch}");

            if (allNumbersLearned)
            {
                Console.WriteLine("Навчання завершено.");
                break;
            }
        }

        Console.WriteLine("Ваги після навчання:");
        foreach (var weight in weights)
        {
            Console.Write(weight + " ");
        }
    }
}

