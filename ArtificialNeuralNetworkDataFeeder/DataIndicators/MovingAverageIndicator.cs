using System;
using ArtificialNeuralNetworkDataFeeder.Core;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicators {
	public class MovingAverageIndicator : DataIndicator {
		public int Period { get; set; }
		public override int InputCount { get { return Period; } }
		public override int OutputCount { get { return 1; } }
		public override double[] Process(double[] data, int index) {
			index = index + 1;
			var limit = index - Period;
			var sum = 0d;
			while (index-- > limit) sum += data[index];
			return new double[1] { sum / Period };
		}
	}
}
