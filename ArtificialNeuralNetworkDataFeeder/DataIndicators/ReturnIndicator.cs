using ArtificialNeuralNetworkDataFeeder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicators {
	public class ReturnIndicator : IDataIndicator {
		public int InputCount { get { return 2; } }

		public double Process(double[] data, int index) {
			return data[index] / data[index - 1];
		}
	}
}
