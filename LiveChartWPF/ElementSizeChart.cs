using LiveCharts;
using lwf = LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LiveChartWPF
{
    class ElementSizeChart
    {
        public static SeriesCollection SeriesCollection { get; set; }


        public static void Create(string tableName, lwf.CartesianChart chart, List<ProjectDbTable> myTable)
        {


            //List<ProjectDbTable> myTable = Helpers.ConnectDB(tableName);


            ChartValues<double> rvtFileSizeValues = new ChartValues<double>();
            ChartValues<double> idValues = new ChartValues<double>();
            ChartValues<double> elementsCount = new ChartValues<double>();

            List<string> dateLabels = new List<string>();

            if (myTable != null)
            {


                foreach (var item in myTable)
                {
                    rvtFileSizeValues.Add(item.rvtFileSize / 1000000);
                    idValues.Add(item.id);
                    dateLabels.Add(item.date.ToString("dd/MM/yy"));
                    elementsCount.Add(item.elementsCount);

                }

                chart.Series = new SeriesCollection {

                new LineSeries
                {
                 Title = "File Size",
                 Values = rvtFileSizeValues,
                 ScalesYAt = 0

                },
                 new LineSeries
                {
                 Title = "Elements",
                 Values = elementsCount,
                 ScalesYAt = 1

                },
             };


                chart.AxisX.Add(Helpers.CreateAxe("Date", 89, dateLabels,5, AxisPosition.LeftBottom)); //step to be adjusted by label count!

                chart.AxisY.Add(Helpers.CreateAxe("MB", 0, AxisPosition.LeftBottom)); 

                Axis eleCount = Helpers.CreateAxe("Elements Count", 0, AxisPosition.RightTop);

                eleCount.LabelFormatter = value => value / 1000 + "k";
                eleCount.Separator = new Separator
                {   
                    //Step = 1000
                };

                chart.AxisY.Add(eleCount);

                /*
                chart.AxisY.Add(new Axis
                {
                    Title = "Elements Count",
                    Position = AxisPosition.RightTop,
                    LabelFormatter = value => value / 1000 + "k"
                    
                });
                */
                chart.LegendLocation = LegendLocation.Bottom;
                
            }
            else
            {
                

            }
        }//close method
        

    }
}
