using System;

namespace ArtificialNeuralNetworkDataFeeder.Core {
    public interface IDataNormalizer {
        double Normalize (double datum);
		double Denormalize(double datum);
        void Initialize (double[] data);
		void Update(double value);
		void Update(double[] values);
	}
	public abstract class DataNormalizer : IDataNormalizer
	{
		public abstract double Normalize(double datum);
		public abstract double Denormalize(double datum);
		public abstract void Initialize(double[] data);
		public abstract void Update(double value);
		public virtual void Update(double[] values) {
			foreach (var value in values) Update(value);
		}
	}
}