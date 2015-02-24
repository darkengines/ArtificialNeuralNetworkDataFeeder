using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtificialNeuralNetworkDataFeeder.Core {
    public interface IDataCompiler {
        double Compile (Datum datum);
    }
    public abstract class DataCompiler: IDataCompiler {
		public virtual double[] Compile(Datum[] data, int start, int count)
		{
			var dataToCompile = new Datum[count];
			Array.Copy(data, start, dataToCompile, 0, count);
			return Array.ConvertAll(dataToCompile, datum => Compile(datum));
		}
        public abstract double Compile (Datum datum);
    }
}
