{  
	"NeuralNetworkConfiguration":{  
		"HiddenLayers":[  
		   70,
		   40,
		   30,
		   10
		],
		"LearingRate": 0.01,
		"MaxEpochs": 1000,
		"EpochsBetweenReports": 1,
		"DesiredMSE": 0.00001
	},
   "DataPickers":[  
      {  
      	"Index":0,
      	"Indicator":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.MovingAverageIndicator, ArtificialNeuralNetworkDataFeeder",
      		"Period":1
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
      		"MinimumIn":1.1,
      		"MaximumIn":1.8
      	},
      	"Compiler":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
      	}
      },
      {  
      	"Index":-1,
      	"Indicator":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.MovingAverageIndicator, ArtificialNeuralNetworkDataFeeder",
      		"Period":1
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
      		"MinimumIn":1.1,
      		"MaximumIn":1.8
      	},
      	"Compiler":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
      	}
      },
      {  
      	"Index":-2,
      	"Indicator":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.MovingAverageIndicator, ArtificialNeuralNetworkDataFeeder",
      		"Period":1
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
      		"MinimumIn":1.1,
      		"MaximumIn":1.8
      	},
      	"Compiler":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
      	}
      },
      {  
      	"Index":0,
      	"Indicator":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.MovingAverageIndicator, ArtificialNeuralNetworkDataFeeder",
      		"Period":13
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
      		"MinimumIn":1.1,
      		"MaximumIn":1.8
      	},
      	"Compiler":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
      	}
      },
	  {  
	  	"Index":0,
	  	"Indicator":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.MovingAverageIndicator, ArtificialNeuralNetworkDataFeeder",
	  		"Period":21
	  	},
	  	"Normalizer":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
	  		"MinimumOut":-0.9,
	  		"MaximumOut":0.9,
	  		"MinimumIn":1.1,
	  		"MaximumIn":1.8
	  	},
	  	"Compiler":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
	  	}
	  },
	  {  
	  	"Index":0,
	  	"Indicator":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.MovingAverageIndicator, ArtificialNeuralNetworkDataFeeder",
	  		"Period":34
	  	},
	  	"Normalizer":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
	  		"MinimumOut":-0.9,
	  		"MaximumOut":0.9,
	  		"MinimumIn":1.1,
	  		"MaximumIn":1.8
	  	},
	  	"Compiler":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
	  	}
	  },
	  {  
	  	"Index":0,
	  	"Indicator":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.MovingAverageIndicator, ArtificialNeuralNetworkDataFeeder",
	  		"Period":55
	  	},
	  	"Normalizer":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
	  		"MinimumOut":-0.9,
	  		"MaximumOut":0.9,
	  		"MinimumIn":1.1,
	  		"MaximumIn":1.8
	  	},
	  	"Compiler":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
	  	}
	  },
      {  
      	"Index":1,
      	"Indicator":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.MovingAverageIndicator, ArtificialNeuralNetworkDataFeeder",
      		"Period":1
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
			"MinimumIn":1.1,
      		"MaximumIn":1.8
      	},
      	"Compiler":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
      	}
      }
   ]
}