using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Ініціалізація персептрону
        int inputSize = 12; // Розмір вхідного вектора
        double[] weights = new double[inputSize]; // Ваги
        double[] biases = new double[33]; // Нейронні зміщення
        double threshold = 0.9; // Поріг чутливості
        Random rand = new Random();

        // Параметри навчання
        double learningRate = 1;

        // Масив для відстеження навчання кожної літери
        bool[] lettersLearned = new bool[33];

        //відслідковування щоб не було однакових вхідних векторів
        List<int[]> usedInputVectors = new List<int[]>();

        // Навчальний цикл
        int maxEpochs = 1000;
        int currentEpoch = 1;

        while (currentEpoch < maxEpochs)
        {
            Console.WriteLine("Нова епоха навчання");
            bool allLettersLearned = true;

            // Генерація випадкового вхідного вектора і його розпізнавання для кожної літери
            for (int i = 0; i < 33; i++)
            {
                if (lettersLearned[i])
                {
                    continue; // Якщо літера вже вивчена, перейти до наступної
                }

                int[] inputVector = GenerateUniqueRandomInputVector(inputSize, usedInputVectors);

                usedInputVectors.Add(inputVector);

                // Визначення бажаного вихідного сигналу для кожної літери
                int[] desiredOutput = new int[33];
                desiredOutput[i] = 1;

                double inputSignal = 0;
                for (int j = 0; j < inputSize; j++)
                {
                    inputSignal += inputVector[j] * weights[j]; //Сумується вагований вхід для кожного нейрона.
                }

                //Додається нейронне зміщення для поточного нейрона.
                inputSignal += biases[i];

                // Визначення виходу персептрону (бінарне рішення)
                double outputSignal = (inputSignal >= threshold) ? 1 : 0;
                Console.WriteLine($"Розпізнавання літери {i + 1}: Вихід = {outputSignal}");

                // Розрахунок помилки
                //Обчислюється різниця між бажаним вихідним сигналом та отриманим вихідним сигналом.
                double error = desiredOutput[i] - outputSignal;

                // Коригування синаптичних ваг та нейронного зміщення
                for (int j = 0; j < inputSize; j++)
                {
                    weights[j] += learningRate * inputVector[j] * error; //дельта-правилo
                }

                biases[i] += learningRate * error;

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
}