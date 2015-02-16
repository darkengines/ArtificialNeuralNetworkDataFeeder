using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
    public class Datum
    {
        public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public long Volume { get; set; }

		public override string ToString()
		{
			return string.Format("{0} {1} {2} {3} {4} {5}", Date, Open, High, Low, Close, Volume);
		}
	}
}
