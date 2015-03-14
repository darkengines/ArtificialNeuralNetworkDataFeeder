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
		public Collection<DataPicker> DataPickers { get; private set; }
		public DataProvider()
		{
			DataPickers = new Collection<DataPicker>();
		}

		protected int OnCallback(NeuralNet net, TrainingData train, uint maxEpochs, uint epochsBetweenReports, float desiredError, uint epochs)
		{
			if (Callback != null) return Callback(net, train, maxEpochs, epochsBetweenReports, desiredError, epochs);
			return 0;
		}

		public static DataProvider Load(string path)
		{
			var neuralNetPath = Path.ChangeExtension(path, NeuralNetConfigurationFileExtension);
			var dataProvider = JsonConvert.DeserializeObject<DataProvider>(File.ReadAllText(path), new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto
			});
			dataProvider.NeuralNetwork = new NeuralNet();
			dataProvider.NeuralNetwork.CreateFromFile(neuralNetPath);
			return dataProvider;
		}

		public static DataProvider Save(DataProvider dataProvider, string path)
		{
			var neuralNetPath = Path.ChangeExtension(path, NeuralNetConfigurationFileExtension);
			File.WriteAllText(path, JsonConvert.SerializeObject(dataProvider, Formatting.Indented, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto
			}));
			dataProvider.NeuralNetwork.Save(neuralNetPath);
			return dataProvider;
		}
		public DataPicker TailDataPicker
		{
			get
			{
				return DataPickers.OrderByDescending(dataPicker => dataPicker.Indicator.InputCount - dataPicker.Index)
				.FirstOrDefault();
			}
		}
		public DataPicker HeadDataPicker
		{
			get
			{
				return DataPickers.OrderByDescending(dataPicker => dataPicker.Index)
				.FirstOrDefault();
			}
		}
		public int BackDataCount
		{
			get
			{
				return DataPickers.Select(dp => dp.Indicator.InputCount - dp.Index).Max();
			}
		}
		public int FrontDataCount
		{
			get
			{
				return DataPickers.Select(dp => dp.Index).Max();
			}
		}


		protected double[] BuildTrainingData(Datum[] data, out uint dataCount)
		{
			var dataPickersCount = DataPickers.Count();
			dataCount = (uint)(data.Length - BackDataCount - FrontDataCount + 1);
			var totalCount = (uint)(dataCount * dataPickersCount);
			var processedCompiled = new double[totalCount];
			var normalizedProcessedCompiled = new double[totalCount];
			var tailDataPicker = TailDataPicker;

			int i = BackDataCount - 1 - tailDataPicker.Index;
			int k = 0;
			while (i < data.Length - FrontDataCount)
			{
				int j = 0;
				foreach (var dataPicker in DataPickers)
				{
					var backDataCount = dataPicker.Indicator.InputCount;
					var compiledData = dataPicker.Compiler.Compile(data, i - backDataCount + 1 + dataPicker.Index, backDataCount);
					var processedData = dataPicker.Indicator.Process(compiledData, compiledData.Length - 1);
					dataPicker.Normalizer.Update(processedData);
					processedCompiled[k * dataPickersCount + j] = processedData;
					j++;
				}
				k++;
				i++;
			}
			i = 0;
			while (i < totalCount)
			{
				var dataPicker = DataPickers[i % dataPickersCount];
				normalizedProcessedCompiled[i] = dataPicker.Normalizer.Normalize(processedCompiled[i]);
				i++;
			}
			return normalizedProcessedCompiled;
		}

		protected TrainingData BuildTrainingData(double[] subset, uint dataCount, int offset = 0, int? count = null)
		{
			if (count == null) count = subset.Length - offset;
			
			Array.Copy()
			var inputCount = (uint)DataPickers.Where(dataPicker => dataPicker.Index <= 0).Count();
			var outputCount = (uint)DataPickers.Where(dataPicker => dataPicker.Index > 0).Count();
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
						Array.Copy(subset, index, input, 0, inputCount);
						Array.Copy(subset, (int)(index + inputCount), output, 0, outputCount);
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
			var inputCount = (uint)DataPickers.Where(dataPicker => dataPicker.Index <= 0).Count();
			var outputCount = (uint)DataPickers.Where(dataPicker => dataPicker.Index > 0).Count();
			NeuralNetwork = new NeuralNet();
			var layers = new List<uint>(NeuralNetworkConfiguration.HiddenLayers);
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
			NeuralNetwork.TestData()
		}

		public void BuildNeuralNetwork(Datum[] rawTrainingData)
		{
			uint dataCount = 0;
			var data = BuildTrainingData(rawTrainingData, out dataCount);
			InitializeNeuralNetwork();
			TrainNeuralNetwork(data, dataCount);
		}

		public double Run(Datum[] data)
		{
			var dataPickers = DataPickers.Where(dataPicker => dataPicker.Index <= 0).ToArray();
			var dataPickersCount = dataPickers.Count();
			var dataCount = (uint)(data.Length - BackDataCount - FrontDataCount + 1);
			var totalCount = (uint)(dataCount * dataPickersCount);
			var processedCompiled = new double[totalCount];
			var normalizedProcessedCompiled = new double[totalCount];
			var tailDataPicker = TailDataPicker;

			int i = BackDataCount - 1 - tailDataPicker.Index;
			int k = 0;
			while (i < data.Length - FrontDataCount)
			{
				int j = 0;
				foreach (var dataPicker in dataPickers)
				{
					var backDataCount = dataPicker.Indicator.InputCount;
					var compiledData = dataPicker.Compiler.Compile(data, i - backDataCount + 1 + dataPicker.Index, backDataCount);
					var processedData = dataPicker.Indicator.Process(compiledData, compiledData.Length - 1);
					processedCompiled[k * dataPickersCount + j] = processedData;
					j++;
				}
				k++;
				i++;
			}
			i = 0;
			while (i < totalCount)
			{
				var dataPicker = dataPickers[i % dataPickersCount];
				normalizedProcessedCompiled[i] = dataPicker.Normalizer.Normalize(processedCompiled[i]);
				i++;
			}
			return Run(normalizedProcessedCompiled)[0];
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
