using System;

namespace ArtificialNeuralNetworkDataFeeder.Core {
	public interface IDataIndicator {
		double Process(double[] data, int index);
		int IndexMinimum { get; }
	}
	public abstract class DataIndicator : IDataIndicator {
		public abstract double Process(double[] data, int index);
		public abstract int IndexMinimum { get; }
	}

}