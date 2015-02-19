using Encog.Neural.Networks;
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
		[JsonIgnore]
		public NeuralNet.CallbackType Callback = null;
		[JsonIgnore]
		public const string NeuralNetConfigurationFileExtension = "nn";
		[JsonIgnore]
		public NeuralNet NeuralNetwork { get; protected set; }
		public NeuralNetworkConfiguration NeuralNetworkConfiguration { get; set; }
		public Collection<DataPicker> InputDataPickers { get; private set; }
		public Collection<DataPicker> OutputDataPickers { get; private set; }
		public DataProvider()
		{
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

		public int MinimumIndex
		{
			get
			{
				var dataPickers = InputDataPickers.Concat(OutputDataPickers);
				return dataPickers.Select(dp => dp.Indicator.IndexMinimum - dp.Index).Max();
			}
		}

		protected double[] BuildTrainingData(Datum[] data, out uint dataCount)
		{
			var dataPickers = InputDataPickers.OrderBy(inputDataPicker => inputDataPicker.Index).Concat(OutputDataPickers.OrderBy(outputDataPicker => outputDataPicker.Index)).ToArray();
			dataCount = (uint)(data.Length - MinimumIndex - dataPickers.Length);
			var processedCompiled = new double[totalCount];
			var normalizedProcessedCompiled = new double[totalCount];
			int i = 0;
			while (i < dataCount)
			{
				var dataPicker = dataPickers[i];
				var compiledInputsCount = dataPicker.Indicator.IndexMinimum + 1;
				var compiledInputs = new double[compiledInputsCount];
				int j = 0;
				while (j < compiledInputsCount)
				{
					compiledInputs[j] = dataPicker.Compiler.Compile(data[dataPicker.Index + j]);
					j++;
				}
				processedCompiledInputs[i] = dataPicker.Indicator.Process(compiledInputs, dataPicker.Indicator.IndexMinimum);
				normalizedProcessedCompiledInputs[i] = dataPicker.Normalizer.Normalize(processedCompiledInputs[i]);
				i++;
			}
		}

		protected TrainingData BuildTrainingData(double[] data, uint dataCount)
		{
			var inputCount = (uint)InputDataPickers.Count();
			var outputCount = (uint)OutputDataPickers.Count();
			var trainingData = new TrainingData();
			//trainingData.CreateTrainFromCallback(dataCount, inputCount, outputCount,
			//	(numData, numInput, numOutput, input, output) =>
			//	{
			//		var index = numData * (numInput + numOutput);
			//		Array.Copy(data, index, input, 0, numInput);
			//		Array.Copy(data, index + numInput, output, 0, numOutput);
			//	}
			//);
			var temp = Path.GetTempFileName();
			using (var stream = new FileStream(temp, FileMode.Create, FileAccess.Write))
			{
				using (var writer = new StreamWriter(stream))
				{
					writer.WriteLine(string.Format("{0} {1} {2}", dataCount, inputCount, outputCount));
					int i = 0;
					int unit = (int)(inputCount + outputCount);
                    while (i < dataCount)
					{
						var index = i * (unit);
						var input = new double[inputCount];
						var output = new double[outputCount];
						Array.Copy(data, index, input, 0, inputCount);
						Array.Copy(data, (int)(index+inputCount), output, 0, outputCount);
						writer.WriteLine(string.Join(" ", input));
						writer.WriteLine(string.Join(" ", output));
						i++;
					}
				}
			}
			trainingData.ReadTrainFromFile(temp);
            return trainingData;
		}

		public void InitializeNeuralNetwork()
		{
			var inputCount = (uint)InputDataPickers.Count();
			var outputCount = (uint)OutputDataPickers.Count();
			NeuralNetwork = new NeuralNet();
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

			var test = new BasicNetwork();
		}

		public void TrainNeuralNetwork(double[] data, uint dataCount)
		{
			var trainingData = BuildTrainingData(data, dataCount);
			NeuralNetwork.Callback += NeuralNetwork_Callback;

			NeuralNetwork.TrainOnData(trainingData, NeuralNetworkConfiguration.MaxEpochs, NeuralNetworkConfiguration.EpochsBetweenReports, NeuralNetworkConfiguration.DesiredMSE);
		}

		public void BuildNeuralNetwork(Datum[] rawTrainingData)
		{
			uint dataCount = 0;
			var data = BuildTrainingData(rawTrainingData, out dataCount);
			InitializeNeuralNetwork();
			TrainNeuralNetwork(data, dataCount);
		}

		public object[] Run(Datum[] data)
		{
			var dataCount = data.Length;
			var inputCount = InputDataPickers.Count();
			var processedCompiledInputs = new double[inputCount];
			var normalizedProcessedCompiledInputs = new double[inputCount];
			var inputDataPickers = InputDataPickers.OrderBy(inputDataPicker => inputDataPicker.Index).ToArray();
			var sets = new Dictionary<IDataPicker, double>();
			int i = 0;
			while (i < inputCount)
			{
				var dataPicker = inputDataPickers[i];
				var compiledInputsCount = dataPicker.Indicator.IndexMinimum + 1;
                var compiledInputs = new double[compiledInputsCount];
				int j = 0;
				while (j < compiledInputsCount)
				{
					compiledInputs[j] = dataPicker.Compiler.Compile(data[dataPicker.Index+j]);
					j++;
				}
				processedCompiledInputs[i] = dataPicker.Indicator.Process(compiledInputs, dataPicker.Indicator.IndexMinimum);
				normalizedProcessedCompiledInputs[i] = dataPicker.Normalizer.Normalize(processedCompiledInputs[i]);
				i++;
			}
			var outputs = NeuralNetwork.Run(normalizedProcessedCompiledInputs);
			var outputsCount = outputs.Length;
			var outputDataPickers = OutputDataPickers.OrderBy(outputDataPicker => outputDataPicker.Index).ToArray();
			var denormalizedOutput = new double[outputsCount];
			i = 0;
			while (i < outputsCount)
			{
				var dataPicker = OutputDataPickers[i];
				denormalizedOutput[i] = dataPicker.Normalizer.Denormalize(outputs[i]);
			}
			return denormalizedOutput;
		}

		

		public double[] Run(double[] data)
		{
			return NeuralNetwork.Run(data);
		}

		private int NeuralNetwork_Callback(NeuralNet net, TrainingData train, uint maxEpochs, uint epochsBetweenReports, float desiredError, uint epochs)
		{
			return OnCallback(net, train, maxEpochs, epochsBetweenReports, desiredError, epochs);
		}
	}
}
