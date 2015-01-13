﻿using System;

namespace ArtificialNeuralNetworkDataFeeder.Core {
	public interface IDataPicker {
		int Index { get; }
		IDataIndicator Indicator { get; }
		IDataNormalizer Normalizer { get; }
        IDataCompiler Compiler { get; }
	}
	public abstract class DataPicker<TIndicator> : IDataPicker where TIndicator : IDataIndicator {
		int Index { get; set; }
		public IDataIndicator Indicator { get; set; }
		public IDataNormalizer Normalizer { get; set; }
        public IDataCompiler Compiler { get; set; }
		IDataIndicator IDataPicker.Indicator { get { return Indicator; } }
		int IDataPicker.Index { get { return Index; } }
		IDataNormalizer IDataPicker.Normalizer { get { return Normalizer; } }
        IDataCompiler IDataPicker.Compiler { get { return Compiler; } }
	}
}