using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int inputSize = 12;
        double[] weights = new double[inputSize];
        double[] biases = new double[33];
        double threshold = 0.5;
        Random rand = new Random();

        double learningRate = 0.1;
        bool[] lettersLearned = new bool[33];

        //відслідковування щоб не було однакових вхідних векторів
        List<int[]> usedInputVectors = new List<int[]>();


        int maxEpochs = 100;
        int currentEpoch = 0;

        while (currentEpoch < maxEpochs)
        {
            Console.WriteLine("Нова епоха навчання");
            bool allLettersLearned = true;

            // Генерація випадкового вхідного вектора і його розпізнавання для кожної літери
            for (int i = 0; i < 33; i++)
            {
                if (lettersLearned[i])
                {
                    continue;
                }

                int[] inputVector = GenerateUniqueRandomInputVector(inputSize, usedInputVectors);
                int[] desiredOutput = new int[33];
                desiredOutput[i] = 1;

                double inputSignal = 0;
                for (int j = 0; j < inputSize; j++)
                {
                    inputSignal += inputVector[j] * weights[j];
                }

                inputSignal += biases[i];

                double outputSignal = Sigmoid(inputSignal);
                Console.WriteLine($"Розпізнавання літери {i + 1}: Вихід = {outputSignal}");

                double error = desiredOutput[i] - outputSignal;

                // Градієнтний спуск
                double[] gradients = new double[inputSize];
                for (int j = 0; j < inputSize; j++)
                {
                    gradients[j] = inputVector[j] * (1 - outputSignal) * outputSignal * error;
                    weights[j] += learningRate * gradients[j];
                }

                // Позначення літери як вивченої, якщо помилка дорівнює 0
                if (error == 0)
                {
                    Console.WriteLine("Правильно розпізнано.");
                    lettersLearned[i] = true;
                }
                else
                {
                    allLettersLearned = false;
                }
            }

            currentEpoch++;
            Console.WriteLine($"Епоха: {currentEpoch}");

            if (allLettersLearned)
            {
                Console.WriteLine("Навчання завершено.");
                break;
            }

            // Перевірка умови зупинки
            bool stopConditionMet = true;
            for (int i = 0; i < 33; i++)
            {
                int[] inputVector = GenerateUniqueRandomInputVector(inputSize, usedInputVectors);
                double inputSignal = 0;
                for (int j = 0; j < inputSize; j++)
                {
                    inputSignal += inputVector[j] * weights[j];
                }
                inputSignal += biases[i];

                double outputSignal = Sigmoid(inputSignal);

                // Перевірка, чи вихід більше 0.9
                if (outputSignal <= 0.9)
                {
                    stopConditionMet = false;
                    break;
                }
            }

            if (stopConditionMet)
            {
                Console.WriteLine("Досягнуто критерію зупинки. Навчання завершено.");
                break;
            }
        }


        // Виведення ваг і нейронних зміщень після навчання
        Console.WriteLine("Синаптичні ваги після навчання:");
        foreach (var weight in weights)
        {
            Console.Write(weight + " ");
        }

        Console.WriteLine("\nНейронні зміщення після навчання:");
        foreach (var bias in biases)
        {
            Console.Write(bias + " ");
        }
    }

    // Генерування унікального випадкового вхідного вектора
    static int[] GenerateUniqueRandomInputVector(int size, List<int[]> usedVectors)
    {
        Random rand = new Random();
        int[] vector = new int[size];

        // Генеруємо новий вектор, поки не отримаємо унікальний
        do
        {
            for (int i = 0; i < size; i++)
            {
                vector[i] = rand.Next(2); // Генеруємо 0 або 1
            }
        } while (usedVectors.Contains(vector));

        return vector;
    }

    static double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Math.Exp(-x));
    }

}