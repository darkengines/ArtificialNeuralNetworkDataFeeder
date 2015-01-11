﻿using System;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
    public interface IDataProcessor
    {
        object Process(object[] data, int index);
    }
	public abstract class DataProcessor<TIn, TOut> : IDataProcessor {
		public abstract TOut Process(TIn[] data, int index);
		object IDataProcessor.Process(object[] data, int index) {
			return Process(Array.ConvertAll(data, datum => (TIn)datum), index);
		}
	}
}