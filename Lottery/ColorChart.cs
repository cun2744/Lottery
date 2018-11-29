using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lottery
{
    public partial class ColorChart : Form
    {
        int[] color = new int[5];
        double[] percentage = new double[5];
        Parents parents;
        
        public ColorChart()
        {
            InitializeComponent();
        }

        private DataTable table;

        private void ColorChart_Load(object sender, EventArgs e)
        {
            LottoChartDisplay();
            string data = Parsing.ReturnDate();

            string connection = ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;
            table = new DataTable();
            table.Columns.Add("회차");
            table.Columns.Add("담청번호");
            table.Columns.Add("보너스");
            table.Columns.Add("당첨일자");

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectLotto";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DataRow row = table.NewRow();
                    row["회차"] = reader["turn"];
                    row["담청번호"] = reader["first_win"]+" , "+ reader["second_win"] + " , " +reader["third_win"] + " , " +reader["fourth_win"]+ " , "+reader["fifth_win"]+ " , "+reader["sixth_win"];
                    row["보너스"] = reader["bonus"];
                    row["당첨일자"] = data;
                    table.Rows.Add(row);
                }

                conn.Close();
                this.dataGridView1.DataSource = table;
            }

        }

        private void LottoChartDisplay()
        {
            int Max = Parsing.ReturnMax();
            parents = (Parents)Owner;

            for (int i = 1; i < Max + 1; i++)
            {
                cbb_Start.Items.Add(i);
                cbb_End.Items.Add(i);
            }
            cbb_End.Text = Max.ToString();


            Charting(parents);
            lottoChart.Titles.Add("색 상 별 통 계");
            lottoChart.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            lottoChart.Series[0].Points[0].LegendText = "1 - 10번";
            lottoChart.Series[0].Points[1].LegendText = "11 - 20번";
            lottoChart.Series[0].Points[2].LegendText = "21 - 30번";
            lottoChart.Series[0].Points[3].LegendText = "31 - 40번";
            lottoChart.Series[0].Points[4].LegendText = "41 - 45번";
        }

        private void Charting(Parents parents)
        {
            color = new int[5];
            percentage = new double[5];
            for (int i = Int32.Parse(cbb_End.Text)-1; i >= Int32.Parse(cbb_Start.Text)-1; i--)
            {
                int[] temp = { parents.Lotteries[i].First_win, parents.Lotteries[i].Second_win, parents.Lotteries[i].Third_win, parents.Lotteries[i].Fourth_win, parents.Lotteries[i].Fifth_win, parents.Lotteries[i].Sixth_win };
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] > 0 && temp[j] < 11)
                    {
                        color[0]++;
                    }
                    if (temp[j] > 10 && temp[j] < 21)
                    {
                        color[1]++;
                    }
                    if (temp[j] > 20 && temp[j] < 31)
                    {
                        color[2]++;
                    }
                    if (temp[j] > 30 && temp[j] < 41)
                    {
                        color[3]++;
                    }
                    if (temp[j] > 40 && temp[j] < 46)
                    {
                        color[4]++;
                    }
                }
            }

            for (int i = 0; i < color.Length; i++)
            {
                percentage[i] = ((double)color[i] / (double)(Int32.Parse(cbb_End.Text) * 6)) * 100;
            }
            lottoChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            lottoChart.Series[0].Points.DataBind(color, "번호", "당첨", null);
           
            //lottoChart.Series[0].Points[0].Color = Color.Aqua;
            for (int i = 0; i < lottoChart.Series[0].Points.Count; i++)
            {
                percentage[i] = Math.Round(percentage[i], 1);
                lottoChart.Series[0].Points[i].Label = (percentage[i]).ToString() + "%";
            }
        }

        Point? previousPos = null; 
        ToolTip toolTip = new ToolTip();
        private void lottoChart_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.Location;

            if (previousPos.HasValue && position == previousPos)
            {
                return;
            }

            toolTip.RemoveAll();
            previousPos = position;


            var hit = lottoChart.HitTest(position.X, position.Y, ChartElementType.DataPoint);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                var xValue = color[hit.PointIndex];

               
                
                toolTip.Show(lottoChart.Series[0].Points[hit.PointIndex].LegendText+"\n"+"(" +xValue.ToString()+")표  "+ percentage[hit.PointIndex]+"%", lottoChart, new Point(position.X + 10, position.Y + 15));

            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            Charting(parents);
        }
    }
}
