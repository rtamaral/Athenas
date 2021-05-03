using DadosJson.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace DadosJson.Controllers
{
    public class PessoasController : ApiController
    {
        // GET: HtmlTable

        public List<EmailModel> Get()
        {
            List<EmailModel> items = new List<EmailModel>();
            WebClient webClient = new WebClient();
            string page = webClient.DownloadString("https://developer.athenas.online/table.html");

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);

            foreach (HtmlNode rows in doc.DocumentNode.SelectNodes("//table/tbody"))
            {
                foreach (HtmlNode row in rows.SelectNodes("tr"))
                {
                    EmailModel item = new EmailModel()
                    {
                        Codigo = int.Parse(row.SelectNodes("td")[0].InnerText),
                        Nome = row.SelectNodes("td")[1].InnerText.Trim(),
                        Email = row.SelectNodes("td")[2].InnerText.Trim(),
                        Categoria = int.Parse(row.SelectNodes("td")[3].InnerText)
                    };
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
