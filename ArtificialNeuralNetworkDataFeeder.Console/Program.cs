using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArtificialNeuralNetworkDataFeeder.Core;
using ArtificialNeuralNetworkDataFeeder.DataIndicator;
using ArtificialNeuralNetworkDataFeeder.DataPickers;
using CsvHelper;
using ArtificialNeuralNetworkDataFeeder.DataCompilers;
using FANN.Net;

namespace ArtificialNeuralNetworkDataFeeder.Console {
	class Program {
		static void Main(string[] args) {
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			var path = args[0];
			Datum[] data = null;
			using(var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
				using (var reader = new StreamReader(stream)) {
					var csv = new CsvReader(reader);
					csv.Configuration.RegisterClassMap<DatumClassMap>();
					data = csv.GetRecords<Datum>().ToArray();
				}
			}
			var dataProvider = new DataProvider();
            dataProvider.InputDataPickers.Add(new MovingAverageDataPicker() { Index = 0, Indicator = new MovingAverageIndicator(), Compiler=new CloseDataCompiler() });
			var set = dataProvider.Build(data);

			var nn = new NeuralNet() {

			};
			nn.CreateStandardArray(new uint[] { (uint)dataProvider.InputDataPickers.Count(), 10, 16, (uint)dataProvider.OutputDataPickers.Count() });
			nn.SetLearningRate(0.7f);
			
        }
	}
}
