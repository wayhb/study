using System.Net;
using System.Xml.Linq;

namespace dzdec
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await webFunction("https://books.toscrape.com/");

            /*

           System.Net.HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create("https://books.toscrape.com/");
           webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
           webRequest.Accept = "text/xml";

           System.Net.HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
           System.IO.Stream responseStream = webResponse.GetResponseStream();
           System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(responseStream);





           // We'll use the HttpClient class to  
           // send a request to the server 
           using (var client = new HttpClient())
           {
               // We'll use the GetAsync method to send  
               // a GET request to the specified URL 
               var response = await client.GetAsync("https://books.toscrape.com/");

               // If the response is successful, we'll 
               // interpret the response as XML 
               if (response.IsSuccessStatusCode)
               {
                   var xml = await response.Content.ReadAsStringAsync();

                   // We can then use the LINQ to XML API to query the XML 
                   var doc = XDocument.Parse(xml);

                   // Let's query the XML to get all of the <title> elements 
                   var titles = from el in doc.Descendants("title")
                                select el.Value;

                   // And finally, we'll print out the titles 
                   foreach (var title in titles)
                   {
                       Console.WriteLine(title);
                   }
               }
           }*/
        }
        public static async Task webFunction(string refer)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(refer);
                await Console.Out.WriteLineAsync($"{content.Length}");
                await Console.Out.WriteLineAsync($"{content}");
            }
        }
    }
}