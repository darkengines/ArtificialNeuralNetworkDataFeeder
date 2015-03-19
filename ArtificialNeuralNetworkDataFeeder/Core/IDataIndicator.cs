using System;

namespace ArtificialNeuralNetworkDataFeeder.Core {
	public interface IDataIndicator {
		double Process(double[] data, int index);
		double[] Process(double[] data, int index, int count);
		int InputCount { get; }
	}
}