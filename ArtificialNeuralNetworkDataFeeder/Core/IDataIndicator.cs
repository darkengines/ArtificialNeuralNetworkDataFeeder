using System;
using System.Linq;

namespace ArtificialNeuralNetworkDataFeeder.Core {
	public interface IDataIndicator {
		double[] Process(double[] data, int index);
		double[] Process(double[] data, int index, int count);
        int InputCount { get; }
		int OutputCount { get; }
	}
	public abstract class DataIndicator : IDataIndicator {
		public abstract int InputCount { get; }
		public abstract int OutputCount { get; }
		public abstract double[] Process(double[] data, int index);
		public virtual double[] Process(double[] data, int index, int count) {
			var result = new double[OutputCount * count];
			while (count-- > 0) Array.Copy(Process(data, index + count), 0, result, count * OutputCount, OutputCount);
            return result;
		}
	}
}