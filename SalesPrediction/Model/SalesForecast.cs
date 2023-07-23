using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SalesPrediction.Model
{
    public class SalesForecast
    {
        private MLContext _mlContext;
        private ITransformer _model;
        private PredictionEngine<SalesData, SalesPrediction> _predictionEngine;

        public List<SalesPrediction> AnomalyPredictions { get; set; }


        public SalesForecast()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(string dataPath, char separator)
        {
            IDataView trainingData = _mlContext.Data.LoadFromTextFile<SalesData>(dataPath, separatorChar: separator);

            _train(trainingData);
        }

        public void TrainModel(List<SalesData> sales)
        {
            IDataView trainData = _mlContext.Data.LoadFromEnumerable<SalesData>(sales);
            _train(trainData);
        }


        public float PredictedSales(DateTime date)
        {
            SalesData salesData = new SalesData(date);
            return _predictionEngine.Predict(salesData).ForecastedUnits;
        }

        public float PredictedSales(SalesData salesData)
        {
            return _predictionEngine.Predict(salesData).ForecastedUnits;
        }

        public void SaveModel()
        {
            _mlContext.Model.Save(_model, null, "model.zip");
        }

        public void LoadModel()
        {
            _model = _mlContext.Model.Load("model.zip", out var modelSchema);
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<SalesData, SalesPrediction>(_model);
        }

        private void _train(IDataView trainData)
        {
            var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding(inputColumnName: nameof(SalesData.Day), outputColumnName: "DayEnc")
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding(inputColumnName: nameof(SalesData.Month), outputColumnName: "MonthEnc"))
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding(inputColumnName: nameof(SalesData.Year), outputColumnName: "YearEnc"))
                .Append(_mlContext.Transforms.Concatenate("Features", "DayEnc", "MonthEnc", "YearEnc"))
                .Append(_mlContext.Transforms.NormalizeMinMax("Features"))
                .Append(_mlContext.Regression.Trainers.FastTree());

            _model = pipeline.Fit(trainData);
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<SalesData, SalesPrediction>(_model);
            SaveModel();
        }

    }
}
