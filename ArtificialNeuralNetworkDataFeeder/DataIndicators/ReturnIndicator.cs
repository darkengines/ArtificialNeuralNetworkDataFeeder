using ArtificialNeuralNetworkDataFeeder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicators {
	public class ReturnIndicator : DataIndicator {
		public override int InputCount { get { return 2; } }
		public override int OutputCount { get { return 1; } }
		public override double[] Process(double[] data, int index) {
			return new double[1] { data[index] / data[index - 1] };
		}
	}
}
