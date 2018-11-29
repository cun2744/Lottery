using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class Parents : Form
    {
        static int i = 1;
        static int max = Parsing.ReturnMax();
        Uri uri;
        WebBrowser parsingweb;
        List<Lottery> lotteries = new List<Lottery>();

        public List<Lottery> Lotteries { get => lotteries; set => lotteries = value; }

        public Parents()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            parsingweb = new WebBrowser();

            uri = new Uri("http://nlotto.co.kr/gameResult.do?method=byWin&drwNo=" + i);

            parsingweb.Url = uri;
            parsingweb.DocumentCompleted += Parsingweb_DocumentCompleted;
        }

        private void Parsingweb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Stream stream = resp.GetResponseStream();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(stream);

            lblParsing.Text = i.ToString() + " / " + max.ToString();


            string conStr = ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertLotto";

                cmd.Parameters.AddWithValue("turn", Int32.Parse(doc.DocumentNode.SelectSingleNode("//div/h3/strong").InnerText));
                cmd.Parameters.AddWithValue("first_win", Int32.Parse(doc.DocumentNode.SelectNodes("//p/img")[0].Attributes["alt"].Value));
                cmd.Parameters.AddWithValue("second_win", Int32.Parse(doc.DocumentNode.SelectNodes("//p/img")[1].Attributes["alt"].Value));
                cmd.Parameters.AddWithValue("third_win", Int32.Parse(doc.DocumentNode.SelectNodes("//p/img")[2].Attributes["alt"].Value));
                cmd.Parameters.AddWithValue("fourth_win", Int32.Parse(doc.DocumentNode.SelectNodes("//p/img")[3].Attributes["alt"].Value));
                cmd.Parameters.AddWithValue("fifth_win", Int32.Parse(doc.DocumentNode.SelectNodes("//p/img")[4].Attributes["alt"].Value));
                cmd.Parameters.AddWithValue("sixth_win", Int32.Parse(doc.DocumentNode.SelectNodes("//p/img")[5].Attributes["alt"].Value));
                cmd.Parameters.AddWithValue("bonus", Int32.Parse(doc.DocumentNode.SelectSingleNode("//span/img").Attributes["alt"].Value));
                var dr = cmd.ExecuteNonQuery();
                if (dr == 1)
                {
                    i++;
                    if (i < max + 1)
                    {
                        uri = new Uri("http://nlotto.co.kr/gameResult.do?method=byWin&drwNo=" + i);
                        parsingweb.Url = uri;

                        double percentage = (double)i / (double)max * 100;
                        ParsingBar.Value = (int)(Math.Truncate(percentage));
                    }
                }
                con.Close();

                Display();
            }
        }

        private void Display()
        {
            lotteries.Clear();
            dataGridView1.DataSource = null;
            string connection = ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;

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
                    Lottery lottery = new Lottery();

                    lottery.Turn = Int32.Parse(reader["turn"].ToString());
                    lottery.First_win = Int32.Parse(reader["first_win"].ToString());
                    lottery.Second_win = Int32.Parse(reader["second_win"].ToString());
                    lottery.Third_win = Int32.Parse(reader["third_win"].ToString());
                    lottery.Fourth_win = Int32.Parse(reader["fourth_win"].ToString());
                    lottery.Fifth_win = Int32.Parse(reader["fifth_win"].ToString());
                    lottery.Sixth_win = Int32.Parse(reader["sixth_win"].ToString());
                    lottery.Bonus = Int32.Parse(reader["bonus"].ToString());

                    lotteries.Add(lottery);
                }
                dataGridView1.DataSource = lotteries;

                conn.Close();
            }
        }

        private void Parents_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorChart color = new ColorChart();
            color.Owner = this;
            color.Show();
        }
    }
    
}
