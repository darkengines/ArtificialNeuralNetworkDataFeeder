using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtificialNeuralNetworkDataFeeder.Core;
using CsvHelper;
using CsvHelper.Configuration;

namespace ArtificialNeuralNetworkDataFeeder.Console {
	public class DatumClassMap : CsvClassMap<Datum> {
		public DatumClassMap() {
			Map(datum => datum.Date).Index(0).ConvertUsing<DateTime>(row => {
				return DateTime.Parse(string.Format("{0} {1}", row.GetField(0), row.GetField(1)));
			});
			Map(datum => datum.Open).Index(2);
			Map(datum => datum.High).Index(3);
			Map(datum => datum.Low).Index(4);
			Map(datum => datum.Close).Index(5);
			Map(datum => datum.Volume).Index(6);
		}
	}
}
