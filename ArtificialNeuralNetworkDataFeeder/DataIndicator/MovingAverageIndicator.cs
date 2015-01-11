using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtificialNeuralNetworkDataFeeder.Core;
using ArtificialNeuralNetworkDataFeeder.DataProcessors;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicator {
	public class MovingAverageIndicator : DataIndicator<double, double> {
		public override DataProcessor<double, double> DataProcessor { get { return new MovingAverageDataProcessor() { Period = 12 }; } }
	}
}
