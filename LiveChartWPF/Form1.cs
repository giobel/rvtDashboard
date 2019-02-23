using LiveCharts;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media;
using System.Diagnostics;
using System;

namespace LiveChartWPF
{
    public partial class Form1 : Form
    {


        public Form1(string choosenProject)
        {

            InitializeComponent();

            label1.Text = choosenProject;

            List<ProjectDbTable> myTable = Helpers.ConnectDB(choosenProject);

            ElementSizeChart.Create(choosenProject, cartesianChart1, myTable);
            ElementSizeChart.Create(choosenProject, cartesianChart2, myTable);

        }//close form


        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked " + chartPoint.From);
        }



    }
}
