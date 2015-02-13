using System.Collections.ObjectModel;
using System.IO;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
	public class NeuralNetworkConfiguration
	{
		public Collection<uint> HiddenLayers { get; set; }
		public float LearingRate { get; set; }
		public uint MaxEpochs { get; set; }
		public uint EpochsBetweenReports { get; set; }
		public float DesiredMSE { get; set; }
		public NeuralNetworkConfiguration()
		{
			LearingRate = 0.1f;
			MaxEpochs = 0;
        }
	}
}