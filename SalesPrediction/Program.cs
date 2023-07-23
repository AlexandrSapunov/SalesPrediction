using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.TimeSeries;
using SalesPrediction.AnomalyDetection;
using SalesPrediction.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SalesPrediction
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
            Generator generator = new Generator();
            generator.Generate(300, 420, 365, true, new DateTime(2017, 1, 1), "Sales.csv");
            generator.Generate(320, 410, 365, true, new DateTime(2018, 1, 1), "Sales.csv");
            generator.Generate(280, 430, 365, true, new DateTime(2019, 1, 1), "Sales.csv");
            generator.Generate(310, 440, 365, true, new DateTime(2020, 1, 1), "Sales.csv");
            generator.Generate(290, 410, 365,true, new DateTime(2021, 1, 1), "Sales.csv");
            generator.Generate(300, 400, 365,true, new DateTime(2022, 1, 1),"Sales.csv");
            generator.Load("Sales.csv");
            SpikeDetection spike = new SpikeDetection();
            spike.FindAnomaly(generator.Sales);
            */
            Application.Run(new ChartWindow());


            
            Console.ReadKey();
            
        }


    }
}
