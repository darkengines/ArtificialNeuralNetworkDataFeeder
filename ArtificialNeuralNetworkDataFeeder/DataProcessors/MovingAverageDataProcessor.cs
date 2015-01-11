using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtificialNeuralNetworkDataFeeder.Core;

namespace ArtificialNeuralNetworkDataFeeder.DataProcessors {
	public class MovingAverageDataProcessor : DataProcessor<double, double> {
		public int Period { get; set; }
		public override double Process(double[] data, int index) {
			index = index + 1;
			if (index < Period) return data[index - 1];
			var limit = index - Period;
			var sum = 0d;
			while (index-- > limit) sum += data[index];
			return sum / Period;
		}
	}
}
