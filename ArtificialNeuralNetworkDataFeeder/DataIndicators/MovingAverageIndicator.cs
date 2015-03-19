using System;
using ArtificialNeuralNetworkDataFeeder.Core;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicators {
	public class MovingAverageIndicator : IDataIndicator {
		public int Period { get; set; }
		public int InputCount { get { return Period; } }
		public int OuputCount { get { return Period; } }
		public double Process(double[] data, int index) {
			index = index + 1;
			var limit = index - Period;
			var sum = 0d;
			while (index-- > limit) sum += data[index];
			return sum / Period;
		}
		public double[] Process(double[] data, int index, int count) {
			
		}
	}
}
