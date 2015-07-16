using System;

namespace ArtificialNeuralNetworkDataFeeder.Console {
	public class TrainParameter {
		public string Config { get; internal set; }
		public string OuputName { get; internal set; }
		public string TrainData { get; internal set; }

		public static implicit operator TrainParameter(TrainParameter v) {
			throw new NotImplementedException();
		}
	}
}