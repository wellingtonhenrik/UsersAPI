using System.Diagnostics;
using System.Runtime.Loader;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using UserApi.Domain.ValueObjects;
using UsersAPI.Infra.Messages.Models;
using UsersAPI.Infra.Messages.Services;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Consumers
{
    public class UserMessageConsumer : BackgroundService
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly RabbitMQSettings? _rabbitMqSettings;
        private readonly EmailMessageService? _emailMessageService;

        private IConnection? _connection;
        private IModel? _model;

        public UserMessageConsumer(IServiceProvider? serviceProvider, IOptions<RabbitMQSettings>? rabbitMqSettings,
            EmailMessageService? emailMessageService)
        {
            _serviceProvider = serviceProvider;
            _rabbitMqSettings = rabbitMqSettings?.Value;
            _emailMessageService = emailMessageService;

            var factory = new ConnectionFactory { Uri = new Uri(_rabbitMqSettings.Url) };
            _connection = factory.CreateConnection();
            _model = _connection.CreateModel();

            _model.QueueDeclare(
                queue: _rabbitMqSettings.Queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //objeto utilizado para ler e processar a fila
            var consumer = new EventingBasicConsumer(_model);

            //criando o mecanismo para ler cada item da fila
            consumer.Received += async (sender, args) =>
            {
                //lendo e deserializando o conteudo do item obtido da fila
                var payload = Encoding.UTF8.GetString(args.Body.ToArray());
                var userMessageVO = JsonConvert.DeserializeObject<UserMessageVO>(payload);

                using (var scope = _serviceProvider.CreateScope())
                {
                    //processando item
                    var messagemRequestModel = new MessageRequestModel
                    {
                        MailTo = userMessageVO.To,
                        Subject = userMessageVO.Subject,
                        Body = userMessageVO.Body,
                    };

                    //enviando a mensagem para o email do usuario
                    await _emailMessageService?.SendMessage(messagemRequestModel);

                    //removendo item da fila
                    _model.BasicAck(args.DeliveryTag, false);

                }
            };
            
            //executando a leitura da fila
            _model.BasicConsume(_rabbitMqSettings.Queue,false,consumer);
        }
    }
}