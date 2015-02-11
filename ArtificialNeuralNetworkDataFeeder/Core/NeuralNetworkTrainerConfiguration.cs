using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
	public class NeuralNetworkTrainerConfiguration
	{
		public DataProvider UninitializedDataProvider { get; set; }
		public string TrainingDataFilePath { get; set; }
		public Collection<int> HiddenLayers { get; set; }
		public float LearingRate { get; set; }
		public int MaxEpochs { get; set; }
		public int EpochsBetweenReports { get; set; }
		public float DesiredMSE { get; set; }.
		public NeuralNetworkTrainerConfiguration()
		{
			LearingRate = 0.1f;
			MaxEpochs = 0;
        }
		public static NeuralNetworkTrainerConfiguration Load(string filePath)
		{
			var serializationSettings = new JsonSerializerSettings() {
				TypeNameHandling = TypeNameHandling.Auto
			};

			return JsonConvert.DeserializeObject<NeuralNetworkTrainerConfiguration>(File.ReadAllText(filePath), serializationSettings);
		}
	}
}