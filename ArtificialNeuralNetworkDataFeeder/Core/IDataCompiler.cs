using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArtificialNeuralNetworkDataFeeder.Core {
    public interface IDataCompiler {
        object Compile (Datum datum);
    }
    public abstract class DataCompiler<TOut>: IDataCompiler {
        public abstract TOut Compile (Datum datum);
        object IDataCompiler.Compile (Datum datum) { return Compile(datum); }
    }
}
