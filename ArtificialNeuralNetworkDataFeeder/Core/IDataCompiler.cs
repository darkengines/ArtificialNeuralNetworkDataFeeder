using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtificialNeuralNetworkDataFeeder.Core {
    public interface IDataCompiler {
        double Compile (Datum datum);
    }
    public abstract class DataCompiler: IDataCompiler {
        public abstract double Compile (Datum datum);
    }
}
