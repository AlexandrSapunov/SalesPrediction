using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPrediction.Model
{
    public class SalesData
    {
        public float Day { get; set; }
        public float Month { get; set; }
        public float Year { get; set; }

        [ColumnName("Label")]
        public float Sales { get; set; }


        public SalesData(DateTime date)
        {
            Day = date.Day; Month = date.Month; Year = date.Year;
        }

    }

    public class SalesPrediction
    {
        [ColumnName("Score")]
        public float ForecastedUnits { get; set; }
    }

    public class AnomalyPrediction
    {
        [VectorType(4)]
        public double[] Prediction { get; set; }
    }

}
