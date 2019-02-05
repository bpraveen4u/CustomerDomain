using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicMessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "Endpoint=sb://customerdomainpr.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=wS99C3g1doEd0+rjabjkIdDo2iIHCk7yS+K6BrrsooQ=";
            QueueClient client = new QueueClient(connString, "CustomerCreatedQueue");
            
            var customer = new Customer()
            {
                Id = 1,
                Name = "FromQueue customer",
                Address = "CA"
            };
            var jsonData = JsonConvert.SerializeObject(customer);
            var data = Encoding.ASCII.GetBytes(jsonData);
            Message msg = new Message(data);

            client.SendAsync(msg);
            Console.ReadLine();
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
