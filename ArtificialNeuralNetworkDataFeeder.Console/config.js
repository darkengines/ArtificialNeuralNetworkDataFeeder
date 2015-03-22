{  
	"NeuralNetworkConfiguration":{  
		"HiddenLayers":[  
		   150,100,70,30,16,8
		],
		"LearingRate": 0.01,
		"MaxEpochs": 500,
		"EpochsBetweenReports": 10,
		"DesiredMSE": 0.00001
	},
   "DataPickers":[
      {  
      	"Index":0,
      	"Compare":1,
      	"Indicator":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
      		"MinimumIn":0.8,
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
			"Period":2
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
      		"MinimumIn":0.8,
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
      		"Period":4
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
      		"MinimumIn":0.8,
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
	  		"Period":8
	  	},
	  	"Normalizer":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
	  		"MinimumOut":-0.9,
	  		"MaximumOut":0.9,
	  		"MinimumIn":0.8,
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
	  		"Period":16
	  	},
	  	"Normalizer":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
	  		"MinimumOut":-0.9,
	  		"MaximumOut":0.9,
	  		"MinimumIn":0.8,
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
	  		"Period":24
	  	},
	  	"Normalizer":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
	  		"MinimumOut":-0.9,
	  		"MaximumOut":0.9,
	  		"MinimumIn":0.8,
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
	  		"Period":48
	  	},
	  	"Normalizer":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
	  		"MinimumOut":-0.9,
	  		"MaximumOut":0.9,
	  		"MinimumIn":0.8,
	  		"MaximumIn":1.8
	  	},
	  	"Compiler":{  
	  		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
	  	}
	  },
      {  
      	"Index":3,
      	"Indicator":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
      	},
      	"Normalizer":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
      		"MinimumOut":-0.9,
      		"MaximumOut":0.9,
      		"MinimumIn":0.8,
      		"MaximumIn":1.8
      	},
      	"Compiler":{  
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
      	}
      }
   ]
}