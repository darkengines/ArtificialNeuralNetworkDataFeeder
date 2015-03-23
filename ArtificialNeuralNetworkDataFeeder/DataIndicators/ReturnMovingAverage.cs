using ArtificialNeuralNetworkDataFeeder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicators {
	public class ReturnMovingAverage : DataIndicator {
		public MovingAverageIndicator movingAverageIndicator { get; private set; }
		public ReturnIndicator returnIndicator { get; private set; }
		public ReturnMovingAverage() {
			movingAverageIndicator = new MovingAverageIndicator();
			returnIndicator = new ReturnIndicator();
		}
		public int Period { get { return movingAverageIndicator.Period; } set { movingAverageIndicator.Period = value; } }
		public override int InputCount { get { return Period + 1; } }
		public override int OutputCount { get { return movingAverageIndicator.OutputCount; } }
		public override double[] Process(double[] data, int index) {
			var returns = returnIndicator.Process(data, index - movingAverageIndicator.InputCount + 1, data.Length - 1);
			return movingAverageIndicator.Process(returns, index - returnIndicator.InputCount+1);
		}
	}
}
