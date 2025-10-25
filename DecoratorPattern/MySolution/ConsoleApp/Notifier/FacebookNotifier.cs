namespace ConsoleApp.Notifier
{
    internal class FacebookNotifier : INotifier
    {
        private INotifier notifier;

        public FacebookNotifier(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public void Send(string message)
        {
            Console.WriteLine($"Sending Facebook message: {message}");
            notifier.Send(message);
        }
    }
}
