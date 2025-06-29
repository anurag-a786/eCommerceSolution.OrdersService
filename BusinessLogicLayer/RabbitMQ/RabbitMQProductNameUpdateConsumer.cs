using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using eCommerce.OrdersMicroservice.BusinessLogicLayer.RabbitMQ;

namespace eCommerce.ProductsService.BusinessLogicLayer.RabbitMQ
{
    public class RabbitMQProductNameUpdateConsumer : IDisposable, IRabbitMQProductNameUpdateConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQProductNameUpdateConsumer(IConfiguration configuration)
        {
            _configuration = configuration;
            string hostName = _configuration["RabbitMQ_HostName"]!;
            string userName = _configuration["RabbitMQ_UserName"]!;
            string password = _configuration["RabbitMQ_Password"]!;
            string port = _configuration["RabbitMQ_Port"]!;

            ConnectionFactory connectionFactory =
                new ConnectionFactory()
                {
                    HostName = hostName,
                    UserName = userName,
                    Password = password,
                    Port = Convert.ToInt32(port)
                };

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Consume()
        {
            string routingKey = "product.update.name";
            string queueName = "orders.product.update.name.queue";

            //Create exchange
            string exchangeName = _configuration["RabbitMQ_Products_Exchange"]!;
            _channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct, durable: true);

            //Create message queue
            _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null); //x-message-ttl | x-max-length | x-expired 

            //Bind the message to exchange
            _channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routingKey);
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

    }
}



