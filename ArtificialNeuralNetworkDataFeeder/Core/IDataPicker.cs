namespace ArtificialNeuralNetworkDataFeeder.Core {
	public interface IDataPicker {
		int Index { get; }
		int Count { get; }
		bool Compare { get; }
		DataIndicator Indicator { get; }
		IDataNormalizer Normalizer { get; }
		DataCompiler Compiler { get; }
	}
	public class DataPicker : IDataPicker {
		public bool Compare { get; set; }
		public int Count { get; }
		public int Index { get; set; }
		public DataIndicator Indicator { get; set; }
		public IDataNormalizer Normalizer { get; set; }
        public DataCompiler Compiler { get; set; }
	}
}