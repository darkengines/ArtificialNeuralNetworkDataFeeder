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
			dataProvider.InputDataPickers.Add(new MovingAverageDataPicker() { Index = 0, Indicator = new MovingAverageIndicator() });
			var set = dataProvider.Build(data);
		}
	}
}
