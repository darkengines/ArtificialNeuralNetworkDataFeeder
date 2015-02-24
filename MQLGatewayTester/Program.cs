using MQLGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MQLGatewayTester
{
	class Program
	{
		static void Main(string[] args)
		{
			Gateway.Initialize("J:\\ArtificialNeuralNetworkDataFeeder\\ArtificialNeuralNetworkDataFeeder.Console\\bin\\x64\\Debug\\config.js.bin");
			var ratesCount = Gateway.GetDataCount();
			var rates = new MqlRates[ratesCount];
			int i = 0;
			while (i < ratesCount) rates[i++] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			var test = Gateway.Run(rates);
		}
	}
}
