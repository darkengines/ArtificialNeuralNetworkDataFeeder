using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.Core
{
	public interface IFinilizer
	{
		double Finilize(Datum[] inputs);
	}
	public abstract class Finilizer : IFinilizer
	{
		public abstract double Finilize();
	}
}
