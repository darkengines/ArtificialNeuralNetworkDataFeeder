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
			var rates = new MqlRates[12];
			rates[0] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[1] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[2] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[3] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[4] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[5] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[6] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[7] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[8] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[9] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[10] =new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			rates[11] = new MqlRates() { time = DateTime.Now.Second, open = 1.52351, high = 1.52456, low = 1.5233, close = 1.52418, real_volume = 100, spread = 12, tick_volume = 1149 };
			Gateway.Initialize("J:\\ArtificialNeuralNetworkDataFeeder\\ArtificialNeuralNetworkDataFeeder.Console\\bin\\x64\\Debug\\config.js.bin");
			var mini = Gateway.GetMinimumIndex();
			var test = Gateway.Run(rates);
		}
	}
}
