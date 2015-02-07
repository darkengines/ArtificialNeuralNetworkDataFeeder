using System;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
    public interface IDataProcessor
    {
        object Process(object[] data, int index);
        int IndexMinimum { get; }
    }
	public abstract class DataProcessor<TIn, TOut> : IDataProcessor {
		public abstract TOut Process(TIn[] data, int index);
        public abstract int IndexMinimum { get; }
		object IDataProcessor.Process(object[] data, int index) {
			return Process(Array.ConvertAll(data, datum => (TIn)datum), index);
		}
	}
}