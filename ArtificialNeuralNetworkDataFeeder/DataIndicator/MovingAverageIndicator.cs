using ArtificialNeuralNetworkDataFeeder.Core;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicator {
	public class MovingAverageIndicator : DataIndicator<double, double> {
		public int Period { get; set; }
		public override double Process(double[] data, int index)
		{
			index = index + 1;
			if (index < Period) return data[index - 1];
			var limit = index - Period;
			var sum = 0d;
			while (index-- > limit) sum += data[index];
			return sum / Period;
		}

		public override int IndexMinimum
		{
			get { return Period - 1; }
		}
	}
}
