using ArtificialNeuralNetworkDataFeeder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.Distributors {
	public class FibonacciDistributor : IDistributor {
		public int GetIndex(int n) {
			return Fibo(n);
		}
		private int Fibo(int n) {
			if (n == 0) return 0;
			if (n == 1) return 1;
			return Fibo(n-1) + Fibo(n-2);
		}
	}
}
