{
	"NeuralNetworkConfiguration": {
		"HiddenLayers": [30, 20, 10, 5],
		"LearingRate": 0.01,
		"MaxEpochs": 50000,
		"EpochsBetweenReports": 10,
		"DesiredMSE": 0.0000008
	},
  "DataPickers": [
    {
    	"Compare": true,
    	"Count": 1,
    	"Index": 0,
    	"Indicator": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
    		"InputCount": 1,
    		"OutputCount": 1
    	},
    	"Normalizer": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
    		"MinimumIn": 0.5,
    		"MaximumIn": 1.5,
    		"MinimumOut": -0.9,
    		"MaximumOut": 0.9
    	},
    	"Compiler": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
    	},
    	"Distributor": null
    },
	{  
		"Index":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
		},
		"Normalizer":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumOut":-0.9,
			"MaximumOut":0.9,
			"MinimumIn":0,
			"MaximumIn":6
		},
		"Compiler":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataCompilers.DayOfWeekDataCompiler, ArtificialNeuralNetworkDataFeeder"
		}
	},
    {
    	"Compare": false,
    	"Count": 32,
    	"Index": -32,
    	"Indicator": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnIndicator, ArtificialNeuralNetworkDataFeeder",
    		"InputCount": 1,
    		"OutputCount": 1
    	},
    	"Normalizer": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
    		"MinimumIn": 0.5,
    		"MaximumIn": 1.5,
    		"MinimumOut": -0.9,
    		"MaximumOut": 0.9
    	},
    	"Compiler": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
    	},
    	"Distributor": null
    },
	{  
		"Index":0,
		"Indicator":{  
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
			"Period":744
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
			"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
			"Period":372
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
	  	"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
	  	"Period":186
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
	  	"$type":"ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
	  	"Period":46
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
		"Compare": false,
		"Count": 1,
		"Index": 4,
		"Indicator": {
			"$type": "ArtificialNeuralNetworkDataFeeder.DataIndicators.InvariantIndicator, ArtificialNeuralNetworkDataFeeder",
			"InputCount": 1,
			"OutputCount": 1
		},
		"Normalizer": {
			"$type": "ArtificialNeuralNetworkDataFeeder.DataNormalizers.RangeDataNormalizer, ArtificialNeuralNetworkDataFeeder",
			"MinimumIn": 0.5,
			"MaximumIn": 1.5,
			"MinimumOut": -0.9,
			"MaximumOut": 0.9
		},
		"Compiler": {
			"$type": "ArtificialNeuralNetworkDataFeeder.DataCompilers.CloseDataCompiler, ArtificialNeuralNetworkDataFeeder"
		},
		"Distributor": null
	}
  ]
}