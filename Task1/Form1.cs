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
using CalcLibrary;
using Point = CalcLibrary.Point;

namespace Task1
{
    public partial class Form1 : Form
    {
        private LineEquation eq1;
        private LineEquation eq2;
        Point endPoint1;
        Point endPoint2;
        private List<Point> InputPointList;
        private List<Point> OutputPointList;
        public Form1()
        {
            InitializeComponent();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize data & endpoints
            InitializeData();

        }

        private void InitializeData()
        {
            dataGridView1.DataSource = null;

            InputPointList = new List<CalcLibrary.Point>() {
                new Point { X = 1, Y = 2 },
                new Point { X = 2, Y = 4 },
                new Point { X = 3, Y = 5.4 },
                new Point { X = 4, Y = 3.2 },
                new Point { X = 5, Y = 7 },
                new Point { X = 6, Y = 7.5 },
                new Point { X = 7, Y = 6 },
                new Point { X = 8, Y = 5 },
                new Point { X = 9, Y = 6.9 },
                new Point { X = 10, Y = 8 },
             };

            dataGridView1.DataSource = InputPointList;

            // Endpoints
            endpoint1X.Text = "1";
            endpoint1Y.Text = "20";
            endpoint2X.Text = "10";
            endpoint2Y.Text = "40";

            this.chartControl.Palette = ChartColorPalette.EarthTones;

            // Set title
            this.chartControl.Titles.Add("Task1");
        }

        private void Plot_Lines()
        {
            this.chartControl.Series.Clear();

            string[] seriesArray = { "Input data", "Endopoints", "Transform" };
            
            // Add series.
            Series series0 = this.chartControl.Series.Add(seriesArray[0]);
            Series series1 = this.chartControl.Series.Add(seriesArray[1]);
            Series series2 = this.chartControl.Series.Add(seriesArray[2]);

            series1.Points.AddXY(endPoint1.X, endPoint1.Y);
            series1.Points.AddXY(endPoint2.X, endPoint2.Y);

            series0.ChartType = SeriesChartType.Line;
            series1.ChartType = SeriesChartType.Point;
            series2.ChartType = SeriesChartType.Line;

            OutputPointList = new List<Point>();
            foreach (var p in InputPointList)
            {
                // Plot input points
                series0.Points.AddXY(p.X, p.Y);

                // Plot output points
                Point newPoint = new Point() { X = p.X, Y = eq1.GetYValue(p.X) + (p.Y -eq2.GetYValue(p.X)) };
                series2.Points.AddXY(newPoint.X, newPoint.Y);

                OutputPointList.Add(newPoint);
            }

            dataGridView2.DataSource = OutputPointList;
        }

        private void chartControl_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            endPoint1 = new Point() { X = Convert.ToDouble(endpoint1X.Text), Y = Convert.ToDouble(endpoint1Y.Text) };
            endPoint2 = new Point() { X = Convert.ToDouble(endpoint2X.Text), Y = Convert.ToDouble(endpoint2Y.Text) };

            eq1 = new LineEquation(endPoint1, endPoint2);

            eq2 = new LineEquation(InputPointList.First(), InputPointList.Last());

            Plot_Lines();
        }
    }
}

