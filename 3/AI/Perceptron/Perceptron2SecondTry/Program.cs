using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Ініціалізація персептрону
        int inputSize = 12; // Розмір вхідного вектора
        double[] weights = new double[inputSize]; // Ваги
        double threshold = 0.5; // Поріг чутливості
        Random rand = new Random();

        // Параметри навчання
        double learningRate = 1.0;

        // Масив для відстеження навчання кожного числа від 1 до 9
        bool[] numbersLearned = new bool[10];

        // Навчальний цикл
        int maxEpochs = 1000;

        while (true)
        {
            Console.WriteLine("Нова епоха навчання");
            bool allNumbersLearned = true;

            // Генерація випадкового вхідного вектора і його розпізнавання для чисел від 1 до 9
            for (int i = 1; i <= 9; i++)
            {
                if (numbersLearned[i])
                {
                    continue; // Якщо число вже вивчено, перейти до наступного
                }

                int[] inputVector = GenerateRandomInputVector(inputSize, rand);
                int target = (i % 2 == 0) ? 0 : 1; // Правильна відповідь

                double inputSignal = 0;
                for (int j = 0; j < inputSize; j++)
                {
                    inputSignal += inputVector[j] * weights[j];
                }

                double outputSignal = (inputSignal >= threshold) ? 1 : 0;
                Console.WriteLine("Розпiзнавання числа " + i + ": Вихiд = " + outputSignal);

                if (outputSignal == target)
                {
                    Console.WriteLine("Правильно розпiзнано.");
                    numbersLearned[i] = true;
                }
                else
                {
                    allNumbersLearned = false;

                    if (outputSignal == 0)
                    {
                        // Збільшення ваги активних входів
                        for (int j = 0; j < inputSize; j++)
                        {
                            if (inputVector[j] == 1)
                            {
                                weights[j] += learningRate;
                            }
                        }
                    }
                    else
                    {
                        // Зменшення ваги активних входів
                        for (int j = 0; j < inputSize; j++)
                        {
                            if (inputVector[j] == 1)
                            {
                                weights[j] -= learningRate;
                            }
                        }
                    }
                }
            }

            if (allNumbersLearned)
            {
                Console.WriteLine("Навчання завершено.");
                break;
            }
        }

        // Виведення ваг після навчання
        Console.WriteLine("Ваги пiсля навчання:");
        foreach (var weight in weights)
        {
            Console.Write(weight + " ");
        }
    }

    // Генерування випадкового вхідного вектора
    static int[] GenerateRandomInputVector(int size, Random rand)
    {
        int[] vector = new int[size];
        for (int i = 0; i < size; i++)
        {
            vector[i] = rand.Next(2); // Генеруємо 0 або 1
        }
        return vector;
    }
}