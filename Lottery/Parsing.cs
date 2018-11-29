using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    static class Parsing
    {
        public static string ReturnDate()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            Uri uri = new Uri("http://nlotto.co.kr/gameResult.do?method=statByColor&sortOrder=DESC&startPage=1&endPage=84&currentPage=84");
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Stream stream = resp.GetResponseStream();
            doc.Load(stream);

            return (doc.DocumentNode.SelectNodes("//tbody/tr")[1].ChildNodes[1].InnerText);
        }

        public static int ReturnMax()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            Uri uri = new Uri("http://nlotto.co.kr/gameResult.do?method=byWin");
            HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Stream stream = resp.GetResponseStream();
            doc.Load(stream);

            return Int32.Parse(doc.DocumentNode.SelectNodes("//select/option")[0].InnerText);
        }
    }
}
