using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtificialNeuralNetworkDataFeeder.Core;

namespace ArtificialNeuralNetworkDataFeeder.DataNormalizers {
    public class RangeDataNormalizer : DataNormalizer {
        public double? MinimumIn { get; set; }
        public double? MaximumIn { get; set; }
        public double MinimumOut { get; set; }
        public double MaximumOut { get; set; }
        public override double Normalize (double datum) {
            var m =(double)MinimumIn;
            var r = (double)MaximumIn - m;
            var y = (datum - m) / r;
            return y*(MaximumOut - MinimumOut) + MinimumOut;
        }
        public override void Initialize (double[] data) {
            MinimumIn = data.Min();
            MaximumIn = data.Max();
            MinimumOut = -1.0;
            MaximumOut = 1.0;
        }

		public override double Denormalize(double datum)
		{
			var m = (double)MinimumIn;
			var r = (double)MaximumIn - m;
			var y = (datum - MinimumOut) / (MaximumOut - MinimumOut);
			return y * r + m;
		}
		public override void Update(double value)
		{
			if (value > MaximumIn || MaximumIn == null) MaximumIn = value;
			if (value < MinimumIn || MinimumIn == null) MinimumIn = value;
		}
	}
}
