using System;

namespace ArtificialNeuralNetworkDataFeeder.Core {
	public interface IDataIndicator {
		IDataProcessor DataProcessor { get; }
	}
	public abstract class DataIndicator<TIn, TOut> : IDataIndicator {
		public abstract DataProcessor<TIn, TOut> DataProcessor { get; }
		IDataProcessor IDataIndicator.DataProcessor { get { return DataProcessor; } }
	}

}