using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
    public class DataProvider
    {
        public ICollection<IDataPicker> InputDataPickers { get; private set; }
        public ICollection<IDataPicker> OutputDataPickers { get; private set; }
        public IDataNormalizer DataNormalizer { get; set; }
		public DataProvider() {
			InputDataPickers = new Collection<IDataPicker>();
			OutputDataPickers = new Collection<IDataPicker>();
		}
		public double[] Build(Datum[] data) {
			var dataLength = data.Length;
			var inputLength = InputDataPickers.Count;
			var outputLength = OutputDataPickers.Count;
			var result = new double[dataLength * (inputLength+outputLength)];
			var i = 0;
			var dataPickers = InputDataPickers.Concat(OutputDataPickers);
			while (i < dataLength-inputLength-outputLength) {
				var j = i * inputLength;
				foreach (var dataPicker in dataPickers) {
                    var compiledData = Array.ConvertAll(data, datum => dataPicker.Compiler.Compile(datum));
                    result[j] = (double)dataPicker.Indicator.DataProcessor.Process(compiledData, i + dataPicker.Index);
					j++;
	            }
				i++;
			}
			return result;
		}
    }
}
