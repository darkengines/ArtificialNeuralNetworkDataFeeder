using System;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
    public interface IDataNormalizer
    {
        object Normalize(object datum);
    }
	public abstract class DataNormalizer<TIn, TOut> : IDataNormalizer {
		public abstract TOut Normalize(TIn datum);
		object IDataNormalizer.Normalize(object datum) { return Normalize((TIn)datum); }
	}
}