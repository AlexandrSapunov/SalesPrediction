using Microsoft.ML;
using Microsoft.ML.TimeSeries;
using Microsoft.ML.Transforms.TimeSeries;
using SalesPrediction.Model;
using System;
using System.Collections.Generic;

namespace SalesPrediction.AnomalyDetection
{
    public class SpikeDetection
    {
        private MLContext _mlContext;
        private ITransformer _model;

        public SpikeDetection()
        {
            _mlContext = new MLContext();
        }

        public void FindAnomaly(List<SalesData> data)
        {
            var dataView = _mlContext.Data.LoadFromEnumerable<SalesData>(data);
            _train(dataView);
        }

        public void Save(IDataView data)
        {
            _mlContext.Model.Save(_model, data.Schema, "anomalyModel.zip");
        }

        public void Load()
        {
            _model = _mlContext.Model.Load("anomalyModel.zip", out var schema);
        }


        private void _train(IDataView data)
        {
            Generator gn = new Generator();
            gn.Load("Sales.csv");
            string outputColName = nameof(AnomalyPrediction.Prediction);
            string inputColName = "Label";
            var pipeline = _mlContext.Transforms.DetectIidSpike(
                outputColName,
                inputColName,
                95.0f,
                data.Schema.Count / 4
                );//.Fit(data).Transform(data);
            _model = pipeline.Fit(data);
            var transformedModel = _model.Transform(data);

            var predicitonColumn = _mlContext.Data.CreateEnumerable<AnomalyPrediction>(transformedModel, reuseRowObject: false);
            int i = 0;
            foreach (var item in predicitonColumn)
            {
                Console.WriteLine($"DD:{gn.Sales[i].Day}\tMM:{gn.Sales[i].Month}\tYY:{gn.Sales[i].Year}\t|\tValue:{gn.Sales[i].Sales}\tAlert:{item.Prediction[0]}\tScore:{item.Prediction[1]}\tP-Value:{item.Prediction[2]}");
                i++;
            }

        }
    }

}
