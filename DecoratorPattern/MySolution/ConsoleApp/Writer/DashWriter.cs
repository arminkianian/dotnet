namespace ConsoleApp.Writer
{
    internal class DashWriter:  IWriter
    {
        private readonly IWriter writer;

        public DashWriter(IWriter writer)
        {
            this.writer = writer;
        }

        public void Write()
        {
            Console.WriteLine($"------");
            writer.Write();
            Console.WriteLine($"------");
        }
    }
}
