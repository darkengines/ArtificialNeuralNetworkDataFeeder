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
        public double[] Build (Datum[] data, out int dataCount) {
            var dataPickers = InputDataPickers.Concat(OutputDataPickers);
            var startIndex = dataPickers.Select(dp => dp.Indicator.DataProcessor.IndexMinimum - dp.Index).Max();
            var endIndex = dataPickers.Select(dp => dp.Index).Max();
            dataCount = data.Length - endIndex - startIndex;
            var sets = new Dictionary<IDataPicker, double[]>();
            foreach (var dataPicker in dataPickers) {
                var set = new object[dataCount];
                var index = dataPicker.Index;
                var setIndex = 0;
                var count = dataPicker.Indicator.DataProcessor.IndexMinimum + 1;
                while (index < dataCount + dataPicker.Index) {
                    var compiledData = new object[count];
                    Array.Copy(data, index, compiledData, 0, count);
                    compiledData = Array.ConvertAll<object, object>(compiledData, x => dataPicker.Compiler.Compile((Datum)x));
                    set[setIndex] = (double)dataPicker.Indicator.DataProcessor.Process(compiledData, count - 1);
                    index++;
                    setIndex++;
                }
                dataPicker.Normalizer.Initialize(set);
                sets[dataPicker] = Array.ConvertAll<object, double>(set, x => (double)dataPicker.Normalizer.Normalize(x));
            }
            var i = 0;
            var total = dataCount * dataPickers.Count();
            var result = new double[total];
            var j = 0;
            while (i < total) {
                foreach (var set in sets.Values) {
                    result[i] = set[j];
                    i++;
                }
                j++;
            }
            return result;
		}
    }
}
