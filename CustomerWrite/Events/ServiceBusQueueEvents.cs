using CustomerWrite.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWrite.Events
{
    public class ServiceBusQueueEvents
    {
        private readonly IConfiguration config;

        public ServiceBusQueueEvents(IConfiguration config)
        {
            this.config = config;
        }

        public async Task SendEventsToQueue(IEvents custEvents)
        {
            var connString = config["serviceBusConn"];
            QueueClient client = new QueueClient(connString, "CustomerCreatedQueue");

            var jsonData = JsonConvert.SerializeObject(custEvents);
            var data = Encoding.ASCII.GetBytes(jsonData);
            Message msg = new Message(data);

            await client.SendAsync(msg);
        }
    }
}
