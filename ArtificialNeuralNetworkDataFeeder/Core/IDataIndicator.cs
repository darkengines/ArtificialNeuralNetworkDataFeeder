using System;

namespace ArtificialNeuralNetworkDataFeeder.Core {
	public interface IDataIndicator {
		object Process(object[] data, int index);
		int IndexMinimum { get; }
	}
	public abstract class DataIndicator<TIn, TOut> : IDataIndicator {
		public abstract TOut Process(TIn[] data, int index);
		public abstract int IndexMinimum { get; }
		object IDataIndicator.Process(object[] data, int index)
		{
			return Process(Array.ConvertAll(data, datum => (TIn)datum), index);
		}
	}

}