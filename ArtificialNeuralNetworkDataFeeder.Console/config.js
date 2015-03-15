{  
	"NeuralNetworkConfiguration":{  
		"HiddenLayers":[  
		   64,
		   32,
		   16,
		   8
		],
		"LearingRate": 0.5,
		"MaxEpochs": 200,
		"EpochsBetweenReports": 1,
		"DesiredMSE": 0.000001
	},
   "DataPickers":[
	{  
		"Index":0,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-1,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-2,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-3,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-4,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-5,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-6,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-7,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-8,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-9,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
	{  
		"Index":-10,
		"Compare":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":1000
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.VolumeDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
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
      	"Index":-1,
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
      	"Index":-2,
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
	  	"Index":-3,
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
	  	"Index":-4,
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
	  	"Index":-5,
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
	  	"Index":-6,
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
	  	"Index":-7,
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
	  	"Index":-8,
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
	  	"Index":-9,
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
	  	"Index":-10,
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