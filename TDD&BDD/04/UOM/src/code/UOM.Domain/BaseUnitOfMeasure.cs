
namespace UOM.Domain
{
    public class BaseUnitOfMeasure
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public long DimensionId { get; private set; }

        public BaseUnitOfMeasure(long id, string name, string symbol, Dimension dimension)
        {
            Id = id;
            this.Name = name;
            this.Symbol = symbol;
            this.DimensionId = dimension.Id;
        }
    }
}