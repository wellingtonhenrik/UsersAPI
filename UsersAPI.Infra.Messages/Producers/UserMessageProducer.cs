using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Domain.Interfaces.Messages;
using UserApi.Domain.ValueObjects;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Producers
{
    public class UserMessageProducer : IUserMessageProducer
    {

        private readonly  RabbitMQSettings? _rabbitmqSettings;

        public UserMessageProducer(IOptions<RabbitMQSettings?> rabbitmqSettings)
        {
            _rabbitmqSettings = rabbitmqSettings.Value;
        }

        public void Send(UserMessageVO userMessage)
        {
            //Conectando no servidor RabbitMQ
            var connectionFactory = new ConnectionFactory() { Uri = new Uri(_rabbitmqSettings?.Url) };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    //criando a fila
                    model.QueueDeclare(
                        queue: _rabbitmqSettings.Queue, //nome da fila
                        durable: true, //não apaga as filas ao desligar ou reiniciar o broker
                        autoDelete: false,//apagar ou não a fila quando ela estiver sem mensagens (vazia)
                        exclusive: false, //fila exclusiva para uma unica aplicaçãoou não
                        arguments: null

                        );

                    //gravando mensagem na fila
                    model.BasicPublish(
                        exchange: string.Empty,
                        routingKey: _rabbitmqSettings.Queue,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userMessage))
                        );
                }
            }
        }
    }
}
