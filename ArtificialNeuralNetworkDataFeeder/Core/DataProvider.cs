using FANN.Net;
using Newtonsoft.Json;
using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
    public class DataProvider
    {
		public NeuralNet.CallbackType Callback = null;
		public const string NeuralNetConfigurationFileExtension = "nn";
		public NeuralNet NeuralNetwork { get; protected set; }
		public NeuralNetworkConfiguration NeuralNetworkConfiguration { get; set; }
        public Collection<DataPicker> InputDataPickers { get; private set; }
        public Collection<DataPicker> OutputDataPickers { get; private set; }
		public DataProvider() {
			InputDataPickers = new Collection<DataPicker>();
			OutputDataPickers = new Collection<DataPicker>();
		}

		protected int OnCallback(NeuralNet net, TrainingData train, uint maxEpochs, uint epochsBetweenReports, float desiredError, uint epochs)
		{
			if (Callback != null) return Callback(net, train, maxEpochs, epochsBetweenReports, desiredError, epochs);
			return 0;
		}

		public static DataProvider Load(string path)
		{
			var neuralNetPath = Path.ChangeExtension(path, NeuralNetConfigurationFileExtension);
			var dataProvider = JsonConvert.DeserializeObject<DataProvider>(File.ReadAllText(path), new JsonSerializerSettings() {
				TypeNameHandling = TypeNameHandling.Auto
			});
			dataProvider.NeuralNetwork = new NeuralNet();
			dataProvider.NeuralNetwork.CreateFromFile(neuralNetPath);
			return dataProvider;
		}

		public static DataProvider Save(DataProvider dataProvider, string path)
		{
			var neuralNetPath = Path.ChangeExtension(path, NeuralNetConfigurationFileExtension);
			File.WriteAllText(path, JsonConvert.SerializeObject(dataProvider, Formatting.Indented, new JsonSerializerSettings() {
				TypeNameHandling = TypeNameHandling.Auto
			}));
			dataProvider.NeuralNetwork.Save(neuralNetPath);
			return dataProvider;
		}

		protected double[] BuildTrainingData(Datum[] data, out uint dataCount) {
			var dataPickers = InputDataPickers.Concat(OutputDataPickers);
			var startIndex = dataPickers.Select(dp => dp.Indicator.IndexMinimum - dp.Index).Max();
			var endIndex = dataPickers.Select(dp => dp.Index).Max();
			dataCount = (uint)(data.Length - endIndex - startIndex);
			var sets = new Dictionary<IDataPicker, double[]>();
			foreach (var dataPicker in dataPickers)
			{
				var set = new object[dataCount];
				var index = dataPicker.Index;
				var setIndex = 0;
				var count = dataPicker.Indicator.IndexMinimum + 1;
				while (index < dataCount + dataPicker.Index)
				{
					var compiledData = new object[count];
					Array.Copy(data, index, compiledData, 0, count);
					compiledData = Array.ConvertAll<object, object>(compiledData, x => dataPicker.Compiler.Compile((Datum)x));
					set[setIndex] = (double)dataPicker.Indicator.Process(compiledData, count - 1);
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
			while (i < total)
			{
				foreach (var set in sets.Values)
				{
					result[i] = set[j];
					i++;
				}
				j++;
			}
			return result;
		}
		public void BuildNeuralNetwork(Datum[] rawTrainingData)
		{
			uint dataCount = 0;
			var data = BuildTrainingData(rawTrainingData, out dataCount);
			NeuralNetwork = new NeuralNet();
			var inputCount = (uint)InputDataPickers.Count();
			var outputCount = (uint)OutputDataPickers.Count();
			var layers = NeuralNetworkConfiguration.HiddenLayers;
			layers.Insert(0, inputCount);
			layers.Add(outputCount);

			NeuralNetwork.CreateStandardArray(layers.ToArray());
			NeuralNetwork.SetLearningRate(NeuralNetworkConfiguration.LearingRate);
			NeuralNetwork.SetActivationSteepnessHidden(1.0);
			NeuralNetwork.SetActivationSteepnessOutput(1.0);
			NeuralNetwork.SetActivationFunctionHidden(ActivationFunction.SigmoidSymmetric);
			NeuralNetwork.SetActivationFunctionOutput(ActivationFunction.SigmoidSymmetric);
			NeuralNetwork.SetTrainStopFunction(StopFunction.MSE);

			var trainingData = new TrainingData();
			trainingData.CreateTrainFromCallback(dataCount, inputCount, outputCount,
				(numData, numInput, numOutput, input, output) =>
				{
					var index = numData * (numInput + numOutput);
					Array.Copy(data, index, input, 0, numInput);
					Array.Copy(data, index + numInput, output, 0, numOutput);
				}
			);
			NeuralNetwork.Callback += NeuralNetwork_Callback;
			NeuralNetwork.TrainOnData(trainingData, NeuralNetworkConfiguration.MaxEpochs, NeuralNetworkConfiguration.EpochsBetweenReports, NeuralNetworkConfiguration.DesiredMSE);
		}

		private int NeuralNetwork_Callback(NeuralNet net, TrainingData train, uint maxEpochs, uint epochsBetweenReports, float desiredError, uint epochs)
		{
			return OnCallback(net, train, maxEpochs, epochsBetweenReports, desiredError, epochs);
		}

		[DllExport("run", CallingConvention = CallingConvention.Cdecl)]
		public double[] Run(double[] input)
		{
			foreach (var inputDataPicker in InputDataPickers)
			{
				inputDataPicker.Normalizer.Normalize(input);
			}			
			return NeuralNetwork.Run(input);
		}
	}
}
