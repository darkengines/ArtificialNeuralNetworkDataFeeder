namespace ArtificialNeuralNetworkDataFeeder.Core {
	public interface IDataPicker {
		int Index { get; }
		IDataIndicator Indicator { get; }
		IDataNormalizer Normalizer { get; }
		DataCompiler Compiler { get; }
	}
	public class DataPicker : IDataPicker {
		public int Index { get; set; }
		public IDataIndicator Indicator { get; set; }
		public IDataNormalizer Normalizer { get; set; }
        public DataCompiler Compiler { get; set; }
	}
}