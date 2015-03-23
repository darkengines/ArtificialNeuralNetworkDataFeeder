{
	"NeuralNetworkConfiguration": {
		"HiddenLayers": [78, 43, 27, 11, 4],
		"LearingRate": 0.01,
		"MaxEpochs": 500,
		"EpochsBetweenReports": 10,
		"DesiredMSE": 1E-05
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
    	"Compare": false,
    	"Count": 1,
    	"Index": 0,
    	"Indicator": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
    		"Period": 8,
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
    	"Compare": false,
    	"Count": 1,
    	"Index": 0,
    	"Indicator": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
    		"Period": 12,
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
    	"Compare": false,
    	"Count": 1,
    	"Index": 0,
    	"Indicator": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
    		"Period": 24,
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
    	"Compare": false,
    	"Count": 1,
    	"Index": 0,
    	"Indicator": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
    		"Period": 48,
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
    	"Compare": false,
    	"Count": 1,
    	"Index": 0,
    	"Indicator": {
    		"$type": "ArtificialNeuralNetworkDataFeeder.DataIndicators.ReturnMovingAverage, ArtificialNeuralNetworkDataFeeder",
    		"Period": 96,
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