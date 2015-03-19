using ArtificialNeuralNetworkDataFeeder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicators {
	public class InvariantIndicator : IDataIndicator {
		public int InputCount { get { return 1; } }
		public double Process(double[] data, int index) { return data[index]; }
		public double[] Process(double[] data, int index, int count) {
			var result = new double[count];
			while (count-- > 0) result[count] = Process(data, index + count);
			return result;
		}
	}
}
