using System.Text;

namespace SuperHero.RabbitMq.Consumer.Helper
{
    public static class ConsumeMessageHelper
    {
        public static string OpenMessage(ReadOnlyMemory<byte> messageBody)
        {
            var body = messageBody.ToArray();
            var message = Encoding.UTF8.GetString(body);
            return message;
        }
    }
}
