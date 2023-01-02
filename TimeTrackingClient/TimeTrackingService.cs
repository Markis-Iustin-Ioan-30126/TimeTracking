using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace TimeTrackingClient
{
    class TimeTrackingService
    {
        static HttpClient Client = new HttpClient();

        public void CreateConnection()
        {
            Client.BaseAddress = new Uri("http://localhost:8082/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            HttpResponseMessage httpResponse = Client.GetAsync("employee/id="+id).Result;
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
            var result = Client.PostAsync("timeTracking", payload).Result;
            //MessageBox.Show(result.Content.ReadAsStringAsync().Result);
            if (result.IsSuccessStatusCode)
            {
                TimeTracking resultedRecord = JsonConvert.DeserializeObject<TimeTracking>(result.Content.ReadAsStringAsync().Result);
                if (resultedRecord != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
