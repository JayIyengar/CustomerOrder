using CustomerOrder.Core.Domain;
using CustomerOrder.Core.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CustomerOrder.Core.Processor
{
    public interface ICustomerDetailProvider
    {
        Customer GetCustomer(string email);
    }
    public class CustomerDetailProvider : ICustomerDetailProvider
    {
        private ISettings _settings;

        public CustomerDetailProvider(ISettings settings)
        {
            _settings = settings;
        }
        public Customer GetCustomer(string email)
        {
            var apikey = _settings.ApiKey;
            var url = _settings.CustomerDetailApiUrl;
            Customer customer = null;

            
            url = url.Replace("{email}", email).Replace("{apikey}", apikey);           

            HttpClient client = new HttpClient();
            HttpResponseMessage response =  client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            
            var responseMessage = response.Content.ReadAsStringAsync().Result;

            customer = JsonConvert.DeserializeObject<Customer>(responseMessage);

            return customer;
        }
    }
}
