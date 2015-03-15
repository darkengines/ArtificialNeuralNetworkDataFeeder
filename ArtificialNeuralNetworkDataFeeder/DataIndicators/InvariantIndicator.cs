using ArtificialNeuralNetworkDataFeeder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.DataIndicators
{
	public class InvariantIndicator : DataIndicator
	{
		public override int InputCount
		{
			get
			{
				return 1;
			}
		}

		public override double Process(double[] data, int index)
		{
			return data[index];
		}
	}
}
