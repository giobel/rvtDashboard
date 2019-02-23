using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveChartWPF
{
    public partial class DBController : Form
    {
        
        string p1 = "filesize";
        string p2 = "CQT";

        public string choosenProjectControl = "";

        public DBController()
        {
            InitializeComponent();
        }


        private void Control_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(p1);
            comboBox1.Items.Add(p2);

        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            choosenProjectControl = comboBox1.SelectedItem.ToString();
            //List<ProjectDbTable> myTable = Helpers.ConnectDB(choosenProject);
            Form myForm = new Form1(choosenProjectControl);
            myForm.Show();



        }
    }
}
