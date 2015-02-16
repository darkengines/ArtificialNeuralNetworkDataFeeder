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
using CsvHelper;
using ArtificialNeuralNetworkDataFeeder.DataCompilers;
using FANN.Net;
using ArtificialNeuralNetworkDataFeeder.DataNormalizers;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ArtificialNeuralNetworkDataFeeder.Console {
	class Program {
		static void Main(string[] args) {
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			var path = args[1];
			Datum[] data = null;
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				using (var reader = new StreamReader(stream))
				{
					var csv = new CsvReader(reader);
					csv.Configuration.RegisterClassMap<DatumClassMap>();
					data = csv.GetRecords<Datum>().ToArray();
				}
			}
			var savePath = string.Format("{0}.bin", args[0]);
			var dataProvider = DataProvider.Load(args[0]);
			dataProvider.Callback = (net, train, maxEpochs, epochsBetweenReports, desiredError, epochs) =>
			 {
				 System.Console.Out.WriteLine(string.Format("[{0:00000000}/{1:00000000}] MSE={2:0.000000000000} Goal={3:0.############}", epochs, maxEpochs, net.GetMSE(), desiredError));
				 return 0;
			 };
			dataProvider.BuildNeuralNetwork(data);
			DataProvider.Save(dataProvider, savePath);
			System.Console.Out.WriteLine("Done !");
			System.Console.In.ReadLine();
		}
	}
}
