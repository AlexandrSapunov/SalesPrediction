using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesPrediction.Model
{
    public class Generator
    {
        private Random _rand;
        public List<(int day, int mounts, double multiplier)> SalesDays { get; set; }
        public List<SalesData> Sales { get; set; }

        public Generator()
        {
            SalesDays = new List<(int, int, double)>();
            Sales = new List<SalesData>();
            _rand = new Random();
            _defaultSalesDay();
        }

        public void Generate(int min, int max, int amount,bool peakSales, DateTime beginDate, string fileName)
        {
            String file = fileName;
            String separator = ",";
            StringBuilder output = new StringBuilder();

            SalesData tempSales;
            DateTime tempBeginDate = beginDate;
            for (int i = 0; i <= amount; i++)
            {
                if (i == 5)
                {

                }
                tempSales = new SalesData(tempBeginDate);
                tempSales.Sales = _checkSalesDay(min, max, tempBeginDate,peakSales);

                String[] newLine = {
                    tempSales.Day.ToString(),
                    tempSales.Month.ToString(),
                    tempSales.Year.ToString(),
                    tempSales.Sales.ToString(),
                };
                output.AppendLine(string.Join(separator, newLine));
                tempBeginDate = tempBeginDate.AddDays(1);
            }

            File.AppendAllText(file, output.ToString());
        }

        public void Load(string fileName)
        {
            Sales.Clear();
            if (File.Exists(fileName))
            {
                string txt = File.ReadAllText(fileName).Replace('\r', ' ').Trim();
                string[] separateTxt = txt.Split('\n');
                for (int i = 0; i < separateTxt.Length; i++)
                {
                    SalesData sales = new SalesData(new DateTime(2020, 1, 1));
                    string[] separateStr = separateTxt[i].Split(',');
                    sales.Day = int.Parse(separateStr[0]);
                    sales.Month = int.Parse(separateStr[1]);
                    sales.Year = int.Parse(separateStr[2]);
                    sales.Sales = int.Parse(separateStr[3]);
                    Sales.Add(sales);
                }
            }
            else
                throw new FileNotFoundException($"Файл {fileName}.csv не найден.");

        }


        private void _defaultSalesDay()
        {
            SalesDays.Clear();
            SalesDays.Add((1, 1, 1.5));
            SalesDays.Add((23, 2, 1.2));
            SalesDays.Add((5, 4, 1.1));
            SalesDays.Add((15, 4, 1.1));
            SalesDays.Add((1, 5, 1.2));
            SalesDays.Add((25, 8, 1.3));
            SalesDays.Add((25, 12, 1.5));
        }

        private int _checkSalesDay(int min, int max, DateTime currentDate,bool isPeakSales)
        {
            double salesRatio = 0;
            if (isPeakSales == true)
            {
                for (int i = 0; i < SalesDays.Count; i++)
                {
                    if (currentDate.Month == SalesDays[i].mounts)
                    {
                        if (currentDate.Day <= SalesDays[i].day + 7 && currentDate.Day >= SalesDays[i].day - 7)
                        {
                            switch (Math.Abs(currentDate.Day - SalesDays[i].day))
                            {
                                case 0:
                                case 1:
                                    salesRatio = 1.4;
                                    break;
                                case 2:
                                case 3:
                                    salesRatio = 1.3;
                                    break;
                                case 4:
                                case 5:
                                    salesRatio = 1.2;
                                    break;
                                case 6:
                                case 7:
                                    salesRatio = 1.1;
                                    break;
                                case 8:
                                case 9:
                                    salesRatio = 1.05;
                                    break;
                                case 10:
                                    salesRatio = 1;
                                    break;
                            }
                            return _rand.Next((int)(min * salesRatio * SalesDays[i].multiplier), (int)(max * salesRatio * SalesDays[i].multiplier));
                        }
                    }
                }
            }
            return _rand.Next(min, max);
        }
    }
}
