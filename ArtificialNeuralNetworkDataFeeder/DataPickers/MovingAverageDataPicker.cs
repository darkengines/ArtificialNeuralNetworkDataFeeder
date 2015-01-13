using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtificialNeuralNetworkDataFeeder.Core;

namespace ArtificialNeuralNetworkDataFeeder.DataPickers {
	public class MovingAverageDataPicker : IDataPicker {
		public int Index { get; set; }
		public IDataIndicator Indicator { get; set; }

		public IDataNormalizer Normalizer {
			get {
				throw new NotImplementedException();
			}
		}
        public IDataCompiler Compiler { get; set; }
    }
}
