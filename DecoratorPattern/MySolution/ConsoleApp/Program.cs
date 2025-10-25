
using ConsoleApp.Writer;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Notifier

            //var notifier = new Notifier.Notifier();
            //var facebookNotifier = new Notifier.FacebookNotifier(notifier);
            //var smsNotifier = new Notifier.SMSNotifier(facebookNotifier);

            //smsNotifier.Send("Hello, World!");

            #endregion

            #region Writer

            IWriter writer = new Writer.Writer();

            Console.WriteLine("Insert Dash? (y/n):");
            var dashResponse = Console.ReadLine();

            if (dashResponse == "y")
            {
                writer = new DashWriter(writer);
            }

            Console.WriteLine("Insert Star? (y/n):");
            var starResponse = Console.ReadLine();
            if (starResponse == "y")
            {
                writer = new StarWriter(writer);
            }
            
            writer.Write();

            #endregion
        }
    }
}
