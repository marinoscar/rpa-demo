using crm.sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace crm.terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = "LEP-87039";
            var lookup = new crm.sdk.ContactLookup();
            var contactDataTable = lookup.GetContactTable(code);

            var json = "{\"Code\":\"LEP-87039\",\"Name\":\"Oscar\",\"LastName\":\"Marin\",\"Company\":\"EY\",\"Address\":\"1 My house road\",\"City\":\"Conroe\",\"State\":\"TX\",\"Zip\":\"77384\",\"Phone1\":\"248-805-0505\",\"Email\":\"oscar@ey.com\"}";
            var url = "https://webcrm2019.azurewebsites.net/Contact/SaveContact";
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var resultTask = httpClient.PostAsync(url, payload);
            resultTask.Wait();
            var result = resultTask.Result.Content.ReadAsStringAsync();
            result.Wait();
            var content = result.Result;
        }
    }
}
