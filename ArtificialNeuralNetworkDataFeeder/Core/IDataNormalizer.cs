using System;

namespace ArtificialNeuralNetworkDataFeeder.Core {
    public interface IDataNormalizer {
        double Normalize (double datum);
		double Denormalize(double datum);
        void Initialize (double[] data);
    }
	public abstract class DataNormalizer : IDataNormalizer
	{
		public abstract double Normalize(double datum);
		public abstract double Denormalize(double datum);
		public abstract void Initialize(double[] data);
	}
}