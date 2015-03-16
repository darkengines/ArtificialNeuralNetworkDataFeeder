{  
	"NeuralNetworkConfiguration":{  
		"HiddenLayers":[  
		   70,50,20,5
		],
		"LearingRate": 0.01,
		"MaxEpochs": 200,
		"EpochsBetweenReports": 10,
		"DesiredMSE": 0.000001
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
			"Period":4
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
      		"Period":8
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
	  		"Period":12
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
	  		"Period":24
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
	  		"Period":48
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
	  		"Period":96
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
	  		"Period":8
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
      		"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
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