using ArtificialNeuralNetworkDataFeeder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetworkDataFeeder.DataCompilers {
	public class DayOfWeekDataCompiler : DataCompiler {
		public override double Compile(Datum datum) {
			return (double)datum.Date.DayOfWeek;
		}
	}
	public class DayOfMonthDataCompiler : DataCompiler {
		public override double Compile(Datum datum) {
			return (double)datum.Date.Day;
		}
	}
	public class HourDataCompiler : DataCompiler {
		public override double Compile(Datum datum) {
			return (double)datum.Date.Hour;
		}
	}
}
