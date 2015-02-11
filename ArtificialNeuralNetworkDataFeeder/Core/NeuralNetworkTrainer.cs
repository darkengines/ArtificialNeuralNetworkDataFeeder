using CsvHelper;
using FANN.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
	public class NeuralNetworkTrainer
	{
		public event NeuralNet.CallbackType Callback;
		public void Train(NeuralNetworkTrainerConfiguration configuration)
		{
			Datum[] data = null;
			using (var stream = new FileStream(configuration.TrainingDataFilePath, FileMode.Open, FileAccess.Read))
			{
				using (var reader = new StreamReader(stream))
				{
					var csv = new CsvReader(reader);
					csv.Configuration.RegisterClassMap<DatumClassMap>();
					data = csv.GetRecords<Datum>().ToArray();
				}
			}
			var count = 0;
			var trainingData = configuration.UninitializedDataProvider.BuildTrainingData(data, out count);

			var nn = new NeuralNet();
			var hiddenLayers = new List<uint>(configuration.HiddenLayers.Cast<uint>());
			hiddenLayers.Insert(0, (uint)configuration.UninitializedDataProvider.InputDataPickers.Count());
			hiddenLayers.Add((uint)configuration.UninitializedDataProvider.OutputDataPickers.Count());
			nn.CreateStandardArray(hiddenLayers.ToArray());
			nn.SetLearningRate(configuration.LearingRate);
			nn.SetActivationSteepnessHidden(1.0);
			nn.SetActivationSteepnessOutput(1.0);
			nn.SetActivationFunctionHidden(ActivationFunction.SigmoidSymmetric);
			nn.SetActivationFunctionOutput(ActivationFunction.SigmoidSymmetric);
			nn.SetTrainStopFunction(StopFunction.MSE);

			var nnTrainingData = new TrainingData();
			nnTrainingData.CreateTrainFromCallback((uint)count, (uint)configuration.UninitializedDataProvider.InputDataPickers.Count, (uint)configuration.UninitializedDataProvider.OutputDataPickers.Count,
				(numData, numInput, numOutput, input, output) =>
				{
					var index = numData * (numInput + numOutput);
					Array.Copy(trainingData, index, input, 0, numInput);
					Array.Copy(trainingData, index + numInput, output, 0, numOutput);
				}
			);
			nn.Callback += Nn_Callback; ;
			nn.TrainOnData(nnTrainingData, 1000000000, 10, 0.0000000001f);
		}

		private int Nn_Callback(NeuralNet net, TrainingData train, uint maxEpochs, uint epochsBetweenReports, float desiredError, uint epochs)
		{
			return OnCallback(net, train, maxEpochs, epochsBetweenReports, desiredError, epochs);
		}
		public virtual int OnCallback(NeuralNet net, TrainingData train, uint maxEpochs, uint epochsBetweenReports, float desiredError, uint epochs)
		{
			if (Callback != null) return Callback(net, train, maxEpochs, epochsBetweenReports, desiredError, epochs);
			return 0;
		}
	}
}
