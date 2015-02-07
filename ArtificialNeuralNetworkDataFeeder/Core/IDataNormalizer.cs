using System;

namespace ArtificialNeuralNetworkDataFeeder.Core {
    public interface IDataNormalizer {
        object Normalize (object datum);
        void Initialize (object[] data);
    }
    public abstract class DataNormalizer<TIn, TOut> : IDataNormalizer {
        public abstract TOut Normalize (TIn datum);
        public abstract void Initialize (double[] data);
        object IDataNormalizer.Normalize (object datum) { return Normalize((TIn)datum); }
        void IDataNormalizer.Initialize (object[] data) { Initialize(Array.ConvertAll<object, double>(data, x => (double)x)); }
    }
}