namespace ConsoleApp.Writer
{
    internal class StarWriter: IWriter
    {
        private readonly IWriter writer;

        public StarWriter(IWriter writer)
        {
            this.writer = writer;
        }

        public void Write()
        {
            Console.WriteLine($"******");
            writer.Write();
            Console.WriteLine($"******");
        }
    }
}
