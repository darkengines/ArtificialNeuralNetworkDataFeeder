using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
	public class TrainData
	{
		public double[][] Inputs { get; private set; }
		public double[][] Outputs { get; private set; }
		public TrainData(int dataLength, int inputLength, int outputLength)
		{
			Inputs = new double[dataLength][];
			Outputs = new double[dataLength][];
			int i = dataLength;
			while (i-- > 0)
			{
				Inputs[i] = new double[inputLength];
				Outputs[i] = new double[inputLength];
			}
		}
	}
}
