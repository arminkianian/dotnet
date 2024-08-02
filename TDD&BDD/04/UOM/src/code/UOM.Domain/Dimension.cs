
namespace UOM.Domain
{
    public class Dimension
    {

        public long Id { get; internal set; }
        public string Name { get; private set; }
        public string Symbol { get; private set; }

        public Dimension(int id, string name, string symbol)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
        }
    }

}