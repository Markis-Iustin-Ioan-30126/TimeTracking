using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace TimeTrackingClient
{
    class AuthenticationService
    {
        static HttpClient Client = new HttpClient();

        public void CreateConnection()
        {
            Client.BaseAddress = new Uri("http://localhost:8082/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public int Authentication(AuthenticationWrapper wrapper)
        {
            var jsonWrapper = JsonConvert.SerializeObject(wrapper);
            var payload = new StringContent(jsonWrapper, Encoding.UTF8, "application/json");
            var result = Client.PostAsync("employee/auth", payload).Result;
            //MessageBox.Show(jsonWrapper);
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<int>(result.Content.ReadAsStringAsync().Result);
            }
            return 0;
        }
    }
}
