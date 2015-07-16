using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArtificialNeuralNetworkDataFeeder.Core;
using CsvHelper;
using ArtificialNeuralNetworkDataFeeder.DataCompilers;
using FANN.Net;
using ArtificialNeuralNetworkDataFeeder.DataNormalizers;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ArtificialNeuralNetworkDataFeeder.Console {
	class Program {
		public delegate void Train(TrainParameter parameter);
		public static Train Callback = TrainRoutine;
        public static void TrainRoutine(TrainParameter parameter) {
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			var path = parameter.TrainData;
			Datum[] data = null;
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
				using (var reader = new StreamReader(stream)) {
					var csv = new CsvReader(reader);
					csv.Configuration.RegisterClassMap<DatumClassMap>();
					data = csv.GetRecords<Datum>().ToArray();
				}
			}
			var savePath = string.Format("{0}.bin", parameter.Config);
			var dataProvider = DataProvider.Load(parameter.Config);
			dataProvider.Callback = (net, train, maxEpochs, epochsBetweenReports, desiredError, epochs) => {
				System.Console.Out.WriteLine(string.Format("[{0:00000000}/{1:00000000}] MSE={2:0.000000000000} Goal={3:0.############}", epochs, maxEpochs, net.GetMSE(), desiredError));
				return 0;
			};
			dataProvider.BuildNeuralNetwork(data);
			DataProvider.Save(dataProvider, savePath);
			System.Console.Out.WriteLine("Done !");
		}
        static void Main(string[] args) {
			
            
			System.Console.In.ReadLine();

			var exit = false;
			while (!exit) {
				var cmd = System.Console.In.ReadLine();
				var @params = cmd.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				switch (@params[0]) {
					case ("train"):
					{
						var result = Callback.BeginInvoke(new TrainParameter() { TrainData = args[1], Config= args[0], OuputName = args[2] }, (result) => {

						}, null);
                        break;
					}
					default:
					{
						break;
					}
				}
			}
		}

		public class TrainingInterface {
			public DataProvider DataProvider { get; private set; }
			public TrainParameter Parameter { get; private set; }
            public TrainingInterface(DataProvider dataProvider, TrainParameter parameter) {
				DataProvider = dataProvider;
				Parameter = parameter;
			}
			public event EventHandler<ProgressEventArgs> Progress;
			public virtual void OnProgress(ProgressEventArgs args) {
				if (Progress != null) Progress(this, args);
			}
		}
		
	}
}
