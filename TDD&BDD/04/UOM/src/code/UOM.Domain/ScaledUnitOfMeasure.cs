using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOM.Domain
{
    public class ScaledUnitOfMeasure
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public decimal ConversionRate { get; private set; }
        public long BaseUnitOfMeasureId { get; private set; }

        public ScaledUnitOfMeasure(int id, string name, string symbol, decimal conversionRate, BaseUnitOfMeasure @base)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
            ConversionRate = conversionRate;
            BaseUnitOfMeasureId = @base.Id;
        }

        public decimal ConvertToBase(decimal amount)
        {
            return amount * ConversionRate;
        }

        public decimal ConvertTo(ScaledUnitOfMeasure targetUom, decimal amount)
        {
            var valueInBase = this.ConvertToBase(amount);
            return valueInBase / targetUom.ConversionRate;
        }
    }
}
