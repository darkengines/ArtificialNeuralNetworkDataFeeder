using ArtificialNeuralNetworkDataFeeder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.DataCompilers
{
	public class VolumeDataCompiler : DataCompiler
	{
		public override double Compile(Datum datum)
		{
			return datum.Volume;
		}
	}
}
