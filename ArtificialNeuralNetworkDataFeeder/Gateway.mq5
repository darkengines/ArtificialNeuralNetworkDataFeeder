//+------------------------------------------------------------------+
//|                                                      Gateway.mq5 |
//|                        Copyright 2013, MetaQuotes Software Corp. |
//|                                              http://www.mql5.com |
//+------------------------------------------------------------------+

#import "MQLGateway.dll"
	void Initialize(string configurationFilePath);
	int GetMinimumIndex();
	double Run(MqlRates& rates[]);
#import

#property copyright "Copyright 2013, MetaQuotes Software Corp."
#property link      "http://www.mql5.com"
#property version   "1.00"
//--- input parameters
input string   ConfigurationFile = "J:\\ArtificialNeuralNetworkDataFeeder\\ArtificialNeuralNetworkDataFeeder.Console\\bin\\x64\\Debug\\config.js.bin";
int minimumIndex = 0;
//+------------------------------------------------------------------+
//| Expert initialization function                                   |
//+------------------------------------------------------------------+
int OnInit()
  {
//---
	Initialize("J:\\ArtificialNeuralNetworkDataFeeder\\ArtificialNeuralNetworkDataFeeder.Console\\bin\\x64\\Debug\\config.js.bin");
	minimumIndex = GetMinimumIndex();
//---
   return(INIT_SUCCEEDED);
  }
//+------------------------------------------------------------------+
//| Expert deinitialization function                                 |
//+------------------------------------------------------------------+
void OnDeinit(const int reason)
  {
//---
   
  }
//+------------------------------------------------------------------+
//| Expert tick function                                             |
//+------------------------------------------------------------------+
void OnTick()
  {
//---
	MqlRates rates[12];
	CopyRates(_Symbol, PERIOD_CURRENT, 0, minimumIndex+1, rates);
	double out = Run(rates);
	Print("Out="+DoubleToString(out));
  }
//+------------------------------------------------------------------+
