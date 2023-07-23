using SalesPrediction.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SalesPrediction
{
    public struct Period
    {
        public int Days;
        public float Sales;

        public Period(int day,float sales)
        {
            Days = day;
            Sales = sales;
        }
    }
    public partial class ChartWindow : Form
    {
        Generator generator;
        SalesForecast forecast;
        List<SalesData> tempData = new List<SalesData>();
        List<int> Years = new List<int>();
        public ChartWindow()
        {
            InitializeComponent();
            forecast = new SalesForecast();
            generator = new Generator();
            generator.Load("Sales.csv");
            forecast.TrainModel(generator.Sales);
            GetYears();
        }

        private void buttonDrawChart_Click(object sender, EventArgs e)
        {
            chartLastYear.Series.Clear();
            Series series = new Series($"Продажи {comboBoxYear.SelectedItem}");
            series.ChartType = SeriesChartType.Spline;
           int beginIndex = _findYearBegin(int.Parse(comboBoxYear.SelectedItem.ToString()));

            for(int i = beginIndex; i < beginIndex+365; i++)
            {
                series.Points.AddXY($"{generator.Sales[i].Day}{generator.Sales[i].Month}", generator.Sales[i].Sales);
            }
            chartLastYear.Series.Add(series);
        }

        private void buttonPredict_Click(object sender, EventArgs e)
        {
            chartCurrentYear.Series.Clear();
            Series series = new Series($"Прогноз {int.Parse(comboBoxYear.SelectedItem.ToString())+1}");
            series.ChartType = SeriesChartType.Spline;
            DateTime currentDate = new DateTime(int.Parse(comboBoxYear.SelectedItem.ToString()) + 1);
            for(int i = 0; i < 365; i++)
            {
                SalesData sales = new SalesData(currentDate);
                sales.Sales = forecast.PredictedSales(sales);
                tempData.Add(sales);
                currentDate = currentDate.AddDays(1);
                series.Points.AddXY($"{sales.Day}-{sales.Month}",sales.Sales);
            }
            chartCurrentYear.Series.Add(series);
        }

        private void GetYears()
        {
            for(int i = 0; i < generator.Sales.Count; i++)
            {
                if (!Years.Contains((int)generator.Sales[i].Year))
                {
                    Years.Add((int)generator.Sales[i].Year);
                    i += 365;
                }
            }
            comboBoxYear.DataSource = Years;
        }

        private int _findYearBegin(int Year)
        {
            for(int i = 0; i < generator.Sales.Count; i+=366)
            {
                if ((int)generator.Sales[i].Year == Year)
                {
                    //MessageBox.Show($"Day:{generator.Sales[i].Day}\tMonth{generator.Sales[i].Month} \tYear:{generator.Sales[i].Year}");
                    return i;
                }
            }
            return 0;
        }
    }
}
