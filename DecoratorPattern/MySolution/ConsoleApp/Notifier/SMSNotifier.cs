namespace ConsoleApp.Notifier
{
    internal class SMSNotifier : INotifier
    {
        private readonly INotifier _notifier;

        public SMSNotifier(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS:{message}");
            _notifier.Send(message);
        }
    }
}
