using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOM.Domain.Tests.Unit.TestUtils
{
    internal static class BaseUnitOfMeasureFactory
    {
        public static BaseUnitOfMeasure CreateGram()
        {
            var mass = DimensionFactory.CreateMassDimension();
            return new BaseUnitOfMeasure(1, "Gram", "gr", mass);
        }
    }
}
