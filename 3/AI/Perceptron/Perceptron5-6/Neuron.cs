
namespace ExclusivelyOrAISolving
{
    public class Neuron
    {
        private double[] _inputs = new double[2];
        private double[] _weights = new double[2];
        private double _error;
        private double _biasWeight;

        public Neuron()
        {
            Random random = new Random();
            _weights[0] = random.NextDouble();
            _weights[1] = random.NextDouble();
            _biasWeight = random.NextDouble();
        }

        public double[] Weights { get { return _weights; } }
        public double NeuronError { get { return _error; } }

        public double Output
        {
            get { return Sigmoid.CalculateOutput(_weights[0] * _inputs[0] + _weights[1] * _inputs[1] + _biasWeight); }
        }

        public void SetNeuronError(double error)
        {
            _error = error;
        }

        public void SetInputs(double input1, double input2)
        {
            _inputs = new double[] { input1, input2 };
        }

        public void UpdateWeights()
        {
            _weights[0] += _error * _inputs[0];
            _weights[1] += _error * _inputs[1];
            _biasWeight += _error;
        }
    }
}
