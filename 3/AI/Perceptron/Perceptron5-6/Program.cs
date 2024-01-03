// the input values
using ExclusivelyOrAISolving;

double[,] inputs =
{
                { 0, 0},
                { 0, 1},
                { 1, 0},
                { 1, 1}
            };

// Очікувані результати
double[] results = { 0, 1, 1, 0 };

// Створення двох нейронів які приймають входи, та одного нейрона який видає результат
Neuron hiddenNeuron1 = new Neuron();
Neuron hiddenNeuron2 = new Neuron();
Neuron outputNeuron = new Neuron();

int epoch = 0;
bool result = false;
int trueResultsCount = 0;

while (trueResultsCount < 4)
{
    epoch++;
    for (int i = 0; i < 4; i++)
    {
        // Передача входів на кожен нейрон
        hiddenNeuron1.SetInputs(inputs[i, 0], inputs[i, 1]);
        hiddenNeuron2.SetInputs(inputs[i, 0], inputs[i, 1]);
        outputNeuron.SetInputs(hiddenNeuron1.Output, hiddenNeuron2.Output);

        // Перевірка на вірний результат
        if ((inputs[i, 0] + inputs[i, 1]) == 1)
        {
            if (outputNeuron.Output > 0.9d)
            {
                result = true;
                trueResultsCount++;
            }
            else
            {
                result = false;
                trueResultsCount = 0;
            }
        }
        else if (((inputs[i, 0] + inputs[i, 1]) == 0) || ((inputs[i, 0] + inputs[i, 1]) == 2))
        {
            if (outputNeuron.Output < 0.9d)
            {
                result = true;
                trueResultsCount++;
            }
            else
            {
                result = false;
                trueResultsCount = 0;
            }
        }

        Console.WriteLine($"{inputs[i, 0]} xor {inputs[i, 1]} = {outputNeuron.Output} - {result}, epoch: {epoch}");

        // Зміна ваг вихідного нейрона відносно його нейронної похибки
        outputNeuron.SetNeuronError(Sigmoid.CalculateDerivative(outputNeuron.Output) * (results[i] - outputNeuron.Output));
        outputNeuron.UpdateWeights();

        // Зміна ваг вхідних нейронів, відносно їхньої нейронної похибки
        hiddenNeuron1.SetNeuronError(Sigmoid.CalculateDerivative(hiddenNeuron1.Output) * outputNeuron.NeuronError * outputNeuron.Weights[0]);
        hiddenNeuron2.SetNeuronError(Sigmoid.CalculateDerivative(hiddenNeuron2.Output) * outputNeuron.NeuronError * outputNeuron.Weights[1]);
        hiddenNeuron1.UpdateWeights();
        hiddenNeuron2.UpdateWeights();
    }

    Console.WriteLine();
}

Console.ReadLine();
