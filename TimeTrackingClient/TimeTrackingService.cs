using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TimeTrackingClient
{
    class TimeTrackingService
    {
        static HttpClient client = new HttpClient();

        public void CreateConnection()
        {
            client.BaseAddress = new Uri("http://localhost:8082/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            HttpResponseMessage httpResponse = client.GetAsync("employee/id="+id).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                string result = httpResponse.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<Employee>(result);
                return employee;
            }
            return null;


        }

        public Boolean AddNewTimeRecord(TimeTrackingRecordWrapper record)
        {
            var jsonRecord = JsonConvert.SerializeObject(record);
            //MessageBox.Show(jsonRecord);
            var payload = new StringContent(jsonRecord, Encoding.UTF8, "application/json");
            var result = client.PostAsync("timeTracking", payload).Result;
            //MessageBox.Show(result.Content.ReadAsStringAsync().Result);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
