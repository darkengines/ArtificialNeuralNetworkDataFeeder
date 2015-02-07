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
			dataProvider.InputDataPickers.Add(new MovingAverageDataPicker() { Index = 1, Indicator = new MovingAverageIndicator(), Compiler = new CloseDataCompiler() });
			dataProvider.InputDataPickers.Add(new MovingAverageDataPicker() { Index = 2, Indicator = new MovingAverageIndicator(), Compiler = new CloseDataCompiler() });
			dataProvider.OutputDataPickers.Add(new MovingAverageDataPicker() { Index = 3, Indicator = new MovingAverageIndicator(), Compiler = new CloseDataCompiler() });
			var set = dataProvider.Build(data);

			var nn = new NeuralNet();
			nn.CreateStandardArray(new uint[] { (uint)dataProvider.InputDataPickers.Count(), 10, 16, (uint)dataProvider.OutputDataPickers.Count() });
			nn.SetLearningRate(0.7f);
			nn.SetActivationSteepnessHidden(1.0);
			nn.SetActivationSteepnessOutput(1.0);
			nn.SetActivationFunctionHidden(ActivationFunction.SigmoidSymmetric);
			nn.SetActivationFunctionOutput(ActivationFunction.SigmoidSymmetric);
			nn.SetTrainStopFunction(StopFunction.Bit);
			nn.SetBitFailLimit(0.01f);

			var trainingData = new TrainingData();
			trainingData.CreateTrainFromCallback((uint)data.Length, (uint)dataProvider.InputDataPickers.Count, (uint)dataProvider.OutputDataPickers.Count,
				(numData, numInput, numOutput, input, output) =>
				{
					var index = numData * (numInput + numOutput);
					Array.Copy(set, index, input, 0, numInput);
					Array.Copy(set, index+numInput, output, 0, numOutput);
				}
            );
			nn.TrainOnData(trainingData, 1000, 100, 100);
		}
	}
}
