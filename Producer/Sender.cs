using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
   public class Sender
    {
       public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
                using(var channel =connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string Messsage = "Hello... Getting Started with .net Core  RabbitMQ..";

                var body = Encoding.UTF8.GetBytes(Messsage);

                channel.BasicPublish("", "BasicTest", null, body);

                Console.WriteLine("Send MEssage.....{0}", Messsage);


            }
            Console.WriteLine("Press [Any Key ] tO  Exit Sender App..");
            Console.ReadKey();
        }
    }
}
