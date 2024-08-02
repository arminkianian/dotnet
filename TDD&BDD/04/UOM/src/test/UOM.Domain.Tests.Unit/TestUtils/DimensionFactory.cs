using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UOM.Domain.Tests.Unit.TestUtils
{
    internal static class DimensionFactory
    {
        public static Dimension CreateMassDimension()
        {
            return new Dimension(1,"Mass", "m");
        }
    }
}
