using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtificialNeuralNetworkDataFeeder.Core;

namespace ArtificialNeuralNetworkDataFeeder.DataNormalizers {
	class RangeDataNormalizer : DataNormalizer<double, double> {
		public double MinimumIn { get; set; }
		public double MaximumIn { get; set; }
		public double MinimumOut { get; set; }
		public double MaximumOut { get; set; }
		public override double Normalize(double datum) {
			return (MaximumOut - MaximumIn) / (MaximumIn - MinimumIn) * (datum - MinimumIn) + MaximumOut;
        }
	}
}
