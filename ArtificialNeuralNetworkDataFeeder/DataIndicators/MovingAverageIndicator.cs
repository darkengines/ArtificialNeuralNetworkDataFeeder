using ArtificialNeuralNetworkDataFeeder.Core;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicators {
	public class MovingAverageIndicator : DataIndicator {
		public int Period { get; set; }
		public override double Process(double[] data, int index)
		{
			index = index + 1;
			var limit = index - Period;
			var sum = 0d;
			while (index-- > limit) sum += data[index];
			return sum / Period;
		}

		public override int InputCount
		{
			get { return Period; }
		}
	}
}
