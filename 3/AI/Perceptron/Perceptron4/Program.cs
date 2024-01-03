using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Встановлення кодування для коректного відображення символів UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Задання розмірності вхідного вектора та ініціалізація ваг і зміщень
        int inputSize = 12;
        double[] weights = new double[inputSize];
        double[] biases = new double[33];
        double threshold = 0.5;
        Random rand = new Random();

        // Встановлення швидкості навчання та ініціалізація додаткових змінних
        double learningRate = 0.1;
        bool[] lettersLearned = new bool[33];

        // Створення списку для відстеження унікальних вхідних векторів
        List<int[]> usedInputVectors = new List<int[]>();

        // Задання кількості максимальних епох та поточної епохи
        int maxEpochs = 100;
        int currentEpoch = 1;

        // Початок циклу навчання
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

                // Генерація унікального випадкового вхідного вектора
                int[] inputVector = GenerateUniqueRandomInputVector(inputSize, usedInputVectors);

                // Додавання вектора до списку вже використаних
                usedInputVectors.Add(inputVector);

                // Задання очікуваного вихідного вектора
                int[] desiredOutput = new int[33];
                desiredOutput[i] = 1;

                // Розрахунок вхідного сигналу та вихідного сигналу
                double inputSignal = 0;
                for (int j = 0; j < inputSize; j++)
                {
                    inputSignal += inputVector[j] * weights[j];
                }

                inputSignal += biases[i];

                double outputSignal = Sigmoid(inputSignal);
                Console.WriteLine($"Розпізнавання літери {i + 1}: Вихід = {outputSignal}");

                // Розрахунок помилки
                double error = desiredOutput[i] - outputSignal;

                // Градієнтний спуск та оновлення ваг
                double[] gradients = new double[inputSize];
                for (int j = 0; j < inputSize; j++)
                {
                    gradients[j] = inputVector[j] * outputSignal * (1 - outputSignal) * (desiredOutput[i] - outputSignal);
                    weights[j] += learningRate * gradients[j] * inputVector[j];
                }


                // Позначення літери як вивченої, якщо помилка дорівнює 0.1 або менше
                if (error <= 0.1)
                {
                    Console.WriteLine("Правильно розпізнано.");
                    lettersLearned[i] = true;
                }
                else
                {
                    allLettersLearned = false;
                }
            }

            // Інкремент поточної епохи та виведення інформації
            currentEpoch++;
            Console.WriteLine($"Епоха: {currentEpoch}");

            // Перевірка, чи всі літери вивчені
            if (allLettersLearned)
            {
                Console.WriteLine("Навчання завершено.");
                break;
            }
        }

        // Виведення синаптичних ваг та нейронних зміщень після навчання
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

        // Генерація нового вектора, доки не буде унікального
        do
        {
            for (int i = 0; i < size; i++)
            {
                vector[i] = rand.Next(2); // Генерація 0 або 1
            }
        } while (usedVectors.Contains(vector));

        return vector;
    }

    // Логістична функція активації (сигмоїда)
    static double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Math.Exp(-x));
    }
}



