namespace ConsoleApp.Notifier
{
    internal class Notifier: INotifier
    {
        public virtual void Send(string message)
        {
            Console.WriteLine($"Sending generic notification: {message}");
        }

    }
}
