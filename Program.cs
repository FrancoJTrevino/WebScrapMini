using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static void Main()
        {
            string url = "https://weather.com/es-AR/tiempo/hoy/l/73221febea810bafc31cd18333b459023779a1cc164ef9f84c77c293f86f1d15";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine(temperature);

            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();
            Console.WriteLine(condition);

            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine(location);
        }
    }
}