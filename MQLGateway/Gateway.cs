using ArtificialNeuralNetworkDataFeeder.Core;
using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace MQLGateway
{
	public static class Gateway
	{
		public static void Log(object message)
		{
			using (var stream = new FileStream(@"C:\out.log", FileMode.Append, FileAccess.Write))
			{
				using (var writer = new StreamWriter(stream))
				{
					writer.WriteLine(message);
				}
			}
		}
		public static DataProvider DataProvider { get; set; }
		[DllExport("Initialize", CallingConvention.StdCall)]
		public static void Initialize([MarshalAs(UnmanagedType.LPWStr)]string configurationFilePath)
		{
			DataProvider = DataProvider.Load(configurationFilePath);
		}
		[DllExport("GetDataCount", CallingConvention.StdCall)]
		public static int GetDataCount()
		{
			return DataProvider.TailDataPicker.Indicator.InputCount - DataProvider.TailDataPicker.Index;
		}
		[DllExport("Run", CallingConvention.StdCall)]
		public static double Run([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct, SizeConst = 10000)] MqlRates[] rates)
		{
			var length = DataProvider.TailDataPicker.Indicator.InputCount - DataProvider.TailDataPicker.Index;
			var data = new Datum[length];
			var i = 0;
			//Log(rates.Length);
			while (i < length)
			{
				var rate = rates[i];
				var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
				date = date.AddSeconds(rate.time);
				var datum = new Datum() {
					Date = date,
					Open = rate.open,
					High = rate.high,
					Low = rate.low,
					Close = rate.close,
					Volume = rate.tick_volume,
				};
				data[i] = datum;
				i++;
			}
			//Log(JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings() {
			//	TypeNameHandling = TypeNameHandling.Auto
			//}));
			var result = DataProvider.Run(data.Reverse().ToArray());
			//Log(string.Format("OUT = {0}", result));
			return result;
		}
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MqlRates
	{
		public long time;		   // Period start time
		public double open;		 // Open price
		public double high;		 // The highest price of the period
		public double low;			 // The lowest price of the period
		public double close;		 // Close price
		public long tick_volume;   // Tick volume
		public int spread;		  // Spread
		public long real_volume;   // Trade volume
	};
}
