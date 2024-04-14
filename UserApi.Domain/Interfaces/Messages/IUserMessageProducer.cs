using UserApi.Domain.ValueObjects;

namespace UserApi.Domain.Interfaces.Messages
{
    public interface IUserMessageProducer
    {
        void Send(UserMessageVO userMessage);
    }
}
