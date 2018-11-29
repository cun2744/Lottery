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
    public partial class Form1 : Form
    {
        static int i = 1;
        static int max = Parsing.ReturnMax();
        Uri uri;
        WebBrowser parsingweb;
        List<Lottery> lotteries = new List<Lottery>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void LottoAdd()
        {

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
            }
        }
    }
}
