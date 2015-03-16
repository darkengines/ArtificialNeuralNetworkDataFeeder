//+------------------------------------------------------------------+
//|                                                      Gateway.mq5 |
//|                        Copyright 2013, MetaQuotes Software Corp. |
//|                                              http://www.mql5.com |
//+------------------------------------------------------------------+

#include <Trade\Trade.mqh>
#include <Trade\PositionInfo.mqh>

#import "MQLGateway.dll"
	void Initialize(string configurationFilePath);
	int GetDataCount();
	double Run(MqlRates& rates[]);
#import

#property copyright "Copyright 2013, MetaQuotes Software Corp."
#property link      "http://www.mql5.com"
#property version   "1.00"
//--- input parameters
input string   ConfigurationFile = "J:\\ArtificialNeuralNetworkDataFeeder\\ArtificialNeuralNetworkDataFeeder.Console\\bin\\x64\\Debug\\config.js.bin";
CTrade m_Trade;
CPositionInfo m_Position;
int dataCount;
double lot_size = 2;//SymbolInfoDouble(_Symbol,SYMBOL_VOLUME_MIN);
//+------------------------------------------------------------------+
//| Expert initialization function                                   |
//+------------------------------------------------------------------+
int OnInit()
  {
//---
	Initialize("J:\\ArtificialNeuralNetworkDataFeeder\\ArtificialNeuralNetworkDataFeeder.Console\\bin\\x64\\Debug\\config.js.bin");
	dataCount = GetDataCount();
	Print("Out="+IntegerToString(dataCount));
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
	static datetime oldTime;
   	datetime newTime[1];
  	bool isNewBar = false;
	isNewBar = oldTime != newTime[0];
	MqlTick lastestPrice;
	SymbolInfoTick(_Symbol, lastestPrice);
	if (isNewBar) {
      MqlRates rates[];
      ArrayResize(rates, dataCount);
      ArraySetAsSeries(rates,true);
		CopyRates(_Symbol, PERIOD_CURRENT, 0, dataCount, rates);
		double out = Run(rates);
		Print("Out="+DoubleToString(out));
      
      MqlTradeRequest request;
      MqlTradeResult result;
      ZeroMemory(request);

	     bool buyOpened = false;
      bool sellOpened = false;
      
      if (PositionSelect(_Symbol)) {
         if (PositionGetInteger(POSITION_TYPE) == POSITION_TYPE_BUY) {
            buyOpened = true;
         } else if (PositionGetInteger(POSITION_TYPE) == POSITION_TYPE_SELL) {
            buyOpened = true;
         }
      }
            
      if (out > 0) {
		if(m_Position.Select(_Symbol)) {
			if(m_Position.PositionType()==POSITION_TYPE_SELL) m_Trade.PositionClose(_Symbol);
			if(m_Position.PositionType()==POSITION_TYPE_BUY) return;
		}
		m_Trade.Buy(lot_size,_Symbol, 0, 0, 0);
	}
	if (out < 0) {
		if(m_Position.Select(_Symbol)) {
			if(m_Position.PositionType()==POSITION_TYPE_BUY) m_Trade.PositionClose(_Symbol);
			if(m_Position.PositionType()==POSITION_TYPE_SELL) return;
		}
		m_Trade.Sell(lot_size,_Symbol, 0, 0, 0);
	}
      
   }
  }
//+------------------------------------------------------------------+
