using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;

namespace LiveChartWPF
{
    class Helpers
    {
        public static List<ProjectDbTable> ConnectDB(string tableName)
        {
            string server = "remotemysql.com";
            string database = "r7BFoOjCty";
            string uid = "r7BFoOjCty";
            string password = "1vU3s1bj6T";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            // string table = "filesize";
            //string table = "CQT";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmdRead = new MySqlCommand("", connection);
            cmdRead.CommandText = "SELECT * FROM " + tableName;

            Dictionary<string, object> dbTable = new Dictionary<string, object>();

            List<int> rvtFileSize = new List<int>();

            List<ProjectDbTable> tableRows = new List<ProjectDbTable>();

            try
            {

                connection.Open();
                MySqlDataReader reader = cmdRead.ExecuteReader();

                while (reader.Read())
                {
                    //dbTable.Add(reader.GetInt16("id"), new int[] { reader.GetInt32("rvtFileSize") });
                    ProjectDbTable pdt = new ProjectDbTable();

                    pdt.id = reader.GetInt16("id");
                    pdt.date = reader.GetDateTime("date");
                    pdt.user = reader.GetString("user");
                    pdt.rvtFileSize = reader.GetInt32("rvtFileSize");
                    pdt.elementsCount = reader.GetInt32("elementsCount");
                    pdt.typesCount = reader.GetInt32("typesCount");
                    pdt.sheetsCount = reader.GetInt32("sheetsCount");
                    pdt.viewsCount = reader.GetInt32("viewsCount");
                    pdt.viewportsCount = reader.GetInt32("viewportsCount");
                    try
                    {
                        pdt.warningsCount = reader.GetInt32("warningsCount");
                    }
                    catch
                    {
                        pdt.warningsCount = 0;
                    }

                    tableRows.Add(pdt);
                    /*
                    dbTable.Add("rvtFileSize", reader.GetInt32("rvtFileSize"));
                    dbTable.Add("user", reader.GetString("user"));
                    rvtFileSize.Add(reader.GetInt32("rvtFileSize"));
                    */
                }
                reader.Close();

                MessageBox.Show(string.Format("Connection with DB {0} established",tableName));
                return tableRows;
                //return rvtFileSize;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                
            }
            }//close method

        public static Axis CreateAxe(string title, int labelRotation, List<string> labelValues, int step, AxisPosition position)
        {
            Axis myAxe = new Axis();

            myAxe.Title = title;
            myAxe.Labels = labelValues;
            myAxe.LabelsRotation = labelRotation;
            myAxe.Separator = new Separator
            {
                //Step = TimeSpan.FromDays(1).Ticks,
                //IsEnabled = false

                Step = step,
                StrokeThickness = 1,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 2 }),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
            };
            myAxe.Position = position;
            return myAxe;
        }

        public static Axis CreateAxe(string title, int labelRotation, AxisPosition position)
        {
            Axis myAxe = new Axis();

            myAxe.Title = title;
            myAxe.LabelsRotation = labelRotation;
            myAxe.Position = position;
            myAxe.Separator = new Separator
            {
                StrokeThickness = 1,
                StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 2 }),
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
            };

            return myAxe;
        }


    }//close class

    public class ProjectDbTable
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string user { get; set; }
        public int rvtFileSize { get; set; }
        public int elementsCount { get; set; }
        public int typesCount { get; set; }
        public int sheetsCount { get; set; }
        public int viewsCount { get; set; }
        public int viewportsCount { get; set; }
        public int warningsCount { get; set; }
    }

}
